using Christmas.Event;
using Microsoft.Extensions.Logging;

namespace test_shadow_calculator.Consumers
{
    using System.Threading.Tasks;
    using MassTransit;

    public class TestShadowCalculatorConsumer :
        IConsumer<PayRunClosedEvent_v1>
    {
        private readonly ILogger<TestShadowCalculatorConsumer> _logger;

        public TestShadowCalculatorConsumer(ILogger<TestShadowCalculatorConsumer> logger)
        {
            _logger = logger;
        }
        public Task Consume(ConsumeContext<PayRunClosedEvent_v1> context)
        {
            _logger.LogInformation("Message : {Data}", context.Message.PayRunId);
            return Task.CompletedTask;
        }
    }
}