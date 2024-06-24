using Microsoft.AspNetCore.Mvc;
using ProdavnicaLibrary;
using ProdavnicaLibrary.DTOs;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProizvodController : ControllerBase
{
    [HttpGet]
    [Route("PreuzmiProizvode/{odeljenjeID}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult GetProizvod(int odeljenjeID)
    {
        (bool isError, var proizvodi, var error) = DataProvider.VratiProizvodeOdeljenjaDo5(odeljenjeID);

        if (isError)
        {
            return StatusCode(error?.StatusCode ?? 400, error?.Message);
        }

        return Ok(proizvodi);
    }

    [HttpPost]
    [Route("DodajSlagalicu/{odeljenjeID}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> AddSlagalicaToOdeljenje(int odeljenjeID, [FromBody] SlagalicaView s)
    {
        (bool isError, int id, var error) = await DataProvider.SacuvajSlagalicuAsync(s);

        if (isError)
        {
            return StatusCode(error?.StatusCode ?? 400, error?.Message);
        }

        (bool isError2, var slagalica, var error2) = await DataProvider.VratiSlagalicuAsync(id);
        (bool isError3, var odeljenje, var error3) = await DataProvider.VratiOdeljenjeDo5Async(odeljenjeID);

        if (isError2 || isError3)
        {
            return StatusCode(error2?.StatusCode ?? 400, $"{error2?.Message}{Environment.NewLine}{error3?.Message}");
        }

        if (slagalica == null || odeljenje == null)
        {
            return BadRequest("Odeljenje ili slagalica nisu validni.");
        }

        var povezi = new ProdajeSeView
        {
            ProdajeOdeljenje = odeljenje,
            ProdajeProzivod = slagalica
        };

        var data = await DataProvider.SacuvajProdajeSeAsync(povezi);

        if (data.IsError)
        {
            return StatusCode(data.Error.StatusCode, data.Error.Message);
        }

        return StatusCode(201, $"Uspešno upisana slagalica i povezana sa odeljenjem: {data.Data}.");
    }

    [HttpPost]
    [Route("DodajSlagalicu")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> AddSlagalica([FromBody] SlagalicaView s)
    {
        (bool isError, int id, var error) = await DataProvider.SacuvajSlagalicuAsync(s);

        if (isError)
        {
            return StatusCode(error?.StatusCode ?? 400, error?.Message);
        }

        return StatusCode(201, $"Sačuvana je slagalica sa ID: {id}");
    }

    [HttpPost]
    [Route("PoveziSlagalicuIOdeljenje/{slagalicaID}/{odeljenjeID}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> LinkSlagalicaToOdeljenje(int slagalicaID, int odeljenjeID)
    {
        (bool isError1, var slagalica, var error1) = await DataProvider.VratiSlagalicuAsync(slagalicaID);
        (bool isError2, var odeljenje, var error2) = await DataProvider.VratiOdeljenjeDo5Async(odeljenjeID);

        if (isError1 || isError2)
        {
            return StatusCode(error1?.StatusCode ?? 400, $"{error1?.Message}{Environment.NewLine}{error2?.Message}");
        }

        if (odeljenje == null || slagalica == null)
        {
            return BadRequest("Nevalidno odeljenje ili slagalica.");
        }

        var povezi = new ProdajeSeView
        {
            ProdajeOdeljenje = odeljenje,
            ProdajeProzivod = slagalica
        };
        
        var data = await DataProvider.SacuvajProdajeSeAsync(povezi);

        if (data.IsError)
        {
            return StatusCode(data.Error.StatusCode, data.Error.Message);
        }

        return Ok($"Uspešno povezana slagalica sa odeljenjem na kome se prodaje: {data.Data}.");
    }

    [HttpPut]
    [Route("PromeniSlagalicu")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> ChangeProizvod([FromBody] SlagalicaView s)
    {
        (bool isError, var slagalica, var error) = await DataProvider.AzurirajSlagalicuAsync(s);

        if (isError)
        {
            return StatusCode(error?.StatusCode ?? 400, error?.Message);
        }

        return Ok(slagalica);
    }

    [HttpDelete]
    [Route("IzbrisiSlagalicu/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> DeleteSlagalica(int id)
    {
        var data = await DataProvider.ObrisiProizvodAsync(id);

        if (data.IsError)
        {
            return StatusCode(data.Error.StatusCode, data.Error.Message);
        }

        return StatusCode(204, $"Uspešno izbrisan proizvod sa ID: {id}");
    }
}
