using System;

namespace Swopblock.DraftA
{
    public record Blockchain
    {

    }

    public record BtcBlockchain : Blockchain
    {

    }

    public record EthBlockchain : Blockchain
    {

    }

    public record SwopblockChain: Blockchain
    {

    }
}

namespace Swopblock
{

    public partial record Market
    {
        public static Market SimulateHistory(int NodeCountAverage, int NodeCountDeviation)
        {
            return null;
        }

        public static Market LoadHistory

        (
            int NodeCount,

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

                    ConfirmationCount,

                    CandidateCount,

                    AddressCount,

                    TransferCount
                );
            }

            //var blockchain = new Blockchain(nodes);

            //return blockchain;

            return null;
        }

    }

    public record BtcBlockchain(HashSet<Node> Nodes) : Market(Nodes)
    {

    }


    public record EthBlockchain(HashSet<Node> Nodes) : Market(Nodes)
    {

    }
}