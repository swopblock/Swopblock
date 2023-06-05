using swop;

/*
using System.Diagnostics.CodeAnalysis; // Required for [NotNullWhen(true)] [MaybeNullWhen(false)]

// int can be parsed because in .NET 7.0 System.Int32 implements IParsable<int>
int i = "691".Parse<int>();

// Our Person class can be instantiated through string parsing too, by the same Parse<T>() method
Person person = "Bill,Gates,US".Parse<Person>();

Console.ReadKey();

static class ExtensionMethods
{
    // Generic parsing
    internal static T Parse<T>(this string s) where T : IParsable<T>
    {
        return T.Parse(s, null);
    }
}
sealed class Person : IParsable<Person>
{
    public string FirstName { get; }
    public string FullName { get; }
    public string Country { get; }

    // Private constructor used from the Parse() method below
    private Person(string firstName, string fullName, string country)
    {
        FirstName = firstName;
        FullName = fullName;
        Country = country;
    }

    // IParsable<Person>  implementation
    public static Person Parse(string s, IFormatProvider? provider)
    {
        string[] strings = s.Split(new[] { ',', ';' });
        if (strings.Length != 3) { throw new OverflowException("Expect: FirstName,LastName,Country"); }
        return new Person(strings[0], strings[1], strings[2]);
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Person result)
    {
        result = null;
        if (s == null) { return false; }
        try
        {
            result = Parse(s, provider);
            return true;
        }
        catch { return false; }
    }
}
*/

Console.WriteLine("Swop is loading.");



// workers

var user = new Users();

var invoicer = new Invoicers();

var autoer = new Autoers();

var receipter = new Receipters();

// orders

//var offer = new OfferForms();

//var invoice = new InvoiceForms();

//var delivery = new DeliveryForms();

//var receipt = new ReceiptForms();

Console.WriteLine("Swop is open.");

string intention;

while ((intention = Console.ReadLine() ?? "I am closing swop.").Contains("closing") == false)
{
    var offerable = OfferForms.Intend(intention);


    Console.WriteLine(offerable.Notify());

    var invoicable = offerable.Offer();


    Console.WriteLine(invoicable.Notify());

    var deliverable = invoicable.Invoice();


    Console.WriteLine(deliverable.Notify());

    var receiptable = deliverable.Deliver();


    Console.WriteLine(receiptable.Notify());

    var textable = receiptable.Receipt();
}



/*
Console.WriteLine("Swop is open.");

string order;

while ((order = Console.ReadLine() ?? "I am closing swop.").Contains("closing") == false)
{
    var fields = order.Split(" am ");

    string ordering = "You are " + order.Split(" am ")[1].Split("ing ")[0] + "ing.";

    switch (ordering)
    {
        // {WhoIs} bidding at least {LeastBid} and at most {MostBid} SWOBL to be sent from {OfWho} {BidMarket} address {BidMarketAddress}
        // in order to
        // buy at least {LeastBuy} and at most {MostBuy} {BuyMarket} to be sent to {MyYour} address {BuyMarketAddress}
        // and the order is good when the market volume reaches at least {LeastMarketVolume} and at most {MostMarketVolume} SWOBL
        // and the order is authorized by {MyYour} signature {Signature}.

        // You are bidding at least {LeastBid} and at most {MostBid} SWOBL to be sent from your {BidMarket} address {BidMarketAddress}
        // in order to
        // buy at least {LeastBuy} and at most {MostBuy} {BuyMarket} to be sent to your address {BuyMarketAddress}
        // and the order is good when the market volume reaches at least {LeastMarketVolume} and at most {MostMarketVolume} SWOBL
        // and the order is authorized by your signature {MySignature}.
        case "You are bidding.":
        {
            Console.WriteLine("You are ordering.");
            Console.WriteLine("You are offering.");
            Console.WriteLine(ordering);
            break;
        }

        // I am asking $ to be sent to my address in order to sell X to be sent from my address
        // You are asking $ to be sent to your address in order to sell X to be sent from your address
        case "You are asking.":
        {
            Console.WriteLine("You are ordering.");
            Console.WriteLine("You are offering.");
            Console.WriteLine(ordering);
            break;
        }

        // You are buying X to be sent from their address to your address in order to pay $ to be sent from your address to their address
        case "You are buying.":
        {
            Console.WriteLine("You are ordering.");
            Console.WriteLine("You are invoicing.");
            Console.WriteLine(ordering);
            break;
        }

        // You are selling X to be sent from your address to their address in order to recieve $ to be sent from their address to your address
        case "You are selling.":
        {
            Console.WriteLine("You are ordering.");
            Console.WriteLine("You are invoicing.");
            Console.WriteLine(ordering);
            break;
        }

        // You are paying $ paid from your address to their address in order to buy X sent from their address to your address
        case "You are paying.":
        {
            Console.WriteLine("You are ordering.");
            Console.WriteLine("You are delivering.");
            Console.WriteLine(ordering);
            break;
        }

        // You are cashing $ paid from their address to your address in order to sell X sent from your address to their address
        case "You are cashing.":
        {
            Console.WriteLine("You are ordering.");
            Console.WriteLine("You are delivering.");
            Console.WriteLine(ordering);
            break;
        }

        // You are receipting X sent from their address to your address in exchange for $ paid from your address to their address
        case "You are expencing.":
        {
            Console.WriteLine("You are ordering.");
            Console.WriteLine("You are receipting.");
            Console.WriteLine(ordering);
            break;
        }

        // You are receipting $ paid from their address to your address in exchange for X sent from your address to their address
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
*/