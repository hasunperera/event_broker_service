namespace test_shadow_calculator.Consumers
{
    using MassTransit;

    public class TestShadowCalculatorConsumerDefinition :
        ConsumerDefinition<TestShadowCalculatorConsumer>
    {
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<TestShadowCalculatorConsumer> consumerConfigurator)
        {
            endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 1000));
        }
    }
}