namespace Swopblock.Utilities
{
    public interface IProcessForm
    {
        static async IAsyncEnumerable<string> ProcessForm(IForm Form)
        {
            await foreach (var Text in Form.NewForm())
            {
                await foreach (var Message in Text.Message())
                {
                    await foreach (var Object in Message.Parse())
                    {
                        await foreach (var Binary in Object.Write())
                        {
                            await foreach (var Signature in Binary.Sign())
                            {
                                await foreach (var Received in Signature.Broadcast())
                                {
                                    await foreach (var Confirmation in Received.Confirm())
                                    {
                                        await foreach (var Status in Confirmation.Status())
                                        {
                                            yield return Status;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public interface IForm { IAsyncEnumerable<IText> NewForm(); }
    public interface IText { IAsyncEnumerable<IParse> Message(); }
    public interface IParse { IAsyncEnumerable<IWrite> Parse(); }
    public interface IWrite { IAsyncEnumerable<ISign> Write(); }
    public interface ISign { IAsyncEnumerable<IBroadcast> Sign(); }
    public interface IBroadcast { IAsyncEnumerable<IConfirm> Broadcast(); }
    public interface IConfirm { IAsyncEnumerable<IStatus> Confirm(); }
    public interface IStatus { IAsyncEnumerable<string> Status(); }

}
