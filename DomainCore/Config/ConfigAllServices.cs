using Microsoft.Extensions.DependencyInjection;

namespace DomainCore.Config
{
    public static class ConfigAllServices
    {
        #region AddDI

        //  add all dependecies inyeccion
        public static void AddDI(this IServiceCollection services)
        {
            #region Identity

            services.AddScoped<
                Core.Interfaces.Identity.IProfileInfoRep,
                Core.Reps.Identity.ProfileInfoRep>();

            #endregion

            #region GeneralEntities

            //  app di in self
            services.AddScoped<
                Core.Interfaces.IProductsRep,
                Core.Reps.ProductsRep>();

            services.AddScoped<
                Core.Interfaces.ISellersRep,
                Core.Reps.SellersRep>();

            #endregion
        }

        #endregion
    }
}
