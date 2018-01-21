namespace VideoConference
{
    partial class Conference
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Conference));
            this.CapturingPic = new System.Windows.Forms.PictureBox();
            this.ReceivedPic = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Messages = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sendBtn = new System.Windows.Forms.Button();
            this.SendMsg = new System.Windows.Forms.Button();
            this.Message = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.CapturingPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceivedPic)).BeginInit();
            this.SuspendLayout();
            // 
            // CapturingPic
            // 
            this.CapturingPic.Image = ((System.Drawing.Image)(resources.GetObject("CapturingPic.Image")));
            this.CapturingPic.Location = new System.Drawing.Point(23, 24);
            this.CapturingPic.Name = "CapturingPic";
            this.CapturingPic.Size = new System.Drawing.Size(399, 302);
            this.CapturingPic.TabIndex = 2;
            this.CapturingPic.TabStop = false;
            // 
            // ReceivedPic
            // 
            this.ReceivedPic.Image = ((System.Drawing.Image)(resources.GetObject("ReceivedPic.Image")));
            this.ReceivedPic.Location = new System.Drawing.Point(440, 24);
            this.ReceivedPic.Name = "ReceivedPic";
            this.ReceivedPic.Size = new System.Drawing.Size(399, 302);
            this.ReceivedPic.TabIndex = 3;
            this.ReceivedPic.TabStop = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.OrangeRed;
            this.button3.Location = new System.Drawing.Point(574, 605);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(265, 37);
            this.button3.TabIndex = 4;
            this.button3.Text = "Ukryj mnie";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 150;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Messages
            // 
            this.Messages.Location = new System.Drawing.Point(23, 359);
            this.Messages.Name = "Messages";
            this.Messages.Size = new System.Drawing.Size(816, 179);
            this.Messages.TabIndex = 8;
            this.Messages.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 336);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Wiadomośći z telekonferencji";
            // 
            // sendBtn
            // 
            this.sendBtn.BackColor = System.Drawing.Color.Green;
            this.sendBtn.Location = new System.Drawing.Point(294, 605);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(275, 37);
            this.sendBtn.TabIndex = 14;
            this.sendBtn.Text = "Pokaż mnie";
            this.sendBtn.UseVisualStyleBackColor = false;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // SendMsg
            // 
            this.SendMsg.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.SendMsg.Location = new System.Drawing.Point(575, 549);
            this.SendMsg.Name = "SendMsg";
            this.SendMsg.Size = new System.Drawing.Size(264, 50);
            this.SendMsg.TabIndex = 16;
            this.SendMsg.Text = "Wyślij wiadomość";
            this.SendMsg.UseVisualStyleBackColor = false;
            this.SendMsg.Click += new System.EventHandler(this.SendMsg_Click);
            // 
            // Message
            // 
            this.Message.Location = new System.Drawing.Point(23, 549);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(546, 50);
            this.Message.TabIndex = 17;
            this.Message.Text = "";
            // 
            // Conference
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(875, 654);
            this.Controls.Add(this.Message);
            this.Controls.Add(this.SendMsg);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Messages);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.ReceivedPic);
            this.Controls.Add(this.CapturingPic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Conference";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Video Conference App";
            ((System.ComponentModel.ISupportInitialize)(this.CapturingPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceivedPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.PictureBox CapturingPic;
        private System.Windows.Forms.PictureBox ReceivedPic;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox Messages;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.Button SendMsg;
        private System.Windows.Forms.RichTextBox Message;
    }
}

