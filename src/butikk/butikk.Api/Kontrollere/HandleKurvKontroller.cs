using butikk.Api.Motor;
using butikk.Kontrakter.HandleKurv;
using Microsoft.AspNetCore.Mvc;

namespace butikk.Api.Kontrollere;

[Route("api/handlekurv")]
[ApiController]
public class HandleKurvKontroller : ControllerBase
{
    private readonly IHandleKurvForretningMotor _motor;
    public HandleKurvKontroller(IHandleKurvForretningMotor motor)
    {
        _motor = motor ?? throw new ArgumentNullException(nameof(motor));
    }

    [HttpPost]
    public IActionResult TaImotBeregneHandleKurvForesporsel(BeregneHandleKurvForesporsel foresporsel)
    {
        var respons = _motor.BehandleBeregneHandleKurvForesporsel(foresporsel);

        return Ok(respons);
    }
}
