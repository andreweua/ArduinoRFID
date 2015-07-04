using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InnerSoft.MeEncontre.Web.Site.ViewModel
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<LocalViewModel> LocaisViewModel { get; set; }
        public virtual ICollection<ColaboradorViewModel> ColaboradoresViewModel { get; set; }
        public virtual ICollection<AcessoViewModel> AcessosViewModel { get; set; }
        public StatusViewModel StatusViewModel { get; set; }
    }
}