using butikk.Api.Kjerne;
using butikk.Api.Modeller;
using butikk.Api.Modeller.Enums;
using butikk.Api.Repository;
using butikk.Kontrakter.HandleKurv;

namespace butikk.Api.Motor;

public class HandleKurvForretningMotor : IHandleKurvForretningMotor
{
    private readonly IPrisRepository _prisRepository;
    private readonly ITilbudRepository _tilbudRepository;
    public HandleKurvForretningMotor(
        IPrisRepository prisRepository,
        ITilbudRepository tilbudRepository)
    {
        _prisRepository = prisRepository ?? throw new ArgumentNullException(nameof(prisRepository));
        _tilbudRepository = tilbudRepository ?? throw new ArgumentNullException( nameof(tilbudRepository));
    }
    public BeregneHandleKurvRespons BehandleBeregneHandleKurvForesporsel(BeregneHandleKurvForesporsel foresporsel)
    {
        var sum = 0m;

        foreach (var vare in foresporsel.Varer)
        {
            var prisEntitet = _prisRepository.HentPrisBasertPaaPLU(vare.TypeVare);
            var tilbudType = _tilbudRepository.HentTilbudBasertPaaVareType(vare.TypeVare);

            if (tilbudType is null)
            {
                BeregneUtenTilbud(ref sum, prisEntitet, vare);
                continue;
            }

            BeregneMedTilbud(ref sum, prisEntitet, tilbudType.Value, vare);
        }

        return new BeregneHandleKurvRespons(HjelpeMetoder.AvrundTilHelTall(sum));
    }

    private void BeregneUtenTilbud(ref decimal sum, PrisEntitet prisEntitet, VareDto vareDto)
    {
        sum += GrunnPrisUtregning(prisEntitet.EnhetsPris, vareDto.Antall);
    }

    private void BeregneMedTilbud(ref decimal sum, PrisEntitet prisEntitet, TilbudType tilbudType, VareDto vareDto)
    {
        if (tilbudType is TilbudType.TreStkPakkePris)
        {
            int antallTreStkPakkePriser = (int)vareDto.Antall / 3;
            int gjenvaarendeAntall = (int)vareDto.Antall - (antallTreStkPakkePriser * 3);

            sum += prisEntitet.PakkePris!.Value * antallTreStkPakkePriser;
            sum += GrunnPrisUtregning(prisEntitet.EnhetsPris, gjenvaarendeAntall);
        }

        else if (tilbudType is TilbudType.TreForTo)
        {
            int gjenvaarendeAntall = (int)vareDto.Antall - ((int)vareDto.Antall / 3);

            sum += GrunnPrisUtregning(prisEntitet.EnhetsPris, gjenvaarendeAntall);
        }
    }

    private decimal GrunnPrisUtregning(decimal enhetsPris, decimal antall)
        => enhetsPris * antall;
}
