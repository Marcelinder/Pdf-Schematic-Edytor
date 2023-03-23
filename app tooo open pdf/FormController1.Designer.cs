namespace app_tooo_open_pdf
{
    partial class FormController1
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
            this.WebBrowser1 = new System.Windows.Forms.WebBrowser();
            this.AddPdfBT = new System.Windows.Forms.Button();
            this.ConvertBt = new System.Windows.Forms.Button();
            this.closeBt = new System.Windows.Forms.Button();
            this.maximizeBt = new System.Windows.Forms.Button();
            this.minimizeBt = new System.Windows.Forms.Button();
            this.Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.ConvertFastToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ConvertSlowToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // WebBrowser1
            // 
            this.WebBrowser1.AllowWebBrowserDrop = false;
            this.WebBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WebBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.WebBrowser1.Location = new System.Drawing.Point(28, 45);
            this.WebBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.WebBrowser1.Name = "WebBrowser1";
            this.WebBrowser1.Size = new System.Drawing.Size(537, 531);
            this.WebBrowser1.TabIndex = 18;
            this.WebBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WebBrowser1_DocumentCompleted);
            // 
            // AddPdfBT
            // 
            this.AddPdfBT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddPdfBT.Location = new System.Drawing.Point(582, 45);
            this.AddPdfBT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddPdfBT.Name = "AddPdfBT";
            this.AddPdfBT.Size = new System.Drawing.Size(110, 46);
            this.AddPdfBT.TabIndex = 0;
            this.AddPdfBT.Text = "Add PDF";
            this.AddPdfBT.UseVisualStyleBackColor = true;
            this.AddPdfBT.Click += new System.EventHandler(this.AddPdfBt_Click);
            // 
            // ConvertBt
            // 
            this.ConvertBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ConvertBt.Location = new System.Drawing.Point(582, 105);
            this.ConvertBt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ConvertBt.Name = "ConvertBt";
            this.ConvertBt.Size = new System.Drawing.Size(110, 46);
            this.ConvertBt.TabIndex = 11;
            this.ConvertBt.Text = "Convert";
            this.ConvertBt.UseVisualStyleBackColor = true;
            this.ConvertBt.Click += new System.EventHandler(this.ConvertBt_Click);
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
            this.closeBt.Location = new System.Drawing.Point(661, -1);
            this.closeBt.Margin = new System.Windows.Forms.Padding(0);
            this.closeBt.Name = "closeBt";
            this.closeBt.Size = new System.Drawing.Size(43, 27);
            this.closeBt.TabIndex = 15;
            this.closeBt.Text = "r";
            this.closeBt.UseVisualStyleBackColor = false;
            // 
            // maximizeBt
            // 
            this.maximizeBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maximizeBt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.maximizeBt.FlatAppearance.BorderSize = 0;
            this.maximizeBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maximizeBt.Font = new System.Drawing.Font("Marlett", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.maximizeBt.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.maximizeBt.Location = new System.Drawing.Point(625, 1);
            this.maximizeBt.Margin = new System.Windows.Forms.Padding(0);
            this.maximizeBt.Name = "maximizeBt";
            this.maximizeBt.Size = new System.Drawing.Size(36, 28);
            this.maximizeBt.TabIndex = 16;
            this.maximizeBt.Text = "1";
            this.maximizeBt.UseVisualStyleBackColor = false;
            // 
            // minimizeBt
            // 
            this.minimizeBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizeBt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.minimizeBt.FlatAppearance.BorderSize = 0;
            this.minimizeBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeBt.Font = new System.Drawing.Font("Marlett", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.minimizeBt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.minimizeBt.Location = new System.Drawing.Point(596, 1);
            this.minimizeBt.Margin = new System.Windows.Forms.Padding(0);
            this.minimizeBt.Name = "minimizeBt";
            this.minimizeBt.Size = new System.Drawing.Size(29, 25);
            this.minimizeBt.TabIndex = 17;
            this.minimizeBt.Text = "0";
            this.minimizeBt.UseVisualStyleBackColor = false;
            // 
            // Menu
            // 
            this.Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConvertFastToolStripMenuItem1,
            this.ConvertSlowToolStripMenuItem1});
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(60, 29);
            this.Menu.Text = "Menu";
            // 
            // ConvertFastToolStripMenuItem1
            // 
            this.ConvertFastToolStripMenuItem1.Checked = true;
            this.ConvertFastToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ConvertFastToolStripMenuItem1.Name = "ConvertFastToolStripMenuItem1";
            this.ConvertFastToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.ConvertFastToolStripMenuItem1.Text = "Convert Fast";
            this.ConvertFastToolStripMenuItem1.Click += new System.EventHandler(this.ConvertFastAndSlowToolStripMenuItem1_Click);
            // 
            // ConvertSlowToolStripMenuItem1
            // 
            this.ConvertSlowToolStripMenuItem1.Name = "ConvertSlowToolStripMenuItem1";
            this.ConvertSlowToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.ConvertSlowToolStripMenuItem1.Text = "Convert Slow";
            this.ConvertSlowToolStripMenuItem1.Click += new System.EventHandler(this.ConvertFastAndSlowToolStripMenuItem1_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.AllowDrop = true;
            this.menuStrip.AllowMerge = false;
            this.menuStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip.AutoSize = false;
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.menuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu});
            this.menuStrip.Location = new System.Drawing.Point(-1, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(0);
            this.menuStrip.Size = new System.Drawing.Size(715, 29);
            this.menuStrip.TabIndex = 14;
            this.menuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip_ItemClicked);
            // 
            // FormController1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(704, 654);
            this.ControlBox = false;
            this.Controls.Add(this.maximizeBt);
            this.Controls.Add(this.minimizeBt);
            this.Controls.Add(this.closeBt);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.WebBrowser1);
            this.Controls.Add(this.AddPdfBT);
            this.Controls.Add(this.ConvertBt);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(600, 450);
            this.Name = "FormController1";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.FormController1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormController1_DragDrop);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddPdfBT;
        private System.Windows.Forms.Button ConvertBt;
        public System.Windows.Forms.Button closeBt;
        public System.Windows.Forms.Button maximizeBt;
        public System.Windows.Forms.Button minimizeBt;
        public System.Windows.Forms.WebBrowser WebBrowser1;
        public new System.Windows.Forms.ToolStripMenuItem Menu;
        public System.Windows.Forms.ToolStripMenuItem ConvertFastToolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem ConvertSlowToolStripMenuItem1;
        public System.Windows.Forms.MenuStrip menuStrip;
    }
}

