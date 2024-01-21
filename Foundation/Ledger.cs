using System;
using System.Web;

namespace Foundation
{

	/*
	public record LedgerInfo(string Symbol, string Name, string Kind, string PlaceOfOrigin, string LocalClone, string CloneVerificationId)
	{
		public static Ledger Bitcoin
		{
			get
			{
				return null; // new Ledger("BTC", "Bitcoin", "Blockchain", "GitHub.com/Swopblock", "./SWOBL/BTC", "Simulation");
			}
		}

		public static Ledger Ethereum
		{
			get
			{
				return null; // new Ledger("ETH", "Ethereum", "Blockchain", "GitHub.com/Swopblock", "./SWOBL/ETH", "Simulation");
			}
		}

		public static Ledger Swopblock
		{
			get
			{
				return new Ledger(new LedgerInfo("USD", "Swopblock", "FedNow", "GitHub.com/Swopblock", "./SWOBL/FedNow", "Simulation"));
			}
		}

		public static Ledger Network
		{
			get
			{
				return null;// new LedgerInfo("SWOBL", "Core", "MultiLedger", "GitHub.com/Swopblock", "./SWOBL", "Simulation");
			}
		}

		//public Ledger NewLedger
		/// <summary>
		/// Gets the Ledger source code from the origin and clones it to local files.
		/// </summary>
		/// <returns>Returns a reference to the Ledger of type specified in the record.</returns>
		public Ledger CloneLedger()
		{
			//var ledger = new LedgerInfo("SWOBL", "Swopblock", "Ledger", "GitHub", "C:/SWOBL", "9475",

			// new LedgerInfo("BTC", "Bitcoin", "Ledger", "GitHub", "C:/SWOBL/BTC", "298347", null),

			//new LedgerInfo(, null)
			//);

			return null;
		}

		/// <summary>
		/// Clones the Ledger source code if needed and then builds it to local files.
		/// </summary>
		/// <returns>Returns a reference to the Ledger of type specified in the record.</returns>
		public Ledger BuildLedger() { return null;// this; }

			/// <summary>
			/// Clones the Ledger source code and builds it if needed and then rebuilds it to local files.
			/// </summary>
			/// <returns></returns>
			public Ledger RebuildLedger() { return null;// this; }

				/// <summary>
				/// Cleans the build files out and only leaves the source code files.
				/// </summary>
				/// <returns></returns>
				public Ledger CleanLedger() { return this; }

				public Ledger AddSubLedger(Ledger SubLedger)
				{
					return this;
				}
			}
		}
	}

	// NSBE
	public record Ledger(LedgerInfo Info)
	{
		//public Ledger CreateNewKindLedger()
	}

	// N
	public record CrossLedger(LedgerInfo Info) : Ledger(Info);


	public record Network(LedgerInfo Info): CrossLedger(Info);

	public record Ledger(LedgerInfo Info): CrossLedger(Info);

	public record Blockchain(LedgerInfo Info): Ledger(Info);

	public record Bitcoin(LedgerInfo Info): Blockchain(Info);

	public record Ethereum(LedgerInfo Info): Blockchain(Info);

	*/
}

