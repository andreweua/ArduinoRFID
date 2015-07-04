using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace InnerSoft.MeEncontre.Domain.Model
{
    public class Cliente
    {
        [Key()]
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Local> Locais { get; set; }
        public virtual ICollection<Colaborador> Colaboradores { get; set; }
        public virtual ICollection<Acesso> Acessos { get; set; }        
        public Status Status { get; set; }
    }
}


