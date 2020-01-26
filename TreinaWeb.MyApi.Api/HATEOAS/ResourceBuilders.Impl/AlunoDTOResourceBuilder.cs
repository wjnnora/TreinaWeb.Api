using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;
using TreinaWeb.MyApi.Api.DTOs;
using TreinaWeb.MyApi.Api.HATEOAS.ResourceBuilders.Interfaces;

namespace TreinaWeb.MyApi.Api.HATEOAS.ResourceBuilders.Impl
{
    public class AlunoDTOResourceBuilder : IResourceBuilder
    {
        public void BuilderResource(object resource, HttpRequestMessage request)
        {
            AlunoDTO dto = resource as AlunoDTO;
            if (dto == null)
            {
                throw new ArgumentException($"Era esperado objeto AlunoDTO, porém, foi enviado um {resource.GetType().Name}");
            }
            UrlHelper urlHelper = new UrlHelper(request);

            string alunoDTORoute = urlHelper.Link("DefaultApi", new { Controller = "Alunos", id = dto.Id });
            dto.Links.Add(new RestLink
            {
                Rel = "self",
                Href = alunoDTORoute
            });
            dto.Links.Add(new RestLink
            {
                Rel = "edit",
                Href = alunoDTORoute
            });
            dto.Links.Add(new RestLink
            {
                Rel = "delete",
                Href = alunoDTORoute
            });
        }
    }
}