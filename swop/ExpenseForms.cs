using System;
namespace swop
{
    public class ExpenseForms: Receipts
    {
        public ExpenseForms()
        {

        }

        public new static ExpenseForms Parse(string text)
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

            return new ExpenseForms();
        }
    }



    public class BtcExpenses : ExpenseForms
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



    public class EthExpenses : ExpenseForms
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

