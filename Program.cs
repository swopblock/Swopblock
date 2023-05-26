using swop;

Console.WriteLine("Hello, World!");

// workers

var applicator = new Applicators();

var user = new Users();

var invoicer = new Invoicers();

var autoer = new Autoers();

var receipter = new Receipters();

// orders

var offer = new OfferForms();

var invoice = new InvoiceForms();

var delivery = new DeliveryForms();

var receipt = new ReceiptForms();

string? line;

while (true)
{
    // Console Command
    line = Console.ReadLine();

    if (line == "I am closing swop.")
    {
        Console.WriteLine("We closed swop.");

        break;
    }

    offer.New(line);

    offer.Sign();

    offer.Pend();

    offer.Confirm();

    //user.WriteLine(offerText);

    line = user.ReadLine();

    invoicer.WriteLine(line);

    line = invoicer.ReadLine();


    autoer.WriteLine(line);

    line = autoer.ReadLine();


    receipter.WriteLine(line);

    line = receipter.ReadLine();


    // Console Notification
    Console.WriteLine(line);
}

string Offer(string text)
{
    text = "I am bidding at least 100 and at most 200 SWOBL " +

        "saved at my BTC address 0x123456 " +

        "in order to " +

        "buy at least 200 and at most 300 BTC from the market " +

        "and save it to my BTC address 0x654321 " +

        "and this offer is good until " +

        "the market volume reaches at least 1000 and at most 2000 SWOBL " +

        "and is signed using my signature 0x789.";

    return "OFFER:";
}

string Invoice(string text)
{
    return "INVOICE:";
}

string Deliver(string text)
{
    return "DELIVERY:";
}

string Receipt(string text)
{
    return "RECEIPT:";
}

