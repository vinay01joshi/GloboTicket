using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoryListWithEvents
{
    public class GetCategoryListWithEventsQueryHandler : IRequestHandler<GetCategoryListWithEventsQuery, List<CategoryEventListVm>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        public GetCategoryListWithEventsQueryHandler(IMapper mapper, ICategoryRepository repository)
        {
            _mapper = mapper;
            _categoryRepository = repository;
        }
        public async Task<List<CategoryEventListVm>> Handle(GetCategoryListWithEventsQuery request, CancellationToken cancellationToken)
        {
            var list = await _categoryRepository.GetCategoriesWithEvents(request.IncludeHistory);
            return _mapper.Map<List<CategoryEventListVm>>(list);
        }
    }
}
