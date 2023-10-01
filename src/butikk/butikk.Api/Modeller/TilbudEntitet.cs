using butikk.Api.Modeller.Enums;
using butikk.Kontrakter.HandleKurv;

namespace butikk.Api.Modeller;

public class TilbudEntitet
{
    public List<PLU> VareTyper { get; set; } = new List<PLU>();
    public TilbudType TilbudType { get; set; }
}
