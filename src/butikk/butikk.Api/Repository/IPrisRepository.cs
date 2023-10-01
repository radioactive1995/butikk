using butikk.Api.Modeller;
using butikk.Kontrakter.HandleKurv;

namespace butikk.Api.Repository;

public interface IPrisRepository
{
    public PrisEntitet HentPrisBasertPaaPLU(PLU vareType);
}
