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
using MyRouteApp.API.Transactions.Path;
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
        [HttpPost("FastestPath")]
        [Authorize]
        public async Task<ActionResult<FullPathModel>> FastestPath([FromBody]PathModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var request = new PathTransactionRequest() { PathModel = model };
                    var response = await _mediator.Send(request);
                    return Ok(response.FullPath);
                }
                catch (NotFoundException ex)
                {
                    return NotFound(ex.Message);
                }

                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
                
            }
            return BadRequest(ModelState);
            
            
        }



        
    }
}