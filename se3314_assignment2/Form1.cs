using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace se3314_assignment2
{
    public partial class Form1 : Form
    {
        Controller _controller;

        public Form1()
        {
            InitializeComponent();
            _controller = new Controller();
            this.button5.Click += new System.EventHandler(_controller.Connect_ButtonClick);
            //this.SetupButton.Click += new System.EventHandler(_controller.SetUpSelected);
        }

        public int GetPort()
        {
            int port = Int32.Parse(Port.Text.ToString());
            return port;
        }

        public string GetIPAddr()
        {
            return IPAddr.Text;
        }

        public string GetVideoName()
        {
            return video.Text;
        }

        public void SetClientText(string s)
        {
            clientBox.AppendText(s + Environment.NewLine);
        }

        public void SetServerText(string s)
        {
            serverBox.AppendText(s + Environment.NewLine + Environment.NewLine);
        }

        //connect button click
        private void button5_Click(object sender, EventArgs e)
        {
            SetupButton.Enabled = true;
            PlayButton.Enabled = true;
            TeardownButton.Enabled = true;
            PauseButton.Enabled = true;
            button5.Enabled = false; //connect button
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void SetupButton_Click(object sender, EventArgs e)
        {
            _controller.SetUpSelected();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            _controller.PlaySelected();
        }
    }
}
