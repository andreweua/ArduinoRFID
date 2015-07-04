using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InnerSoft.MeEncontre.WCF.Messages
{
    public class RegistraAcessoLocalRequest : ResponseBase
    {
        public string ChaveCliente;
        public string ChaveLocal;
        public string ChaveColaborador;
    }
}
