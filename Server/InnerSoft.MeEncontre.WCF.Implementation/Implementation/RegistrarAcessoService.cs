using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InnerSoft.MeEncontre.WCF.Contracts;
using System.ServiceModel;
using InnerSoft.MeEncontre.WCF.Messages;
using InnerSoft.MeEncontre.Application.Contracts;

namespace InnerSoft.MeEncontre.WCF.Implementation
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class RegistrarAcessoService : IRegistrarAcessoService
    {
         IClienteService cliente;
        public RegistraAcessoLocalResponse Local(RegistraAcessoLocalRequest request)
        {
            var response = new RegistraAcessoLocalResponse();
            try
            {

        //        cliente = new ClienteService();
         //       response.Status =  cliente.RegistraAcesso(request.ChaveCliente, request.ChaveLocal, request.ChaveColaborador);

                response.Status = "E";
                response.Sucess = true;
            }
            catch (Exception ex)
            {
                response.Status = "X";
                response.Sucess = false;
                response.Message = "Ocorreu um erro durante o registro de Acesso Local: " + ex.Message;

            }
            return response;
        }


        public RegistraAcessoCoordenadaResponse Coordenada(RegistraAcessoCoordenadaRequest request)
        {

            var response = new RegistraAcessoCoordenadaResponse();
            try
            {





            }
            catch (Exception ex)
            {
                response.Status = "X";
                response.Sucess = false;
                response.Message = "Ocorreu um erro durante o registro de Acesso por Coordenada: " + ex.Message;

            }
            return response;

        }

    } 
}
