using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Queries.Products.GetProduct;
internal class GetProductQueryHandler : IRequestHandler<GetProductQuery, GetProductQueryResponse>
{
    private readonly IReadRepository<Product, long> _productRepo;

    public GetProductQueryHandler(IReadRepository<Product, long> productRepo)
    {
        _productRepo = productRepo;
    }

    public async Task<GetProductQueryResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepo.FirstOrDefaultAsync(x => x.Id == request.Id);

        return new GetProductQueryResponse(Message: product?.Name, IsSuccess: true);
    }
}
