using System.IO;
namespace Swopblock;

public partial record Network
{
    public static Network? CreateGenesis()
    {
        Address genesisAddress = new Address(new HashSet<Transfer>());


        Candidate genesisCandidate = new Candidate(new HashSet<Address>());

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

