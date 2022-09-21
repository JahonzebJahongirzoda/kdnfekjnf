using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Entities;
using Domain.Wrapper;
namespace Webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuoteController : ControllerBase
{
    private readonly QuoteServices _service;

    public QuoteController()
    {
        _service = new QuoteServices();
    }


    [HttpGet("GetQuote")]
    public async Task<Response<string>> Get()

    {
        return await _service.GetQuote();
    }


    [HttpGet("GetRand")]
    public async Task<Response<string>> Getbyrand()

    {
        return await _service.Getbyrand();
    }









    [HttpPut("UpdateQuote")]
    public async Task<Response<string>> Put(Quote quote)

    {
        return await _service.UpdateQuote(quote);
    }










    [HttpDelete("DeleteQuote")]
    public async Task<Response<string>> Delete(int id)

    {
        return await _service.DeleteQuote(id);
    }





    [HttpGet("GetQuoteWithCategory")]
    public async Task<Response<List<GetQuoteWithCategoryDto>>> GetQuotebyCategory(int id)

    {
        return await _service.GetQuoteWithCategory(id);
    }

    [HttpPost]
    public async Task<Response<string>> Create(Quote quote)
    {
        return await _service.AddQuote(quote);

    }







}
