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
            //create a timer to mimic the one in the server 
            timer = new System.Timers.Timer();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(DisplayFrames);
            timer.Interval = 100;
        }

        /// <summary>
        /// Initialize the set up by creating a tcp connection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Connect_ButtonClick(object sender, EventArgs e)
        {
            _view = (Form1)((Button)sender).FindForm();

            _view.SetClientText("You are connected!");

            IPAddr = _view.GetIPAddr(); //get the ip address from the view
            port = _view.GetPort(); //get the port address from the view 
            videoName = _view.GetVideoName(); //get the video name from the view

            _rtsp = new RTSPModel(_view.GetPort(), _view.GetIPAddr());
        }

        /// <summary>
        /// If setup is selected send a request, receive a response, and print it - getting the sessionID.
        /// When requested has been handled create a UDP socket using RTP.
        /// </summary>
        public void SetUpSelected()
        {
            localEndPoint = _rtsp.GetLocalEndpoint(); //determine the local end point of the current client
            Console.WriteLine("PORT: " + localEndPoint.Port + ", IPAddr: " + localEndPoint.Address);

            sequenceNo++; //increment sequence number with each request

            //send setup request
            string request = "SETUP rtsp://" + IPAddr + ":" + port + "/" + videoName + " RTSP/1.0\nCSeq: " + sequenceNo + "\nTransport: RTP/UDP; client_port= " + localEndPoint.Port.ToString();
            _rtsp.SendRequest(request);

            string response = _rtsp.GetResponse(); //get the response from the server

            //if the response is not null print it and determine the sessionID
            if(response != "")
            {
                _view.SetServerText(response);
                _view.SetClientText("New RTSP State: READY");
                char[] separators = { ' ', ',', ';', ':', '/', '\n', '\r' };
                string[] words = response.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                sessionID = Int32.Parse(words[7]);

                _rtp = new RTPModel(); //create a new RTP model class to create the UDP connection
                _rtp.CreateConnection(localEndPoint.Port, IPAddr); 
            }
        }

        /// <summary>
        /// When play is selected when send a request to the server to start the video and display the response.
        /// Start the timer to continuously read the packets that are being received.
        /// </summary>
        public void PlaySelected()
        {
            //increment the sequence number again with the request
            sequenceNo++;

            //request string 
            string request = "PLAY rtsp://" + IPAddr + ":" + port + "/" + videoName + " RTSP/1.0\nCSeq: " + sequenceNo + "\nSession: " + sessionID;
            _rtsp.SendRequest(request);

            string response = _rtsp.GetResponse(); //get response from server

            //if the response is not empty write the response to the client and start the timer
            if(response != "")
            {
                _view.SetServerText(response);
                _view.SetClientText("New RTSP State: PLAYING");
                timer.Start();
            }
        }

        /// <summary>
        /// When pause is selected we want to stop receiving data from the server. The server should know to stop sending it but to keep with consistency
        /// stopping the timer allows it to be synced up with the server.
        /// </summary>
        public void PauseSelected()
        {
            sequenceNo++;

            //send the request string
            string request = "PAUSE rtsp://" + IPAddr + ":" + port + "/" + videoName + " RTSP/1.0\nCSeq: " + sequenceNo + "\nSession: " + sessionID;
            _rtsp.SendRequest(request);
            string response = _rtsp.GetResponse();

            //if response is not empty stop timer and set response
            if(response != "")
            {
                _view.SetClientText("New RTSP State: PAUSED");
                _view.SetServerText(response);
                timer.Stop();
            }
        }

        /// <summary>
        /// When teardown is selected we send the request, the server will close the connection on it's side and we will close the connection on our side
        /// also stopping the timer as no more packets can be received.
        /// </summary>
        public void TearDownSelected()
        {
            sequenceNo++;
            string request = "TEARDOWN rtsp://" + IPAddr + ":" + port + "/" + videoName + " RTSP/1.0\nCSeq: " + sequenceNo + "\nSession: " + sessionID;
            _rtsp.SendRequest(request);
            string response = _rtsp.GetResponse();

            if (response != "")
            {
                _view.SetClientText("New RTSP State: WAITING");
                _view.SetServerText(response);
                timer.Stop();
                sequenceNo = 0; //reset rtsp sequence number 
                _rtp.TerminateConnection();
            }
        }

        /// <summary>
        /// Every timer interval, receive packets from the server and display each frame to the picture box.
        /// If display header packet is selected, it will display current header packet. 
        /// If display packet info is selected, it will display current packet info.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void DisplayFrames(Object source, System.Timers.ElapsedEventArgs e)
        {
            _rtp.ReceivePackets(); //receive the packets through UDP connection

            DisplayHeaderInformation(); //display the header information
            DisplayPacketReport(); //display the packet report

            byte[] data = _rtp.GetData(); //get the frame

            //if the data is not empty, display it to the picture box 
            if(data != null)
            {
                using (var memoryStream = new System.IO.MemoryStream(data))
                {
                    _view.DisplayImage(System.Drawing.Image.FromStream(memoryStream));
                }
            }
           
        }

        /// <summary>
        /// Get all the parsed information from the header and display the information to the client
        /// </summary>
        private void DisplayPacketReport()
        { 
            int payload = _rtp.GetPayload(); //get the payload value
            int timestamp = _rtp.GetTimeStamp(); //get the timestamp value
            int seqNo = _rtp.GetSeqNo(); //get the sequence number

            //display info if the checkbox is selected
            if (_view.GetShowPacketInfo())
            {
                string info = "Got RTP packet with SeqNo #" + seqNo + ", TimeStamp " + timestamp + " ms, of type " + payload;
                _view.ShowDataInfo(info);
            }
        }

        /// <summary>
        /// Display the header in bits.
        /// </summary>
        private void DisplayHeaderInformation()
        {
            byte[] headerData = _rtp.GetHeader(); //get the header

            if(headerData != null)
            {
                string bits = "";
                for (int i = 0; i < headerData.Length; i++)
                {
                    bits += Convert.ToString(headerData[i], 2); //convert header to bits 
                }

                if (_view.GetDisplayHeader())
                {
                    _view.SendRTPHeaders(bits); //call the thread safe function
                }
            }
        }

    }
}
