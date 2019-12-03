using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SharpPcap;
using PacketDotNet;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using netDude.Globals;

namespace netDude
{
    public partial class Form1 : Form
    {
        #region packet vars

        private bool BackgroundThreadStop;
        private object QueueLock = new object();
        private List<RawCapture> PacketQueue = new List<RawCapture>();
        private DateTime LastStatisticsOutput;
        private TimeSpan LastStatisticsInterval = new TimeSpan(0, 0, 2);
        private System.Threading.Thread backgroundThread;
        private ICaptureDevice device;
        private int packetCount;
        private ICaptureStatistics captureStatistics;
        private bool statisticsUiNeedsUpdate = false;

        private PacketArrivalEventHandler arrivalEventHandler;
        private CaptureStoppedEventHandler captureStoppedEventHandler;

        public clsGlobals.t[] tcpData;

        List<string> seenIPs;
        List<string> pro1;

        int filledSlotCount = 0;      
        bool ip, igmp, icmp, udp, ipv6, ipv4, tcp, raw;
        private Packet packet, tcpPacket;

        #endregion

        #region graphics vars

        private Bitmap bmp;
        private Graphics gForm;
        private Graphics gBmp;
        private int fHeight, fWidth;
        private int midWidth, midHeight;
        private Random rand;
        private FastBitmap fb;
        const double PI = 3.14159;

        Pen bigPen, hostPen, ipPen, igPen, icPen, iUDPPen, ip6Pen, ip4Pen, tcpPen, circlePen;
        Font font;

        #endregion

        public Form1()
        {
            InitializeComponent();

            Globals.clsGlobals.topTalkers = new SortedDictionary<string, int>();
            Globals.clsGlobals.hostIP = Globals.clsGlobals.getIP();
            txtHostIP.Text = Globals.clsGlobals.hostIP;
            seenIPs = new List<string>();
            rand = new Random();
            numFontSize.Value = 12;
        }

        #region form events

        private void Form1_Load(object sender, EventArgs e)
        {
            ip = chkIP.Checked;
            igmp = chkIGMP.Checked;
            icmp = chkICMP.Checked;
            udp = chkUDP.Checked;
            ipv6 = chkIP.Checked;
            ipv4 = chkIP4.Checked;
            tcp = chkTCP.Checked;
            raw = chkHost.Checked;

            lblStatus.Text = "Status: Not running";
            initPens();

            pro1 = new List<string>();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
            Shutdown();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            foreach (var dev in CaptureDeviceList.Instance)
            {
                string str = String.Format("{0} {1}", dev.Description, dev.Name);
                cmbDevice.Items.Add(str);
            }

            // based on the number of points on the circle, any more 
            // and the IPs won't be visible
            tcpData = new clsGlobals.t[127];
            initGraphics();
            initCircle();

            int index = 0;
            string val = cmbDevice.Items[index].ToString();
            cmbDevice.Text = val;
        }
       
        #endregion


        #region graphics

        private void initGraphics()
        {
            Bitmap newbmp = new Bitmap(pBox1.Width, pBox1.Height, PixelFormat.Format8bppIndexed);
            bmp = new Bitmap(newbmp.Width, newbmp.Height);
            gForm = pBox1.CreateGraphics();
            gBmp = Graphics.FromImage(bmp);

            fHeight = bmp.Height;
            fWidth = bmp.Width;
            midWidth = fHeight >> 1;
            midHeight = fHeight >> 1;
        }

        private void initPens()
        {
            AdjustableArrowCap bigArrow = new AdjustableArrowCap(3, 3);

            ipPen = new Pen(lnkIPColor.LinkColor, 1);
            igPen = new Pen(lnkIGMPColor.LinkColor, 1);
            icPen = new Pen(lnkICMPColor.LinkColor, 1);
            ip6Pen = new Pen(lnkIP6Color.LinkColor, 1);
            ip4Pen = new Pen(lnkIP4Color.LinkColor, 1);
            tcpPen = new Pen(lnkTCPColor.LinkColor, 1);
            iUDPPen = new Pen(lnkUDPColor.LinkColor, 1);
            hostPen = new Pen(lnkHostColor.LinkColor, 1);

            ipPen.CustomEndCap = bigArrow;
            igPen.CustomEndCap = bigArrow;
            icPen.CustomEndCap = bigArrow;
            ip6Pen.CustomEndCap = bigArrow;
            ip4Pen.CustomEndCap = bigArrow;
            tcpPen.CustomEndCap = bigArrow;
            iUDPPen.CustomEndCap = bigArrow;
            hostPen.CustomEndCap = bigArrow;

            bigPen = new Pen(Color.Red, 3);
            bigPen.CustomEndCap = bigArrow;
            circlePen = new Pen(Color.Red, 1);
            font = new Font("Tahoma", 11);
        }

        private void initCircle()
        {
            double radius = midWidth * 0.8;
            // draw a circle, save the points to the tcpData struct. We'll use the points 
            // to draw the IP addresses
            int count = 0; // 126
            for (double radians = .01; radians < 6.28; radians += .05)
            {
                int x = midWidth + (int)(radius * Math.Sin(radians));
                int y = midHeight + (int)(radius * Math.Cos(radians));
                tcpData[count].x = x;
                tcpData[count].y = y;
                tcpData[count].ip = "";
                tcpData[count].dstIP = "";
                tcpData[count].packetCount = 0;
                count++;
            }
        }

        private void drawCircle()
        {
            fb = new FastBitmap(bmp);
            for (int i = 0; i < 126; i++)
                fb.SetPixel(tcpData[i].x, tcpData[i].y, Color.Cyan);

            fb.Release();
        }

        private void drawGraph()
        {
            gBmp.FillRectangle(Brushes.Black, 0, 0, fWidth, fHeight);

            drawCircle();

            font = new Font("Tahoma", (int)numFontSize.Value);

            for (int from = 0; from < 126; from++)
            {
                if (!chkNull.isNull(tcpData[from].ip))
                {
                    // draw the IP at the xy point of the circle we assigned it
                    if (tcpData[from].ip == Globals.clsGlobals.hostIP)
                        gBmp.DrawString(tcpData[from].ip, font, Brushes.Lime, tcpData[from].x, tcpData[from].y);
                    else
                        gBmp.DrawString(tcpData[from].ip, font, Brushes.White, tcpData[from].x, tcpData[from].y);

                    bool OKToProcess = false;
                    Pen p = getPen(tcpData[from].protocol, ref OKToProcess);

                    if (OKToProcess && !chkNull.isNull(tcpData[from].dstIP))
                    {
                        for (int to = 0; to < 126; to++)
                        {
                            // draw a line from src to dst
                            if (tcpData[to].ip == tcpData[from].dstIP)
                            {
                                clsGlobals.t td = tcpData[from];
                                clsGlobals.t tdi = tcpData[to];

                                if (tcpData[from].topTalker)
                                {
                                    gBmp.DrawLine(bigPen, td.x, td.y, tdi.x, tdi.y);
                                    // center the top talker circle 
                                    gBmp.DrawEllipse(circlePen, td.x - 15, td.y - 15, 30, 30);
                                }
                                else
                                {
                                    if (tcpData[from].protocol == "IPV4" && raw)
                                        gBmp.DrawLine(hostPen, td.x, td.y, tdi.x, tdi.y);
                                    else
                                        gBmp.DrawLine(p, td.x, td.y, tdi.x, tdi.y);
                                }
                                break;
                            }

                        }
                    }
                }
            }

            try
            {
                gForm.DrawImage(bmp, 0, 0, fWidth, fHeight);
            }
            catch
            {
                //Application.Exit();
            }
        }

        private Pen getPen(string protocol, ref bool OKToProcess)
        {
            // If the protocol is x and we've checked the x checkbox, display it
            Pen p;
            switch (protocol)
            {
                case "IP":
                    if (ip) OKToProcess = true;
                    p = ipPen;
                    break;
                case "IGMP":
                    if (igmp) OKToProcess = true;
                    p = igPen;
                    break;
                case "ICMPV6":
                    if (icmp) OKToProcess = true;
                    p = icPen;
                    break;
                case "UDP":
                    if (udp) OKToProcess = true;
                    p = iUDPPen;
                    break;
                case "IPV6":
                    if (ipv6) OKToProcess = true;
                    p = ip6Pen;
                    break;
                case "IPV4":
                    if (ipv4 || raw) OKToProcess = true;
                    p = ip4Pen;
                    break;
                case "TCP":
                    if (tcp) OKToProcess = true;
                    p = tcpPen;
                    break;
                default:
                    OKToProcess = true;
                    p = hostPen;
                    break;
            }

            return p;
        }

        #endregion


        #region events
 
        private void pBox1_Resize(object sender, EventArgs e)
        {
            tcpData = new clsGlobals.t[127];
            initGraphics();
            initCircle();
            drawCircle();
        }

        private void btnCapStart_ItemClick(object sender, EventArgs e)
        {
            object v = cmbDevice.Text;
            int index = cmbDevice.Items.IndexOf(v);
            lblStatus.Text = "Status: capture running";
            lblStatusPic.Image = netDude.Properties.Resources.greenon1;
            btnCapStart.Image = netDude.Properties.Resources.greenon1;
            StartCapture(index, "");
        }

        private void btnCapStop_ItemClick(object sender, EventArgs e)
        {
            Shutdown();
            lblStatus.Text = "Status: capture stopped";
            lblStatusPic.Image = netDude.Properties.Resources.greenoff1;
            btnCapStart.Image = netDude.Properties.Resources.greenoff1;
        }

        private void cmbDevice_ItemClick(object sender, EventArgs e)
        {
        }        

        private void timer1_Tick(object sender, EventArgs e)
        {
            drawGraph();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shutdown();
            Application.Exit();
        }

        #endregion


        #region checkboxen
      
        private void chkTCP_CheckedChanged(object sender, EventArgs e)
        {
            tcp = chkTCP.Checked;           
        }
       
        private void chkHost_CheckedChanged(object sender, EventArgs e)
        {
            raw = chkHost.Checked;
        }
                 
        private void chkICMP_CheckedChanged(object sender, EventArgs e)
        {
            icmp = chkICMP.Checked;
            if (!icmp)
                clearIP("ICMPV6");
        }

        private void chkIP6_CheckedChanged(object sender, EventArgs e)
        {
            ipv6 = chkIP6.Checked;
            if (!ipv6)
                clearIP("IPV6");
        }

      
        private void chkIP4_CheckedChanged(object sender, EventArgs e)
        {
            ipv4 = chkIP4.Checked;
            if (!ipv4)
                clearIP("IPV4");
        }

        private void chkUDP_CheckedChanged(object sender, EventArgs e)
        {
            udp = chkUDP.Checked;
            if (!udp)
                clearIP("UDP");
        }

        private void chkIGMP_CheckedChanged(object sender, EventArgs e)
        {
            igmp = chkIGMP.Checked;
            if (!igmp)
                clearIP("IGMP");
        }

        private void chkIP_CheckedChanged(object sender, EventArgs e)
        {
            ip = chkIP.Checked;
            if (!ip)
                clearIP("IP");
        }

        #endregion


        #region methods

        private void clearIP(string protocol)
        {
            for (int i = 0; i < 126; i++)
            {
                if (tcpData[i].protocol == protocol)
                {
                    seenIPs.Remove(tcpData[i].ip);

                    tcpData[i].ip = "";
                    tcpData[i].dstIP = "";
                    tcpData[i].topTalker = false;

                    filledSlotCount--;
                }
            }
        }

        private void StartCapture(int itemIndex, string filter)
        {
            packetCount = 0;

            device = CaptureDeviceList.Instance[itemIndex];

            LastStatisticsOutput = DateTime.Now;

            // start the background thread
            BackgroundThreadStop = false;
            backgroundThread = new System.Threading.Thread(BackgroundThread);
            backgroundThread.Start();

            // setup background capture
            arrivalEventHandler = new PacketArrivalEventHandler(device_OnPacketArrival);
            device.OnPacketArrival += arrivalEventHandler;
            captureStoppedEventHandler = new CaptureStoppedEventHandler(device_OnCaptureStopped);
            device.OnCaptureStopped += captureStoppedEventHandler;

            int readTimeoutMilliseconds = 1000;
            device.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);

            string filter1 = "not arp";
            if (!chkNull.isNull(filter))
                filter1 += " and " + filter;

            // "ip and tcp " + filter;// and not src host " + txtHostIP.Text + " and not dst host " + txtHostIP.Text;
            device.Filter = filter1;

            // force an initial statistics update
            captureStatistics = device.Statistics;
            UpdateCaptureStatistics();

            // start the background capture
            device.StartCapture();

        }

        private void device_OnCaptureStopped(object sender, CaptureStoppedEventStatus status)
        {
            if (status != CaptureStoppedEventStatus.CompletedWithoutError)
            {
                MessageBox.Show("Error stopping capture", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        private void lnkClearData_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < 126; i++)
            {
                tcpData[i].ip = "";
                tcpData[i].dstIP = "";
                tcpData[i].topTalker = false;
                tcpData[i].protocol = "";
            }

            seenIPs.Clear();
            filledSlotCount = 0;
        }

        void device_OnPacketArrival(object sender, CaptureEventArgs e)
        {
            var Now = DateTime.Now;
            var interval = Now - LastStatisticsOutput;
            if (interval > LastStatisticsInterval)
            {
                captureStatistics = e.Device.Statistics;
                statisticsUiNeedsUpdate = true;
                LastStatisticsOutput = Now;
            }

            // lock QueueLock to prevent multiple threads accessing PacketQueue at
            // the same time
            lock (QueueLock)
            {
                PacketQueue.Add(e.Packet);
            }
        }

        private void BackgroundThread()
        {
            while (!BackgroundThreadStop)
            {
                bool shouldSleep = true;

                lock (QueueLock)
                {
                    if (PacketQueue.Count != 0)
                    {
                        shouldSleep = false;
                    }
                }

                if (shouldSleep)
                {
                    System.Threading.Thread.Sleep(250);
                }
                else // should process the queue
                {
                    List<RawCapture> ourQueue;
                    lock (QueueLock)
                    {
                        // swap queues, giving the capture callback a new one
                        ourQueue = PacketQueue;
                        PacketQueue = new List<RawCapture>();
                    }
                   
                    foreach (var p in ourQueue)
                    {  
                        if (chkNull.isNull(Globals.clsGlobals.topTalkers))
                            Globals.clsGlobals.topTalkers = new SortedDictionary<string, int>();

                        packet = PacketDotNet.Packet.ParsePacket(p.LinkLayerType, p.Data);
                        tcpPacket = (PacketDotNet.TcpPacket)packet.Extract(typeof(PacketDotNet.TcpPacket));

                        //string foo = "";
                        if (!chkNull.isNull(tcpPacket))
                        {
                            var ipPacket = (PacketDotNet.IpPacket)tcpPacket.ParentPacket;
                            System.Net.IPAddress srcIp = ipPacket.SourceAddress;

                            if (srcIp.ToString() != Globals.clsGlobals.hostIP)
                            {
                                if (!Globals.clsGlobals.topTalkers.ContainsKey(srcIp.ToString()))
                                {
                                    Globals.clsGlobals.topTalkers.Add(srcIp.ToString(), 1);
                                }
                                else
                                {
                                    int x = 0;
                                    Globals.clsGlobals.topTalkers.TryGetValue(srcIp.ToString(), out x);
                                    Globals.clsGlobals.topTalkers[srcIp.ToString()] = ++x;
                                }
                            }

                           // foo = srcIp.ToString();

                        }
                      
                        string protocol = "";
                        if (packet is PacketDotNet.EthernetPacket)
                        {
                            var eth = ((PacketDotNet.EthernetPacket)packet);
                            protocol = eth.Type.ToString();
                        }
                      
                        if (protocol == "LLDP") continue;

                        var IPPacket = (PacketDotNet.IpPacket)packet.PayloadPacket;
                       
                        string protocol1 = "";
                        if (!chkNull.isNull(IPPacket))
                            protocol1 = chkNull.whenNull(IPPacket.Protocol);

                        bool OKToProcessPayload = false;
                        bool OKToProcessHost = false;

                        if (ip && protocol1 == "IP") OKToProcessPayload = true;
                        if (igmp && protocol1 == "IGMP") OKToProcessPayload = true;
                        if (icmp && protocol1 == "ICMPV6") OKToProcessPayload = true;
                        if (udp && protocol1 == "UDP") OKToProcessPayload = true;
                        if (ipv6 && protocol1 == "IPV6") OKToProcessPayload = true;
                        if (ipv4 && protocol == "IPV4") OKToProcessPayload = true;
                        if (tcp && protocol1 == "TCP") OKToProcessPayload = true;
                       
                        if (raw)
                        {                           
                            OKToProcessHost = true;
                            protocol = "IPV4";
                        }

                        bool ok = OKToProcessHost || OKToProcessPayload;

                        if (ok && filledSlotCount < 126)
                        {                            
                            if (!chkNull.isNull(IPPacket) && OKToProcessPayload)
                            {
                                System.Net.IPAddress anysrcIp = IPPacket.SourceAddress;
                                System.Net.IPAddress anydstIp = IPPacket.DestinationAddress;
                                // ensure graph has only one instance of an IP
                                if (!seenIPs.Contains(anysrcIp.ToString())) 
                                {
                                    int pos = rand.Next(126);
                                    // find an unused spot
                                    while (!chkNull.isNull(tcpData[pos].ip)) 
                                    {
                                        pos = rand.Next(126);
                                    }
                                    filledSlotCount++;
                                    tcpData[pos].ip = anysrcIp.ToString();
                                    tcpData[pos].dstIP = chkNull.whenNull(anydstIp).ToString();
                                    tcpData[pos].protocol = protocol1;
                                    seenIPs.Add(anysrcIp.ToString());
                                }
                                // add the destination IP
                                if (!seenIPs.Contains(anydstIp.ToString())) 
                                {
                                    int pos = rand.Next(126);
                                    while (!chkNull.isNull(tcpData[pos].ip))
                                    {
                                        pos = rand.Next(126);
                                    }
                                    filledSlotCount++;
                                    tcpData[pos].ip = anydstIp.ToString();
                                    tcpData[pos].dstIP = chkNull.whenNull(anysrcIp).ToString();
                                    tcpData[pos].protocol = protocol1;
                                    seenIPs.Add(anydstIp.ToString());
                                }
                            }

                            if (!chkNull.isNull(tcpPacket) && filledSlotCount < 126 && OKToProcessHost)
                            {
                                var ipPacket = (PacketDotNet.IpPacket)tcpPacket.ParentPacket;
                                System.Net.IPAddress srcIp = ipPacket.SourceAddress;
                                System.Net.IPAddress dstIp = ipPacket.DestinationAddress;
                                // ensure graph has only one instance of an IP
                                if (!seenIPs.Contains(srcIp.ToString()))
                                {
                                    int pos = rand.Next(126);
                                    // find an unused spot
                                    while (!chkNull.isNull(tcpData[pos].ip))
                                    {
                                        pos = rand.Next(126);
                                    }
                                    filledSlotCount++;
                                    tcpData[pos].ip = srcIp.ToString();
                                    tcpData[pos].dstIP = chkNull.whenNull(dstIp).ToString();
                                    tcpData[pos].protocol = protocol;
                                    seenIPs.Add(srcIp.ToString());
                                }
                                // add the destination IP
                                if (!seenIPs.Contains(dstIp.ToString())) 
                                {
                                    int pos = rand.Next(126);
                                    while (!chkNull.isNull(tcpData[pos].ip))
                                    {
                                        pos = rand.Next(126);
                                    }
                                    filledSlotCount++;
                                    tcpData[pos].ip = dstIp.ToString();
                                    tcpData[pos].dstIP = chkNull.whenNull(srcIp).ToString();
                                    tcpData[pos].protocol = protocol;
                                    seenIPs.Add(dstIp.ToString());
                                }
                            }

                            packetCount++;

                        }

                        if (statisticsUiNeedsUpdate)
                        {
                            UpdateCaptureStatistics();
                            statisticsUiNeedsUpdate = false;
                        }
                    }
                }
            }
        }

        private void UpdateCaptureStatistics()
        {
            appendRcv(String.Format("{0}", captureStatistics.ReceivedPackets));
            appendDrop(String.Format("{0}", captureStatistics.DroppedPackets));
            appendInter(String.Format("{0}", captureStatistics.InterfaceDroppedPackets));

            if (Globals.clsGlobals.topTalkers.Count > 0)
            {                
                var max = Globals.clsGlobals.topTalkers.OrderByDescending(d => d.Value).First();

                clearTopTalkers();
                appendTopTalker(max.Key);

                int count = 0;
                foreach (KeyValuePair<string, int> item in Globals.clsGlobals.topTalkers.OrderByDescending(p => p.Value))
                {
                    for (int j = 0; j < 126; j++)
                    {
                        if (tcpData[j].ip == item.Key)
                        {
                            tcpData[j].topTalker = true;
                            break;
                        }
                    }
                    count++;
                    // only use bigPen for the top 1, we can do more top talkers
                    // but it starts to look messy
                    if (count == 1) break; 
                }

                clearTopList();
                foreach (KeyValuePair<string, int> item in Globals.clsGlobals.topTalkers.OrderByDescending(p => p.Value))
                {
                    listTopTalkers(item.Key + " , " + item.Value);
                }
            }

        }

        private void clearTopTalkers()
        {
            for (int j = 0; j < 126; j++)
                tcpData[j].topTalker = false;
        }

        private void appendRcv(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(appendRcv), new object[] { value });
            }
            else
            {
                txtPacketRcv.Text = chkNull.whenNull(value);
            }
        }

        private void appendDrop(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(appendDrop), new object[] { value });
            }
            else
            {
                txtPacketDrop.Text = chkNull.whenNull(value);
            }
        }

        private void appendInter(string value)
        {
            //if (InvokeRequired)
            //{
            //    this.Invoke(new Action<string>(appendInter), new object[] { value });
            //    return;
            //}
            //else
            //{
            //    txtPacketInterfaceDrop.Text = chkNull.whenNull(value);
            //}
        }

        private void clearTopList()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(clearTopList));
                return;
            }
            else
            {
                lstTopTalkers.Items.Clear();
            }
        }

        private void listTopTalkers(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(listTopTalkers), new object[] { value });
                return;
            }
            else
            {
                if (!lstTopTalkers.Items.Contains(value))
                    lstTopTalkers.Items.Add(value);
            }
        }

        private void appendTopTalker(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(appendTopTalker), new object[] { value });
            }
            else
            {
                txtTopTalker.Text = chkNull.whenNull(value);
                for (int j = 0; j < 126; j++)
                {
                    if (tcpData[j].ip == value)
                    {
                        tcpData[j].topTalker = true;
                        break;
                    }
                }

            }
        }

        private void Shutdown()
        {
            if (device != null)
            {
                device.StopCapture();
                device.Close();
                device.OnPacketArrival -= arrivalEventHandler;
                device.OnCaptureStopped -= captureStoppedEventHandler;
                device = null;

                // ask the background thread to shut down
                BackgroundThreadStop = true;

                Application.DoEvents();

                // wait for the background thread to terminate
                //  backgroundThread.Join();

                //  Application.DoEvents();


            }
        }

        #endregion

    }
}
