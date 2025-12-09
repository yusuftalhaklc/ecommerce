using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.CategoryDTOs.Commands;
using ecommerce.Application.DTOs.CategoryDTOs.Results;
using ecommerce.Concract.Repositories;
using ecommerce.Domain.Enums;

namespace ecommerce.Application.Handlers.CategoryHandlers.Modify
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryResult>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category == null)
            {
                throw new KeyNotFoundException($"Category with Id {request.Id} not found.");
            }

            _mapper.Map(request, category);
            category.UpdatedDate = DateTime.Now;
            category.Status = DataStatus.Updated;

            // ParentCategoryId 0 ise null yap
            if (category.ParentCategoryId == 0)
            {
                category.ParentCategoryId = null;
            }

            await _categoryRepository.UpdateAsync(category);
            await _categoryRepository.SaveChangesAsync();

            return _mapper.Map<CategoryResult>(category);
        }
    }
}

