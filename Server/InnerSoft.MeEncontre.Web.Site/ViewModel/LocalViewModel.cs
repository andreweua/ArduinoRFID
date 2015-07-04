using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using InnerSoft.MeEncontre.Domain.Model;

namespace InnerSoft.MeEncontre.Web.Site.ViewModel
{
    public class LocalViewModel
    {
        public LocalViewModel()
        { 
        
        }

        public LocalViewModel(Local local)
        {
            Id = local.Id;
            Nome = local.Nome;
            Key = local.Key;
            Endereco = local.Endereco;
            Latitude = local.Latitude;
            Longitude = local.Longitude;
            UltimoiLive = local.UltimoiLive;
            UltimoInicializacao = local.UltimoInicializacao;
        }


        public int Id { get; set; }

        [DisplayName("Local")]
        [Required(ErrorMessage = "Nome do Local é obrigatório")]
        public string Nome { get; set; }

        [DisplayName("Chave de Integração")]
        [Required(ErrorMessage = "Chave de Integração é obrigatória")]
        public string Key { get; set; }

        [DisplayName("Endereço")]
        [Required(ErrorMessage = "Endereço é obrigatório")]
        public string Endereco { get; set; }

        [DisplayName("Latitude")]
        public string Latitude { get; set; }

        [DisplayName("Longitude")]
        public string Longitude { get; set; }
		
		[DisplayName("Último iLive")]
		public DateTime? UltimoiLive { get; set; }
		
		[DisplayName("Última Inicialização")]
        public DateTime? UltimoInicializacao { get; set; }        

        [DisplayName("Status")]
        public StatusViewModel StatusViewModel { get; set; }

        [DisplayName("Cliente")]
        public ClienteViewModel ClienteViewModel { get; set; }

        [DisplayName("Permissões")]
        public virtual ICollection<PermissaoLocalColaboradorViewModel> PermissaoLocalColaboradoresViewModel { get; set; }

        [DisplayName("Acessos")]
        public virtual ICollection<AcessoViewModel> AcessosViewModel { get; set; }        
    }
}