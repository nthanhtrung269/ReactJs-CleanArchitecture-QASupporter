using QASupporter.Domain.SharedKernel;

namespace QASupporter.Application.CqrsHandlers.EventHandlers
{
    public class PreGenerateResizedImagesEvent : DomainEvent
    {
        public PreGenerateResizedImagesEvent(long id)
        {
            Id = id;
        }

        public long Id { get; }
    }
}
