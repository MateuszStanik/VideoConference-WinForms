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
            this.CreateConnection = new System.Windows.Forms.Button();
            this.CapturingPic = new System.Windows.Forms.PictureBox();
            this.ReceivedPic = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Messages = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.OutputPort = new System.Windows.Forms.TextBox();
            this.InputPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sendBtn = new System.Windows.Forms.Button();
            this.Wyślij = new System.Windows.Forms.Button();
            this.Message = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.CapturingPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceivedPic)).BeginInit();
            this.SuspendLayout();
            // 
            // CreateConnection
            // 
            this.CreateConnection.BackColor = System.Drawing.Color.DarkCyan;
            this.CreateConnection.Location = new System.Drawing.Point(23, 645);
            this.CreateConnection.Name = "CreateConnection";
            this.CreateConnection.Size = new System.Drawing.Size(265, 37);
            this.CreateConnection.TabIndex = 0;
            this.CreateConnection.Text = "Utwórz konferencje";
            this.CreateConnection.UseVisualStyleBackColor = false;
            this.CreateConnection.Click += new System.EventHandler(this.CreateConnection_Click);
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
            this.button3.Location = new System.Drawing.Point(574, 645);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(265, 37);
            this.button3.TabIndex = 4;
            this.button3.Text = "Opuść konferencje";
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
            this.Messages.Location = new System.Drawing.Point(23, 378);
            this.Messages.Name = "Messages";
            this.Messages.Size = new System.Drawing.Size(816, 179);
            this.Messages.TabIndex = 8;
            this.Messages.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 355);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Wiadomośći z telekonferencji";
            // 
            // OutputPort
            // 
            this.OutputPort.Location = new System.Drawing.Point(132, 330);
            this.OutputPort.Name = "OutputPort";
            this.OutputPort.Size = new System.Drawing.Size(290, 22);
            this.OutputPort.TabIndex = 10;
            // 
            // InputPort
            // 
            this.InputPort.Location = new System.Drawing.Point(549, 330);
            this.InputPort.Name = "InputPort";
            this.InputPort.Size = new System.Drawing.Size(290, 22);
            this.InputPort.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 333);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Port wyjściowy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(437, 335);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Port docelowy";
            // 
            // sendBtn
            // 
            this.sendBtn.BackColor = System.Drawing.Color.Green;
            this.sendBtn.Location = new System.Drawing.Point(294, 645);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(275, 37);
            this.sendBtn.TabIndex = 14;
            this.sendBtn.Text = "Nawiąż połączenie";
            this.sendBtn.UseVisualStyleBackColor = false;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // Wyślij
            // 
            this.Wyślij.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Wyślij.Location = new System.Drawing.Point(575, 568);
            this.Wyślij.Name = "Wyślij";
            this.Wyślij.Size = new System.Drawing.Size(264, 50);
            this.Wyślij.TabIndex = 16;
            this.Wyślij.Text = "Wyślij wiadomość";
            this.Wyślij.UseVisualStyleBackColor = false;
            this.Wyślij.Click += new System.EventHandler(this.Wyślij_Click);
            // 
            // Message
            // 
            this.Message.Location = new System.Drawing.Point(23, 568);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(546, 71);
            this.Message.TabIndex = 17;
            this.Message.Text = "";
            // 
            // Conference
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(875, 731);
            this.Controls.Add(this.Message);
            this.Controls.Add(this.Wyślij);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InputPort);
            this.Controls.Add(this.OutputPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Messages);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.ReceivedPic);
            this.Controls.Add(this.CapturingPic);
            this.Controls.Add(this.CreateConnection);
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

        private System.Windows.Forms.Button CreateConnection;
        //private System.Windows.Forms.PictureBox CapturingPic;
        private System.Windows.Forms.PictureBox ReceivedPic;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox Messages;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox OutputPort;
        private System.Windows.Forms.TextBox InputPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.Button Wyślij;
        private System.Windows.Forms.RichTextBox Message;
    }
}

