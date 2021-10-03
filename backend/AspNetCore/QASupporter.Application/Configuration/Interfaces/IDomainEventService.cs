using QASupporter.Domain.SharedKernel;
using System.Threading.Tasks;

namespace QASupporter.Application.Configuration.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
