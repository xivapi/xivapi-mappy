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
            output.Text = String.Format("Found: {0}", entities.Count) + Environment.NewLine + Environment.NewLine;

            // spit out all entities
            foreach(ActorItem entity in entities)
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
            output.Text = String.Format("Found: {0}", entities.Count) + Environment.NewLine + Environment.NewLine;

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
            ActorItem entity = GameMemory.GetCurrentTarget();

            try
            {
                output.Text = String.Format("Outputting Target:") + Environment.NewLine + Environment.NewLine;
                PrintEntity(entity);
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
        private void Readplayer_Click(object sender, EventArgs e)
        {
            player = GameMemory.GetPlayer();

            try
            {
                output.Text = String.Format("Outputting Player:") + Environment.NewLine + Environment.NewLine;
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
            output.AppendText(String.Format("Name: {0}", entity.Name) + Environment.NewLine);
            output.AppendText(String.Format("Level: {0}", entity.Level) + Environment.NewLine);
            output.AppendText(String.Format("HP: {0}/{1}", entity.HPCurrent, entity.HPMax) + Environment.NewLine);
            output.AppendText(String.Format("MP: {0}/{1}", entity.MPCurrent, entity.MPMax) + Environment.NewLine);

            output.AppendText(String.Format("Model ID: {0}", entity.ModelID) + Environment.NewLine);
            output.AppendText(String.Format("NPCID 1: {0}", entity.NPCID1) + Environment.NewLine);
            output.AppendText(String.Format("NPCID 2: {0}", entity.NPCID2) + Environment.NewLine);
            output.AppendText(String.Format("Owner ID: {0}", entity.OwnerID) + Environment.NewLine);
            output.AppendText(String.Format("Memory ID: {0}", entity.ID) + Environment.NewLine);
            output.AppendText(String.Format("Map ID: {0}", entity.MapID) + Environment.NewLine);
            output.AppendText(String.Format("Map Index: {0}", entity.MapIndex) + Environment.NewLine);
            output.AppendText(String.Format("Map Territory: {0}", entity.MapTerritory) + Environment.NewLine);
            
            output.AppendText(String.Format("Is Casting: {0}", entity.IsCasting ? "Yes" : "No") + Environment.NewLine);
            output.AppendText(String.Format("Is Claimed: {0}", entity.IsClaimed ? "Yes" : "No") + Environment.NewLine);
            output.AppendText(String.Format("Is Fate: {0}", entity.IsFate ? "Yes" : "No") + Environment.NewLine);
            output.AppendText(String.Format("Status: {0}", entity.Status) + Environment.NewLine);
            output.AppendText(String.Format("Type: {0}", entity.Type) + Environment.NewLine);
            output.AppendText(String.Format("Target Type: {0}", entity.TargetType) + Environment.NewLine);

            output.AppendText(String.Format("Position: X {0} / Y {1} / Z {2}", entity.X, entity.Y, entity.Z) + Environment.NewLine);
            output.AppendText(String.Format("Distance from player: {0}", entity.GetDistanceTo(player)) + Environment.NewLine);
            output.AppendText("---------------------------------------------------------" + Environment.NewLine);
        }
    }
}
