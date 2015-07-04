using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using InnerSoft.MeEncontre.Domain.Model;

namespace InnerSoft.MeEncontre.Web.Site.ViewModel
{
    public class AcessoViewModel
    {
        public AcessoViewModel()
        {


        }
        public AcessoViewModel(Acesso acesso)
        {
            Id = acesso.Id;
            LocalKey = acesso.LocalKey;
            ColaboradorKey = acesso.ColaboradorKey;
            LocalViewModel = new LocalViewModel(acesso.Local);
            ColaboradorViewModel = new ColaboradorViewModel(acesso.Colaborador);
            Movimento = acesso.Movimento;
            Data = acesso.Data;

        }

        public int Id { get; set; }
		
		[DisplayName("Chave Local")]
        public string LocalKey { get; set; }
		
		[DisplayName("RFID Tag")]
        public string ColaboradorKey { get; set; }
		
		[DisplayName("Local")]
        public LocalViewModel LocalViewModel { get; set; }
		
		[DisplayName("Colaborador")]
        public ColaboradorViewModel ColaboradorViewModel { get; set; }
		
		[DisplayName("Movimento")]
        public String Movimento { get; set; }

        [DisplayName("Data")]
        public DateTime Data { get; set; }
		
		[DisplayName("Movimento")]
		public String MovimentoFormatado 
		{ 
			get
			{
				if (Movimento=="E")
				{
					return "Entrada";
				}
				else if (Movimento=="S")
				{
					return "Saída";
				}
				else
				{
					return Movimento;
				}
			
			}
		}
		
		
    }
}