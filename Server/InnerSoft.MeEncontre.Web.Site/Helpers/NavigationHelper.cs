using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InnerSoft.MeEncontre.Web.Site.Helpers
{
    public static class NavigationHelper
    {

        public static void Visit(string page)
        {
            HttpCookie cookie = new HttpCookie("visit", page);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        public static string Navigate()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["visit"];
            var link = cookie.Value.Replace("Visit=", "");
            return link;
        }
       
    }
}