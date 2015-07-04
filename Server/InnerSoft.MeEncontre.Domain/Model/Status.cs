using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace InnerSoft.MeEncontre.Domain.Model
{
    public class Status
    {
        [Key()]
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
		public bool StatusUsuario { get; set; }
    }
}
