using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.CategoryDTOs.Queries;
using ecommerce.Application.DTOs.CategoryDTOs.Results;
using ecommerce.Concract.Repositories;

namespace ecommerce.Application.Handlers.CategoryHandlers.Read
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, CategoryListResult>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryListResult> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync();
            var categoryResults = _mapper.Map<IEnumerable<CategoryResult>>(categories);

            return new CategoryListResult
            {
                Categories = categoryResults,
                TotalCount = categoryResults.Count()
            };
        }
    }
}

