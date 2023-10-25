using System.IO;
namespace Swopblock;

public partial record Network
{
    public Network? CreateGenesis()
    {
        Address genesisAddress = new Address(new HashSet<Transfer>());


        Candidate genesisCandidate = new Candidate(new HashSet<Address>());

        genesisCandidate.Addresses.Add(genesisAddress);


        Confirmation genesisConfirmation = new Confirmation(new HashSet<Candidate>());

        genesisConfirmation.Candidates.Add(genesisCandidate);


        Node genesisNode = new Node(new HashSet<Confirmation>());

        genesisNode.Confirmations.Add(genesisConfirmation);


        Blockchain genesisBlockchain = new Blockchain(new HashSet<Node>());

        genesisBlockchain.Nodes.Add(genesisNode);


        Core genesisCore = new Core(new HashSet<Blockchain>());

        genesisCore.Blockchains.Add(genesisBlockchain);


        App genesisApp = new App(new HashSet<Core>());

        genesisApp.Cores.Add(genesisCore);


        //Live genesisLive = new App

    
        return null;
    }

    public void LoadHistory()
    {
    }
}

