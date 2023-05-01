using System;
namespace swop
{
    public class Expenses : Receipts
    {
        public Expenses()
        {

        }

        public new static Expenses Parse(string text)
        {
            var txt = text.Split("in order to", 2)[0];

            if (txt.Contains("BTC"))
            {
                return BtcExpenses.Parse(text);
            }

            if (txt.Contains("ETH"))
            {
                return EthExpenses.Parse(text);
            }

            return new Expenses();
        }
    }



    public class BtcExpenses : Expenses
    {
        public BtcExpenses()
        {

        }

        public new static BtcExpenses Parse(string text)
        {
            var txt = text.Split(' ', 1)[0];

            if (txt.Contains("I"))
            {
                return SignableBtcExpenses.Parse(text);
            }

            if (txt.Contains("We"))
            {
                return ConfirmedBtcExpenses.Parse(text);
            }
            return new BtcExpenses();
        }
    }

    public class SignableBtcExpenses : BtcExpenses
    {
        public SignableBtcExpenses()
        {

        }

        public new static SignableBtcExpenses Parse(string text)
        {
            return new SignableBtcExpenses();
        }
    }

    public class ConfirmedBtcExpenses : BtcExpenses
    {
        public ConfirmedBtcExpenses()
        {

        }

        public new static ConfirmedBtcExpenses Parse(string text)
        {
            return new ConfirmedBtcExpenses();
        }
    }



    public class EthExpenses : Expenses
    {
        public EthExpenses()
        {

        }

        public new static EthExpenses Parse(string text)
        {
            var txt = text.Split(' ', 1)[0];


            if (txt.Contains("I"))
            {
                return SignableEthExpenses.Parse(text);
            }

            if (txt.Contains("We"))
            {
                return ConfirmedEthExpenses.Parse(text);
            }

            return new EthExpenses();
        }
    }

    public class SignableEthExpenses : EthExpenses
    {
        public SignableEthExpenses()
        {

        }

        public new static SignableEthExpenses Parse(string text)
        {
            return new SignableEthExpenses();
        }
    }

    public class ConfirmedEthExpenses : EthExpenses
    {
        public ConfirmedEthExpenses()
        {

        }

        public new static ConfirmedEthExpenses Parse(string text)
        {
            return new ConfirmedEthExpenses();
        }
    }

}

