using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.Extensions.Options;

namespace ContactManager.Persistence.Services
{
	public class KafkaProducerService
	{
		private readonly IProducer<Null, string> producer;

		public KafkaProducerService(IOptions<ProducerConfig> options)
		{
			producer = new ProducerBuilder<Null, string>(options.Value).Build();
		}

		public async Task<DeliveryResult<Null, string>> ProduceAsync(CancellationToken cancellationToken)
		{
			return await producer.ProduceAsync(KafkaConsumerHostedService.TOPIC, new Message<Null, string>()
			{
				Value = "???"
			}, cancellationToken);
		}
	}
}
