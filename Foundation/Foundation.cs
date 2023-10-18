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

    : Address(new Transfer[]
                {
                    PaymentOffer,

                    DeliveryOffer,

                    PaymentDue,

                    DeliveryDue,

                    PaymentDeed,

                    DeliveryDeed,

                    PaymentReceipt,

                    DeliveryReceipt
                });

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


public partial record Transfer;

public partial record Address(Transfer[] Transfers);

public partial record Candidate(Address[] Addresses);

public partial record Confirmation(Candidate[] Candidates);

public partial record PublicKey(Confirmation[] Confirmations);

public partial record PrivateKey(PublicKey[] PublicKeys);

public partial record Node(PrivateKey[] PrivateKeys);

public partial record Blockchain(Node[] Nodes);


public partial record Core(Blockchain[] Blockchains);

/* “Core” is a collection of Blockchains ... */


public partial record App(Core[] Cores);

/* “App” is a collection of Cores ... */


public partial record Live(App[] Apps);

/* “Live” is a collection of Apps and is a dashboard view of relevant summary
 * information about the entire network of internet connected applications 
 * that are running the Swopblock exchange protocol. Live has 
 * methods that allow for adding a new App to its collection, removing 
 * Apps from its collection and making various system wide summary and 
 * statical reports that are relevant to an understanding of the operational 
 * health of the Swopblock network. */




