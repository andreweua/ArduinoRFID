using System.Web;
using System.Web.Mvc;

namespace InnerSoft.MeEncontre.Web.API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}