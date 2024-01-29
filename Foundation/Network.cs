using System.IO;

namespace Swopblock.DraftA
{
    public class NetworkInfo
    {
        HashSet<Blockchain> Blockchains = new HashSet<Blockchain>();

        HashSet<Core> Cores = new HashSet<Core>();

        HashSet<App> Apps = new HashSet<App>();

        HashSet<Live> Lives = new HashSet<Live>();

        public NetworkInfo(int BlockchainCount, int CoreCount, int AppCount, Live LiveCount)
        {
            Blockchains.Add(new BtcBlockchain());

            Blockchains.Add(new EthBlockchain());

            Blockchains.Add(new SwopblockChain());

            for (int i = 0; i < BlockchainCount; i++)
            {
                Blockchains.Add(new Blockchain());
            }

            for (int j = 0; j < CoreCount; j++)
            {
                Cores.Add(new Core());
            }

            for (int k = 0; k < AppCount; k++)
            {
                Apps.Add(new App());
            }
        }

    }

    public record Network(HashSet<Blockchain> Blockchains, HashSet<Core> Cores, HashSet<App> Apps, HashSet<Live> Lives);


}

namespace Swopblock
{

    public class NetworkInfo
    {

    }

    public partial record Network
    {
        public static Network? CreateGenesis()
        {
            Address genesisAddress = new Address(new HashSet<Entries>());


            Candidate genesisCandidate = null; // new Candidate(new HashSet<Address>());

            genesisCandidate.Addresses.Add(genesisAddress);


            Confirmation genesisConfirmation = new Confirmation(new HashSet<Candidate>(), genesisCandidate);

            genesisConfirmation.Candidates.Add(genesisCandidate);


            Node genesisNode = new Node(new HashSet<Confirmation>());

            genesisNode.Confirmations.Add(genesisConfirmation);


            Blockchain genesisBlockchain = new Blockchain(new HashSet<Node>());

            genesisBlockchain.Nodes.Add(genesisNode);


            Core genesisCore = new Core(new HashSet<Blockchain>());

            genesisCore.Blockchains.Add(genesisBlockchain);


            App genesisApp = new App(new HashSet<Core>());

            genesisApp.Cores.Add(genesisCore);


            //Live genesisLive = new Live(new HashSet<Core>(), new HashSet<App>());

            //genesisLive.Cores.Add(genesisCore);

            //genesisLive.Apps.Add(genesisApp);


            //Network genesisNetwork = new Network(new HashSet<Core>(), new HashSet<App>(), new HashSet<Live>());

            //genesisNetwork.Cores.Add(genesisCore);

            //genesisNetwork.Apps.Add(genesisApp);

            //genesisNetwork.Lives.Add(genesisLive);


            return null;// genesisNetwork;
        }

        //public decimal GetGenesisBtcBaseValues

        public void LoadHistory()
        {
        }
    }
}

