using System;
namespace Swopblock;

public partial record CashNotes
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

