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
            this.SendingPic = new System.Windows.Forms.PictureBox();
            this.ReceivedPic1 = new System.Windows.Forms.PictureBox();
            this.hideMe = new System.Windows.Forms.Button();
            this.Messages = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.showMe = new System.Windows.Forms.Button();
            this.SendMsg = new System.Windows.Forms.Button();
            this.Message = new System.Windows.Forms.RichTextBox();
            this.ReceivedPic2 = new System.Windows.Forms.PictureBox();
            this.ReceivedPic3 = new System.Windows.Forms.PictureBox();
            this.ReceivedPic4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.SendingPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceivedPic1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceivedPic2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceivedPic3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceivedPic4)).BeginInit();
            this.SuspendLayout();
            // 
            // SendingPic
            // 
            this.SendingPic.Image = ((System.Drawing.Image)(resources.GetObject("SendingPic.Image")));
            this.SendingPic.Location = new System.Drawing.Point(23, 24);
            this.SendingPic.Name = "SendingPic";
            this.SendingPic.Size = new System.Drawing.Size(411, 306);
            this.SendingPic.TabIndex = 2;
            this.SendingPic.TabStop = false;
            // 
            // ReceivedPic1
            // 
            this.ReceivedPic1.Image = ((System.Drawing.Image)(resources.GetObject("ReceivedPic1.Image")));
            this.ReceivedPic1.Location = new System.Drawing.Point(440, 24);
            this.ReceivedPic1.Name = "ReceivedPic1";
            this.ReceivedPic1.Size = new System.Drawing.Size(200, 150);
            this.ReceivedPic1.TabIndex = 3;
            this.ReceivedPic1.TabStop = false;
            // 
            // hideMe
            // 
            this.hideMe.BackColor = System.Drawing.Color.OrangeRed;
            this.hideMe.Location = new System.Drawing.Point(577, 458);
            this.hideMe.Name = "hideMe";
            this.hideMe.Size = new System.Drawing.Size(262, 37);
            this.hideMe.TabIndex = 4;
            this.hideMe.Text = "Ukryj mnie";
            this.hideMe.UseVisualStyleBackColor = false;
            this.hideMe.Click += new System.EventHandler(this.hideMe_Click);
            // 
            // Messages
            // 
            this.Messages.Location = new System.Drawing.Point(23, 359);
            this.Messages.Name = "Messages";
            this.Messages.Size = new System.Drawing.Size(546, 179);
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
            this.label3.Text = "Wiadomości z telekonferencji";
            // 
            // showMe
            // 
            this.showMe.BackColor = System.Drawing.Color.Green;
            this.showMe.Location = new System.Drawing.Point(577, 501);
            this.showMe.Name = "showMe";
            this.showMe.Size = new System.Drawing.Size(262, 37);
            this.showMe.TabIndex = 14;
            this.showMe.Text = "Pokaż mnie";
            this.showMe.UseVisualStyleBackColor = false;
            this.showMe.Click += new System.EventHandler(this.showMe_Click);
            // 
            // SendMsg
            // 
            this.SendMsg.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.SendMsg.Location = new System.Drawing.Point(577, 549);
            this.SendMsg.Name = "SendMsg";
            this.SendMsg.Size = new System.Drawing.Size(262, 50);
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
            // ReceivedPic2
            // 
            this.ReceivedPic2.Image = ((System.Drawing.Image)(resources.GetObject("ReceivedPic2.Image")));
            this.ReceivedPic2.Location = new System.Drawing.Point(646, 24);
            this.ReceivedPic2.Name = "ReceivedPic2";
            this.ReceivedPic2.Size = new System.Drawing.Size(200, 150);
            this.ReceivedPic2.TabIndex = 18;
            this.ReceivedPic2.TabStop = false;
            // 
            // ReceivedPic3
            // 
            this.ReceivedPic3.Image = ((System.Drawing.Image)(resources.GetObject("ReceivedPic3.Image")));
            this.ReceivedPic3.Location = new System.Drawing.Point(440, 180);
            this.ReceivedPic3.Name = "ReceivedPic3";
            this.ReceivedPic3.Size = new System.Drawing.Size(200, 150);
            this.ReceivedPic3.TabIndex = 19;
            this.ReceivedPic3.TabStop = false;
            // 
            // ReceivedPic4
            // 
            this.ReceivedPic4.Image = ((System.Drawing.Image)(resources.GetObject("ReceivedPic4.Image")));
            this.ReceivedPic4.Location = new System.Drawing.Point(646, 180);
            this.ReceivedPic4.Name = "ReceivedPic4";
            this.ReceivedPic4.Size = new System.Drawing.Size(200, 150);
            this.ReceivedPic4.TabIndex = 20;
            this.ReceivedPic4.TabStop = false;
            // 
            // Conference
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(856, 613);
            this.Controls.Add(this.ReceivedPic4);
            this.Controls.Add(this.ReceivedPic3);
            this.Controls.Add(this.ReceivedPic2);
            this.Controls.Add(this.Message);
            this.Controls.Add(this.SendMsg);
            this.Controls.Add(this.showMe);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Messages);
            this.Controls.Add(this.hideMe);
            this.Controls.Add(this.ReceivedPic1);
            this.Controls.Add(this.SendingPic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Conference";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Video Conference App";
            ((System.ComponentModel.ISupportInitialize)(this.SendingPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceivedPic1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceivedPic2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceivedPic3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceivedPic4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
            this.FormClosed += Conference_FormClosed;
        }

        #endregion

        //private System.Windows.Forms.PictureBox CapturingPic;
        private System.Windows.Forms.PictureBox ReceivedPic1;
        private System.Windows.Forms.Button hideMe;
        private System.Windows.Forms.RichTextBox Messages;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button showMe;
        private System.Windows.Forms.Button SendMsg;
        private System.Windows.Forms.RichTextBox Message;
        private System.Windows.Forms.PictureBox ReceivedPic2;
        private System.Windows.Forms.PictureBox ReceivedPic3;
        private System.Windows.Forms.PictureBox ReceivedPic4;
    }
}

