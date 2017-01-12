namespace Amx_Emailing_Service
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label_WelcomeToAmx = new System.Windows.Forms.Label();
            this.label_EnterEmail = new System.Windows.Forms.Label();
            this.textBox_userEnterEmail = new System.Windows.Forms.TextBox();
            this.checkBox_AddInfo = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_AddAdditionalInfo = new System.Windows.Forms.TextBox();
            this.button_Submit = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_WelcomeToAmx
            // 
            this.label_WelcomeToAmx.AutoSize = true;
            this.label_WelcomeToAmx.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_WelcomeToAmx.Location = new System.Drawing.Point(85, 28);
            this.label_WelcomeToAmx.Name = "label_WelcomeToAmx";
            this.label_WelcomeToAmx.Size = new System.Drawing.Size(302, 36);
            this.label_WelcomeToAmx.TabIndex = 0;
            this.label_WelcomeToAmx.Text = "      Welcome to the DGX Emailing Service\r\nTo get started click on the help butto" +
    "n above.\r\n";
            // 
            // label_EnterEmail
            // 
            this.label_EnterEmail.AutoSize = true;
            this.label_EnterEmail.Location = new System.Drawing.Point(85, 93);
            this.label_EnterEmail.Name = "label_EnterEmail";
            this.label_EnterEmail.Size = new System.Drawing.Size(311, 13);
            this.label_EnterEmail.TabIndex = 1;
            this.label_EnterEmail.Text = "Please Enter a email below that you want the email to be sent to.";
            // 
            // textBox_userEnterEmail
            // 
            this.textBox_userEnterEmail.Location = new System.Drawing.Point(141, 109);
            this.textBox_userEnterEmail.Name = "textBox_userEnterEmail";
            this.textBox_userEnterEmail.Size = new System.Drawing.Size(198, 20);
            this.textBox_userEnterEmail.TabIndex = 2;
            this.textBox_userEnterEmail.TextChanged += new System.EventHandler(this.EnterEmailAddress);
            // 
            // checkBox_AddInfo
            // 
            this.checkBox_AddInfo.AutoSize = true;
            this.checkBox_AddInfo.Location = new System.Drawing.Point(183, 193);
            this.checkBox_AddInfo.Name = "checkBox_AddInfo";
            this.checkBox_AddInfo.Size = new System.Drawing.Size(105, 17);
            this.checkBox_AddInfo.TabIndex = 3;
            this.checkBox_AddInfo.Text = "Add information?";
            this.checkBox_AddInfo.UseVisualStyleBackColor = true;
            this.checkBox_AddInfo.CheckedChanged += new System.EventHandler(this.addedInfoCheckBoxChange);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 39);
            this.label1.TabIndex = 4;
            this.label1.Text = "Would you like to add any additional information \r\n                    default me" +
    "ssage sent is \r\n            \"Your DGX system is upgraded.\"";
            // 
            // textBox_AddAdditionalInfo
            // 
            this.textBox_AddAdditionalInfo.Enabled = false;
            this.textBox_AddAdditionalInfo.Location = new System.Drawing.Point(45, 216);
            this.textBox_AddAdditionalInfo.Multiline = true;
            this.textBox_AddAdditionalInfo.Name = "textBox_AddAdditionalInfo";
            this.textBox_AddAdditionalInfo.Size = new System.Drawing.Size(370, 80);
            this.textBox_AddAdditionalInfo.TabIndex = 5;
            // 
            // button_Submit
            // 
            this.button_Submit.Enabled = false;
            this.button_Submit.Location = new System.Drawing.Point(401, 344);
            this.button_Submit.Name = "button_Submit";
            this.button_Submit.Size = new System.Drawing.Size(75, 23);
            this.button_Submit.TabIndex = 6;
            this.button_Submit.Text = "Submit";
            this.button_Submit.UseVisualStyleBackColor = true;
            this.button_Submit.Click += new System.EventHandler(this.button_Submit_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(488, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.startToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Enabled = false;
            this.button_Cancel.Location = new System.Drawing.Point(12, 344);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 8;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 379);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Submit);
            this.Controls.Add(this.textBox_AddAdditionalInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox_AddInfo);
            this.Controls.Add(this.textBox_userEnterEmail);
            this.Controls.Add(this.label_EnterEmail);
            this.Controls.Add(this.label_WelcomeToAmx);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "DGX\'s Mailing Service";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_WelcomeToAmx;
        private System.Windows.Forms.Label label_EnterEmail;
        private System.Windows.Forms.TextBox textBox_userEnterEmail;
        private System.Windows.Forms.CheckBox checkBox_AddInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_AddAdditionalInfo;
        private System.Windows.Forms.Button button_Submit;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button button_Cancel;
    }
}

