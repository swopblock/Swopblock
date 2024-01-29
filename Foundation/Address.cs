using System;

namespace Swopblock.DraftA
{
    public record Addresses;
}


namespace Swopblock
{



    public partial record Address
    {
        //protected static decimal FaceValue = 52800000;

        public static Node SimulateHistory(int TransferCountAverage, int TransferCountDeviation)
        {
            return null;
        }

        public static Address LoadHistory
        (
            int TransferCount
        )

        {
            var transfers = new Entries[TransferCount];

            for (int i = 0; i < TransferCount; i++)
            {
                transfers[i] = Swopblock.Entries.LoadHistory();
            }

            //var address = new Address(transfers);

            //return address;

            return null;
        }

    }

    public partial record BtcAddress(HashSet<Entries> Transfers)
    {

    }

    public partial record EthAddress(HashSet<Entries> Transfers)
    {

    }
}
