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

public partial record Market(Node[] Nodes);

public partial record Core(Market[] Markets);

/* “Core” is a software application installation that owns digital assets in one
 * or more kinds of private access blockchain markets (Markets). Each kind of
 * blockchain being configured to be used by a Core in the Swopblock exchange
 * protocol is called a Market and the Core collection of these markets
 * (Markets) provide owner trading access to blockchain digital assets of each
 * such Market. */


public partial record App(Core[] Cores);

/* “App” is a mobile software application that has one or more 
 * core devices (Cores) configured to run the Swopblock protocol specifically 
 * for an App and to enable the execution of crypto market trading orders 
 * cryptographically safe in autonomous trading between peers of crypto owning 
 * traders. App provides a user interface to view market information, create 
 * market trading orders and to submit the orders to one or more of the user’s 
 * core devices which will autonomously negotiate among peers the completion of
 * the market order. App is similarly licensed as Live is under GPL 2.0 as are
 * all of the herein remaining backbone elements. */


public partial record Live(App[] Apps);

/* “Live” is a dashboard view of relevant summary information about the entire 
 * network of internet connected applications that are running the Swopblock 
 * exchange protocol. As a collection of these applications  (Apps) Live has 
 * methods that allow for adding a new application to its collection, removing 
 * applications from its collection and making various system wide summary and 
 * statical reports that are relevant to an understanding of the operational 
 * health of the Swopblock exchange protocol network. Live is not a centralized 
 * server owned by Swopblock but rather a Swopblock open source software that 
 * communicates with Swopblock applications to collect information that is 
 * summarized into the reports that are shown in the dashboard view that is 
 * available to anyone licensed by the terms of the GPL 2.0 open source 
 * license. */




