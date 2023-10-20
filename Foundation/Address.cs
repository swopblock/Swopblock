using System;
namespace Swopblock;

public partial record Address
{
    public static Address LoadHistory
    (
        int TransferCount
    )

    {
        var transfers = new Transfer[TransferCount];

        var address = new Address(transfers);

        return address;
    }

}

