using Swopblock;

namespace Testing;

public class TestNetwork
{
    [Fact]
    public void TestCreateGenesis()
    {
        var genesisNetwork = Network.CreateGenesis();

        Assert.NotNull(genesisNetwork);
    }

    [Fact]
    public void TestGenesisBaseValue()
    {
        var genesisNetwork = Network.CreateGenesis();

        //var baseValues = genesisNetwork.BaseValues;
    }
}
