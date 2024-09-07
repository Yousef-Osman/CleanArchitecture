using MediatR;
namespace CleanArchitecture.Application.Commands.Product.CreateProduct;
public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductCommandResponse>
{
    public async Task<CreateProductCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        await Task.Run(() => 1 + 1);

        return new CreateProductCommandResponse(IsSuccess: true, Message: "It works");
    }
}
