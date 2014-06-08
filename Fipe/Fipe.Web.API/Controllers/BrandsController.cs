using System.Net;
using System.Net.Http;
using System.Web.Http;
using Fipe.Application.Contracts;
using Microsoft.Practices.ServiceLocation;

namespace Fipe.Web.API.Controllers
{
    public class BrandsController : ApiController
    {
        private readonly IBrandQueryApplicationService _queryApplicationService;

        public BrandsController()
        {
            _queryApplicationService = ServiceLocator.Current.GetInstance<IBrandQueryApplicationService>();
        }

        public HttpResponseMessage Get()
        {
            var brands = _queryApplicationService.GetAllBrands();
            return Request.CreateResponse(HttpStatusCode.OK, brands);
        }
    }
}
