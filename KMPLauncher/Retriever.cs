using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;

namespace KMPLauncher
{
    class Retriever : WebClient
    {
        protected override WebRequest GetWebRequest(Uri uri)
        {
            WebRequest w = base.GetWebRequest(uri);
            w.Timeout = 5 * 60 * 1000;//Reduced timeout so it goes for 5 seconds
            return w;
        }
    }
}
