namespace WindowsFormsApplication2
{
    partial class ChatClientForm
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
            this.sendButton = new System.Windows.Forms.Button();
            this.connectButton = new System.Windows.Forms.Button();
            this.chatField = new System.Windows.Forms.TextBox();
            this.messageField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sendButton
            // 
            this.sendButton.Enabled = false;
            this.sendButton.Location = new System.Drawing.Point(163, 250);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(109, 23);
            this.sendButton.TabIndex = 0;
            this.sendButton.Text = "Send Message";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendMsgButtonClick);
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(163, 12);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(109, 23);
            this.connectButton.TabIndex = 1;
            this.connectButton.Text = "Connect to Server";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButtonClick);
            // 
            // chatField
            // 
            this.chatField.Location = new System.Drawing.Point(12, 41);
            this.chatField.Multiline = true;
            this.chatField.Name = "chatField";
            this.chatField.ReadOnly = true;
            this.chatField.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.chatField.Size = new System.Drawing.Size(260, 177);
            this.chatField.TabIndex = 2;
            // 
            // messageField
            // 
            this.messageField.AcceptsReturn = true;
            this.messageField.Enabled = false;
            this.messageField.Location = new System.Drawing.Point(13, 224);
            this.messageField.Name = "messageField";
            this.messageField.Size = new System.Drawing.Size(259, 20);
            this.messageField.TabIndex = 3;
            this.messageField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.senMsgKeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(197, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Disconnect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.dissconButtonClick);
            // 
            // ChatClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 281);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.messageField);
            this.Controls.Add(this.chatField);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.sendButton);
            this.Name = "ChatClientForm";
            this.Text = "Chat Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button sendButton;
        public System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.TextBox chatField;
        public System.Windows.Forms.TextBox messageField;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button button1;
    }
}

