using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using InnerSoft.MeEncontre.Domain.Model;

namespace InnerSoft.MeEncontre.Web.Site.ViewModel
{
    public class ColaboradorViewModel
    {
        public ColaboradorViewModel()
        {

        }
        public ColaboradorViewModel(Colaborador colaborador)
        {
            Id = colaborador.Id;
            Documento = colaborador.Documento;
            Nome = colaborador.Nome;
            Email = colaborador.Email;
            Foto = colaborador.Foto;
            Key = colaborador.Key;
            UltimoAcesso = colaborador.UltimoAcesso;

        }
    

        public int Id { get; set; }

        [DisplayName("Documento")]
        public string Documento { get; set; }

        [DisplayName("Colaborador")]
        [Required(ErrorMessage = "Nome do Colaborador é obrigatório")]
        public string Nome { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Foto")]
        public string Foto { get; set; }

        [DisplayName("RFID Tag")]
        [Required(ErrorMessage = "RFID Tag é obrigatório")]
        public string Key { get; set; }

        [DisplayName("Último Acesso")]
        public DateTime? UltimoAcesso { get; set; }

        public virtual ICollection<PermissaoLocalColaboradorViewModel> PermissaoLocalColaboradoresViewModel { get; set; }
        public virtual ICollection<AcessoViewModel> AcessosViewModel { get; set; }
        public StatusViewModel StatusViewModel { get; set; }
        public ClienteViewModel ClienteViewModel { get; set; }
    }
}