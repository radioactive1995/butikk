using butikk.Kontrakter.HandleKurv;

namespace butikk.Api.Modeller;

public class PrisEntitet
{
    public PLU TypeVare { get; set; }
    public decimal EnhetsPris { get; set; }
    public decimal? PakkePris { get; set; }
}
