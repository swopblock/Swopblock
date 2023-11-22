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

public class TestSwopblockLedger
{
    [Fact]
    static async Task TestLedger()
    {
        var ledger = new SwopblockLedger();

        var tasks = new Task[100];

        for (int i = 0; i < tasks.Length; i++)
        {
            tasks[i] = Task.Run(() => Update(ledger));
        }

        await Task.WhenAll(tasks);

        Assert.Equal(2000, ledger.GetFaceValue(), 0);
    }

    static void Update(SwopblockLedger ledger)
    {
        decimal[] faceValues = { 0, 2, -3, 6, -2, -1, 8, -5, 11, -6 };

        foreach (var value in faceValues)
        {
            if (value >= 0)
            {
                ledger.Credit(value);
            }
            else
            {
                ledger.Debit(Math.Abs(value));
            }
        }
    }
}

