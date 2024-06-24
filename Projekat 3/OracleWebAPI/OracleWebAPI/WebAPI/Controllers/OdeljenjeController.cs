using Microsoft.AspNetCore.Mvc;
using ProdavnicaLibrary;
using WebAPI.Code;
using ProdavnicaLibrary.DTOs;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class OdeljenjeController : ControllerBase
{
    [HttpGet("PruzmiSvaOdeljenja")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult> VratiSvaOdeljenja()
    {
        var (isError, odeljenja, error) = await DataProvider.VratiSvaOdeljenjaAsync();

        if (isError)
        {
            return StatusCode(error?.StatusCode ?? 400, error?.Message);
        }

        return Ok(odeljenja);
    }

    [HttpGet("PruzmiSvaOdeljenjaProdavnice/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult> VratiSvaOdeljenjaProdavnice(int id)
    {
        var (isError, odeljenja, error) = await DataProvider.VratiSvaOdeljenjaProdavniceAsync(id);

        if (isError)
        {
            return StatusCode(error?.StatusCode ?? 400, error?.Message);
        }

        return Ok(odeljenja);
    }

    [HttpPost("KreirajOdeljenjeDo5/{prodavnicaID}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult> KreirajOdeljenjeDo5([FromBody] OdeljenjeDo5View odeljenjeDo5, int prodavnicaID)
    {
        var (isError, id, error) = await DataProvider.SacuvajOdeljenjeDo5Async(odeljenjeDo5, prodavnicaID);

        if (isError)
        {
            return StatusCode(error?.StatusCode ?? 400, error?.Message);
        }

        /*
         * U ovom primeru ne možemo ovako da upišemo odeljenje, zato što BROJP ne sme da bude NULL!
         * 
        var (isError, id, error) = await DataProvider.SacuvajOdeljenjeDo5BezProdavniceAsync(odeljenjeDo5);

        if (isError)
        {
            return StatusCode(error?.StatusCode ?? 400, error?.Message);
        }

        var data = await DataProvider.PoveziOdeljenjeDo5IProdavnicuAsync(id, prodavnicaID);

        if (data.IsError)
        {
            return StatusCode(data.Error.StatusCode, data.Error.Message);
        }*/

        return StatusCode(201, $"Upisano odeljenje do 5 godina, sa ID: {id}");
    }

    [HttpPost("KreirajOdeljenje/{tipOdeljenja}/{prodavnicaID}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult> KreirajOdeljenje([FromBody] OdeljenjeView odeljenje, TipOdeljenja tipOdeljenja, int prodavnicaID)
    {
        var (isError, success, error) = await DataProvider.SacuvajOdeljenjeAsync(odeljenje, tipOdeljenja.ToString(), prodavnicaID);

        if (isError)
        {
            return StatusCode(error?.StatusCode ?? 400, error?.Message);
        }

        if (success)
        {
            return StatusCode(201, $"Upisano odeljenje {tipOdeljenja}, sa ID: {odeljenje.OdeljenjeId}");
        }
        else
        {
            return BadRequest("Neuspešan upis odeljenja.");
        }
    }

    [HttpPut("IzmenaOdeljenja")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult> IzmenaOdeljenja([FromBody]OdeljenjeDo5View odeljenje)
    {
        var data = await DataProvider.IzmeniOdeljenjeDo5Async(odeljenje);

        if (data.IsError)
        {
            return StatusCode(data.Error.StatusCode, data.Error.Message);
        }

        return Ok($"Upisano izmenjeno odeljenje do 5 godina, sa ID: {odeljenje.OdeljenjeId}");
    }

    [HttpDelete("IzbrisiOdeljenje/{idOdeljenja}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult> IzbrisiOdeljenje(int idOdeljenja)
    {
        var data = await DataProvider.ObrisiOdeljenjeAsync(idOdeljenja);
        
        if (data.IsError)
        {
            return StatusCode(data.Error.StatusCode, data.Error.Message);
        }

        return StatusCode(204, $"Izbrisano odeljenje, sa ID: {idOdeljenja}");
    }
}
