using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Application.Contracts.Persistance;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsExport
{
    class GetEventsExportQueryHandler : IRequestHandler<GetEventExportQuery, EventExportFileVm>
    {
        private readonly IAsyncRepository<Event> _eventReposiotry;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExproter;

        public GetEventsExportQueryHandler(IAsyncRepository<Event> eventRepository, IMapper mapper, ICsvExporter exporter)
        {
            _eventReposiotry = eventRepository;
            _mapper = mapper;
            _csvExproter = exporter;    
        }

        public async Task<EventExportFileVm> Handle(GetEventExportQuery request, CancellationToken cancellationToken)
        {
            var allEvents = _mapper.Map<List<EventExportDto>>((await _eventReposiotry.ListAllAsync()).OrderBy(x => x.Date));

            var fileData = _csvExproter.ExportEventsToCsv(allEvents);

            var eventExportFileDto = new EventExportFileVm() { ContentType = "text/csv", Data = fileData, EventExportFileName = $"{Guid.NewGuid()}.csv" };

            return eventExportFileDto;
        }
    }
}
