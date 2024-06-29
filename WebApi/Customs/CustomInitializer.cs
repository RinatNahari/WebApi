namespace WebApi.Customs
{
    public static class CustomInitializer
    {
        public static IServiceCollection AddCustom(this IServiceCollection services)
        {
            services.Configure<RouteOptions>(options
                => options.ConstraintMap.Add("string", typeof(CustomStringRouteConstraint)));
            return services;
        }
    }
}
