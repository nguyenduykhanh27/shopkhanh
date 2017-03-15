using ShopKhanh.Service;
using ShopKhanh.Web.infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopKhanh.Web.Api
{

    [RoutePrefix("api/statistic")]
    public class StatisticController : ApiControllerBase
    {
        IStatisticService _statisticServices;

        public StatisticController(IErrorService errorService, IStatisticService statisticServices) : base(errorService)
        {
            _statisticServices = statisticServices;
        }
        [Route("getrevenue")]
        [HttpGet]
        public HttpResponseMessage GetRevenueStatistic(HttpRequestMessage request,string fromDate,string toDate)
        {
            return CreateHttpResponse(request, () =>
            {

                var model = _statisticServices.GetRevenueStatistic(fromDate, toDate);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, model);
                return response;
            });
        }
    }
}
