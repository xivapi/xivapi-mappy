namespace Mappy
{
    partial class App
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(App));
            this.labelStatus = new System.Windows.Forms.Label();
            this.InitializeTimer = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelPlayerName = new System.Windows.Forms.Label();
            this.btnOpenMap = new System.Windows.Forms.Button();
            this.logview = new System.Windows.Forms.RichTextBox();
            this.LogViewTickTimer = new System.Windows.Forms.Timer(this.components);
            this.Settings_Submit = new System.Windows.Forms.CheckBox();
            this.Settings_AlwaysOnTop = new System.Windows.Forms.CheckBox();
            this.Settings_MapBoundaries = new System.Windows.Forms.CheckBox();
            this.Settings_IgnoreNoneEnglish = new System.Windows.Forms.CheckBox();
            this.btnOpenDebug = new System.Windows.Forms.Button();
            this.Settings_ExtendLogMessages = new System.Windows.Forms.CheckBox();
            this.Settings_ScanTimerSpeed = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Settings_MapPlayerTimerSpeed = new System.Windows.Forms.TextBox();
            this.labelTotalNpcs = new System.Windows.Forms.Label();
            this.labelTotalEnemies = new System.Windows.Forms.Label();
            this.labelTotalSubmits = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelSubmitStatus = new System.Windows.Forms.Label();
            this.Settings_ApiKey = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnSubmitToApi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStatus.BackColor = System.Drawing.Color.Black;
            this.labelStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelStatus.Location = new System.Drawing.Point(-3, 59);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.labelStatus.Size = new System.Drawing.Size(1322, 42);
            this.labelStatus.TabIndex = 24;
            this.labelStatus.Text = "APP STATUS";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InitializeTimer
            // 
            this.InitializeTimer.Interval = 1000;
            this.InitializeTimer.Tick += new System.EventHandler(this.InitializeTimer_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(59)))), ((int)(((byte)(192)))));
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(11, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(232, 23);
            this.label4.TabIndex = 32;
            this.label4.Text = "FINAL FANTASY XIV MAPPY";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(59)))), ((int)(((byte)(192)))));
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1322, 60);
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            // 
            // labelPlayerName
            // 
            this.labelPlayerName.AutoSize = true;
            this.labelPlayerName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(59)))), ((int)(((byte)(192)))));
            this.labelPlayerName.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayerName.ForeColor = System.Drawing.Color.Yellow;
            this.labelPlayerName.Location = new System.Drawing.Point(10, 6);
            this.labelPlayerName.Name = "labelPlayerName";
            this.labelPlayerName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelPlayerName.Size = new System.Drawing.Size(129, 32);
            this.labelPlayerName.TabIndex = 34;
            this.labelPlayerName.Text = "YourName";
            this.labelPlayerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnOpenMap
            // 
            this.btnOpenMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(22)))), ((int)(((byte)(165)))));
            this.btnOpenMap.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOpenMap.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(11)))), ((int)(((byte)(111)))));
            this.btnOpenMap.FlatAppearance.BorderSize = 0;
            this.btnOpenMap.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(11)))), ((int)(((byte)(111)))));
            this.btnOpenMap.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(11)))), ((int)(((byte)(111)))));
            this.btnOpenMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenMap.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnOpenMap.Location = new System.Drawing.Point(1205, 12);
            this.btnOpenMap.Name = "btnOpenMap";
            this.btnOpenMap.Size = new System.Drawing.Size(100, 36);
            this.btnOpenMap.TabIndex = 35;
            this.btnOpenMap.Text = "MAP";
            this.btnOpenMap.UseVisualStyleBackColor = false;
            this.btnOpenMap.Click += new System.EventHandler(this.BtnOpenMap_Click);
            // 
            // logview
            // 
            this.logview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.logview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logview.DetectUrls = false;
            this.logview.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logview.ForeColor = System.Drawing.Color.LightGray;
            this.logview.Location = new System.Drawing.Point(381, 101);
            this.logview.Margin = new System.Windows.Forms.Padding(0);
            this.logview.Name = "logview";
            this.logview.ReadOnly = true;
            this.logview.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.logview.Size = new System.Drawing.Size(935, 741);
            this.logview.TabIndex = 36;
            this.logview.Text = "";
            // 
            // LogViewTickTimer
            // 
            this.LogViewTickTimer.Enabled = true;
            this.LogViewTickTimer.Tick += new System.EventHandler(this.LogViewTickTimer_Tick);
            // 
            // Settings_Submit
            // 
            this.Settings_Submit.AutoSize = true;
            this.Settings_Submit.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.Settings_Submit.Location = new System.Drawing.Point(19, 325);
            this.Settings_Submit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Settings_Submit.Name = "Settings_Submit";
            this.Settings_Submit.Size = new System.Drawing.Size(148, 29);
            this.Settings_Submit.TabIndex = 37;
            this.Settings_Submit.Text = "Submit to API";
            this.Settings_Submit.UseVisualStyleBackColor = true;
            this.Settings_Submit.CheckedChanged += new System.EventHandler(this.Settings_Submit_CheckedChanged);
            // 
            // Settings_AlwaysOnTop
            // 
            this.Settings_AlwaysOnTop.AutoSize = true;
            this.Settings_AlwaysOnTop.Checked = true;
            this.Settings_AlwaysOnTop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Settings_AlwaysOnTop.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.Settings_AlwaysOnTop.Location = new System.Drawing.Point(20, 467);
            this.Settings_AlwaysOnTop.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Settings_AlwaysOnTop.Name = "Settings_AlwaysOnTop";
            this.Settings_AlwaysOnTop.Size = new System.Drawing.Size(276, 29);
            this.Settings_AlwaysOnTop.TabIndex = 38;
            this.Settings_AlwaysOnTop.Text = "Keep windows always on top";
            this.Settings_AlwaysOnTop.UseVisualStyleBackColor = true;
            this.Settings_AlwaysOnTop.CheckedChanged += new System.EventHandler(this.Settings_AlwaysOnTop_CheckedChanged);
            // 
            // Settings_MapBoundaries
            // 
            this.Settings_MapBoundaries.AutoSize = true;
            this.Settings_MapBoundaries.Checked = true;
            this.Settings_MapBoundaries.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Settings_MapBoundaries.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.Settings_MapBoundaries.Location = new System.Drawing.Point(20, 494);
            this.Settings_MapBoundaries.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Settings_MapBoundaries.Name = "Settings_MapBoundaries";
            this.Settings_MapBoundaries.Size = new System.Drawing.Size(346, 29);
            this.Settings_MapBoundaries.TabIndex = 39;
            this.Settings_MapBoundaries.Text = "Keep map boundaries within window";
            this.Settings_MapBoundaries.UseVisualStyleBackColor = true;
            this.Settings_MapBoundaries.CheckedChanged += new System.EventHandler(this.Settings_MapBoundaries_CheckedChanged);
            // 
            // Settings_IgnoreNoneEnglish
            // 
            this.Settings_IgnoreNoneEnglish.AutoSize = true;
            this.Settings_IgnoreNoneEnglish.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.Settings_IgnoreNoneEnglish.Location = new System.Drawing.Point(20, 521);
            this.Settings_IgnoreNoneEnglish.Name = "Settings_IgnoreNoneEnglish";
            this.Settings_IgnoreNoneEnglish.Size = new System.Drawing.Size(265, 29);
            this.Settings_IgnoreNoneEnglish.TabIndex = 40;
            this.Settings_IgnoreNoneEnglish.Text = "Ignore Non-English entities";
            this.Settings_IgnoreNoneEnglish.UseVisualStyleBackColor = true;
            this.Settings_IgnoreNoneEnglish.CheckedChanged += new System.EventHandler(this.Settings_IgnoreNoneEnglish_CheckedChanged);
            // 
            // btnOpenDebug
            // 
            this.btnOpenDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenDebug.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(22)))), ((int)(((byte)(165)))));
            this.btnOpenDebug.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOpenDebug.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(11)))), ((int)(((byte)(111)))));
            this.btnOpenDebug.FlatAppearance.BorderSize = 0;
            this.btnOpenDebug.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(11)))), ((int)(((byte)(111)))));
            this.btnOpenDebug.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(11)))), ((int)(((byte)(111)))));
            this.btnOpenDebug.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenDebug.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnOpenDebug.Location = new System.Drawing.Point(1096, 12);
            this.btnOpenDebug.Name = "btnOpenDebug";
            this.btnOpenDebug.Size = new System.Drawing.Size(100, 36);
            this.btnOpenDebug.TabIndex = 41;
            this.btnOpenDebug.Text = "DEBUG";
            this.btnOpenDebug.UseVisualStyleBackColor = false;
            this.btnOpenDebug.Click += new System.EventHandler(this.BtnOpenDebug_Click);
            // 
            // Settings_ExtendLogMessages
            // 
            this.Settings_ExtendLogMessages.AutoSize = true;
            this.Settings_ExtendLogMessages.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.Settings_ExtendLogMessages.Location = new System.Drawing.Point(20, 549);
            this.Settings_ExtendLogMessages.Name = "Settings_ExtendLogMessages";
            this.Settings_ExtendLogMessages.Size = new System.Drawing.Size(209, 29);
            this.Settings_ExtendLogMessages.TabIndex = 42;
            this.Settings_ExtendLogMessages.Text = "Extend log messages";
            this.Settings_ExtendLogMessages.UseVisualStyleBackColor = true;
            this.Settings_ExtendLogMessages.CheckedChanged += new System.EventHandler(this.Settings_ExtendLogMessages_CheckedChanged);
            // 
            // Settings_ScanTimerSpeed
            // 
            this.Settings_ScanTimerSpeed.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Settings_ScanTimerSpeed.Location = new System.Drawing.Point(20, 616);
            this.Settings_ScanTimerSpeed.Name = "Settings_ScanTimerSpeed";
            this.Settings_ScanTimerSpeed.Size = new System.Drawing.Size(346, 34);
            this.Settings_ScanTimerSpeed.TabIndex = 43;
            this.Settings_ScanTimerSpeed.Text = "1000";
            this.Settings_ScanTimerSpeed.TextChanged += new System.EventHandler(this.Settings_ScanTimerSpeed_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(16, 591);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 23);
            this.label1.TabIndex = 44;
            this.label1.Text = "Memory Parse Rate (ms)";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.ForeColor = System.Drawing.Color.DarkGray;
            this.label2.Location = new System.Drawing.Point(17, 652);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(335, 47);
            this.label2.TabIndex = 45;
            this.label2.Text = "If you lower this value, memory will be scanned more frequently. (Requires a rest" +
    "art)";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.ForeColor = System.Drawing.Color.DarkGray;
            this.label3.Location = new System.Drawing.Point(18, 775);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(335, 48);
            this.label3.TabIndex = 48;
            this.label3.Text = "If you lower this value, the map refresh rate will increase. (Requires a restart)" +
    "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Gold;
            this.label5.Location = new System.Drawing.Point(17, 714);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(192, 23);
            this.label5.TabIndex = 47;
            this.label5.Text = "Map Refresh Rate (ms)";
            // 
            // Settings_MapPlayerTimerSpeed
            // 
            this.Settings_MapPlayerTimerSpeed.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Settings_MapPlayerTimerSpeed.Location = new System.Drawing.Point(21, 739);
            this.Settings_MapPlayerTimerSpeed.Name = "Settings_MapPlayerTimerSpeed";
            this.Settings_MapPlayerTimerSpeed.Size = new System.Drawing.Size(346, 34);
            this.Settings_MapPlayerTimerSpeed.TabIndex = 46;
            this.Settings_MapPlayerTimerSpeed.Text = "200";
            this.Settings_MapPlayerTimerSpeed.TextChanged += new System.EventHandler(this.Settings_MapPlayerTimerSpeed_TextChanged);
            // 
            // labelTotalNpcs
            // 
            this.labelTotalNpcs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.labelTotalNpcs.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.labelTotalNpcs.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelTotalNpcs.Location = new System.Drawing.Point(0, 151);
            this.labelTotalNpcs.Name = "labelTotalNpcs";
            this.labelTotalNpcs.Size = new System.Drawing.Size(126, 50);
            this.labelTotalNpcs.TabIndex = 49;
            this.labelTotalNpcs.Text = "-";
            this.labelTotalNpcs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTotalEnemies
            // 
            this.labelTotalEnemies.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.labelTotalEnemies.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.labelTotalEnemies.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelTotalEnemies.Location = new System.Drawing.Point(127, 151);
            this.labelTotalEnemies.Name = "labelTotalEnemies";
            this.labelTotalEnemies.Size = new System.Drawing.Size(127, 50);
            this.labelTotalEnemies.TabIndex = 50;
            this.labelTotalEnemies.Text = "-";
            this.labelTotalEnemies.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTotalSubmits
            // 
            this.labelTotalSubmits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.labelTotalSubmits.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.labelTotalSubmits.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.labelTotalSubmits.Location = new System.Drawing.Point(255, 151);
            this.labelTotalSubmits.Name = "labelTotalSubmits";
            this.labelTotalSubmits.Size = new System.Drawing.Size(126, 50);
            this.labelTotalSubmits.TabIndex = 51;
            this.labelTotalSubmits.Text = "-";
            this.labelTotalSubmits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 50);
            this.label6.TabIndex = 53;
            this.label6.Text = "NPCs";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(127, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 50);
            this.label7.TabIndex = 54;
            this.label7.Text = "ENEMYs";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(255, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 50);
            this.label8.TabIndex = 55;
            this.label8.Text = "API";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSubmitStatus
            // 
            this.labelSubmitStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.labelSubmitStatus.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.labelSubmitStatus.ForeColor = System.Drawing.Color.Gray;
            this.labelSubmitStatus.Location = new System.Drawing.Point(0, 202);
            this.labelSubmitStatus.Name = "labelSubmitStatus";
            this.labelSubmitStatus.Size = new System.Drawing.Size(382, 50);
            this.labelSubmitStatus.TabIndex = 56;
            this.labelSubmitStatus.Text = "-";
            this.labelSubmitStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Settings_ApiKey
            // 
            this.Settings_ApiKey.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Settings_ApiKey.Location = new System.Drawing.Point(19, 289);
            this.Settings_ApiKey.Name = "Settings_ApiKey";
            this.Settings_ApiKey.Size = new System.Drawing.Size(346, 34);
            this.Settings_ApiKey.TabIndex = 58;
            this.Settings_ApiKey.TextChanged += new System.EventHandler(this.Settings_ApiKey_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.Gold;
            this.label10.Location = new System.Drawing.Point(15, 264);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 23);
            this.label10.TabIndex = 59;
            this.label10.Text = "XIVAPI Key";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label11.ForeColor = System.Drawing.Color.DarkGray;
            this.label11.Location = new System.Drawing.Point(15, 349);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(335, 51);
            this.label11.TabIndex = 60;
            this.label11.Text = "Enter your apps key, only valid keys can submit data to the API. Ask @Vekien for " +
    "approval.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semilight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Gray;
            this.label12.Location = new System.Drawing.Point(12, 423);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(141, 41);
            this.label12.TabIndex = 61;
            this.label12.Text = "OPTIONS";
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.label13.Location = new System.Drawing.Point(0, 403);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(385, 1);
            this.label13.TabIndex = 62;
            // 
            // btnSubmitToApi
            // 
            this.btnSubmitToApi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmitToApi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(22)))), ((int)(((byte)(165)))));
            this.btnSubmitToApi.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSubmitToApi.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(11)))), ((int)(((byte)(111)))));
            this.btnSubmitToApi.FlatAppearance.BorderSize = 0;
            this.btnSubmitToApi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(11)))), ((int)(((byte)(111)))));
            this.btnSubmitToApi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(11)))), ((int)(((byte)(111)))));
            this.btnSubmitToApi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmitToApi.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnSubmitToApi.Location = new System.Drawing.Point(912, 12);
            this.btnSubmitToApi.Name = "btnSubmitToApi";
            this.btnSubmitToApi.Size = new System.Drawing.Size(176, 36);
            this.btnSubmitToApi.TabIndex = 63;
            this.btnSubmitToApi.Text = "SUBMIT TO API";
            this.btnSubmitToApi.UseVisualStyleBackColor = false;
            this.btnSubmitToApi.Click += new System.EventHandler(this.BtnSubmitToApi_Click);
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1316, 841);
            this.Controls.Add(this.btnSubmitToApi);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.logview);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Settings_ApiKey);
            this.Controls.Add(this.labelSubmitStatus);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelTotalSubmits);
            this.Controls.Add(this.labelTotalEnemies);
            this.Controls.Add(this.labelTotalNpcs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Settings_MapPlayerTimerSpeed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Settings_ScanTimerSpeed);
            this.Controls.Add(this.Settings_ExtendLogMessages);
            this.Controls.Add(this.btnOpenDebug);
            this.Controls.Add(this.Settings_IgnoreNoneEnglish);
            this.Controls.Add(this.Settings_MapBoundaries);
            this.Controls.Add(this.Settings_AlwaysOnTop);
            this.Controls.Add(this.Settings_Submit);
            this.Controls.Add(this.btnOpenMap);
            this.Controls.Add(this.labelPlayerName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MinimumSize = new System.Drawing.Size(416, 295);
            this.Name = "App";
            this.Text = "FINAL FANTASY XIV MAPPY";
            this.Activated += new System.EventHandler(this.App_Focused);
            this.Load += new System.EventHandler(this.AppLoaded);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Timer InitializeTimer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelPlayerName;
        private System.Windows.Forms.Button btnOpenMap;
        private System.Windows.Forms.RichTextBox logview;
        private System.Windows.Forms.Timer LogViewTickTimer;
        private System.Windows.Forms.CheckBox Settings_Submit;
        private System.Windows.Forms.CheckBox Settings_AlwaysOnTop;
        private System.Windows.Forms.CheckBox Settings_MapBoundaries;
        private System.Windows.Forms.CheckBox Settings_IgnoreNoneEnglish;
        private System.Windows.Forms.Button btnOpenDebug;
        private System.Windows.Forms.CheckBox Settings_ExtendLogMessages;
        private System.Windows.Forms.TextBox Settings_ScanTimerSpeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Settings_MapPlayerTimerSpeed;
        public System.Windows.Forms.Label labelTotalNpcs;
        public System.Windows.Forms.Label labelTotalSubmits;
        public System.Windows.Forms.Label labelTotalEnemies;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label labelSubmitStatus;
        private System.Windows.Forms.TextBox Settings_ApiKey;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnSubmitToApi;
    }
}

