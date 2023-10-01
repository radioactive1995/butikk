namespace butikk.Api.Kjerne;

public static class HjelpeMetoder
{
    public static ulong AvrundTilHelTall(decimal verdi)
        => (ulong)Math.Round(verdi);
}
