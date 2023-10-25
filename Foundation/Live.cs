using System;

namespace Swopblock;

public partial record Live
{
    public static Live SimulateHistory(int AppCountAverage, int AppCountDeviation)
    {
        return null;
    }

    public static Live LoadHistory
        (
            int AppCount,

            int CoreCount,

            int BlockchainCount,

            int NodeCount,

            int ConfirmationCount,

            int CandidateCount,

            int AddressCount,

            int TransferCount
        )
    {
        var apps = new App[AppCount];

        for (int i = 0; i < AppCount; i++)
        {
            apps[i] = App.LoadHistory
                (
                    CoreCount,

                    BlockchainCount,

                    NodeCount,

                    ConfirmationCount,

                    CandidateCount,

                    AddressCount,

                    TransferCount
                );
        }

        var live =

        Live.LoadHistory
        (
            AppCount,

            CoreCount,

            BlockchainCount,

            NodeCount,

            ConfirmationCount,

            CandidateCount,

            AddressCount,

            TransferCount);

        return live;
    }
}

