using butikk.Api.Repository;
using static butikk.Tests.Enhetstest.HandleKurv.TestData;

namespace butikk.Tests.Enhetstest.HandleKurv;

public class HandleKurvForretningMotorTests
{
    private readonly IHandleKurvForretningMotor _motor 
        = new HandleKurvForretningMotor(new PrisRepository(), new TilbudRepository());

    [Fact]
    public void Motor_Skal_Returnere_Gyldig_Respons()
    {
        //arrange
        var foresporsel = new BeregneHandleKurvForesporsel(new VareDto[] {});

        //act
        var respons = _motor.BehandleBeregneHandleKurvForesporsel(foresporsel);

        //assert
        Assert.True(respons is BeregneHandleKurvRespons);
    }

    [Theory]
    [MemberData(nameof(HandleKurvSimuleringer), MemberType = typeof(TestData))]
    public void Motor_Skal_Returnere_Riktig_Beregnet_Sum(VareDto[] varer, ulong fasitSum)
    {
        //arrange
        var foresporsel = new BeregneHandleKurvForesporsel(varer);

        //act
        var respons = _motor.BehandleBeregneHandleKurvForesporsel(foresporsel);

        //assert
        Assert.Equal(respons.BeregnetSum, fasitSum);
    }
}
