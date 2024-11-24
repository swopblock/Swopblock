using APP;

Task whenAllDone = Task.CompletedTask;

var SelfOrder = new SelfOrder(args, out whenAllDone);

await whenAllDone;

class SelfOrder : App
{
    public SelfOrder(string[] args, out Task whenAll) : base("SelfQuery", args, out whenAll)
    {
    }
}
