using butikk.Api.Modeller;
using butikk.Kontrakter.HandleKurv;
using butikk.Api.Modeller.Enums;

namespace butikk.Api.Repository;

public class TilbudRepository : ITilbudRepository
{
    private readonly List<TilbudEntitet> _tilbuder;

    public TilbudRepository()
    {
        _tilbuder = new List<TilbudEntitet>
        {
            new()
            {
                VareTyper = new() { PLU.A },
                TilbudType = TilbudType.TreForTo
            },

            new()
            {
                VareTyper = new() { PLU.B },
                TilbudType = TilbudType.TreStkPakkePris
            }
        };
    }

    public TilbudType? HentTilbudBasertPaaVareType(PLU vareType)
        => _tilbuder.FirstOrDefault(e => e.VareTyper.Any(x => x == vareType))?.TilbudType;
}
