using System;
namespace swop
{
    public class Sales : Invoices
    {
        public Sales()
        {

        }

        public new static Sales Parse(string text)
        {
            var txt = text.Split("in order to", 2)[0];

            if (txt.Contains("BTC"))
            {
                return BtcSales.Parse(text);
            }

            if (txt.Contains("ETH"))
            {
                return EthSales.Parse(text);
            }

            return new Sales();
        }
    }



    public class BtcSales : Sales
    {
        public BtcSales()
        {

        }

        public new static BtcSales Parse(string text)
        {
            var txt = text.Split(' ', 1)[0];

            if (txt.Contains("I"))
            {
                return SignableBtcSales.Parse(text);
            }

            if (txt.Contains("We"))
            {
                return ConfirmedBtcSales.Parse(text);
            }
            return new BtcSales();
        }
    }

    public class SignableBtcSales : BtcSales
    {
        public SignableBtcSales()
        {

        }

        public new static SignableBtcSales Parse(string text)
        {
            return new SignableBtcSales();
        }
    }

    public class ConfirmedBtcSales : BtcSales
    {
        public ConfirmedBtcSales()
        {

        }

        public new static ConfirmedBtcSales Parse(string text)
        {
            return new ConfirmedBtcSales();
        }
    }



    public class EthSales : Sales
    {
        public EthSales()
        {

        }

        public new static EthSales Parse(string text)
        {
            var txt = text.Split(' ', 1)[0];


            if (txt.Contains("I"))
            {
                return SignableEthSales.Parse(text);
            }

            if (txt.Contains("We"))
            {
                return ConfirmedEthSales.Parse(text);
            }

            return new EthSales();
        }
    }

    public class SignableEthSales : EthSales
    {
        public SignableEthSales()
        {

        }

        public new static SignableEthSales Parse(string text)
        {
            return new SignableEthSales();
        }
    }

    public class ConfirmedEthSales : EthSales
    {
        public ConfirmedEthSales()
        {

        }

        public new static ConfirmedEthSales Parse(string text)
        {
            return new ConfirmedEthSales();
        }
    }

}


