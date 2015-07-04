using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace InnerSoft.MeEncontre.Domain.Model
{
    public class PermissaoLocalColaborador
    {
        [Key()]
        public int Id { get; set; }
        public Local Local { get; set; }
        public Colaborador Colaborador { get; set; }
    }
}
