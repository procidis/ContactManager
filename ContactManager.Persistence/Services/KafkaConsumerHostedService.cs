using System;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ContactManager.Persistence.Services
{
	public class KafkaConsumerHostedService : IHostedService
	{
		private readonly ILogger<KafkaConsumerHostedService> logger;
		private readonly ConsumerConfig consumerConfig;
		public const string TOPIC = "REPORT";
		private const string GROUP_ID = "test-consumer-group";

		public KafkaConsumerHostedService(ILogger<KafkaConsumerHostedService> logger, IOptions<ProducerConfig> options)
		{
			this.logger = logger;
			consumerConfig = new ConsumerConfig
			{
				GroupId = GROUP_ID,
				BootstrapServers = options.Value.BootstrapServers
			};

		}

		public Task StartAsync(CancellationToken cancellationToken)
		{
			using (var cons = new ConsumerBuilder<Ignore, string>(consumerConfig).Build())
			{
				cons.Subscribe(TOPIC);
				var cts = new CancellationTokenSource();
				Console.CancelKeyPress += (_, e) =>
				{
					e.Cancel = true;
					cts.Cancel();
				};

				try
				{
					while (true)
						try
						{
							var cr = cons.Consume(cts.Token);
							logger.LogInformation(cr.Message.Value);
						}
						catch (ConsumeException e)
						{
							logger.LogError(e, e.Message);
						}
				}
				catch (Exception)
				{
					cons.Close();
				}
			}
			return Task.CompletedTask;
		}

		public Task StopAsync(CancellationToken cancellationToken)
		{
			return Task.CompletedTask;
		}
	}
}
