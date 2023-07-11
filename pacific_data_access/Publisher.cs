using System.Threading;
using System.Threading.Tasks;
using Contracts;
using MassTransit;
using Microsoft.Extensions.Hosting;

namespace pacific_data_access
{
    public class Publisher: BackgroundService
    {
        private readonly IBus _bus;
        private int _counter = 0;

        public Publisher(IBus bus)
        {
            _bus = bus;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _bus.Publish(new PayRunClosedEvent_v1
                {
                    PayRunId = _counter++
                }, stoppingToken);
                
                await Task.Delay(1000, stoppingToken);
            }

            
        }
    }
}