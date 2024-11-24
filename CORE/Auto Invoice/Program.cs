using CORE;

Task whenAllDone = Task.CompletedTask;

var AutoInvoice = new AutoInvoice(args, out whenAllDone);

await whenAllDone;

class AutoInvoice : Core
{
    public AutoInvoice(string[] args, out Task whenAll) : base("AutoInvoice", args, out whenAll)
    {
    }
}
