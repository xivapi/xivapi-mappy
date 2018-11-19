using Sharlayan.Core;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Mappy.Helpers;

namespace Mappy
{
    public partial class Viewer : Form
    {
        public Viewer()
        {
            InitializeComponent();
        }

        private void Viewer_Load(object sender, EventArgs e)
        {
            TopMost = Properties.Settings.Default.AlwaysOnTop;
        }

        private void Viewer_Focus(object sender, EventArgs e)
        {
            TopMost = Properties.Settings.Default.AlwaysOnTop;
        }

        private void Viewer_Closing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        ActorItem player;

        /// <summary>
        /// Scan for npcs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Scannpcs_Click(object sender, EventArgs e)
        {
            player = GameMemory.GetPlayer();

            // GameMemory.getNpcsAroundPlayer();
            List<ActorItem> entities = App.Instance.TrackingNpcs.GetEntities();

            // reset output
            output.Text = $@"Found: {entities.Count}{Environment.NewLine}{Environment.NewLine}";

            // spit out all entities
            foreach (ActorItem entity in entities)
            {
                PrintEntity(entity);
            }
        }

        /// <summary>
        /// Scan for enemies
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            player = GameMemory.GetPlayer();

            // GameMemory.getNpcsAroundPlayer();
            List<ActorItem> entities = App.Instance.TrackingEnemies.GetEntities();

            // reset output
            output.Text = $@"Found: {entities.Count}{Environment.NewLine}{Environment.NewLine}";

            // spit out all entities
            foreach (ActorItem entity in entities)
            {
                PrintEntity(entity);
            }
        }

        /// <summary>
        /// Scan current target
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Readtarget_Click(object sender, EventArgs e)
        {
            player = GameMemory.GetPlayer();
            var entity = GameMemory.GetCurrentTarget();

            try
            {
                if (entity == null)
                {
                    output.Text = "No Target selected.";
                }
                else
                {
                    output.Text = $@"Outputting Target:{Environment.NewLine}{Environment.NewLine}";
                    PrintEntity(entity);
                }
            }
            catch (Exception ex)
            {
                Logger.Exception(ex, "Viewer -> readtarget_Click");
            }
        }

        /// <summary>
        /// Read Player
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReadPlayer_Click(object sender, EventArgs e)
        {
            player = GameMemory.GetPlayer();

            try
            {
                output.Text = $@"Outputting Player:{Environment.NewLine}{Environment.NewLine}";
                PrintEntity(player);
            }
            catch (Exception ex)
            {
                Logger.Exception(ex, "Viewer -> readplayer_Click");
            }
        }

        /// <summary>
        /// Print an Actor Entity to the output window
        /// </summary>
        /// <param name="entity"></param>
        private void PrintEntity(ActorItem entity)
        {
            output.AppendText($"Name: {entity.Name}{Environment.NewLine}");
            output.AppendText($"Level: {entity.Level}{Environment.NewLine}");
            output.AppendText($"HP: {entity.HPCurrent}/{entity.HPMax}{Environment.NewLine}");
            output.AppendText($"MP: {entity.MPCurrent}/{entity.MPMax}{Environment.NewLine}");

            output.AppendText($"Model ID: {entity.ModelID}" + Environment.NewLine);
            output.AppendText($"NPCID 1: {entity.NPCID1}" + Environment.NewLine);
            output.AppendText($"NPCID 2: {entity.NPCID2}" + Environment.NewLine);
            output.AppendText($"Owner ID: {entity.OwnerID}" + Environment.NewLine);
            output.AppendText($"Memory ID: {entity.ID}" + Environment.NewLine);
            output.AppendText($"Map ID: {entity.MapID}" + Environment.NewLine);
            output.AppendText($"Map Index: {entity.MapIndex}" + Environment.NewLine);
            output.AppendText($"Map Territory: {entity.MapTerritory}" + Environment.NewLine);

            output.AppendText($"Is Casting: {(entity.IsCasting ? "Yes" : "No")}" + Environment.NewLine);
            output.AppendText($"Is Claimed: {(entity.IsClaimed ? "Yes" : "No")}" + Environment.NewLine);
            output.AppendText($"Is Fate: {(entity.IsFate ? "Yes" : "No")}" + Environment.NewLine);
            output.AppendText($"Status: {entity.Status}" + Environment.NewLine);
            output.AppendText($"Type: {entity.Type}" + Environment.NewLine);
            output.AppendText($"Target Type: {entity.TargetType}" + Environment.NewLine);

            output.AppendText($"Position: X {entity.X} / Y {entity.Y} / Z {entity.Z}" + Environment.NewLine);
            output.AppendText($"Distance from player: {entity.GetDistanceTo(player)}" + Environment.NewLine);
            output.AppendText("---------------------------------------------------------" + Environment.NewLine);
        }
    }
}
