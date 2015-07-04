using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace MeEncontre.Infrastructure.Page
{
    public static class WebPage
    {

        public static string GetWebPageText(string url, Encoding enco)
        {
            if (url.IndexOf("://") < 0)
                url = url.Insert(0, "http://");
            try
            {

                WebRequest request = WebRequest.Create(url);
                HttpWebRequest http = (HttpWebRequest)request;
                request.Credentials = CredentialCache.DefaultCredentials;
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream, enco);
                string responseFromServer = reader.ReadToEnd();
                reader.Close();
                response.Close();
                return responseFromServer;

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("URL: {0}\r\nErro: {1}", url, e.Message));
                return string.Empty;
            }

        }
    }
}
