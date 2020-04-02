using LinkDev.AngularAutomation.Services.CRMasServiceLogic.Base;
using LinkDev.AngularAutomation.Services.CRMasServiceLogic.CRMasServiceLogic;
using System;
using System.Web.Configuration;
using System.Web.Http;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.WebApi;

namespace LinkDev.AngularAutomation.Services.CRMasServiceProviderApi
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });


        public static IUnityContainer Container => container.Value;
        #endregion

        public static void RegisterTypes(IUnityContainer container)

        {
            #region CRMConnection
            ICrmConnection _crmConnection = null;
            container.RegisterType<ICrmConnection>(new ContainerControlledLifetimeManager(),
                new InjectionFactory(c =>
                {
                    if (_crmConnection == null)
                    {
                        _crmConnection = new CrmConnection();
                        _crmConnection.ConnectToCrm(WebConfigurationManager.ConnectionStrings["CrmAccess"]
                            .ConnectionString);
                    }

                    return _crmConnection;
                }));
            #endregion

            container.RegisterType<ICrmServiceLogic, CrmServiceLogic>();

         


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        //public static IUnityContainer RegisterComponents()
        //{
        //    var container = new UnityContainer();

        //    return container;
        //}
    }
}