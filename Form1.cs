using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Working_With_NTP_Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public  DateTime GetNetWorkTime()
        {
            string ntpServer = tBx_timeserver.Text;

            var ntpData = new byte[48];

            ntpData[0] = 27;

            var addresses = Dns.GetHostEntry(ntpServer).AddressList;

            var ipEndPoint = new IPEndPoint(addresses[0], 123);

            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            {
                socket.Connect(ipEndPoint);

                socket.ReceiveTimeout = 3000;
                socket.Send(ntpData);
                socket.Receive(ntpData);
                socket.Close(); 
            }

            byte serverReplayTime = 40;

            ulong intPart = BitConverter.ToUInt32(ntpData, serverReplayTime);

            ulong fractPart = BitConverter.ToUInt32(ntpData, serverReplayTime + 4);

            intPart = SWapEndianness(intPart);
            fractPart = SWapEndianness(fractPart);

            var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);

            var networkDateTime = (new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds((long)milliseconds);
            return networkDateTime.ToLocalTime();
        }


        static uint SWapEndianness(ulong x)
        {
            return (uint)(((x & 0x000000ff) << 24) +((x & 0x0000ff00) << 8)+((x & 0x00ff0000)>> 8 )+((x & 0xff000000) >> 24));
        }

        private void btn_Run_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText($"{GetNetWorkTime()}");
            richTextBox1.AppendText(Environment.NewLine);
            richTextBox1.ScrollToCaret();

            Run();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetSystemTime(ref SYSTEMTIME st);

        public void Run(int UpdateFreq = 1000)
        {
            TimeSpan TickDiff;
            var LocalTime = DateTime.Now.ToUniversalTime();
            Stopwatch sw = new Stopwatch();

            sw.Start();
            var RemoteTime = GetNetWorkTime();
            TickDiff = new TimeSpan(-(sw.ElapsedTicks) + (RemoteTime.Ticks - LocalTime.Ticks));
            sw.Stop();

            SYSTEMTIME st = new SYSTEMTIME();
            
            RemoteTime = RemoteTime.AddHours(-Convert.ToInt32(tBx_TimeLine.Text));

            st.wYear = (short)RemoteTime.Year;
            //st.wYear = (short)2021;
            st.wMonth = (short)RemoteTime.Month;
            st.wDay = (short)RemoteTime.Day;
            st.wHour = (short)(RemoteTime.Hour - 1);
            st.wMinute = (short)RemoteTime.Minute;
            st.wSecond = (short)RemoteTime.Second;
            st.wMilliseconds = (short)RemoteTime.Millisecond;

            SetSystemTime(ref st);

            richTextBox1.AppendText($"[{RemoteTime.ToLocalTime().ToShortDateString()} {RemoteTime.ToLocalTime().ToString("HH:m:ss:ffff")}] Updated ! Time difference : {TickDiff.TotalMilliseconds} ms");
            richTextBox1.AppendText(Environment.NewLine);
            richTextBox1.ScrollToCaret();

            System.Threading.Thread.Sleep(UpdateFreq);
        }



        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEMTIME
        {
            public short wYear;
            public short wMonth;
            public short wDayOfWeek;
            public short wDay;
            public short wHour;
            public short wMinute;
            public short wSecond;
            public short wMilliseconds;
        }
    }
}
