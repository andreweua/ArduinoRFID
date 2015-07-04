using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using InnerSoft.MeEncontre.Domain.Model;

namespace InnerSoft.MeEncontre.Web.Site.ViewModel
{
    public class ColaboradorLocalizacaoViewModel
    {

        public int Id { get; set; }
        public string Documento { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Foto { get; set; }
        public DateTime Data { get; set; }

        public string Local { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Movimento { get; set; }


    }
}