using System.Net;
using application.Requests;
using domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace presentation.Controllers;

/// <summary>
/// 
/// </summary>
/// <param name="mediator"></param>
[ApiController]
[Route("api/[controller]")]
public class OrderController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="body"></param>
    /// <returns></returns>
    [HttpPost]
    [Produces(typeof(IOrder))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> Post([FromBody] PlaceOrder body)
    {
        return Ok(await mediator.Send(body));
    }
}