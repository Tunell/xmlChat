namespace WindowsFormsApplication2
{
    partial class clientConnectForm
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
            this.IPField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.portField = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nickField = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // IPField
            // 
            this.IPField.Location = new System.Drawing.Point(84, 12);
            this.IPField.Name = "IPField";
            this.IPField.Size = new System.Drawing.Size(174, 20);
            this.IPField.TabIndex = 0;
            this.IPField.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Server Port:";
            // 
            // portField
            // 
            this.portField.Location = new System.Drawing.Point(84, 38);
            this.portField.Name = "portField";
            this.portField.Size = new System.Drawing.Size(174, 20);
            this.portField.TabIndex = 2;
            this.portField.Text = "2000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nickname:";
            // 
            // nickField
            // 
            this.nickField.Location = new System.Drawing.Point(84, 64);
            this.nickField.Name = "nickField";
            this.nickField.Size = new System.Drawing.Size(174, 20);
            this.nickField.TabIndex = 4;
            this.nickField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nickField_KeyUp);
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(183, 90);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 6;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // clientConnectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 125);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nickField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.portField);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IPField);
            this.Name = "clientConnectForm";
            this.Text = "Connect to Server";
            this.ResumeLayout(false);
            this.PerformLayout();
            this.ActiveControl = nickField;

        }

        #endregion

        private System.Windows.Forms.TextBox IPField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox portField;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nickField;
        private System.Windows.Forms.Button connectButton;
    }
}