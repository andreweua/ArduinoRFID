using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using InnerSoft.MeEncontre.WCF.Messages;

namespace InnerSoft.MeEncontre.WCF.Contracts
{
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IRegistrarAcessoService
    {
        [OperationContract]
        RegistraAcessoLocalResponse Local(RegistraAcessoLocalRequest request);

        [OperationContract]
        RegistraAcessoCoordenadaResponse Coordenada(RegistraAcessoCoordenadaRequest request);

    }
}
