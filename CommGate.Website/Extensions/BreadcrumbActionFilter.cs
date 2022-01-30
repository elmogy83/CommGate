﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;
using System.Text.RegularExpressions;

namespace CommGate.Website.Extensions
{
    public class BreadcrumbActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {

            var breadcrumbs = this.ConfigureBreadcrumb(context);

            var controller = context.Controller as Controller;
            controller.ViewBag.Breadcrumbs = breadcrumbs;

            base.OnActionExecuted(context);
        }

        private List<Breadcrumb> ConfigureBreadcrumb(ActionExecutedContext context)
        {
            var breadcrumbList = new List<Breadcrumb>();
            var homeControllerName = "Home";

            breadcrumbList.Add(new Breadcrumb
            {
                Text = "Home",
                Action = "Index",
                Controller = homeControllerName, // Change this controller name to match your Home Controller.
                Active = true
            });

            if (context.HttpContext.Request.Path.HasValue)
            {
                var pathSplit = context.HttpContext.Request.Path.Value.Split("/");

                for (var i = 0; i < pathSplit.Length; i++)
                {
                    // Check if first element is equal to our Index (home) page.
                    if (string.IsNullOrEmpty(pathSplit[i]) || string.Compare(pathSplit[i], homeControllerName, true) == 0)
                    {
                        continue;
                    }

                    // First check if path is a Controller class.
                    var controller = this.GetControllerType(pathSplit[i] + "Controller");

                    // If this is a controller, does it have a default Index method? If so, that needs adding as a breadcrumb. Is the next path element called Index?
                    if (controller != null)
                    {
                        var indexMethod = controller.GetMethod("Index");

                        if (indexMethod != null)
                        {
                            breadcrumbList.Add(new Breadcrumb
                            {
                                Text = this.CamelCaseSpacing(pathSplit[i]),
                                Action = "Index",
                                Controller = pathSplit[i],
                                Active = true
                            });

                            if (i + 1 < pathSplit.Length && string.Compare(pathSplit[i + 1], "Index", true) == 0)
                            {
                                // This is the last element in the breadcrumb list. This should be disabled.
                                breadcrumbList.LastOrDefault().Active = false;

                                // Next path item is the Index method. We can escape from this method now.
                                return breadcrumbList;
                            }
                        }
                    }

                    // If not a Controller, check if this is a method on the previous path element.
                    if (i - 1 > 0)
                    {
                        var controllerName = pathSplit[i - 1] + "Controller";
                        var prevController = this.GetControllerType(controllerName);

                        if (prevController != null)
                        {
                            var method = prevController.GetMethod(pathSplit[i]);

                            if (method != null)
                            {
                                // We've found an endpoint on the previous controller.
                                breadcrumbList.Add(new Breadcrumb
                                {
                                    Text = this.CamelCaseSpacing(pathSplit[i]),
                                    Action = pathSplit[i],
                                    Controller = pathSplit[i - 1]
                                });
                            }
                        }
                    }
                }
            }

            // There will always be at least 1 entry in the breadcrumb list. The last element should always be disabled.
            breadcrumbList.LastOrDefault().Active = false;

            return breadcrumbList;
        }


        private Type GetControllerType(string name)
        {
            Type controller = null;

            try
            {
                controller = Assembly.GetCallingAssembly().GetType("CommGate.Web.Controllers." + name);
            }
            catch
            { }

            return controller;
        }

        private string CamelCaseSpacing(string s)
        {

            var r = new Regex(@"
        (?<=[A-Z])(?=[A-Z][a-z]) |
         (?<=[^A-Z])(?=[A-Z]) |
         (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);

            return r.Replace(s, " ");
        }
    }

}
