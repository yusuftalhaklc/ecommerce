using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.CategoryDTOs.Commands;
using ecommerce.Application.DTOs.CategoryDTOs.Results;
using ecommerce.Concract.Repositories;
using ecommerce.Domain.Models;
using ecommerce.Domain.Enums;

namespace ecommerce.Application.Handlers.CategoryHandlers.Modify
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryResult>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request);
            category.Status = DataStatus.Inserted;
            category.CreatedDate = DateTime.Now;

            if (category.ParentCategoryId == 0)
            {
                category.ParentCategoryId = null;
            }

            var createdCategory = await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveChangesAsync();

            return _mapper.Map<CategoryResult>(createdCategory);
        }
    }
}

