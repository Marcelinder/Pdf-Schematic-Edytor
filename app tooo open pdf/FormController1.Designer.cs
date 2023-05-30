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
            this.CloseBt = new System.Windows.Forms.Button();
            this.MaximizeBt = new System.Windows.Forms.Button();
            this.MinimizeBt = new System.Windows.Forms.Button();
            this.Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.ConvertFastToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ConvertSlowToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.MenuStrip.SuspendLayout();
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
            // CloseBt
            // 
            this.CloseBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CloseBt.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CloseBt.FlatAppearance.BorderSize = 0;
            this.CloseBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBt.Font = new System.Drawing.Font("Marlett", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.CloseBt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CloseBt.Location = new System.Drawing.Point(661, -1);
            this.CloseBt.Margin = new System.Windows.Forms.Padding(0);
            this.CloseBt.Name = "CloseBt";
            this.CloseBt.Size = new System.Drawing.Size(43, 27);
            this.CloseBt.TabIndex = 15;
            this.CloseBt.Text = "r";
            this.CloseBt.UseVisualStyleBackColor = false;
            // 
            // MaximizeBt
            // 
            this.MaximizeBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MaximizeBt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MaximizeBt.FlatAppearance.BorderSize = 0;
            this.MaximizeBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MaximizeBt.Font = new System.Drawing.Font("Marlett", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.MaximizeBt.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.MaximizeBt.Location = new System.Drawing.Point(625, 1);
            this.MaximizeBt.Margin = new System.Windows.Forms.Padding(0);
            this.MaximizeBt.Name = "MaximizeBt";
            this.MaximizeBt.Size = new System.Drawing.Size(36, 28);
            this.MaximizeBt.TabIndex = 16;
            this.MaximizeBt.Text = "1";
            this.MaximizeBt.UseVisualStyleBackColor = false;
            // 
            // MinimizeBt
            // 
            this.MinimizeBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinimizeBt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MinimizeBt.FlatAppearance.BorderSize = 0;
            this.MinimizeBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeBt.Font = new System.Drawing.Font("Marlett", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.MinimizeBt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MinimizeBt.Location = new System.Drawing.Point(596, 1);
            this.MinimizeBt.Margin = new System.Windows.Forms.Padding(0);
            this.MinimizeBt.Name = "MinimizeBt";
            this.MinimizeBt.Size = new System.Drawing.Size(29, 25);
            this.MinimizeBt.TabIndex = 17;
            this.MinimizeBt.Text = "0";
            this.MinimizeBt.UseVisualStyleBackColor = false;
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
            this.ConvertFastToolStripMenuItem1.Size = new System.Drawing.Size(179, 26);
            this.ConvertFastToolStripMenuItem1.Text = "Convert Fast";
            this.ConvertFastToolStripMenuItem1.Click += new System.EventHandler(this.ConvertFastAndSlowToolStripMenuItem1_Click);
            // 
            // ConvertSlowToolStripMenuItem1
            // 
            this.ConvertSlowToolStripMenuItem1.Name = "ConvertSlowToolStripMenuItem1";
            this.ConvertSlowToolStripMenuItem1.Size = new System.Drawing.Size(179, 26);
            this.ConvertSlowToolStripMenuItem1.Text = "Convert Slow";
            this.ConvertSlowToolStripMenuItem1.Click += new System.EventHandler(this.ConvertFastAndSlowToolStripMenuItem1_Click);
            // 
            // MenuStrip
            // 
            this.MenuStrip.AllowDrop = true;
            this.MenuStrip.AllowMerge = false;
            this.MenuStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MenuStrip.AutoSize = false;
            this.MenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MenuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MenuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.MenuStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu});
            this.MenuStrip.Location = new System.Drawing.Point(-1, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Padding = new System.Windows.Forms.Padding(0);
            this.MenuStrip.Size = new System.Drawing.Size(715, 29);
            this.MenuStrip.TabIndex = 14;
            // 
            // FormController1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(704, 654);
            this.ControlBox = false;
            this.Controls.Add(this.MaximizeBt);
            this.Controls.Add(this.MinimizeBt);
            this.Controls.Add(this.CloseBt);
            this.Controls.Add(this.MenuStrip);
            this.Controls.Add(this.WebBrowser1);
            this.Controls.Add(this.AddPdfBT);
            this.Controls.Add(this.ConvertBt);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.MenuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(600, 450);
            this.Name = "FormController1";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.FormController1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormController1_DragDrop);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddPdfBT;
        private System.Windows.Forms.Button ConvertBt;
        public System.Windows.Forms.Button CloseBt;
        public System.Windows.Forms.Button MaximizeBt;
        public System.Windows.Forms.Button MinimizeBt;
        public System.Windows.Forms.WebBrowser WebBrowser1;
        public new System.Windows.Forms.ToolStripMenuItem Menu;
        public System.Windows.Forms.ToolStripMenuItem ConvertFastToolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem ConvertSlowToolStripMenuItem1;
        public System.Windows.Forms.MenuStrip MenuStrip;
    }
}

