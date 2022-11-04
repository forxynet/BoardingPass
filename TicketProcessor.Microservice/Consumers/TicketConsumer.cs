using MassTransit;
using Microsoft.Extensions.Logging;
using Shared.Models;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace TicketProcessor.Microservice.Consumers
{
    public class TicketConsumer : IConsumer<BoardingPass>
    {
        private readonly ILogger<TicketConsumer> _logger;
        public TicketConsumer(ILogger<TicketConsumer> logger) {
            _logger=logger;
        }

        public async Task Consume(ConsumeContext<BoardingPass> context) {
            var data = context.Message;
            var source = JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            _logger.LogInformation($"BoardingPass :{source}");
        }
    }
}
