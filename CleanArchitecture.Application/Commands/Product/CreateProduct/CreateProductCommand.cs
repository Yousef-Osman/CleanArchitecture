using MediatR;

namespace CleanArchitecture.Application.Commands.Product.CreateProduct;

public record CreateProductCommand(
    string Name, 
    string Description, 
    decimal Price, 
    int Stock, 
    string ImageUrl, 
    long BrandId, 
    string VendorId) : IRequest<CreateProductCommandResponse>;
