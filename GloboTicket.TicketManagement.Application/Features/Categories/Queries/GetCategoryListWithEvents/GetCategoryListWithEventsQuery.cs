using MediatR;
using System.Collections.Generic;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoryListWithEvents
{
    public class GetCategoryListWithEventsQuery : IRequest<List<CategoryEventListVm>>    
    {
        public bool IncludeHistory { get; set; }
    }
}
