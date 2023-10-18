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

}

