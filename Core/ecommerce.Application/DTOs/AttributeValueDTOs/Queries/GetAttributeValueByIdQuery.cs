using MediatR;
using ecommerce.Application.DTOs.AttributeValueDTOs.Results;

namespace ecommerce.Application.DTOs.AttributeValueDTOs.Queries
{
    public class GetAttributeValueByIdQuery : IRequest<AttributeValueResult?>
    {
        public int Id { get; set; }
    }
}

