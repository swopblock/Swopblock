using CORE;

Task whenAllDone = Task.CompletedTask;

var AutoReceipt = new AutoReceipt(args, out whenAllDone);

await whenAllDone;

class AutoReceipt : Core
{
    public AutoReceipt(string[] args, out Task whenAll) : base("AutoEstimate", args, out whenAll)
    {
    }
}
