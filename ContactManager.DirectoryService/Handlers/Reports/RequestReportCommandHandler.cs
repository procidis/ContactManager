using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using ContactManager.DirectoryService.Commands.Reports;
using ContactManager.Persistence.Services;
using MediatR;

namespace ContactManager.DirectoryService.Handlers.Reports
{
	public class RequestReportCommandHandler : IRequestHandler<RequestReportCommand, TopicPartitionOffset>
	{
		private readonly KafkaProducerService producerService;

		public RequestReportCommandHandler(KafkaProducerService producerService)
		{
			this.producerService = producerService;
		}
		public async Task<TopicPartitionOffset> Handle(RequestReportCommand request, CancellationToken cancellationToken)
		{
			var result = await producerService.ProduceAsync(CancellationToken.None);
			return result.TopicPartitionOffset;
		}
	}
}
