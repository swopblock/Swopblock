using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Reflection.PortableExecutable;

namespace Swopblock;

public partial record Orders
(
    CashOffers PaymentOffer,

    SaleOffers DeliveryOffer,

    CashDues PaymentDue,

    SaleDues DeliveryDue,

    CashDeeds PaymentDeed,

    SaleDeeds DeliveryDeed,

    CashNotes PaymentReceipt,

    SaleNotes DeliveryReceipt
);


public partial record CashNotes : Notes;

public partial record SaleNotes : Notes;

public partial record CashDeeds : Deeds;

public partial record SaleDeeds : Deeds;

public partial record CashDues : Dues;

public partial record SaleDues : Dues;

public partial record CashOffers : Offers;

public partial record SaleOffers : Offers;

public partial record Notes : Results;

public partial record Deeds : Controls;

public partial record Dues : Results;

public partial record Offers : Commands;

public partial record Commands: Entries;

public partial record Controls: Entries;

public partial record Results: Entries;

public partial record Entries;

public partial record Address(HashSet<Entries> Entries);

public partial record Candidate(HashSet<Address> Addresses, HashSet<Orders> Orders);

public partial record Confirmation;

public partial record Node(HashSet<Confirmation> Confirmations);//: SwopPoint;

public partial record Market(HashSet<Node> Nodes);

public partial record Core(HashSet<Market> Blockchains);//: SwopPoint;

/* “Core” is a collection of Blockchains ... */


public partial record App(HashSet<Core> Cores): SwopPoint;

/* “App” is a collection of Cores ... */


public partial record Live(HashSet<Core> Cores);


/* “Live” is a collection of Apps and is a dashboard view of relevant summary
 * information about the entire network of internet connected applications 
 * that are running the Swopblock exchange protocol. Live has 
 * methods that allow for adding a new App to its collection, removing 
 * Apps from its collection and making various system wide summary and 
 * statical reports that are relevant to an understanding of the operational 
 * health of the Swopblock network. */

public partial record Network(HashSet<Market> Blockchains, HashSet<Core> Cores, HashSet<App> Apps, HashSet<Live> Lives);

//Swop Points are physical devices that connect to and exchange SWOBL with
//a computer network. Some examples of Swop Points are mobile devices,
//desktop computers, virtual machines, embedded devices, and servers

public partial interface SwopPoint { }

public partial interface View { }