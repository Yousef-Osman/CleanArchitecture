using Azure.Core;
using CleanArchitecture.Application.Commands.Product.CreateProduct;
using CleanArchitecture.Application.Queries.Products.GetProduct;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ISender _mediator;

    public ProductsController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("Create")]
    public async Task<IActionResult> Create()
    {
        var command = new CreateProductCommand(
            Name: "Lenovo",
            Description: "Brand new laptop",
            Price: 30000,
            Stock: 6,
            ImageUrl: "imageurl.com",
            BrandId: 1,
            VendorId: "dbhdbv");

        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpGet("GetProducts")]
    public async Task<IActionResult> GetProducts()
    {
        var query = new GetProductQuery(Id: 1);

        var result = await _mediator.Send(query);

        return Ok(result);
    }
}
