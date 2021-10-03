using QASupporter.Application.Configuration.Database;
using QASupporter.Application.Configuration.DomainEvents;
using QASupporter.Application.Configuration.Interfaces;
using QASupporter.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace QASupporter.Application.CqrsHandlers.EventHandlers
{
    class PreGenerateResizedImagesEventHandler : INotificationHandler<DomainEventNotification<PreGenerateResizedImagesEvent>>
    {
        private readonly ILogger<PreGenerateResizedImagesEventHandler> _logger;
        private readonly IPreGeneratorService _preGeneratorService;
        private readonly IFileRepository _fileRepository;

        public PreGenerateResizedImagesEventHandler(ILogger<PreGenerateResizedImagesEventHandler> logger,
            IPreGeneratorService preGeneratorService,
            IFileRepository fileRepository)
        {
            _logger = logger;
            _preGeneratorService = preGeneratorService;
            _fileRepository = fileRepository;
        }

        public async Task Handle(DomainEventNotification<PreGenerateResizedImagesEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;
            _logger.LogInformation("Handling Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            File rsFile = await _fileRepository.GetByIdAsync(domainEvent.Id);

            if (rsFile != null)
            {
                await _preGeneratorService.PreGenerateResizedImages(rsFile);
            }
        }
    }
}
