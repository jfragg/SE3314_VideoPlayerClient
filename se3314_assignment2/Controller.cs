using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;


namespace se3314_assignment2
{
    class Controller
    {
        private static Form1 _view;
        RTSPModel _rtsp;
        RTPModel _rtp;
        System.Timers.Timer timer;

        int sequenceNo = 0;
        int sessionID;
        int port;

        string IPAddr;
        string videoName;

        IPEndPoint localEndPoint;

        public Controller()
        {
            timer = new System.Timers.Timer();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(DisplayFrames);
            timer.Interval = 150;
        }

        public void Connect_ButtonClick(object sender, EventArgs e)
        {
            _view = (Form1)((Button)sender).FindForm();

            _view.SetClientText("You are connected!");

            IPAddr = _view.GetIPAddr();
            port = _view.GetPort();
            videoName = _view.GetVideoName();

            _rtsp = new RTSPModel(_view.GetPort(), _view.GetIPAddr());
        }

        public void SetUpSelected()
        {
            localEndPoint = _rtsp.GetLocalEndpoint();
            Console.WriteLine("PORT: " + localEndPoint.Port + ", IPAddr: " + localEndPoint.Address);

            sequenceNo++;

            string request = "SETUP rtsp://" + IPAddr + ":" + port + "/" + videoName + " RTSP/1.0\nCSeq: " + sequenceNo + "\nTransport: RTP/UDP; client_port= " + localEndPoint.Port.ToString();
            _rtsp.SendRequest(request);

            string response = _rtsp.GetResponse();

            if(response != "")
            {
                _view.SetServerText(response);
                _view.SetClientText("New RTSP State: READY");
                char[] separators = { ' ', ',', ';', ':', '/', '\n', '\r' };
                string[] words = response.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                sessionID = Int32.Parse(words[7]);

                _rtp = new RTPModel();
                _rtp.CreateConnection(localEndPoint.Port, IPAddr);

            }
        }

        public void PlaySelected()
        {
            sequenceNo++;

            string request = "PLAY rtsp://" + IPAddr + ":" + port + "/" + videoName + " RTSP/1.0\nCSeq: " + sequenceNo + "\nSession: " + sessionID;
            _rtsp.SendRequest(request);

            string response = _rtsp.GetResponse();

            if(response != "")
            {
                _view.SetServerText(response);
                _view.SetClientText("New RTSP State: PLAYING");
                timer.Start();
            }
        }

        public void PauseSelected()
        {
            sequenceNo++;
            string request = "PAUSE rtsp://" + IPAddr + ":" + port + "/" + videoName + " RTSP/1.0\nCSeq: " + sequenceNo + "\nSession: " + sessionID;
            _rtsp.SendRequest(request);
            string response = _rtsp.GetResponse();

            if(response != "")
            {
                _view.SetClientText("New RTSP State: PAUSED");
                _view.SetServerText(response);
                timer.Stop();
            }
        }

        public void TearDownSelected()
        {
            sequenceNo++;
            string request = "TEARDOWN rtsp://" + IPAddr + ":" + port + "/" + videoName + " RTSP/1.0\nCSeq: " + sequenceNo + "\nSession: " + sessionID;
            _rtsp.SendRequest(request);
            string response = _rtsp.GetResponse();
            _view.SetServerText(response);
        }

        public void DisplayFrames(Object source, System.Timers.ElapsedEventArgs e)
        {
            _rtp.ReceivePackets();

            DisplayHeaderInformation();

            byte[] data = _rtp.GetData();

            if(data != null)
            {
                Console.WriteLine("WE GOT DATA!");
                using (var memoryStream = new System.IO.MemoryStream(data))
                {
                    _view.DisplayImage(System.Drawing.Image.FromStream(memoryStream));
                }
            }
           
        }

        private void DisplayHeaderInformation()
        {
            byte[] headerData = _rtp.GetHeader();

            if(headerData != null)
            {
                string bits = "";
                for (int i = 0; i < headerData.Length; i++)
                {
                    bits += Convert.ToString(headerData[i], 2);
                }

                if (_view.GetDisplayHeader())
                {
                    _view.SendRTPHeaders(bits);
                }
            }
        }

    }
}
