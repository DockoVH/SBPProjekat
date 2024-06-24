using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZgradaLibrary.DTOs;
using ZgradaLibrary;

namespace ZgradaWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProstorController : ControllerBase
{
    [HttpGet]
    [Route("PreuzmiSveProstore")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetProstori()
    {
        var res = DataProvider.VratiSveProstore();

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok(res.Data);
    }

    [HttpGet]
    [Route("PreuzmiSveProstoreZgrade/{idZgrade}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetProstoriZgrade(int idZgrade)
    {
        var res = DataProvider.VratiSveProstoreZgrade(idZgrade);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok(res.Data);
    }

    [HttpGet]
    [Route("Lokal/PreuzmiSveLokaleZgrade/{idZgrade}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetLokaliiZgrade(int idZgrade)
    {
        var res = DataProvider.VratiSveLokaleUZgradi(idZgrade);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok(res.Data);
    }

    [HttpGet]
    [Route("Parking/PreuzmiSveParkingeZgrade/{idZgrade}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetParkinziZgrade(int idZgrade)
    {
        var res = DataProvider.VratiSveParkingeUZgradi(idZgrade);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok(res.Data);
    }

    [HttpGet]
    [Route("Stan/PreuzmiSveStanoveZgrade/{idZgrade}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetStanoviZgrade(int idZgrade)
    {
        var res = DataProvider.VratiSveStanoveUZgradi(idZgrade);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok(res.Data);
    }

    [HttpGet]
    [Route("PreuzmiProstor/{idProstora}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProstor(int idProstora)
    {
        var res = await DataProvider.VratiProstor(idProstora);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok(res.Data);
    }

    [HttpPost]
    [Route("Lokal/DodajLokal")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddLokal([FromBody] LokalPregled novi)
    {
        (bool isError, int id, var error) = await DataProvider.DodajProstor(novi);

        if (isError)
        {
            return StatusCode(error!.StatusCode, error.Message);
        }

        return Ok($"Uspešno dodat lokal sa ID: {id}");
    }

    [HttpPost]
    [Route("Parking/DodajParking")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddParking([FromBody] ParkingPregled novi)
    {
        (bool isError, int id, var error) = await DataProvider.DodajProstor(novi);

        if (isError)
        {
            return StatusCode(error!.StatusCode, error.Message);
        }

        return Ok($"Uspešno dodat parking sa ID: {id}");
    }

    [HttpPost]
    [Route("Stan/DodajStan")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddStan([FromBody] StanPregled novi)
    {
        (bool isError, int id, var error) = await DataProvider.DodajProstor(novi);

        if (isError)
        {
            return StatusCode(error!.StatusCode, error.Message);
        }

        return Ok($"Uspešno dodat stan sa ID: {id}");
    }

    [HttpPut]
    [Route("Lokal/AzurirajLokal")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateLokal([FromBody] LokalPregled lokal)
    {
        var res = await DataProvider.AzurirajProstor(lokal);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok("Uspešno ažuriran lokal.");
    }

    [HttpPut]
    [Route("Parking/AzurirajParking")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateParking([FromBody] ParkingPregled parking)
    {
        var res = await DataProvider.AzurirajProstor(parking);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok("Uspešno ažuriran parking.");
    }

    [HttpPut]
    [Route("Stan/AzurirajStan")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateStan([FromBody] StanPregled stan)
    {
        var res = await DataProvider.AzurirajProstor(stan);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok("Uspešno ažuriran stan.");
    }

    [HttpDelete]
    [Route("ObrisiProstor/{idProstora}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteProstor(int idProsotra)
    {
        var res = await DataProvider.ObrisiProstor(idProsotra);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok("Uspešno obrisan prostor.");
    }

    [HttpGet]
    [Route("ImeStanara/PreuzmiSveStanare")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetStanari()
    {
        var res = DataProvider.VratiSveStanare();

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok(res.Data);
    }

    [HttpGet]
    [Route("ImeStanara/PreuzmiSveStanareZgrade/{idZgrade}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetStanariZgrade(int idZgrade)
    {
        var res = DataProvider.VratiSveStanareUZgradi(idZgrade);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok(res.Data);
    }

    [HttpGet]
    [Route("ImeStanara/PreuzmiSveStanareStana/{idStana}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetStanariStana(int idStana)
    {
        var res = DataProvider.VratiSveStanareStana(idStana);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok(res.Data);
    }

    [HttpGet]
    [Route("ImeStanara/PreuzmiStanara/{idStanara}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetStanar(int idStanara)
    {
        var res = await DataProvider.VratiStanara(idStanara);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok(res.Data);
    }

    [HttpPost]
    [Route("ImeStanara/DodajStanara")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddStanar([FromBody] ImeStanaraPregled novi)
    {
        (bool isError, int id, var error) = await DataProvider.DodajStanara(novi);

        if (isError)
        {
            return StatusCode(error!.StatusCode, error.Message);
        }

        return Ok($"Uspešno dodat stanar sa ID: {id}");
    }

    [HttpPut]
    [Route("ImeStanara/AzurirajStanara")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateStanar([FromBody] ImeStanaraPregled stanar)
    {
        var res = await DataProvider.AzurirajStanara(stanar);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok("Uspešno ažuriran stanar.");
    }

    [HttpDelete]
    [Route("ImeStanara/ObrisiStanara/{idStanara}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteStanar(int idStanara)
    {
        var res = await DataProvider.ObrisiStanara(idStanara);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok("Uspešno obrisan stanar.");
    }
}