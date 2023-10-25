using System;

namespace Swopblock;

public partial record Core
{
    public static Core SimulateHistory(int BlockchainCountAverage, int BlockchainCountDeviation)
    {
        return null;
    }

    public static Core LoadHistory

    (
        int BlockchainCount,

        int NodeCount,

        int ConfirmationCount,

        int CandidateCount,

        int AddressCount,

        int TransferCount
    )

    {
        var blockchains = new Blockchain[BlockchainCount];

        for (int i = 0; i < BlockchainCount; i++)
        {
            blockchains[i] =

            Blockchain.LoadHistory
            (
                NodeCount,

                ConfirmationCount,

                CandidateCount,

                AddressCount,

                TransferCount
            );
        }

        //var core = new Core(blockchains);

        //return core;

        return null;
    }
}

