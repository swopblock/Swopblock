using System;

namespace Swopblock;

public partial record PrivateKey
{
    public static PrivateKey LoadHistory

    (
        int PrivateKeyCount,

        int PublicKeyCount,

        int ConfirmationCount,

        int CandidateCount,

        int AddressCount,

        int TransferCount
    )

    {
        var publicKeys = new PublicKey[PublicKeyCount];

        for (int i = 0; i < PublicKeyCount; i++)
        {
            publicKeys[i] = PublicKey.LoadHistory
            (
                ConfirmationCount,

                CandidateCount,

                AddressCount,

                TransferCount
            );
        }

        var privateKey = new PrivateKey(publicKeys);

        return privateKey;
    }

}

