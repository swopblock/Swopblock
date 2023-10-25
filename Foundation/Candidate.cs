using System;

namespace Swopblock;

public partial record Candidate
{
    public static Candidate SimulateHistory(int AddressCountAverage, int AddressCountDeviation)
    {
        return null;
    }

    public static Candidate LoadHistory
    (
        int AddressCount,

        int TransferCount
    )
    {
        var addresses = new Address[AddressCount];

        for (int i = 0; i < AddressCount; i++)
        {
            addresses[i] = Address.LoadHistory(TransferCount);
        }

        //var candidate = new Candidate(addresses);

        //return candidate;

        return null;
    }

}

