using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace InnerSoft.MeEncontre.Web.Site.Helpers
{
    public static class SiteHelper
    {
        public static string ClienteDemo()
        {
            return ConfigurationManager.AppSettings["ClienteDemo"].ToString();
        }

    }
}