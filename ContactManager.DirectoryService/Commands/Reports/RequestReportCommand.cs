using Confluent.Kafka;
using MediatR;

namespace ContactManager.DirectoryService.Commands.Reports
{
	public class RequestReportCommand : IRequest<TopicPartitionOffset>
	{
	}
}
