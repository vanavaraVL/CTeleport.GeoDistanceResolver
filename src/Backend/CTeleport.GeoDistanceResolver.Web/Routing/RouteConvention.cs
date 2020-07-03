using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Routing;

namespace CTeleport.GeoDistanceResolver.Web.Routing
{
    /// <summary>
    /// Route convention
    /// </summary>
    public class RouteConvention : IApplicationModelConvention
    {
        /// <summary>
        /// Route prefix
        /// </summary>
        private readonly AttributeRouteModel _centralPrefix;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="routeTemplateProvider">Route template provider</param>
        public RouteConvention(IRouteTemplateProvider routeTemplateProvider)
        {
            _centralPrefix = new AttributeRouteModel(routeTemplateProvider);
        }

        /// <summary>
        /// <see cref="IApplicationModelConvention"/>
        /// </summary>
        public void Apply(ApplicationModel application)
        {
            foreach (var controller in application.Controllers)
            {
                var routeTemplate = string.Join("/",
                    controller.ControllerType.GetCustomAttributes<RouteAttribute>(inherit: true)
                        .Select(x => x.Template)
                        .Reverse());

                var routeModel = AttributeRouteModel.CombineAttributeRouteModel(
                    _centralPrefix,
                    new AttributeRouteModel(new RouteAttribute(routeTemplate))
                );

                if (controller.Selectors.Any())
                {
                    foreach (var selectorModel in controller.Selectors)
                    {
                        selectorModel.AttributeRouteModel = routeModel;
                    }
                }
            }
        }
    }
}
