using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PurchaseOrderTracker.Application.Features.Reporting.Queries;

namespace PurchaseOrderTracker.WebApi.Features.Reporting
{
    public class ReportingController : BaseController
    {
        public ReportingController(IMediator mediator, IMapper mapper)
            : base(mediator, mapper)
        {
        }
        [AllowAnonymous]
        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ShipmentsSummaryQuery.Result>> ShipmentsSummary()
        {
            return new ShipmentsSummaryQuery.Result(1, 32, 4, 23);
            //return await _mediator.Send(new ShipmentsSummaryQuery());
        }
    }
}
