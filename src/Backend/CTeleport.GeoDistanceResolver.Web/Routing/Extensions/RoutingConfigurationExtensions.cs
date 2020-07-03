using Microsoft.AspNetCore.Mvc;

namespace CTeleport.GeoDistanceResolver.Web.Routing.Extensions
{
    /// <summary>
    /// A shortcuts to modify MVC Options
    /// </summary>
    public static class RoutingConfiguration
    {
        /// <summary>
        /// Add a route convention to build routes
        /// </summary>
        /// <param name="options">MVC Options</param>
        /// <param name="routePrefix">Route prefix to be a static part</param>
        public static void UseRouteConvention(this MvcOptions options, string routePrefix)
        {
            options.Conventions.Insert(0, new RouteConvention(new RouteAttribute(routePrefix)));
        }
    }
}
