using swop;

Console.WriteLine("Hello, World!");

// workers

var applicator = new Applicators();

var user = new Users();

var invoicer = new Invoicers();

var autoer = new Autoers();

var receipter = new Receipters();

// orders

var offer = new Offers();

var invoice = new Invoices();

var delivery = new Deliveries();

var receipt = new Receipts();

string? line;

while (true)
{
    // Console Command
    line = Console.ReadLine();

    if (line == "I am closing swop.")
    {
        break;
    }

    if (args.Contains("u"))
    {
        user.WriteLine(line);

        line = user.ReadLine();
    }

    invoicer.WriteLine(line);

    line = invoicer.ReadLine();


    autoer.WriteLine(line);

    line = autoer.ReadLine();


    receipter.WriteLine(line);

    line = receipter.ReadLine();


    // Console Notification
    Console.WriteLine(line);
}





