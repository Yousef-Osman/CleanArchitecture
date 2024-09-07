using MediatR;

namespace CleanArchitecture.Application.Queries.Products.GetProduct;
public record GetProductQuery(long Id): IRequest<GetProductQueryResponse>;