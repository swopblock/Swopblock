using System;
namespace Swopblock;

public partial record Deeds
	(
		decimal BaseValue,

		decimal FaceValue
	)
:OrderItems
	(
		BaseValue,

		FaceValue
	)
{
}

