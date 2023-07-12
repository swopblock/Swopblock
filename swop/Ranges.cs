using System;
namespace swop
{
	public struct Ranges
	{
		UInt64 AtLeast;

		UInt64 AtMost;

		public Ranges(UInt64 atLeast, UInt64 atMost)
		{
			AtLeast = atLeast;

			AtMost = atMost;
		}
	}
}

