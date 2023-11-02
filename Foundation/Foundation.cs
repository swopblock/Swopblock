using System;
using System.Collections;

namespace Swopblock;

public partial record Invoice
(
    PaymentOffers PaymentOffer,

    DeliveryOffers DeliveryOffer,

    PaymentDues PaymentDue,

    DeliveryDues DeliveryDue,

    PaymentDeeds PaymentDeed,

    DeliveryDeeds DeliveryDeed,

    PaymentReceipts PaymentReceipt,

    DeliveryReceipts DeliveryReceipt
)

    : Transfer;

public partial record PaymentReceipts : Receipts;

public partial record DeliveryReceipts : Receipts;

public partial record PaymentDeeds : Deeds;

public partial record DeliveryDeeds : Deeds;

public partial record PaymentDues : Dues;

public partial record DeliveryDues : Dues;

public partial record PaymentOffers : Offers;

public partial record DeliveryOffers : Offers;

public partial record Receipts : InvoiceItems;

public partial record Deeds : InvoiceItems;

public partial record Dues : InvoiceItems;

public partial record Offers : InvoiceItems;

public partial record InvoiceItems : Transfer;


public partial record Input: Transfer;

public partial record Output: Transfer;

public partial record Balance: Transfer;

public partial record Transfer();

public partial record Address(HashSet<Transfer> Transfers);

public partial record Candidate(HashSet<Address> Addresses);

public partial record Confirmation;

public partial record Node(HashSet<Confirmation> Confirmations);

public partial record Blockchain(HashSet<Node> Nodes);

public partial record Core(HashSet<Blockchain> Blockchains);

/* “Core” is a collection of Blockchains ... */


public partial record App(HashSet<Core> Cores);

/* “App” is a collection of Cores ... */


public partial record Live(HashSet<Core> Cores, HashSet<App> Apps);


/* “Live” is a collection of Apps and is a dashboard view of relevant summary
 * information about the entire network of internet connected applications 
 * that are running the Swopblock exchange protocol. Live has 
 * methods that allow for adding a new App to its collection, removing 
 * Apps from its collection and making various system wide summary and 
 * statical reports that are relevant to an understanding of the operational 
 * health of the Swopblock network. */

public partial record Network(HashSet<Core> Cores, HashSet<App> Apps, HashSet<Live> Lives);


