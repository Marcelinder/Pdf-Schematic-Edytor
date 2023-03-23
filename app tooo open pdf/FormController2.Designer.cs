namespace app_tooo_open_pdf
{
    partial class FormController2
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
            this.Nextbt = new System.Windows.Forms.Button();
            this.Previousbt = new System.Windows.Forms.Button();
            this.PanelMouseSupport = new System.Windows.Forms.Panel();
            this.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddThisPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConvertThisPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.A4x4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.A4x2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorDot = new System.Windows.Forms.Label();
            this.labelPageAndMaxPage = new System.Windows.Forms.Label();
            this.PictureOpen = new System.Windows.Forms.PictureBox();
            this.minimizeBt = new System.Windows.Forms.Button();
            this.maximizeBt = new System.Windows.Forms.Button();
            this.closeBt = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EnlargeMakeA2AndDivideIntoA4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EnlargeMakeA3AndDivideIntoA4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TexboxToolStripMenuItem = new System.Windows.Forms.ToolStripTextBox();
            this.SkirtsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureOpen)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // Nextbt
            // 
            this.Nextbt.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Nextbt.Location = new System.Drawing.Point(419, 538);
            this.Nextbt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Nextbt.Name = "Nextbt";
            this.Nextbt.Size = new System.Drawing.Size(91, 26);
            this.Nextbt.TabIndex = 1;
            this.Nextbt.Text = "Next >";
            this.Nextbt.UseVisualStyleBackColor = true;
            this.Nextbt.Click += new System.EventHandler(this.Nextbt_Click);
            // 
            // Previousbt
            // 
            this.Previousbt.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Previousbt.Location = new System.Drawing.Point(323, 538);
            this.Previousbt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Previousbt.Name = "Previousbt";
            this.Previousbt.Size = new System.Drawing.Size(91, 26);
            this.Previousbt.TabIndex = 2;
            this.Previousbt.Text = "< Previous";
            this.Previousbt.UseVisualStyleBackColor = true;
            this.Previousbt.Click += new System.EventHandler(this.Previousbt_Click);
            // 
            // PanelMouseSupport
            // 
            this.PanelMouseSupport.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PanelMouseSupport.ContextMenuStrip = this.ContextMenuStrip;
            this.PanelMouseSupport.Location = new System.Drawing.Point(177, 33);
            this.PanelMouseSupport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelMouseSupport.Name = "PanelMouseSupport";
            this.PanelMouseSupport.Size = new System.Drawing.Size(483, 479);
            this.PanelMouseSupport.TabIndex = 3;
            this.PanelMouseSupport.Visible = false;
            this.PanelMouseSupport.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelMouseSupport_MouseDown);
            // 
            // ContextMenuStrip
            // 
            this.ContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddThisPageToolStripMenuItem,
            this.ConvertThisPageToolStripMenuItem});
            this.ContextMenuStrip.Name = "ContextMenuStrip";
            this.ContextMenuStrip.Size = new System.Drawing.Size(193, 52);
            // 
            // AddThisPageToolStripMenuItem
            // 
            this.AddThisPageToolStripMenuItem.Name = "AddThisPageToolStripMenuItem";
            this.AddThisPageToolStripMenuItem.Size = new System.Drawing.Size(192, 24);
            this.AddThisPageToolStripMenuItem.Text = "Add this Page";
            this.AddThisPageToolStripMenuItem.Click += new System.EventHandler(this.AddPageFromLabelAndConttexAddPage_Click);
            // 
            // ConvertThisPageToolStripMenuItem
            // 
            this.ConvertThisPageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.A4x4ToolStripMenuItem,
            this.A4x2ToolStripMenuItem});
            this.ConvertThisPageToolStripMenuItem.Name = "ConvertThisPageToolStripMenuItem";
            this.ConvertThisPageToolStripMenuItem.Size = new System.Drawing.Size(192, 24);
            this.ConvertThisPageToolStripMenuItem.Text = "Convert this Page";
            // 
            // A4x4ToolStripMenuItem
            // 
            this.A4x4ToolStripMenuItem.Name = "A4x4ToolStripMenuItem";
            this.A4x4ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.A4x4ToolStripMenuItem.Text = "A4 x 4";
            this.A4x4ToolStripMenuItem.Click += new System.EventHandler(this.A4x4ToolStripMenuItem_Click);
            // 
            // A4x2ToolStripMenuItem
            // 
            this.A4x2ToolStripMenuItem.Name = "A4x2ToolStripMenuItem";
            this.A4x2ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.A4x2ToolStripMenuItem.Text = "A4 x 2";
            this.A4x2ToolStripMenuItem.Click += new System.EventHandler(this.A4x2ToolStripMenuItem_Click);
            // 
            // ColorDot
            // 
            this.ColorDot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ColorDot.AutoSize = true;
            this.ColorDot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ColorDot.Font = new System.Drawing.Font("Marlett", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.ColorDot.Location = new System.Drawing.Point(691, 4);
            this.ColorDot.Name = "ColorDot";
            this.ColorDot.Size = new System.Drawing.Size(34, 23);
            this.ColorDot.TabIndex = 1;
            this.ColorDot.Text = "h";
            // 
            // labelPageAndMaxPage
            // 
            this.labelPageAndMaxPage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelPageAndMaxPage.BackColor = System.Drawing.Color.IndianRed;
            this.labelPageAndMaxPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPageAndMaxPage.ForeColor = System.Drawing.Color.White;
            this.labelPageAndMaxPage.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.labelPageAndMaxPage.Location = new System.Drawing.Point(351, 7);
            this.labelPageAndMaxPage.Name = "labelPageAndMaxPage";
            this.labelPageAndMaxPage.Size = new System.Drawing.Size(141, 18);
            this.labelPageAndMaxPage.TabIndex = 0;
            this.labelPageAndMaxPage.Text = "Jebac pis";
            this.labelPageAndMaxPage.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.labelPageAndMaxPage.Click += new System.EventHandler(this.AddPageFromLabelAndConttexAddPage_Click);
            // 
            // PictureOpen
            // 
            this.PictureOpen.BackColor = System.Drawing.Color.Transparent;
            this.PictureOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PictureOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureOpen.Location = new System.Drawing.Point(0, 0);
            this.PictureOpen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PictureOpen.Name = "PictureOpen";
            this.PictureOpen.Size = new System.Drawing.Size(828, 566);
            this.PictureOpen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureOpen.TabIndex = 0;
            this.PictureOpen.TabStop = false;
            this.PictureOpen.Click += new System.EventHandler(this.PictureOpen_Click);
            this.PictureOpen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureOpen_MouseDown);
            // 
            // minimizeBt
            // 
            this.minimizeBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizeBt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.minimizeBt.FlatAppearance.BorderSize = 0;
            this.minimizeBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeBt.Font = new System.Drawing.Font("Marlett", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.minimizeBt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.minimizeBt.Location = new System.Drawing.Point(739, 0);
            this.minimizeBt.Margin = new System.Windows.Forms.Padding(0);
            this.minimizeBt.Name = "minimizeBt";
            this.minimizeBt.Size = new System.Drawing.Size(27, 26);
            this.minimizeBt.TabIndex = 18;
            this.minimizeBt.Text = "0";
            this.minimizeBt.UseVisualStyleBackColor = false;
            // 
            // maximizeBt
            // 
            this.maximizeBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maximizeBt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.maximizeBt.FlatAppearance.BorderSize = 0;
            this.maximizeBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maximizeBt.Font = new System.Drawing.Font("Marlett", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.maximizeBt.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.maximizeBt.Location = new System.Drawing.Point(765, 0);
            this.maximizeBt.Margin = new System.Windows.Forms.Padding(0);
            this.maximizeBt.Name = "maximizeBt";
            this.maximizeBt.Size = new System.Drawing.Size(35, 27);
            this.maximizeBt.TabIndex = 19;
            this.maximizeBt.Text = "1";
            this.maximizeBt.UseVisualStyleBackColor = false;
            // 
            // closeBt
            // 
            this.closeBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeBt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.closeBt.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.closeBt.FlatAppearance.BorderSize = 0;
            this.closeBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBt.Font = new System.Drawing.Font("Marlett", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.closeBt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.closeBt.Location = new System.Drawing.Point(799, 0);
            this.closeBt.Margin = new System.Windows.Forms.Padding(0);
            this.closeBt.Name = "closeBt";
            this.closeBt.Size = new System.Drawing.Size(29, 27);
            this.closeBt.TabIndex = 20;
            this.closeBt.Text = "r";
            this.closeBt.UseVisualStyleBackColor = false;
            // 
            // menuStrip
            // 
            this.menuStrip.AllowMerge = false;
            this.menuStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip.AutoSize = false;
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(828, 31);
            this.menuStrip.TabIndex = 21;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EnlargeMakeA2AndDivideIntoA4ToolStripMenuItem,
            this.EnlargeMakeA3AndDivideIntoA4ToolStripMenuItem,
            this.TexboxToolStripMenuItem,
            this.SkirtsToolStripMenuItem});
            this.menuToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(60, 27);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // EnlargeMakeA2AndDivideIntoA4ToolStripMenuItem
            // 
            this.EnlargeMakeA2AndDivideIntoA4ToolStripMenuItem.Name = "EnlargeMakeA2AndDivideIntoA4ToolStripMenuItem";
            this.EnlargeMakeA2AndDivideIntoA4ToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.EnlargeMakeA2AndDivideIntoA4ToolStripMenuItem.Text = "A2 skirts for 4 x A4";
            this.EnlargeMakeA2AndDivideIntoA4ToolStripMenuItem.Click += new System.EventHandler(this.A3_And_A2_Menu_Click);
            // 
            // EnlargeMakeA3AndDivideIntoA4ToolStripMenuItem
            // 
            this.EnlargeMakeA3AndDivideIntoA4ToolStripMenuItem.Checked = true;
            this.EnlargeMakeA3AndDivideIntoA4ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EnlargeMakeA3AndDivideIntoA4ToolStripMenuItem.Name = "EnlargeMakeA3AndDivideIntoA4ToolStripMenuItem";
            this.EnlargeMakeA3AndDivideIntoA4ToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.EnlargeMakeA3AndDivideIntoA4ToolStripMenuItem.Text = "A3 skirts for 2  x A4";
            this.EnlargeMakeA3AndDivideIntoA4ToolStripMenuItem.Click += new System.EventHandler(this.A3_And_A2_Menu_Click);
            // 
            // TexboxToolStripMenuItem
            // 
            this.TexboxToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TexboxToolStripMenuItem.Name = "TexboxToolStripMenuItem";
            this.TexboxToolStripMenuItem.Size = new System.Drawing.Size(180, 27);
            this.TexboxToolStripMenuItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TexboxToolStripMenuItem_KeyDown);
            this.TexboxToolStripMenuItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TexboxToolStripMenuItem_KeyPress);
            this.TexboxToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TexboxToolStripMenuItem_MouseDown);
            this.TexboxToolStripMenuItem.TextChanged += new System.EventHandler(this.TexboxToolStripMenuItem_TextChanged);
            // 
            // SkirtsToolStripMenuItem
            // 
            this.SkirtsToolStripMenuItem.Name = "SkirtsToolStripMenuItem";
            this.SkirtsToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.SkirtsToolStripMenuItem.Text = " Skirts";
            this.SkirtsToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.SkirtsToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.SkirtsToolStripMenuItem.Click += new System.EventHandler(this.SkirtsToolStripMenuItem_Click);
            // 
            // FormController2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(828, 566);
            this.ControlBox = false;
            this.Controls.Add(this.ColorDot);
            this.Controls.Add(this.Previousbt);
            this.Controls.Add(this.Nextbt);
            this.Controls.Add(this.closeBt);
            this.Controls.Add(this.maximizeBt);
            this.Controls.Add(this.labelPageAndMaxPage);
            this.Controls.Add(this.minimizeBt);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.PanelMouseSupport);
            this.Controls.Add(this.PictureOpen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormController2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.FormController2_Load);
            this.SizeChanged += new System.EventHandler(this.Form2_SizeChanged);
            this.ContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureOpen)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Nextbt;
        private System.Windows.Forms.Button Previousbt;
        private System.Windows.Forms.Panel PanelMouseSupport;
        public System.Windows.Forms.PictureBox PictureOpen;
        public System.Windows.Forms.Label labelPageAndMaxPage;
        public System.Windows.Forms.Button minimizeBt;
        public System.Windows.Forms.Button maximizeBt;
        public System.Windows.Forms.Button closeBt;
        public System.Windows.Forms.MenuStrip menuStrip;
        public System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem EnlargeMakeA2AndDivideIntoA4ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem EnlargeMakeA3AndDivideIntoA4ToolStripMenuItem;
        public System.Windows.Forms.ToolStripTextBox TexboxToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem SkirtsToolStripMenuItem;
        public System.Windows.Forms.Label ColorDot;
        public new System.Windows.Forms.ContextMenuStrip ContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem AddThisPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConvertThisPageToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem A4x4ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem A4x2ToolStripMenuItem;
    }
}