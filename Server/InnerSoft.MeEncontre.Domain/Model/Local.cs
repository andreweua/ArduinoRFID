using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace InnerSoft.MeEncontre.Domain.Model
{
    public class Local
    {
        [Key()]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Key { get; set; }
        public string Endereco { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }        
		public DateTime? UltimoiLive { get; set; }
        public DateTime? UltimoInicializacao { get; set; }        
				
        public Status Status { get; set; }
        public Cliente Cliente { get; set; }

        public virtual ICollection<PermissaoLocalColaborador> PermissaoLocalColaboradores { get; set; }
        public virtual ICollection<Acesso> Acessos { get; set; }        
    }
}
