using Microsoft.AspNetCore.Mvc;
using ZgradaLibrary;
using ZgradaLibrary.DTOs;

namespace ZgradaWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ZgradaController : ControllerBase
{
    [HttpGet]
    [Route("PreuzmiSveZgrade")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetZgrade()
    {
        var zgrade = DataProvider.VratiSveZgrade();

        if(zgrade.IsError)
        {
            return StatusCode(zgrade.Error.StatusCode, zgrade.Error.Message);
        }

        return Ok(zgrade.Data);
    }

    [HttpGet]
    [Route("PreuzmiZgradu/{idZgrade}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetZgrada(int idZgrade)
    {
        var zgrada = await DataProvider.VratiZgradu(idZgrade);

        if(zgrada.IsError)
        {
            return StatusCode(zgrada.Error.StatusCode, zgrada.Error.Message);
        }

        return Ok(zgrada.Data);
    }

    [HttpPost]
    [Route("DodajZgradu")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddZgrada([FromBody] ZgradaPregled zgrada)
    {
        (bool isError, int id, var error)= await DataProvider.DodajZgradu(zgrada);

        if (isError)
        {
            return StatusCode(error?.StatusCode ?? 400, error?.Message);
        }

        return Ok($"Uspešno dodata zgrada sa ID: {id}.");
    }

    [HttpPut]
    [Route("AzurirajZgradu")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateZgrada([FromBody] ZgradaPregled zgrada)
    {
        (bool isError, bool _, var error) = await DataProvider.AzurirajZgradu(zgrada);

        if (isError)
        {
            return StatusCode(error?.StatusCode ?? 400, error?.Message);
        }

        return Ok("Uspešno ažurirana zgrada.");
    }

    [HttpDelete]
    [Route("ObrisiZgradu/{idZgrade}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteZgrada(int idZgrade)
    {
        (bool isError, bool _, var error) = await DataProvider.ObrisiZgradu(idZgrade);

        if (isError)
        {
            return StatusCode(error?.StatusCode ?? 400, error?.Message);
        }

        return Ok($"Uspešno obrisana zgrada.");
    }

    [HttpGet]
    [Route("Ulaz/PreuzmiSveUlazeZgrade/{idZgrade}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetUlaziZgrade(int idZgrade)
    {
        var ulazi = DataProvider.VratiSveUlazeZgrade(idZgrade);

        if (ulazi.IsError)
        {
            return StatusCode(ulazi.Error.StatusCode, ulazi.Error.Message);
        }

        return Ok(ulazi.Data);
    }

    [HttpGet]
    [Route("Ulaz/PreuzmiUlaz/{idUlaza}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUlaz(int idUlaza)
    {
        var ulaz = await DataProvider.VratiUlaz(idUlaza);

        if (ulaz.IsError)
        {
            return StatusCode(ulaz.Error.StatusCode, ulaz.Error.Message);
        }

        return Ok(ulaz.Data);
    }

    [HttpPost]
    [Route("Ulaz/DodajUlaz")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddUlaz([FromBody] UlazPregled novi)
    {
        (bool isError, int id, var error) = await DataProvider.DodajUlaz(novi);

        if (isError)
        {
            return StatusCode(error!.StatusCode, error.Message);
        }

        return Ok($"Uspešno dodat ulaz sa ID: {id}");
    }

    [HttpPut]
    [Route("Ulaz/AzurirajUlaz")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateUlaz([FromBody] UlazPregled ulaz)
    {
        var u = await DataProvider.AzurirajUlaz(ulaz);

        if (u.IsError)
        {
            return StatusCode(u.Error.StatusCode, u.Error.Message);
        }

        return Ok("Uspešno ažuriran ulaz.");
    }

    [HttpDelete]
    [Route("Ulaz/ObrisiUlaz/{idUlaza}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteUlaz(int idUlaza)
    {
        var zgrada = await DataProvider.ObrisiUlaz(idUlaza);

        if (zgrada.IsError)
        {
            return StatusCode(zgrada.Error.StatusCode, zgrada.Error.Message);
        }

        return Ok("Uspešno obrisan ulaz.");
    }

    [HttpGet]
    [Route("Ugovor/PreuzmiSveUgovore")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetUgovori()
    {
        var ugovori = DataProvider.VratiSveUgovore();

        if (ugovori.IsError)
        {
            return StatusCode(ugovori.Error.StatusCode, ugovori.Error.Message);
        }

        return Ok(ugovori.Data);
    }

    [HttpGet]
    [Route("Ugovor/PreuzmiSveUgovoreZgrade/{idZgrade}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetUgovoriZgrade(int idZgrade)
    {
        var ugovori = DataProvider.VratiSveUgovoreZgrade(idZgrade);

        if (ugovori.IsError)
        {
            return StatusCode(ugovori.Error.StatusCode, ugovori.Error.Message);
        }

        return Ok(ugovori.Data);
    }

    [HttpGet]
    [Route("Ugovor/PreuzmiUgovor/{sifraUgovora}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUgovor(int sifraUgovora)
    {
        var ugovor = await DataProvider.VratiUgovor(sifraUgovora);

        if (ugovor.IsError)
        {
            return StatusCode(ugovor.Error.StatusCode, ugovor.Error.Message);
        }

        return Ok(ugovor.Data);
    }

    [HttpPost]
    [Route("Ugovor/DodajUgovor")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddUgovor([FromBody] UgovorPregled novi)
    {
        (bool isError, int id, var error) = await DataProvider.DodajUgovor(novi);

        if (isError)
        {
            return StatusCode(error!.StatusCode, error.Message);
        }

        return Ok($"Uspešno dodat ugovor sa šifrom: {id}");
    }

    [HttpPut]
    [Route("Ugovor/AzurirajUgovor")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateUgovor([FromBody] UgovorPregled ugovor)
    {
        var u = await DataProvider.AzurirajUgovor(ugovor);

        if (u.IsError)
        {   
            return StatusCode(u.Error.StatusCode, u.Error.Message);
        }

        return Ok("Uspešno ažuriran ugovor.");
    }

    [HttpDelete]
    [Route("Ugovor/ObrisiUgovor/{sifraUgovora}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteUgovor(int sifraUgovora)
    {
        var ugovor = await DataProvider.ObrisiUgovor(sifraUgovora);

        if (ugovor.IsError)
        {
            return StatusCode(ugovor.Error.StatusCode, ugovor.Error.Message);
        }

        return Ok("Uspešno obrisan ugovor.");
    }

    [HttpGet]
    [Route("Sprat/PreuzmiSveSpratove")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetSpratovi()
    {
        var spratovi = DataProvider.VratiSveSpratove();

        if (spratovi.IsError)
        {
            return StatusCode(spratovi.Error.StatusCode, spratovi.Error.Message);
        }

        return Ok(spratovi.Data);
    }

    [HttpGet]
    [Route("Sprat/PreuzmiSveSpratoveZgrade/{idZgrade}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetSpratoviZgrade(int idZgrade)
    {
        var spratovi = DataProvider.VratiSveSpratoveUZgradi(idZgrade);

        if (spratovi.IsError)
        {
            return StatusCode(spratovi.Error.StatusCode, spratovi.Error.Message);
        }

        return Ok(spratovi.Data);
    }

    [HttpGet]
    [Route("Sprat/PreuzmiSprat/{idSprata}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSprat(int idSprata)
    {
        var res = await DataProvider.VratiSprat(idSprata);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok(res.Data);
    }

    [HttpPost]
    [Route("Sprat/DodajSprat")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddSprat([FromBody] SpratPregled novi)
    {
        (bool isError, int id, var error) = await DataProvider.DodajSprat(novi);

        if (isError)
        {
            return StatusCode(error!.StatusCode, error.Message);
        }

        return Ok($"Uspešno dodat sprat sa ID: {id}");
    }

    [HttpPut]
    [Route("Sprat/AzurirajSprat")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateSprat([FromBody] SpratPregled sprat)
    {
        var res = await DataProvider.AzurirajSprat(sprat);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok("Uspešno ažuriran sprat.");
    }

    [HttpDelete]
    [Route("Sprat/ObrisiSprat/{idSprata}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteSprat(int idSprata)
    {
        var res = await DataProvider.ObrisiSprat(idSprata);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok("Uspešno obrisan sprat.");
    }

    [HttpGet]
    [Route("SkupstinaStanara/PreuzmiSveClanoveSkupstine")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetSkupstinaStanara()
    {
        var res = DataProvider.VratiSveClanoveSkupstineStanara();

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok(res.Data);
    }

    [HttpGet]
    [Route("SkupstinaStanara/PreuzmiSveClanoveSkupstineZgrade/{idZgrade}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetSkupstinaStanaraZgrade(int idZgrade)
    {
        var res = DataProvider.VratiSveClanoveSkupstineStanaraUZgradi(idZgrade);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok(res.Data);
    }

    [HttpGet]
    [Route("SkupstinaStanara/PreuzmiClanaSkupstine/{idClana}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetClanSkupstine(int idClana)
    {
        var res = await DataProvider.VratiClanaSkupstine(idClana);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok(res.Data);
    }

    [HttpPost]
    [Route("SkupstinaStanara/DodajClanaSkupstineStanara")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddClanSkupstine([FromBody] SkupstinaStanaraPregled novi)
    {
        (bool isError, int id, var error) = await DataProvider.DodajClanaSkupstineStanara(novi);

        if (isError)
        {
            return StatusCode(error!.StatusCode, error.Message);
        }

        return Ok($"Uspešno dodat član skupštine stanara sa ID: {id}");
    }

    [HttpPut]
    [Route("SkupstinaStanara/AzurirajClanaSkupstineStanara")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateClanSkupstine([FromBody] SkupstinaStanaraPregled clan)
    {
        var res = await DataProvider.AzurirajClanaSkupstineStanara(clan);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok("Uspešno ažuriran član skupštine stanara.");
    }

    [HttpDelete]
    [Route("SkupstinaStanara/ObrisiClanaSkupstineStanara/{idClana}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteClanSkupstine(int idClana)
    {
        var res = await DataProvider.ObrisiClanaSkupstineStanara(idClana);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok("Uspešno obrisan član skupštine stanara.");
    }

    [HttpGet]
    [Route("Lift/PreuzmiSveLiftove")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetLiftovi()
    {
        var res = DataProvider.VratiSveLiftove();

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok(res.Data);
    }

    [HttpGet]
    [Route("Lift/PreuzmiSveLiftoveZgrade/{idZgrade}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetLiftoviZgrade(int idZgrade)
    {
        var res = DataProvider.VratiSveLiftoveUZgradi(idZgrade);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok(res.Data);
    }

    [HttpGet]
    [Route("Lift/PreuzmiSveTeretneLiftoveUZgradi/{idZgrade}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetTeretniLiftoviZgrade(int idZgrade)
    {
        var res = DataProvider.VratiSveTeretneLiftoveUZgradi(idZgrade);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok(res.Data);
    }

    [HttpGet]
    [Route("Lift/PreuzmiSveLiftoveZaLjudeUZgradi/{idZgrade}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetLiftoviZaLjudeZgrade(int idZgrade)
    {
        var res = DataProvider.VratiSveLiftoveZaLjudeUZgradi(idZgrade);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok(res.Data);
    }

    [HttpGet]
    [Route("Lift/PreuzmiLift/{serijskiBrojLifta}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetLift(int serijskiBrojLifta)
    {
        var res = await DataProvider.VratiLift(serijskiBrojLifta);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok(res.Data);
    }

    [HttpPost]
    [Route("Lift/DodajLiftTeretni")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddLiftTeretni([FromBody] LiftTeretniPregled novi)
    {
        (bool isError, int id, var error) = await DataProvider.DodajLift(novi);

        if (isError)
        {
            return StatusCode(error!.StatusCode, error.Message);
        }

        return Ok($"Uspešno dodat teretni lift sa serijskim brojem: {id}");
    }

    [HttpPost]
    [Route("Lift/DodajLiftZaLjude")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddLiftZaLjude([FromBody] LiftZaLjudePregled novi)
    {
        (bool isError, int id, var error) = await DataProvider.DodajLift(novi);

        if(isError)
        {
            return StatusCode(error!.StatusCode, error.Message);
        }

        return Ok($"Uspešno dodat lift za ljude sa serijskim brojem: {id}");
    }

    [HttpPut]
    [Route("Lift/AzurirajLiftTeretni")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateLiftTeretni([FromBody] LiftTeretniPregled lift)
    {
        var res = await DataProvider.AzurirajLift(lift);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok("Uspešno ažuriran teretni lift.");
    }

    [HttpPut]
    [Route("Lift/AzurirajLiftZaLjude")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateLiftZaLjude([FromBody] LiftZaLjudePregled lift)
    {
        var res = await DataProvider.AzurirajLift(lift);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok("Uspešno ažuriran teretni lift.");
    }

    [HttpDelete]
    [Route("Lift/ObrisiLift/{serijskiBrojLifta}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteLift(int serijskiBrojLifta)
    {
        var res = await DataProvider.ObrisiLift(serijskiBrojLifta);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok("Uspešno obrisan lift.");
    }

    [HttpGet]
    [Route("Angazovanje/PreuzmiSvaAngazovanja")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetAngazovanja()
    {
        var res = DataProvider.VratiSvaAngazovanja();

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok(res.Data);
    }

    [HttpGet]
    [Route("Angazovanje/PreuzmiSvaAngazovanjaZgrade/{idZgrade}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetAngazovanjaZgrade(int idZgrade)
    {
        var res = DataProvider.VratiSvaAngazovanjaZgrade(idZgrade);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok(res.Data);
    }

    [HttpGet]
    [Route("Angazovanje/PreuzmiAngazovanje{idZgrade}/{jmbgUpravnika}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetAngazovanje(int idZgrade, string jmbgUpravnika)
    {
        var res = DataProvider.VratiAngazovanje(idZgrade, jmbgUpravnika);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok(res.Data);
    }

    [HttpPost]
    [Route("Angazovanje/DodajAngazovanje/{idZgrade}/{jmbgUpravnika}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddAngazovanje(int idZgrade, string jmbgUpravnika)
    {
        (bool isError, _, var error) = await DataProvider.DodajAngazovanje(jmbgUpravnika, idZgrade);

        if (isError)
        {
            return StatusCode(error!.StatusCode, error.Message);
        }

        return Ok("Uspešno dodato angažovanje.");
    }

    [HttpDelete]
    [Route("Angazovanje/ObrisiAngazovanje/{idZgrade}/{jmbgUpravnika}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAngazovanje(int idZgrade, string jmbgUpravnika)
    {
        var res = await DataProvider.ObrisiAngazovanje(jmbgUpravnika, idZgrade);

        if (res.IsError)
        {
            return StatusCode(res.Error.StatusCode, res.Error.Message);
        }

        return Ok("Uspešno obrisano angažovanje.");
    }
}