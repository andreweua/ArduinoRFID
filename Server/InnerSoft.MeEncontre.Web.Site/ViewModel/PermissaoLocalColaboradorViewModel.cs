using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InnerSoft.MeEncontre.Web.Site.ViewModel
{
    public class PermissaoLocalColaboradorViewModel
    {
        public int Id { get; set; }
        public LocalViewModel LocalViewModel { get; set; }
        public ColaboradorViewModel ColaboradorViewModel { get; set; }
    }
}