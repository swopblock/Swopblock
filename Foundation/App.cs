using System;

namespace Swopblock
{

    public partial record App
    {
        public static App SimulateHistory(int CoreCountAverage, int CoreCountDeviation)
        {
            return null;
        }

        public static App LoadHistory
            (
                int CoreCount,

                int BlockchainCount,

                int NodeCount,

                int ConfirmationCount,

                int CandidateCount,

                int AddressCount,

                int TransferCount
            )
        {
            var cores = new Core[CoreCount];

            for (int i = 0; i < CoreCount; i++)
            {
                cores[i] =

                Core.LoadHistory
                (
                    BlockchainCount,

                    NodeCount,

                    ConfirmationCount,

                    CandidateCount,

                    AddressCount,

                    TransferCount
                );
            }

            //var app = new App(cores);

            //return app;

            return null;
        }
    }

}

