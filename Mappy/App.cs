using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Timers;
using Mappy.Tracking;
using Mappy.Helpers;
using Sharlayan.Core;
using System.Drawing;

namespace Mappy
{
    public partial class App : Form
    {
        public static App Instance;
        public MapViewer MapViewer = new MapViewer();
        public Viewer DebugViewer = new Viewer();

        private bool Scanning = true;
        public TrackingEnemies TrackingEnemies = new TrackingEnemies();
        public TrackingNpcs TrackingNpcs = new TrackingNpcs();
        public TrackingPlayer TrackingPlayer = new TrackingPlayer();

        /// <summary>
        /// app
        /// </summary>
        public App()
        {
            InitializeComponent();
            Instance = this;
        }

        /// <summary>
        /// when my app loads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppLoaded(object sender, EventArgs e)
        {
            LoadSettings();
            SetupApplication();
        }

        /// <summary>
        /// setup the application    
        /// </summary>
        private void SetupApplication()
        {
            Logger.Geset();

            Logger.Add("================================================");
            Logger.Add("FINAL FANTASY XIV MAPPY");
            Logger.Add("Built by: Vekien");
            Logger.Add("Discord: https://discord.gg/MFFVHWC");
            Logger.Add("Source: https://github.com/xivapi/xivapi-mappy");
            Logger.Add("");
            Logger.Add("This app reads the FFXIV Memory to look for ");
            Logger.Add("enemies and NPCs. Data of these findings are");
            Logger.Add("stored in the /logs/ folder, you can use this");
            Logger.Add("data in your own applications! You do not need a");
            Logger.Add("XIVAPI Key for personal usage.");
            Logger.Add("If you have any problems, please ask on Discord!");
            Logger.Add("================================================");
            Logger.Add("Connecting to the FFXIV Game Memory ...");
            SetStatus("Connecting ...");

            if (GameMemory.setGameProcess()) {
                InitializeTimer.Enabled = true;
            } else {
                Logger.Add("Could not connect to the games memory, stupid question... Have you started FFXIV and logged in?");
                SetStatus("Could not connect to FFXIV Game Memory!");
            }
        }

        /// <summary>
        /// called when app initialized, this is delayed
        /// </summary>
        private void Initialized()
        {
            // set player name
            ActorItem player = GameMemory.getPlayer();
            labelPlayerName.Text = player.Name;

            // create timer
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += (sender, e) => {
                ScanIntervalAction();
            };
            aTimer.Interval = Properties.Settings.Default.ScanTimerSpeed;
            aTimer.Enabled = true;

            // check key
            API.CheckApiKey(Properties.Settings.Default.ApiKey);
        }

        #region Log View Window

        private List<string> logs = new List<string>();

        /// <summary>
        /// Tick timer for log view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogViewTickTimer_Tick(object sender, EventArgs e)
        {
            UpdateLogView();
        }

        /// <summary>
        /// Update the visuals of the map
        /// </summary>
        public void UpdateLogView()
        {
            // if we're selecting something, don't update
            if (!logview.SelectedText.Equals(String.Empty))
            {
                return;
            }

            try
            {
                List<string> newentries = Logger.Get(logs.Count);
                if (newentries.Count == 0)
                {
                    return;
                }

                // get log entries
                foreach (string entry in newentries)
                {
                    logview.AppendText(entry + Environment.NewLine);
                    logs.Add(entry);
                }

                logview.SelectionStart = logview.Text.Length;
            }
            catch { }
        }

        #endregion

        #region Scanning Timers

        /// <summary>
        /// Memory scan timer
        /// </summary>
        private void ScanIntervalAction()
        {
            // if scanning disabled, do nothing
            if (Scanning)
            {
                ActorItem player = GameMemory.getPlayer();

                // if player has moved map, disable memory timer
                if (TrackingPlayer.hasMovedMap())
                {
                    // clear markers
                    TrackingEnemies.Clear();
                    TrackingNpcs.Clear();

                    // disable tickers
                    SetScanningState(false);
                    MapViewer.SetMapCountdown("Zoning ...");

                    // get the map viewer to request latest map,
                    // once it has done it, it will renable memory timer
                    MapViewer.RequestLatestMap();                    
                }
                else
                {
                    // scan for enemies
                    TrackingEnemies.Scan();
                    TrackingNpcs.Scan();
                }
            }
        }

        /// <summary>
        /// Set scanning state
        /// </summary>
        /// <param name="state"></param>
        public void SetScanningState(bool state)
        {
            Logger.Add("> MEMORY SCANNING: " + (state ? "ON" : "OFF"));
            Scanning = state;

            // set the same state on the map view
            MapViewer.SetScanningState(state);
        }


        /// <summary>
        /// Init timer, basically a "delay"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitializeTimer_Tick(object sender, EventArgs e)
        {
            ActorItem player = GameMemory.getPlayer();

            Logger.Add(" ");
            Logger.Add($"~ Hello {player.Name}!");
            Logger.Add(" ");

            if (player.MapID == 0)
            {
                Logger.Add("Oh no, the MapID is 0, either the offsets are broke, you're not logged in, or idk... Ask Vekien.");
                Logger.Add("No mapping today");
                SetStatus("/sadface");
            }

            // disable initialize timer, and add memory timer
            InitializeTimer.Enabled = false;
            Initialized();
        }

        /// <summary>
        /// Start countdown when zoning, give memory time to init
        /// </summary>
        int zonedTimerCountdownValue = 3;
        System.Timers.Timer StartZonedTimer;
        public void StartZonedTimerCountdown()
        {
            Logger.Add("Starting map recording countdown");

            StartZonedTimer = new System.Timers.Timer(1000)
            {
                Enabled = true
            };
            StartZonedTimer.Elapsed += new ElapsedEventHandler(StartZonedTimerCountdownTick);
            StartZonedTimer.Start();
        }

        public void StartZonedTimerCountdownTick(object sender, ElapsedEventArgs e)
        {
            if (zonedTimerCountdownValue == 0)
            {
                Logger.Add("Ready to record");
                Logger.Add("================================================");
                MapViewer.SetMapCountdown("Recording");

                // reset count
                zonedTimerCountdownValue = 3;

                // stop timer
                StartZonedTimer.Stop();

                // set scanning state
                SetScanningState(true);
            }
            else
            {
                string message = $"Starting in: {zonedTimerCountdownValue} ...";
                Logger.Add(message);
                MapViewer.SetMapCountdown(message);
                zonedTimerCountdownValue--;
            }
        }

        #endregion

        #region Application Move/Close

        /// <summary>
        /// Closing the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppClose(object sender, EventArgs e)
        {
            MapViewer.Dispose();
            DebugViewer.Dispose();
            Application.Exit();
        }

        /// <summary>
        /// Setting application focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void App_Focused(object sender, EventArgs e)
        {
            TopMost = Properties.Settings.Default.AlwaysOnTop;
        }

        #endregion

        #region Application Status

        /// <summary>
        /// Set window status
        /// </summary>
        /// <param name="text"></param>
        public void SetStatus(string text)
        {
            labelStatus.Text = text;
        }

        #endregion

        #region Application Buttons

        /// <summary>
        /// Open map
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOpenMap_Click(object sender, EventArgs e)
        {
            MapViewer.Show();
        }

        /// <summary>
        /// Open debug viewer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOpenDebug_Click(object sender, EventArgs e)
        {
            DebugViewer.Show();
        }

        #endregion

        #region Settings

        public void ToggleSubmitting(bool enable)
        {
            Settings_Submit.Checked = enable;
            Properties.Settings.Default.Submit = Settings_Submit.Checked;
            Properties.Settings.Default.Save();

            Logger.Add(enable 
                ? "XIVAPI key enabled! Data will submit. If you have enabled the API key after memory scan, you will need to restart the app to pickup the existing data." 
                : "XIVAPI key does not have permission to submit data. Ask @Vekien for permission!"
            );
        }

        private void LoadSettings()
        {
            TopMost = Properties.Settings.Default.AlwaysOnTop;
            Settings_Submit.Checked = Properties.Settings.Default.Submit;
            Settings_AlwaysOnTop.Checked = Properties.Settings.Default.AlwaysOnTop;
            Settings_MapBoundaries.Checked = Properties.Settings.Default.MapBounds;
            Settings_IgnoreNoneEnglish.Checked = Properties.Settings.Default.IgnoreNoneEnglish;
            Settings_ExtendLogMessages.Checked = Properties.Settings.Default.ExtendLogMessages;
            Settings_ScanTimerSpeed.Text = Properties.Settings.Default.ScanTimerSpeed.ToString();
            Settings_MapPlayerTimerSpeed.Text = Properties.Settings.Default.MapPlayerTimerSpeed.ToString();
            Settings_ApiKey.Text = Properties.Settings.Default.ApiKey.ToString();
        }

        private void Settings_Submit_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Submit = Settings_Submit.Checked;
            Properties.Settings.Default.Save();

            if (Settings_Submit.Checked) {
                API.CheckApiKey(Properties.Settings.Default.ApiKey);
            }
        }

        private void Settings_AlwaysOnTop_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AlwaysOnTop = Settings_AlwaysOnTop.Checked;
            Properties.Settings.Default.Save();

        }

        private void Settings_MapBoundaries_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.MapBounds = Settings_MapBoundaries.Checked;
            Properties.Settings.Default.Save();
        }

        private void Settings_IgnoreNoneEnglish_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.IgnoreNoneEnglish = Settings_IgnoreNoneEnglish.Checked;
            Properties.Settings.Default.Save();
        }

        private void Settings_ExtendLogMessages_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ExtendLogMessages = Settings_ExtendLogMessages.Checked;
            Properties.Settings.Default.Save();
        }

        private void Settings_ScanTimerSpeed_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ScanTimerSpeed = Int32.Parse(Settings_ScanTimerSpeed.Text);
            Properties.Settings.Default.Save();
        }

        private void Settings_MapPlayerTimerSpeed_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.MapPlayerTimerSpeed = Int32.Parse(Settings_MapPlayerTimerSpeed.Text);
            Properties.Settings.Default.Save();
        }

        private void Settings_ApiKey_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ApiKey = Settings_ApiKey.Text.Trim();
            Properties.Settings.Default.Save();
        }
    }

    #endregion


}
