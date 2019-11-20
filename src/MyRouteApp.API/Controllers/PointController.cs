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
using MyRouteApp.API.Transactions.Point;
using MyRouteApp.Infrastructure.Exceptions;
using MyRouteApp.Infrastructure.Persistence.Repository;

namespace MyRouteApp.API.Controllers
{
    /// <summary>
    /// Control of the Point Data of the System.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PointController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PointController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// List all Points Registered in the system
        /// </summary>
        /// <returns>Points with Id and Name</returns>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<PointModel>>> Get()
        {
            var response = await _mediator.Send(new PointListTransactionRequest());
            if (response == null || response.PointList?.Count == 0)
                return NoContent();
            return response.PointList;
        }
        /// <summary>
        /// Add new Point Name to the database.
        /// </summary>
        /// <param name="model">A Point Data with Name.</param>
        /// <returns>The Point Data with the new ID generated</returns>
        [HttpPost]
        [Authorize(Roles = AppConstants.AdminsRole)]
        public async Task<ActionResult<PointModel>> Post(PointModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _mediator.Send(new PointCreateTransactionRequest() { Name = model.Name });
                if (response == null || response.Point == null)
                    return NoContent();
                return response.Point;
            }
            return BadRequest(ModelState);

        }
        /// <summary>
        /// Update a Post record based on Id and Name
        /// </summary>
        /// <param name="model">Point object Id and Name</param>
        /// <returns>The Point object updated</returns>
        [HttpPut]
        [Authorize(Roles = AppConstants.AdminsRole)]
        public async Task<ActionResult<PointModel>> Put(PointModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _mediator.Send(new PointUpdateTransactionRequest() { Point = model });
                    if (response == null || response.Point == null)
                        return NoContent();
                    return response.Point;
                }
                catch (NotFoundException)
                {
                    return NotFound();
                }

            }
            return BadRequest(ModelState);

        }

        /// <summary>
        /// Delete from Database a Point based on ID
        /// </summary>
        /// <param name="id">Identificator point</param>
        /// <returns>Only the HTTP status code indicating success or failed</returns>
        [HttpDelete]
        [Authorize(Roles = AppConstants.AdminsRole)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _mediator.Send(new PointDeleteTransactionRequest() { Id = id });
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