using System;

namespace Swopblock;

public partial record Node
{
    public static Node LoadHistory

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
        var privateKeys = new PrivateKey[PrivateKeyCount];

        for (int i = 0; i < PrivateKeyCount; i++)
        {
            privateKeys[i] = PrivateKey.LoadHistory
            (
                PrivateKeyCount,

                PublicKeyCount,

                ConfirmationCount,

                CandidateCount,

                AddressCount,

                TransferCount
            );
        }

        var node = new Node(privateKeys);

        return node;
    }

}

