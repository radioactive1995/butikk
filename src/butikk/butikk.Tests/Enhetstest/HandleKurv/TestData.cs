namespace butikk.Tests.Enhetstest.HandleKurv;

public static class TestData
{

    public static IEnumerable<object[]> HandleKurvSimuleringer()
    {
        yield return new object[]
        {
        new VareDto[]
        {
            new VareDto(
                TypeVare: PLU.A,
                Antall: 5),
            new VareDto(
                TypeVare: PLU.B,
                Antall: 2),
            new VareDto(
                TypeVare: PLU.C,
                Antall: 2.32m),
        },
        1083
        };

        yield return new object[]
        {
            new VareDto[]
        {
            new VareDto(
                TypeVare: PLU.A,
                Antall: 1),
            new VareDto(
                TypeVare: PLU.B,
                Antall: 3),
            new VareDto(
                TypeVare: PLU.C,
                Antall: 0.12m),
        },
        1061
        };

        yield return new object[]
        {
        new VareDto[]
        {
            new VareDto(
                TypeVare: PLU.A,
                Antall: 1),
            new VareDto(
                TypeVare: PLU.B,
                Antall: 2),
        },
        858
        };

        yield return new object[]
        {
        new VareDto[]
        {
            new VareDto(
                TypeVare: PLU.B,
                Antall: 23),
        },
        7791
        };
    }

}
