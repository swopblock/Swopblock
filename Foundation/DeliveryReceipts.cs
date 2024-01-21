using System;
namespace Swopblock;

public partial record SaleNotes
    (
        decimal BaseValue,

        decimal FaceValue
    )
: Notes
    (
        BaseValue,

        FaceValue
    )
{
}

