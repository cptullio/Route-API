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
    public class RouteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RouteController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// List all Routes Registered in the system
        /// </summary>
        /// <returns>Routes with Id and Name</returns>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<RouteModel>>> Get()
        {
            var response = await _mediator.Send(new RouteListTransactionRequest());
            if (response == null || response.RouteList?.Count == 0)
                return NoContent();
            return response.RouteList;
        }
        /// <summary>
        /// Add new Route Name to the database.
        /// </summary>
        /// <param name="model">A Route Data with Name.</param>
        /// <returns>The Route Data with the new ID generated</returns>
        [HttpPost]
        [Authorize(Roles = AppConstants.AdminsRole)]
        public async Task<ActionResult<RouteModel>> Post(RouteModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _mediator.Send(new RouteCreateTransactionRequest() { Route = model});
                if (response == null || response.Route == null)
                    return NoContent();
                return response.Route;
            }
            return BadRequest(ModelState);

        }
        /// <summary>
        /// Update a Post record based on Id
        /// </summary>
        /// <param name="model">Route object Id</param>
        /// <returns>The Route object updated</returns>
        [HttpPut]
        [Authorize(Roles = AppConstants.AdminsRole)]
        public async Task<ActionResult<RouteModel>> Put(RouteModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _mediator.Send(new RouteUpdateTransactionRequest() { Route = model });
                    if (response == null || response.Route == null)
                        return NoContent();
                    return response.Route;
                }
                catch (NotFoundException)
                {
                    return NotFound();
                }

            }
            return BadRequest(ModelState);

        }

        /// <summary>
        /// Delete from Database a Route based on ID
        /// </summary>
        /// <param name="id">Identificator Route</param>
        /// <returns>Only the HTTP status code indicating success or failed</returns>
        [HttpDelete]
        [Authorize(Roles = AppConstants.AdminsRole)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _mediator.Send(new RouteDeleteTransactionRequest() { Id = id });
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}