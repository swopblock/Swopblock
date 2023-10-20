using System;

namespace Swopblock;

public partial record Blockchain
{
    public static Blockchain LoadHistory

    (
        int NodeCount,

        int PrivateKeyCount,

        int PublicKeyCount,

        int ConfirmationCount,

        int CandidateCount,

        int AddressCount,

        int TransferCount
    )

    {
        var nodes = new Node[NodeCount];

        for (int i = 0; i < NodeCount; i++)
        {
            nodes[i] = Node.LoadHistory
            (
                NodeCount,

                PrivateKeyCount,

                PublicKeyCount,

                ConfirmationCount,

                CandidateCount,

                AddressCount,

                TransferCount
            );
        }

        var blockchain = new Blockchain(nodes);

        return blockchain;
    }

}

