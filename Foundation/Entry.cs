using System;
namespace Swopblock;

public partial record Entries
{
    public static Entries SimulateHistory()
    {
        return null;
    }

    public static Entries LoadHistory()
    {
        var transfer  = new Entries();

        return transfer;
    }

    public static Entries NewRandomEntry()
    {
        return new Entries();
    }

}

public record BtcTransfer: Entries
{

}

public record EthTransfer : Entries
{

}