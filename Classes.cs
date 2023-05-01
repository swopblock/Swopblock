using System;
namespace swop
{
	public class Classes
	{
		public Classes()
		{
		}

		public static Classes Parse(string text)
		{
			if (text.EndsWith(".") == false)
			{
				return new Classes();
			}

			if (Char.IsUpper(text[0]) == false)
			{
				return new Classes();
			}


            //switch (text[0])
            //{
            //    case 'I': return SignedOrders.Parse(text);
            //    case 'W': return ConfirmedOrders.Parse(text);
            //}

            return Intentions.Parse(text);
		}
	}
}

