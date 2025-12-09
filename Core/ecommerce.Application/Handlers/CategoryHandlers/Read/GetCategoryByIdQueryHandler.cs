using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.CategoryDTOs.Queries;
using ecommerce.Application.DTOs.CategoryDTOs.Results;
using ecommerce.Concract.Repositories;

namespace ecommerce.Application.Handlers.CategoryHandlers.Read
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryResult?>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryResult?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category == null)
            {
                return null;
            }

            return _mapper.Map<CategoryResult>(category);
        }
    }
}

