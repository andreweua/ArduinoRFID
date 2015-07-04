using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace InnerSoft.MeEncontre.Web.Site.Helpers
{
    public static class UserHelper
    {
        public static string CurrentProviderUserKey()
        {
            return Membership.GetUser().ProviderUserKey.ToString();
        }

        public static bool IsAuthenticated()
        {
            return (Membership.GetUser() != null);
        }

        public static string Name()
        {
            return Membership.GetUser().UserName;
        }

        public static string Email()
        {
            return Membership.GetUser().Email;
        }


    }
}