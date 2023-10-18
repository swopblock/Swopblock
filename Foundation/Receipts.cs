using System;
namespace Swopblock;

public partial record Receipts
    (
        decimal BaseValue,

        decimal FaceValue
    )
: InvoiceItems
    (
        BaseValue,

        FaceValue
    )
{
}

