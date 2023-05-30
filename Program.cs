using swop;

string text = "I am starting swop.";

Console.WriteLine("You are starting swop.");

// workers

var user = new Users();

var invoicer = new Invoicers();

var autoer = new Autoers();

var receipter = new Receipters();

// orders

var offer = new OfferForms();

var invoice = new InvoiceForms();

var delivery = new DeliveryForms();

var receipt = new ReceiptForms();


text = "I am opening swop.";

Console.WriteLine("You are opening swop.");

string order;

while ((order = Console.ReadLine() ?? "I am closing swop.").Contains("closing") == false)
{
    var fields = order.Split(" am ");

    string ordering = "You are " + order.Split(" am ")[1].Split("ing ")[0] + "ing.";

    switch (ordering)
    {
        case "You are bidding.":
            {
                Console.WriteLine("You are ordering.");
                Console.WriteLine("You are offering.");
                Console.WriteLine(ordering);
                break;
            }
        case "You are asking.":
            {
                Console.WriteLine("You are ordering.");
                Console.WriteLine("You are offering.");
                Console.WriteLine(ordering);
                break;
            }
        case "You are buying.":
            {
                Console.WriteLine("You are ordering.");
                Console.WriteLine("You are invoicing.");
                Console.WriteLine(ordering);
                break;
            }
        case "You are selling.":
            {
                Console.WriteLine("You are ordering.");
                Console.WriteLine("You are invoicing.");
                Console.WriteLine(ordering);
                break;
            }
        case "You are paying.":
            {
                Console.WriteLine("You are ordering.");
                Console.WriteLine("You are delivering.");
                Console.WriteLine(ordering);
                break;
            }
        case "You are cashing.":
            {
                Console.WriteLine("You are ordering.");
                Console.WriteLine("You are delivering.");
                Console.WriteLine(ordering);
                break;
            }
        case "You are expencing.":
            {
                Console.WriteLine("You are ordering.");
                Console.WriteLine("You are receipting.");
                Console.WriteLine(ordering);
                break;
            }
        case "You are incoming.":
            {
                Console.WriteLine("You are ordering.");
                Console.WriteLine("You are receipting.");
                Console.WriteLine(ordering);
                break;
            }
    }
}

Console.WriteLine("You are closing swop.");

// 

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

