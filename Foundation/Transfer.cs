using System;
namespace Swopblock;

public partial record Transfer
{
    public static Transfer LoadHistory()
    {
        var transfer  = new Transfer();

        return transfer;
    }

}

