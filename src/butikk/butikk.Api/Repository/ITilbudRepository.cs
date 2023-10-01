using butikk.Api.Modeller.Enums;
using butikk.Kontrakter.HandleKurv;

namespace butikk.Api.Repository;

public interface ITilbudRepository
{
    TilbudType? HentTilbudBasertPaaVareType(PLU vareType);
}
