using Swopblock.Alpha;

namespace TestTeller;

// save this idea here: text messages and binary messages

public record TestSwoblAutoTill() : AutoTill("USD", new TestUsdAccount());

public record TestBtcMessage() : Message()
{
    public static TestBtcMessage[] History()
    {
        var messages = new TestBtcMessage[2];

        messages[0] = new TestBtcMessage();

        messages[1] = new TestBtcMessage();

        return messages;
    }
}

public record TestEthMessage() : Message()
{
    public static TestEthMessage[] History()
    {
        var messages = new TestEthMessage[2];

        messages[0] = new TestEthMessage();

        messages[1] = new TestEthMessage();

        return messages;
    }
}


public record TestBtcMarket() : Markets("BTC", TestBtcMessage.History());

public record TestEthMarket() : Markets("ETH", TestEthMessage.History());


public record TestBtcPublicLock() : PublicLock();

public record TestEthPublicLock() : PublicLock();

public record TestUsdPublicLock() : PublicLock();


public record TestBtcPrivateKey() : PrivateKey();

public record TestEthPrivateKey() : PrivateKey();

public record TestUsdPrivateKey() : PrivateKey();


public record TestBtcAccount()

    : Account("BTC", new TestBtcPublicLock(), new TestEthPrivateKey());

public record TestEthAccount()

    : Account("ETH", new TestEthPublicLock(), new TestEthPrivateKey());

public record TestUsdAccount()

    : Account("USD", new TestUsdPublicLock(), new TestUsdPrivateKey());


public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        //var till = new AutoTill();

        var accounts = new Account[2];

        var markets = new Markets[3];

        //var btcMarket = new TestBtcMarket();

        //markets[0] = btcMarket;
    }
}
