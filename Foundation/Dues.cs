using System;
namespace Swopblock;

public partial record Dues
	(
		decimal BaseValue,

		decimal FaceValue

	):OrderItems
	(
		BaseValue,

		FaceValue
	)
{
}

