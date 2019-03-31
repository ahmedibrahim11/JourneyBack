using AutoMapper;
using Framework.Data.EF;
using joureny.Data;
using joureny.Data.Entities;
using joureny.Dtos;
using journey.Utilities.Cryptography;
using System;
using System.Data.Entity;
using Unity;
using Unity.Lifetime;

namespace joureny
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

        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();

            var MapConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<Trip, TripDto>();
                cfg.CreateMap<UserTrips,UserTripDto>();
            });

            container.RegisterInstance(typeof(IConfigurationProvider), MapConfig);

            container.RegisterType<DbContext, JourenyContext>(new PerThreadLifetimeManager());

            container.RegisterType(typeof(IRepository<>), typeof(Repository<>), new TransientLifetimeManager());
           
            container.RegisterType<IUnitOfWorkFactory, UnitOfWorkFactory>(new TransientLifetimeManager());

            container.RegisterType<IEncryptionService, EncrptionService>(new TransientLifetimeManager());

        }
    }
}