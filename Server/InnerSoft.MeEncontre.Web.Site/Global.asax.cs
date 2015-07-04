using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MeEncontre.Domain.Model;
using System.Data.Entity;
using MeEncontre.Infrastructure.ModelBinders;
using Microsoft.Practices.Unity;
using InnerSoft.MeEncontre.Application.Contracts;
using InnerSoft.MeEncontre.Application.ServiceImplementation;
using MeEncontre.Infrastructure.Repository;
using MeEncontre.Infrastructure.UnitOfWork;
using SmartAqua.UI.DI;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InnerSoft.MeEncontre.Domain.Model;
using InnerSoft.MeEncontre.Web.Site.ViewModel;

namespace InnerSoft.MeEncontre.Web.Site
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {


            //Database.SetInitializer<MeEncontreEntities>(new DropCreateDatabaseIfModelChanges<MeEncontreEntities>());
            Database.SetInitializer<MeEncontreEntities>(null);

            GlobalConfiguration.Configuration.MessageHandlers.Add(new XHttpMethodDelegatingHandler());

            AreaRegistration.RegisterAllAreas();

            ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //RouteDebug.RouteDebugger.RewriteRoutesForTesting(RouteTable.Routes);


            ConfigureUserMapping();

            // var container = new UnityContainer();
            //container.RegisterType<IAquarioService, AquarioService>
            //    (new PerThreadLifetimeManager()).RegisterType<IDALContext, DALContext>();

            IUnityContainer container = new UnityContainer()
               .RegisterType<IClienteService, ClienteService>()
               .RegisterType<IStatusService, StatusService>()
                //.RegisterType<IMembershipService, AccountMembershipService>()
                //.RegisterInstance<MembershipProvider>(Membership.Provider)
               .RegisterType<IClienteRepository, ClienteRepository>()
               .RegisterType<IStatusRepository, StatusRepository>()       
               .RegisterType(typeof(IDALContext), typeof(DALContext));
            //Set container for Controller Factory

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

        }


        private static void ConfigureUserMapping()
        {

            Mapper.CreateMap<Acesso, AcessoViewModel>();
            Mapper.CreateMap<AcessoViewModel, Acesso>();

            Mapper.CreateMap<Cliente, ClienteViewModel>();
            Mapper.CreateMap<ClienteViewModel, Cliente>();
           
            Mapper.CreateMap<Colaborador, ColaboradorViewModel>();
            Mapper.CreateMap<ColaboradorViewModel, Colaborador>();

            Mapper.CreateMap<Local, LocalViewModel>();
            Mapper.CreateMap<LocalViewModel, Local>();

            Mapper.CreateMap<PermissaoLocalColaborador, PermissaoLocalColaboradorViewModel>();
            Mapper.CreateMap<PermissaoLocalColaboradorViewModel, PermissaoLocalColaborador>();

            Mapper.CreateMap<Status, StatusViewModel>();
            Mapper.CreateMap<StatusViewModel, Status>();
            
        }
    }
    public class XHttpMethodDelegatingHandler : DelegatingHandler
    {
        private static readonly string[] _allowedHttpMethods = { "PUT", "DELETE" };
        private static readonly string _httpMethodHeader = "X-HTTP-Method";

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Method == HttpMethod.Post && request.Headers.Contains(_httpMethodHeader))
            {
                string httpMethod = request.Headers.GetValues(_httpMethodHeader).FirstOrDefault();
                if (_allowedHttpMethods.Contains(httpMethod, StringComparer.InvariantCultureIgnoreCase))
                    request.Method = new HttpMethod(httpMethod);
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}