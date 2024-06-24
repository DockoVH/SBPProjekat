using Microsoft.AspNetCore.Mvc;
using ProdavnicaLibrary;
using ProdavnicaLibrary.DTOs;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class RadnikController : ControllerBase
{
    [HttpGet]
    [Route("PreuzmiSveRadnike")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> GetRadnici()
    {
        var radnici = await DataProvider.VratiSveRadnikeAsync();

        if (radnici.IsError)
        {
            return StatusCode(radnici.Error.StatusCode, radnici.Error.Message);
        }

        return Ok(radnici.Data);
    }

    [HttpGet]
    [Route("PreuzmiSveRadnikeProdavnice/{prodavnicaID}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult GetRadniciProdavnice(int prodavnicaID)
    {
        (bool isError, var radnici, var error) = DataProvider.VratiSveRadnikeProdavnice(prodavnicaID);

        if (isError)
        {
            return StatusCode(error?.StatusCode ?? 400, error?.Message);
        }

        return Ok(radnici);
    }

    [HttpGet]
    [Route("PreuzmiSefoveProdavnice/{prodavnicaID}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> PreuzmiSefoveProdavnice(int prodavnicaID)
    {
        (bool isError, var radnici, var error) = await DataProvider.VratiSveSefoveProdavniceAsync(prodavnicaID);
        
        if (isError)
        {
            return StatusCode(error?.StatusCode ?? 400, error?.Message);
        }

        return Ok(radnici);
    }

    [HttpGet]
    [Route("RadiUProdavnice/{radnikID}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult RadiUProdavnice(int radnikID)
    {
        (bool isError, var radnici, var error) = DataProvider.RadiUProdavnice(radnikID);

        if (isError)
        {
            return StatusCode(error?.StatusCode ?? 400, error?.Message);
        }

        return Ok(radnici);
    }

    [HttpPost]
    [Route("DodajRadnika")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> AddRadnik([FromBody] RadnikView r)
    {
        var data = await DataProvider.DodajRadnikaAsync(r);

        if (data.IsError)
        {
            return StatusCode(data.Error.StatusCode, data.Error.Message);
        }

        return StatusCode(201, $"Uspešno dodat radnik: {r.Ime}");
    }

    [HttpPost]
    [Route("PoveziRadnika/{radnikID}/{prodavnicaID}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> LinkRadnik(int radnikID, int prodavnicaID)
    {
        (bool isError1, var radnik, var error1) = await DataProvider.VratiRadnikaAsync(radnikID);
        (bool isError2, var prodavnica, var error2) = await DataProvider.VratiProdavnicuAsync(prodavnicaID);

        if (isError1 || isError2)
        {
            return StatusCode(error1?.StatusCode ?? 400, $"{error1?.Message}{Environment.NewLine}{error2?.Message}");
        }

        if (radnik == null || prodavnica == null)
        {
            return BadRequest("Radnik ili prodavnica nisu validni.");
        }

        var data = await DataProvider.DodajRadniOdnosAsync(new RadiUView
        {
            // Datum bi trebalo da se šalje putem parametra
            DatumOd = DateTime.Now.AddYears(-1),
            DatumDo = DateTime.Now.AddDays(1),

            Id = new RadiUIdView
            {
                RadiUProdavnica = prodavnica,
                RadnikRadiU = radnik
            }
        });

        if (data.IsError)
        {
            return StatusCode(data.Error.StatusCode, data.Error.Message);
        }

        return Ok($"Dodat radni odnos. Radnik: {radnik.Ime} {radnik.Prezime}. Prodavnica: {prodavnica.Naziv}");
    }

    [HttpDelete]
    [Route("IzbrisiRadnika/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> DeleteRadnik(int id)
    {
        var data = await DataProvider.ObrisiRadnikaIzSistemaAsync(id);

        if (data.IsError)
        {
            return StatusCode(data.Error.StatusCode, data.Error.Message);
        }

        return StatusCode(204, $"Uspešno obrisan radnik: {data.Data}.");
    }
}
