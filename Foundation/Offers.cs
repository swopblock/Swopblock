using System;

namespace Swopblock;

public partial record Offers
    (
        decimal BaseValue,

        decimal FaceValue

    ): InvoiceItems
    (
        BaseValue,

        FaceValue
    )
{
    public void Write()
    {

    }

    public void Sign()
    {

    }

    public void Broadcast()
    {

    }



}

