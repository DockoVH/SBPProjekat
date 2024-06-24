using Microsoft.AspNetCore.Mvc;
using ZgradaLibrary.DTOs;
using ZgradaLibrary;

namespace ZgradaWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class OsobaController : ControllerBase
{
    [HttpGet]
    [Route("PreuzmiSveOsobe")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetOsobe()
    {
        var res = DataProvider.VratiSveOsobe();

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok(res.Data);
    }

    [HttpGet]
    [Route("Zaposleni/PreuzmiSveZaposlene")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetZaposlene()
    {
        var res = DataProvider.VratiSveZaposlene();

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok(res.Data);
    }

    [HttpGet]
    [Route("Upravnik/PreuzmiSveUpravnike")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetUpravnici()
    {
        var res = DataProvider.VratiSveUpravnike();

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok(res.Data);
    }

    [HttpGet]
    [Route("Upravnik/PreuzmiSveUpravnikeZgrade/{idZgrade}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetUpravniciZgrade(int idZgrade)
    {
        var res = DataProvider.VratiSveUpravnikeZgrade(idZgrade);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok(res.Data);
    }

    [HttpGet]
    [Route("Zaposleni/PreuzmiZaposlenog/{jmbgZaposlenog}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetZaposleni(string jmbgZaposlenog)
    {
        var res = await DataProvider.VratiZaposlenog(jmbgZaposlenog);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok(res.Data);
    }

    [HttpPost]
    [Route("Zaposleni/DodajZaposlenog")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddZaposleni([FromBody] ZaposleniPregled novi)
    {
        (bool isError, string? id, var error) = await DataProvider.DodajZaposlenog(novi);

        if (isError)
        {
            return StatusCode(error!.StatusCode, error.Message);
        }

        return Ok($"Uspešno dodat zaposleni sa JMBG: {id}");
    }

    [HttpPut]
    [Route("Zaposleni/AzurirajZaposlenog")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateZaposleni([FromBody] ZaposleniPregled zaposleni)
    {
        var res = await DataProvider.AzurirajZaposlenog(zaposleni);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok("Uspešno ažuriran zaposleni.");
    }

    [HttpDelete]
    [Route("Zaposleni/ObrisiZaposlenog/{jmbgZaposlenog}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteZaposleni(string jmbgZaposlenog)
    {
        var res = await DataProvider.ObrisiZaposlenog(jmbgZaposlenog);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok("Uspešno obrisan zaposleni.");
    }

    [HttpGet]
    [Route("Licenca/PreuzmiSveLicence")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GeLicence()
    {
        var res = DataProvider.VratiSveLicence();

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok(res.Data);
    }

    [HttpGet]
    [Route("Licenca/PreuzmiSveLicenceUpravnika/{jmbgUpravnika}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetLicenceUpravnika(string jmbgUpravnika)
    {
        var res = DataProvider.VratiSveLicenceUpravnika(jmbgUpravnika);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok(res.Data);
    }

    [HttpGet]
    [Route("Licenca/PreuzmiLicencu/{idLicence}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetLicenca(int idLicence)
    {
        var res = await DataProvider.VratiLicencu(idLicence);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok(res.Data);
    }

    [HttpPost]
    [Route("Licenca/DodajLicencu")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddClanSkupstine([FromBody] LicencaPregled nova)
    {
        (bool isError, int id, var error) = await DataProvider.DodajLicencu(nova);

        if (isError)
        {
            return StatusCode(error!.StatusCode, error.Message);
        }

        return Ok($"Uspešno dodata licenca sa ID: {id}");
    }

    [HttpPut]
    [Route("Licenca/AzurirajLicencu")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateLicenca([FromBody] LicencaPregled licenca)
    {
        var res = await DataProvider.AzurirajLicencu(licenca);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok("Uspešno ažurirana licenca.");
    }

    [HttpDelete]
    [Route("Licenca/ObrisiLicencu/{idLicence}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteLicenca(int idLicence)
    {
        var res = await DataProvider.ObrisiLicencu(idLicence);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok("Uspešno obrisana licenca.");
    }

    [HttpGet]
    [Route("Obrazovanje/PreuzmiSvaObrazovanja")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetObrazovanja()
    {
        var res = DataProvider.VratiSvaObrazovanja();

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok(res.Data);
    }

    [HttpGet]
    [Route("Obrazovanje/PreuzmiSvaObrazovanjaUpravnika/{jmbgUpravnika}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetObrazovanjaUpravnika(string jmbgUpravnika)
    {
        var res = DataProvider.VratiSvaObrazovanjaUpravnika(jmbgUpravnika);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok(res.Data);
    }

    [HttpGet]
    [Route("Obrazovanja/PreuzmiObrazovanje/{idObrazovanja}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetObrazovanje(int idObrazovanja)
    {
        var res = await DataProvider.VratiObrazovanje(idObrazovanja);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok(res.Data);
    }

    [HttpPost]
    [Route("Obrazovanje/DodajObrazovanje")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddObrazovanje([FromBody] ObrazovanjePregled novo)
    {
        (bool isError, int id, var error) = await DataProvider.DodajObrazovanje(novo);

        if (isError)
        {
            return StatusCode(error!.StatusCode, error.Message);
        }

        return Ok($"Uspešno dodato obrazovanje sa ID: {id}");
    }

    [HttpPut]
    [Route("Obrazovanje/AzurirajObrazovanje")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateObrazovanje([FromBody] ObrazovanjePregled obrazovanje)
    {
        var res = await DataProvider.AzurirajObrazovanje(obrazovanje);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok("Uspešno ažurirano obrazovanje.");
    }

    [HttpDelete]
    [Route("ObrazovanjeObrisiObrazovanje/{idObrazovanja}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteObrazovanje(int idObrazovanja)
    {
        var res = await DataProvider.ObrisiObrazovanje(idObrazovanja);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok("Uspešno obrisano obrazovanje.");
    }

    [HttpGet]
    [Route("Telefon/PreuzmiSveTelefoneOsobe/{jmbgOsobe}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetTelefoneOsobe(string jmbgOsobe)
    {
        var res = DataProvider.VratiSveTelefoneOsobe(jmbgOsobe);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok(res.Data);
    }

    [HttpGet]
    [Route("Telefon/PreuzmiTelefon/{idTelefona}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetTelefon(int idTelefona)
    {
        var res = await DataProvider.VratiTelefonOsobe(idTelefona);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok(res.Data);
    }

    [HttpPost]
    [Route("Telefon/DodajTelefon")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddTelefon([FromBody] TelefonPregled novi)
    {
        (bool isError, int id, var error) = await DataProvider.DodajTelefonOsobi(novi);

        if (isError)
        {
            return StatusCode(error!.StatusCode, error.Message);
        }

        return Ok($"Uspešno dodat broj telefona sa ID: {id}");
    }

    [HttpPut]
    [Route("Telefon/AzurirajTelefon")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateTelefon([FromBody] TelefonPregled telefon)
    {
        var res = await DataProvider.AzurirajTelefonOsobe(telefon);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok("Uspešno ažuriran broj telefona.");
    }

    [HttpDelete]
    [Route("Telefon/ObrisiTelefon/{idTelefona}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteTelefon(int idTelefona)
    {
        var res = await DataProvider.ObrisiTelefonOsobe(idTelefona);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok("Uspešno obrisan broj telefona.");
    }
}