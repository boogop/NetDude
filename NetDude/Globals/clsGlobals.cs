using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;

namespace netDude.Globals
{
    public static class clsGlobals
    {
        public static SortedDictionary<string,int> topTalkers;

        public static string hostIP = "";

        public struct t
        {
            public int x, y;
            public string ip;
            public string dstIP;
            public int packetCount;
            public bool topTalker;
            public string protocol;
        }


        public static string getIP()
        {
            string strHostName = "";
            strHostName = Dns.GetHostName();
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;
            return addr[addr.Length - 1].ToString();
        }



    }
}
