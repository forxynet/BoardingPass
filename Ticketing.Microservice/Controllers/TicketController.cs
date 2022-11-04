using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using System;
using System.Threading.Tasks;

namespace Ticketing.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IBus _bus;
        public TicketController(IBus bus)
        {
            _bus = bus;
        }
        [HttpPost]
        public async Task<IActionResult> CreateTicket(BoardingPass ticket)
        {
            if (ticket != null)
            {
                ticket.Date = DateTime.Now.ToShortDateString();
                Uri uri = new Uri("rabbitmq://localhost/ticketQueue");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(ticket);
                return Ok();
            }
            return BadRequest();
        }
    }
}