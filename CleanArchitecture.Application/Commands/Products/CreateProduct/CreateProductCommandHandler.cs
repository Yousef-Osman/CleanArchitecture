using CleanArchitecture.Application.Interfaces.Persistence;
using MediatR;
namespace CleanArchitecture.Application.Commands.Products.CreateProduct;
public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductCommandResponse>
{
    //private readonly IRepository<Product> _productRepo;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(
        //IRepository<Product> productRepo,
        IUnitOfWork unitOfWork)
    {
        //_productRepo = productRepo;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateProductCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        await Task.Run(() => 1 + 1);

        return new CreateProductCommandResponse(IsSuccess: true, Message: "It works");
    }
}
