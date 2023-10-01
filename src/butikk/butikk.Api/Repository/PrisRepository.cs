using butikk.Api.Modeller;
using butikk.Kontrakter.HandleKurv;

namespace butikk.Api.Repository;

public class PrisRepository : IPrisRepository
{
    private readonly List<PrisEntitet> _priser;

    public PrisRepository()
    {
        _priser = new List<PrisEntitet>
        {
            new()
            {
                TypeVare = PLU.A,
                EnhetsPris = 59.90m
            },

            new()
            {
                TypeVare = PLU.B,
                EnhetsPris = 399,
                PakkePris = 999
            },

            new()
            {
                TypeVare = PLU.C,
                EnhetsPris = 19.54m
            }
        };
    }

    public PrisEntitet HentPrisBasertPaaPLU(PLU vareType)
    {
        return _priser.First(e => e.TypeVare == vareType);
    }
}
