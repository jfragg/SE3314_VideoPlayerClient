namespace se3314_assignment2
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
            this.components = new System.ComponentModel.Container();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.Port = new System.Windows.Forms.TextBox();
            this.IPAddr = new System.Windows.Forms.TextBox();
            this.video = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.videoScreen = new System.Windows.Forms.PictureBox();
            this.SetupButton = new System.Windows.Forms.Button();
            this.PlayButton = new System.Windows.Forms.Button();
            this.PauseButton = new System.Windows.Forms.Button();
            this.TeardownButton = new System.Windows.Forms.Button();
            this.clientBox = new System.Windows.Forms.TextBox();
            this.serverBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // Port
            // 
            this.Port.Location = new System.Drawing.Point(96, 15);
            this.Port.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(52, 20);
            this.Port.TabIndex = 0;
            this.Port.Text = "3000";
            // 
            // IPAddr
            // 
            this.IPAddr.Location = new System.Drawing.Point(256, 15);
            this.IPAddr.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.IPAddr.Name = "IPAddr";
            this.IPAddr.Size = new System.Drawing.Size(74, 20);
            this.IPAddr.TabIndex = 1;
            this.IPAddr.Text = "127.0.0.1";
            // 
            // video
            // 
            this.video.Location = new System.Drawing.Point(376, 15);
            this.video.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.video.Name = "video";
            this.video.Size = new System.Drawing.Size(52, 20);
            this.video.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Connect to Port: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Server IP Address:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(337, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Video:";
            // 
            // videoScreen
            // 
            this.videoScreen.Location = new System.Drawing.Point(6, 39);
            this.videoScreen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.videoScreen.Name = "videoScreen";
            this.videoScreen.Size = new System.Drawing.Size(425, 234);
            this.videoScreen.TabIndex = 6;
            this.videoScreen.TabStop = false;
            // 
            // SetupButton
            // 
            this.SetupButton.Enabled = false;
            this.SetupButton.Location = new System.Drawing.Point(13, 277);
            this.SetupButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SetupButton.Name = "SetupButton";
            this.SetupButton.Size = new System.Drawing.Size(100, 55);
            this.SetupButton.TabIndex = 7;
            this.SetupButton.Text = "SETUP";
            this.SetupButton.UseVisualStyleBackColor = true;
            this.SetupButton.Click += new System.EventHandler(this.SetupButton_Click);
            // 
            // PlayButton
            // 
            this.PlayButton.Enabled = false;
            this.PlayButton.Location = new System.Drawing.Point(117, 277);
            this.PlayButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(99, 55);
            this.PlayButton.TabIndex = 8;
            this.PlayButton.Text = "PLAY";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // PauseButton
            // 
            this.PauseButton.Enabled = false;
            this.PauseButton.Location = new System.Drawing.Point(227, 277);
            this.PauseButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(102, 55);
            this.PauseButton.TabIndex = 9;
            this.PauseButton.Text = "PAUSE";
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // TeardownButton
            // 
            this.TeardownButton.Enabled = false;
            this.TeardownButton.Location = new System.Drawing.Point(333, 277);
            this.TeardownButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TeardownButton.Name = "TeardownButton";
            this.TeardownButton.Size = new System.Drawing.Size(92, 55);
            this.TeardownButton.TabIndex = 10;
            this.TeardownButton.Text = "TEARDOWN";
            this.TeardownButton.UseVisualStyleBackColor = true;
            this.TeardownButton.Click += new System.EventHandler(this.TeardownButton_Click);
            // 
            // clientBox
            // 
            this.clientBox.Location = new System.Drawing.Point(8, 345);
            this.clientBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.clientBox.Multiline = true;
            this.clientBox.Name = "clientBox";
            this.clientBox.Size = new System.Drawing.Size(335, 124);
            this.clientBox.TabIndex = 11;
            // 
            // serverBox
            // 
            this.serverBox.Location = new System.Drawing.Point(8, 499);
            this.serverBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.serverBox.Multiline = true;
            this.serverBox.Name = "serverBox";
            this.serverBox.Size = new System.Drawing.Size(335, 110);
            this.serverBox.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 479);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Server Response:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(344, 345);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(95, 17);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "Packet Report";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(344, 368);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(85, 17);
            this.checkBox2.TabIndex = 15;
            this.checkBox2.Text = "Print Header";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(346, 499);
            this.button5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(81, 26);
            this.button5.TabIndex = 16;
            this.button5.Text = "Connect";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(344, 533);
            this.button6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(81, 26);
            this.button6.TabIndex = 17;
            this.button6.Text = "Cancel";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 624);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.serverBox);
            this.Controls.Add(this.clientBox);
            this.Controls.Add(this.TeardownButton);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.SetupButton);
            this.Controls.Add(this.videoScreen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.video);
            this.Controls.Add(this.IPAddr);
            this.Controls.Add(this.Port);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "SE3314_Client";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoScreen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TextBox Port;
        private System.Windows.Forms.TextBox IPAddr;
        private System.Windows.Forms.TextBox video;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox videoScreen;
        private System.Windows.Forms.Button SetupButton;
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.Button TeardownButton;
        private System.Windows.Forms.TextBox clientBox;
        private System.Windows.Forms.TextBox serverBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}

