using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace InnerSoft.MeEncontre.Domain.Model
{
    public class Colaborador
    {
        [Key()]
        public int Id { get; set; }
        public string Documento { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Foto { get; set; }
        public string Key { get; set; }
        public DateTime? UltimoAcesso { get; set; }
        public virtual ICollection<PermissaoLocalColaborador> PermissaoLocalColaboradores { get; set; }
        public virtual ICollection<Acesso> Acessos { get; set; }        
        public Status Status { get; set; }
        public Cliente Cliente { get; set; }
    }
}

