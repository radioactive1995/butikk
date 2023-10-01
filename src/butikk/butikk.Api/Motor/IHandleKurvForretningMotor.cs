using butikk.Kontrakter.HandleKurv;

namespace butikk.Api.Motor;

public interface IHandleKurvForretningMotor
{
    BeregneHandleKurvRespons BehandleBeregneHandleKurvForesporsel(BeregneHandleKurvForesporsel foresporsel);
}
