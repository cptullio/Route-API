using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyRouteApp.API.Helpers;
using MyRouteApp.API.Model;
using MyRouteApp.API.Transactions.Route;
using MyRouteApp.Infrastructure.Exceptions;
using MyRouteApp.Infrastructure.Persistence.Repository;

namespace MyRouteApp.API.Controllers
{
    /// <summary>
    /// Control of the Route Data of the System.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PathController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PathController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Present 
        /// </summary>
        /// <returns>Routes with Id and Name</returns>
        [HttpGet("FastestPath")]
        [Authorize]
        public async Task<ActionResult<List<RouteModel>>> Get(int OriginalPointId, int DestinationPointId)
        {
            return NoContent();
            //var response = await _mediator.Send(new FastestPathTransactionRequest());
            //if (response == null || response.RouteList?.Count == 0)
            //    return NoContent();
            //return response.RouteList;
        }



        
    }
}