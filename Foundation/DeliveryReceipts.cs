using System;
namespace Swopblock;

public partial record DeliveryReceipts
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

