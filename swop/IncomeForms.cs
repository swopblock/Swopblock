using System;
namespace swop
{
    public class IncomeForms : Receipts
    {
        public IncomeForms()
        {

        }

        public new static IncomeForms Parse(string text)
        {
            var txt = text.Split("in order to", 2)[0];

            if (txt.Contains("BTC"))
            {
                return BtcIncomes.Parse(text);
            }

            if (txt.Contains("ETH"))
            {
                return EthIncomes.Parse(text);
            }

            return new IncomeForms();
        }
    }



    public class BtcIncomes : IncomeForms
    {
        public BtcIncomes()
        {

        }

        public new static BtcIncomes Parse(string text)
        {
            var txt = text.Split(' ', 1)[0];

            if (txt.Contains("I"))
            {
                return SignableBtcIncomes.Parse(text);
            }

            if (txt.Contains("We"))
            {
                return ConfirmedBtcIncomes.Parse(text);
            }
            return new BtcIncomes();
        }
    }

    public class SignableBtcIncomes : BtcIncomes
    {
        public SignableBtcIncomes()
        {

        }

        public new static SignableBtcIncomes Parse(string text)
        {
            return new SignableBtcIncomes();
        }
    }

    public class ConfirmedBtcIncomes : BtcIncomes
    {
        public ConfirmedBtcIncomes()
        {

        }

        public new static ConfirmedBtcIncomes Parse(string text)
        {
            return new ConfirmedBtcIncomes();
        }
    }



    public class EthIncomes : IncomeForms
    {
        public EthIncomes()
        {

        }

        public new static EthIncomes Parse(string text)
        {
            var txt = text.Split(' ', 1)[0];


            if (txt.Contains("I"))
            {
                return SignableEthIncomes.Parse(text);
            }

            if (txt.Contains("We"))
            {
                return ConfirmedEthIncomes.Parse(text);
            }

            return new EthIncomes();
        }
    }

    public class SignableEthIncomes : EthIncomes
    {
        public SignableEthIncomes()
        {

        }

        public new static SignableEthIncomes Parse(string text)
        {
            return new SignableEthIncomes();
        }
    }

    public class ConfirmedEthIncomes : EthIncomes
    {
        public ConfirmedEthIncomes()
        {

        }

        public new static ConfirmedEthIncomes Parse(string text)
        {
            return new ConfirmedEthIncomes();
        }
    }

}

