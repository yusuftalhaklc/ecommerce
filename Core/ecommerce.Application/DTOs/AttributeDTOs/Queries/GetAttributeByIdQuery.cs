using MediatR;
using ecommerce.Application.DTOs.AttributeDTOs.Results;

namespace ecommerce.Application.DTOs.AttributeDTOs.Queries
{
    public class GetAttributeByIdQuery : IRequest<AttributeResult?>
    {
        public int Id { get; set; }
    }
}

