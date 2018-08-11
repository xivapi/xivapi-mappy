namespace Mappy
{
    partial class MapViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapViewer));
            this.mapvisual = new System.Windows.Forms.PictureBox();
            this.UpdateTicker = new System.Windows.Forms.Timer(this.components);
            this.mapstatus = new System.Windows.Forms.Label();
            this.mapinfo = new System.Windows.Forms.Label();
            this.mappos = new System.Windows.Forms.Label();
            this.mapCountdown = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mapvisual)).BeginInit();
            this.SuspendLayout();
            // 
            // mapvisual
            // 
            this.mapvisual.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapvisual.BackColor = System.Drawing.Color.Transparent;
            this.mapvisual.InitialImage = null;
            this.mapvisual.Location = new System.Drawing.Point(0, 0);
            this.mapvisual.Name = "mapvisual";
            this.mapvisual.Size = new System.Drawing.Size(752, 567);
            this.mapvisual.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.mapvisual.TabIndex = 0;
            this.mapvisual.TabStop = false;
            this.mapvisual.Paint += new System.Windows.Forms.PaintEventHandler(this.VisualPaint);
            this.mapvisual.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VisualMouseDown);
            this.mapvisual.MouseMove += new System.Windows.Forms.MouseEventHandler(this.VisualMouseMove);
            // 
            // UpdateTicker
            // 
            this.UpdateTicker.Enabled = true;
            this.UpdateTicker.Interval = 1000;
            this.UpdateTicker.Tick += new System.EventHandler(this.UpdateTicker_Tick);
            // 
            // mapstatus
            // 
            this.mapstatus.AutoSize = true;
            this.mapstatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.mapstatus.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.mapstatus.ForeColor = System.Drawing.Color.White;
            this.mapstatus.Location = new System.Drawing.Point(0, 0);
            this.mapstatus.Name = "mapstatus";
            this.mapstatus.Padding = new System.Windows.Forms.Padding(5, 3, 5, 5);
            this.mapstatus.Size = new System.Drawing.Size(107, 31);
            this.mapstatus.TabIndex = 0;
            this.mapstatus.Text = "Map Status";
            this.mapstatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mapinfo
            // 
            this.mapinfo.AutoSize = true;
            this.mapinfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.mapinfo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.mapinfo.ForeColor = System.Drawing.Color.White;
            this.mapinfo.Location = new System.Drawing.Point(0, 27);
            this.mapinfo.Name = "mapinfo";
            this.mapinfo.Padding = new System.Windows.Forms.Padding(5, 3, 5, 5);
            this.mapinfo.Size = new System.Drawing.Size(91, 31);
            this.mapinfo.TabIndex = 2;
            this.mapinfo.Text = "Map Info";
            this.mapinfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mappos
            // 
            this.mappos.AutoSize = true;
            this.mappos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.mappos.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.mappos.ForeColor = System.Drawing.Color.White;
            this.mappos.Location = new System.Drawing.Point(0, 54);
            this.mappos.Name = "mappos";
            this.mappos.Padding = new System.Windows.Forms.Padding(5, 3, 5, 5);
            this.mappos.Size = new System.Drawing.Size(120, 31);
            this.mappos.TabIndex = 4;
            this.mappos.Text = "Map Position";
            this.mappos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mapCountdown
            // 
            this.mapCountdown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mapCountdown.AutoSize = true;
            this.mapCountdown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.mapCountdown.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.mapCountdown.ForeColor = System.Drawing.Color.White;
            this.mapCountdown.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mapCountdown.Location = new System.Drawing.Point(0, 540);
            this.mapCountdown.Name = "mapCountdown";
            this.mapCountdown.Padding = new System.Windows.Forms.Padding(5, 3, 5, 5);
            this.mapCountdown.Size = new System.Drawing.Size(27, 31);
            this.mapCountdown.TabIndex = 5;
            this.mapCountdown.Text = "-";
            this.mapCountdown.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MapViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.ClientSize = new System.Drawing.Size(752, 567);
            this.Controls.Add(this.mapCountdown);
            this.Controls.Add(this.mappos);
            this.Controls.Add(this.mapinfo);
            this.Controls.Add(this.mapstatus);
            this.Controls.Add(this.mapvisual);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MapViewer";
            this.Text = "MAP - FINAL FANTASY XIV MAPPY";
            this.Activated += new System.EventHandler(this.MapViewer_Focused);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MapViewer_Closing);
            this.Load += new System.EventHandler(this.MapViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mapvisual)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox mapvisual;
        private System.Windows.Forms.Timer UpdateTicker;
        private System.Windows.Forms.Label mapstatus;
        private System.Windows.Forms.Label mapinfo;
        private System.Windows.Forms.Label mappos;
        private System.Windows.Forms.Label mapCountdown;
    }
}