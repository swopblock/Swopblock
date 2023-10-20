using System;

namespace Swopblock;

public partial record PublicKey
{
    public static PublicKey LoadHistory

    (
        int ConfirmationCount,

        int CandidateCount,

        int AddressCount,

        int TransferCount
    )

    {
        var confirmations = new Confirmation[ConfirmationCount];

        for (int i = 0; i < ConfirmationCount; i++)
        {
            confirmations[i] = Confirmation.LoadHistory
            (
                CandidateCount,

                AddressCount,

                TransferCount
            );
        }

        var publicKey = new PublicKey(confirmations);

        return publicKey;
    }

}

