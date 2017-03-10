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
        int sequenceNo = 0;
        int sessionID;
        int port;
        string IPAddr;
        string videoName;

        public void Connect_ButtonClick(object sender, EventArgs e)
        {
            _view = (Form1)((Button)sender).FindForm();
            Console.WriteLine("You are connected!");
            _view.SetClientText("You are connected!");

            IPAddr = _view.GetIPAddr();
            port = _view.GetPort();
            videoName = _view.GetVideoName();
            _rtsp = new RTSPModel(_view.GetPort(), _view.GetIPAddr());
        }

        public void SetUpSelected()
        {
            sequenceNo++;
            string request = "SETUP rtsp://" + IPAddr + ":" + port + "/" + videoName + " RTSP/1.0\nCSeq: " + sequenceNo + "\nTransport: RTP/UDP; client_port= 25000";
            _rtsp.SendRequest(request);
            string response = _rtsp.GetResponse();
            _view.SetServerText(response);

            if(response != "")
            {
                char[] separators = { ' ', ',', ';', ':', '/', '\n', '\r' };
                string[] words = response.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                sessionID = Int32.Parse(words[7]);
                Console.WriteLine(sessionID);

                //prob have to setup some sh** here for RTP

            }
        }

        public void PlaySelected()
        {
            sequenceNo++;
            string request = "PLAY rtsp://" + IPAddr + ":" + port + "/" + videoName + " RTSP/1.0\nCSeq: " + sequenceNo + "\nSession: " + sessionID;
            _rtsp.SendRequest(request);
            string response = _rtsp.GetResponse();
            _view.SetServerText(response);
        }
    }
}
