using System;
namespace Swopblock;

public partial record PaymentReceipts
    (
        decimal BaseValue,

        decimal FaceValue
    )
: Receipts
    (
        BaseValue,

        FaceValue
    )
{
}

