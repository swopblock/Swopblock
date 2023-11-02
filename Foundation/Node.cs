using System;

namespace Swopblock;

public partial record Node
{
    public static Node SimulateHistory(int ConfirmationCountAverage, int ConfirmationCountDeviation)
    {
        return null;
    }


    public static Node LoadHistory

    (
        int NodeCount,

        int ConfirmationCount,

        int CandidateCount,

        int AddressCount,

        int TransferCount
    )

    {
        var privateKeys = new Confirmation[ConfirmationCount];

        for (int i = 0; i < ConfirmationCount; i++)
        {
        }

        // node = new Node(privateKeys);

        //return node;

        return null;
    }

}

public record BtcNode(HashSet<Confirmation> Confirmations): Node(Confirmations)
{

}

public record EthNode(HashSet<Confirmation> Confirmations) : Node(Confirmations)
{

}