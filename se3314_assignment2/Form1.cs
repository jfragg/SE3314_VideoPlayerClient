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
        private bool displayHeader = false;
        private bool showPacketInfo = false;
        delegate void RTPHeaderDelegate(string data);
        delegate void ShowDataInfoDelegate(string data);
        delegate void SetImageDelegate(Image image);

        public Form1()
        {
            InitializeComponent();
            _controller = new Controller();
            this.button5.Click += new System.EventHandler(_controller.Connect_ButtonClick); //connect to the controller 
            videoScreen.SizeMode = PictureBoxSizeMode.StretchImage; //fits the image to the picture box perfectly
        }

        //gets the port number from view
        public int GetPort()
        {
            int port = Int32.Parse(Port.Text.ToString()); //convert it to int
            return port;
        }

        //get the ip address from the view
        public string GetIPAddr()
        {
            return IPAddr.Text;
        }

        //get the video name from the view
        public string GetVideoName()
        {
            return video.Text;
        }

        //set the client text box
        public void SetClientText(string s)
        {
            clientBox.AppendText(s + Environment.NewLine);
        }

        //send rtp header data to the client textbox (thread safe function)
        public void SendRTPHeaders(string data)
        {
            if (this.clientBox.InvokeRequired)
            {
                RTPHeaderDelegate del = new RTPHeaderDelegate(SendRTPHeaders);
                this.Invoke(del, data); 
            } else
            {
                this.clientBox.AppendText(data + Environment.NewLine);
            }
        }

        //thread safe function to show the packet information
        public void ShowDataInfo(string data)
        {
            if (this.clientBox.InvokeRequired)
            {
                ShowDataInfoDelegate del = new ShowDataInfoDelegate(ShowDataInfo);
                this.Invoke(del, data);
            }
            else
            {
                this.clientBox.AppendText(data + Environment.NewLine);
            }
        }

        //thread safe function to display each frame
        public void DisplayImage(Image image)
        {
            if (this.videoScreen.InvokeRequired)
            {
                SetImageDelegate del = new SetImageDelegate(DisplayImage);
                this.Invoke(del, new object[] { image });
            } else
            {
                this.videoScreen.Image = image;
            }
        }

        //add strings to the server text box 
        public void SetServerText(string s)
        {
            serverBox.AppendText(s + Environment.NewLine + Environment.NewLine);
        }

        //check if the display header is checked
        public bool GetDisplayHeader()
        {
            return displayHeader;
        }

        //connect button click; when connect button is selected enable the set up button
        private void button5_Click(object sender, EventArgs e)
        {
            SetupButton.Enabled = true;
            PlayButton.Enabled = false;
            TeardownButton.Enabled = false;
            PauseButton.Enabled = false;
            button5.Enabled = false; //connect button
        }

        //if the showpacket info is true set it to false else set it to true
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            showPacketInfo = showPacketInfo ? false : true;
        }

        //get the value for show packet info
        public bool GetShowPacketInfo()
        {
            return showPacketInfo;
        }

        //exit button
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close(); //close application
        }

        //call the set up function in controller 
        private void SetupButton_Click(object sender, EventArgs e)
        {
            _controller.SetUpSelected();
            SetupButton.Enabled = false;
            PlayButton.Enabled = true;
            PauseButton.Enabled = true;
            TeardownButton.Enabled = true;
        }

        //call the play button function in controller
        private void PlayButton_Click(object sender, EventArgs e)
        {
            _controller.PlaySelected();
            PlayButton.Enabled = false;
        }

        //call pause button function in controller
        private void PauseButton_Click(object sender, EventArgs e)
        {
            _controller.PauseSelected();
            PlayButton.Enabled = true;
        }

        //call teardown and reset the buttons to disabled or enabled
        private void TeardownButton_Click(object sender, EventArgs e)
        {
            _controller.TearDownSelected();
            SetupButton.Enabled = true;
            PlayButton.Enabled = false;
            PauseButton.Enabled = false;
            TeardownButton.Enabled = false;
        }

        //print rtp header check box
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            displayHeader = displayHeader ? false : true; //if displayHeader is already true set it to false if not set it to true
        }
    }
}
