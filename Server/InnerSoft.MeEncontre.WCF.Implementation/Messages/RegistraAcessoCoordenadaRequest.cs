using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InnerSoft.MeEncontre.WCF.Messages
{
    public class RegistraAcessoCoordenadaRequest : ResponseBase
    {
        public string Latitude;
        public string Longitude;
        public string Observacoes;
        public string ChaveColaborador;
    }
}
