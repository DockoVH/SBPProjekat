using Microsoft.AspNetCore.Mvc;
using ProdavnicaLibrary;
using ProdavnicaLibrary.DTOs;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdavnicaController : ControllerBase
{
    [HttpGet]
    [Route("PreuzmiProdavnice")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult GetProdavnice()
    {
        (bool isError, var prodavnice, ErrorMessage? error) = DataProvider.VratiSveProdavnice();

        if (isError)
        {
            return StatusCode(error?.StatusCode ?? 400, error?.Message);
        }

        return Ok(prodavnice);
    }

    [HttpPost]
    [Route("DodajProdavnicu")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> AddProdavnica([FromBody] ProdavnicaView p)
    {
        var data = await DataProvider.DodajProdavnicuAsync(p);
        
        if (data.IsError)
        {
            return StatusCode(data.Error.StatusCode, data.Error.Message);
        }

        return StatusCode(201, $"Uspešno dodata prodavnica. Naziv: {p.Naziv}");
    }

    [HttpPut]
    [Route("PromeniProdavnicu")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> ChangeProdavnica([FromBody] ProdavnicaView p)
    {
        (bool isError, var prodavnica, ErrorMessage? error) = await DataProvider.AzurirajProdavnicuAsync(p);

        if (isError)
        {
            return StatusCode(error?.StatusCode ?? 400, error?.Message);
        }

        if (prodavnica == null)
        {
            return BadRequest("Prodavnica nije validna.");
        }

        return Ok($"Uspešno ažurirana prodavnica. Naziv: {prodavnica.Naziv}");
    }

    [HttpDelete]
    [Route("IzbrisiProdavnicu/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> DeleteProdavnica(int id)
    {
        var data = await DataProvider.ObrisiProdavnicuAsync(id);

        if (data.IsError)
        {
            return StatusCode(data.Error.StatusCode, data.Error.Message);
        }

        return StatusCode(204, $"Uspešno obrisana prodavnica. ID: {id}");
    }
}
