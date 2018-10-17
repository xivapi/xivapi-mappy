namespace Mappy
{
    partial class Viewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Viewer));
            this.scannpcs = new System.Windows.Forms.Button();
            this.output = new System.Windows.Forms.RichTextBox();
            this.readtarget = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.readplayer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // scannpcs
            // 
            this.scannpcs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.scannpcs.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.scannpcs.Location = new System.Drawing.Point(16, 15);
            this.scannpcs.Margin = new System.Windows.Forms.Padding(4);
            this.scannpcs.Name = "scannpcs";
            this.scannpcs.Size = new System.Drawing.Size(109, 36);
            this.scannpcs.TabIndex = 0;
            this.scannpcs.Text = "Scan NPCs";
            this.scannpcs.UseVisualStyleBackColor = false;
            this.scannpcs.Click += new System.EventHandler(this.Scannpcs_Click);
            // 
            // output
            // 
            this.output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.output.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.output.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.output.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.output.ForeColor = System.Drawing.Color.Gainsboro;
            this.output.Location = new System.Drawing.Point(16, 58);
            this.output.Margin = new System.Windows.Forms.Padding(4);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(687, 382);
            this.output.TabIndex = 1;
            this.output.Text = "";
            // 
            // readtarget
            // 
            this.readtarget.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.readtarget.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.readtarget.Location = new System.Drawing.Point(261, 15);
            this.readtarget.Margin = new System.Windows.Forms.Padding(4);
            this.readtarget.Name = "readtarget";
            this.readtarget.Size = new System.Drawing.Size(109, 36);
            this.readtarget.TabIndex = 2;
            this.readtarget.Text = "Read Target";
            this.readtarget.UseVisualStyleBackColor = false;
            this.readtarget.Click += new System.EventHandler(this.Readtarget_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(133, 15);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 36);
            this.button1.TabIndex = 3;
            this.button1.Text = "Scan Enemies";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // readplayer
            // 
            this.readplayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.readplayer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.readplayer.Location = new System.Drawing.Point(379, 15);
            this.readplayer.Margin = new System.Windows.Forms.Padding(4);
            this.readplayer.Name = "readplayer";
            this.readplayer.Size = new System.Drawing.Size(109, 36);
            this.readplayer.TabIndex = 4;
            this.readplayer.Text = "Read Player";
            this.readplayer.UseVisualStyleBackColor = false;
            this.readplayer.Click += new System.EventHandler(this.Readplayer_Click);
            // 
            // Viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(719, 455);
            this.Controls.Add(this.readplayer);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.readtarget);
            this.Controls.Add(this.output);
            this.Controls.Add(this.scannpcs);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Viewer";
            this.Text = "DEBUG VIEWER - FINAL FANTASY XIV MAPPY";
            this.Activated += new System.EventHandler(this.Viewer_Focus);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Viewer_Closing);
            this.Load += new System.EventHandler(this.Viewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button scannpcs;
        private System.Windows.Forms.RichTextBox output;
        private System.Windows.Forms.Button readtarget;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button readplayer;
    }
}