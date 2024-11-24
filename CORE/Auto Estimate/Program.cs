using CORE;

Task whenAllDone = Task.CompletedTask;

var AutoEstimate = new AutoEstimate(args, out whenAllDone);

await whenAllDone;

class AutoEstimate : Core
{
    public AutoEstimate(string[] args, out Task whenAll) : base("AutoEstimate", args, out whenAll)
    {
    }
}
