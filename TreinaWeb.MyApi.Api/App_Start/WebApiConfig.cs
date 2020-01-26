using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TreinaWeb.MyApi.Api.Filters;
using TreinaWeb.MyApi.Api.Formatters;

namespace TreinaWeb.MyApi.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Serviços e configuração da API da Web

            //Faz com que a API responda as request em CamelCase
            var jsonFormatter = config.Formatters.JsonFormatter;
            jsonFormatter.SerializerSettings = new Newtonsoft.Json.JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore
            };

            //Adiciona um formatador CSV que foi criado
            config.Formatters.Add(new CsvMediaTypeFormatter());

            //Remove a possibilidade de a API responder no formato XML
            //var xmlFormatter = config.Formatters.XmlFormatter;
            //config.Formatters.Remove(xmlFormatter);
            // Rotas da API da Web

            config.Filters.Add(new FillResponseWithHATEOASAttribute());
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
