using System;
using Swopblock.Orders;

namespace Swopblock.TestOrders
{
    #region Entry Test Items

    public class TestIEntryItem : IEntryItem
    {
        [Fact]
        public void TestAssignableFromIEntryItem()
        {
            Assert.IsAssignableFrom<IEntryItem>(this);
        }
    }

    public class TestIBuyEntryItem : IBuyEntryItem
    {
        [Fact]
        public void TestAssignableFromIEntryItem()
        {
            Assert.IsAssignableFrom<IEntryItem>(this);
        }

        [Fact]
        public void TestAssignableFromIBuyEntryItem()
        {
            Assert.IsAssignableFrom<IBuyEntryItem>(this);
        }
    }

    public class TestISellEntryItem : ISellEntryItem
    {
        [Fact]
        public void TestAssignableFromIEntryItem()
        {
            Assert.IsAssignableFrom<IEntryItem>(this);
        }

        [Fact]
        public void TestAssignableFromISellEntryItem()
        {
            Assert.IsAssignableFrom<ISellEntryItem>(this);
        }
    }

    #endregion

    #region Charge Test Items

    public class TestIChargeItem : IChargeItem
    {
        [Fact]
        public void TestAssignableFromIEntryItem()
        {
            Assert.IsAssignableFrom<IEntryItem>(this);
        }

        [Fact]
        public void TestAssignableFromIChargeItem()
        {
            Assert.IsAssignableFrom<IChargeItem>(this);
        }
    }

    public class TestIBuyChargeItem : IBuyChargeItem
    {
        [Fact]
        public void TestAssignableFromIEntryItem()
        {
            Assert.IsAssignableFrom<IEntryItem>(this);
        }

        [Fact]
        public void TestAssignableFromIBuyEntryItem()
        {
            Assert.IsAssignableFrom<IBuyEntryItem>(this);
        }

        [Fact]
        public void TestAssignableFromIChargeItem()
        {
            Assert.IsAssignableFrom<IChargeItem>(this);
        }

        [Fact]
        public void TestAssignableFromIBuyChargeItem()
        {
            Assert.IsAssignableFrom<IBuyChargeItem>(this);
        }
    }

    public class TestISellChargeItem : ISellChargeItem
    {
        [Fact]
        public void TestAssignableFromIEntryItem()
        {
            Assert.IsAssignableFrom<IEntryItem>(this);
        }

        [Fact]
        public void TestAssignableFromISellEntryItem()
        {
            Assert.IsAssignableFrom<ISellEntryItem>(this);
        }
        [Fact]
        public void TestAssignableFromIChargeItem()
        {
            Assert.IsAssignableFrom<IChargeItem>(this);
        }

        [Fact]
        public void TestAssignableFromISellChargeItem()
        {
            Assert.IsAssignableFrom<ISellChargeItem>(this);
        }
    }

    #endregion

    #region Discharge Test Items

    public class TestIDischargeItem : IDischargeItem
    {
        [Fact]
        public void TestAssignableFromIEntryItem()
        {
            Assert.IsAssignableFrom<IEntryItem>(this);
        }

        [Fact]
        public void TestAssignableFromIChargeItem()
        {
            Assert.IsAssignableFrom<IChargeItem>(this);
        }

        [Fact]
        public void TestAssignableFromIDischargeItem()
        {
            Assert.IsAssignableFrom<IDischargeItem>(this);
        }
    }

    public class TestIBuyDischargeItem : IBuyDischargeItem
    {
        [Fact]
        public void TestAssignableFromIDisChargeItem()
        {
            Assert.IsAssignableFrom<IDischargeItem>(this);
        }

        [Fact]
        public void TestAssignableFromIEntryItem()
        {
            Assert.IsAssignableFrom<IEntryItem>(this);
        }

        [Fact]
        public void TestAssignableFromIChargeItem()
        {
            Assert.IsAssignableFrom<IChargeItem>(this);
        }

        [Fact]
        public void TestAssignableFromIBuyEntryItem()
        {
            Assert.IsAssignableFrom<IBuyEntryItem>(this);
        }

        [Fact]
        public void TestAssignableFromIBuyChargeItem()
        {
            Assert.IsAssignableFrom<IBuyChargeItem>(this);
        }

        [Fact]
        public void TestAssignableFromIBuyDischareItem()
        {
            Assert.IsAssignableFrom<IBuyDischargeItem>(this);
        }
    }

    public class TestISellDischargeItem : ISellDischargeItem
    {
        [Fact]
        public void TestAssignableFromIDisChargeItem()
        {
            Assert.IsAssignableFrom<IDischargeItem>(this);
        }

        [Fact]
        public void TestAssignableFromIEntryItem()
        {
            Assert.IsAssignableFrom<IEntryItem>(this);
        }

        [Fact]
        public void TestAssignableFromIChargeItem()
        {
            Assert.IsAssignableFrom<IChargeItem>(this);
        }

        [Fact]
        public void TestAssignableFromISellEntryItem()
        {
            Assert.IsAssignableFrom<ISellEntryItem>(this);
        }

        [Fact]
        public void TestAssignableFromISellChargeItem()
        {
            Assert.IsAssignableFrom<ISellChargeItem>(this);
        }

        [Fact]
        public void TestAssignableFromISellDischareItem()
        {
            Assert.IsAssignableFrom<ISellDischargeItem>(this);
        }
    }



    #endregion

    #region Offer Test Items

    public class TestIOfferItem : IOfferItem
    {
        [Fact]
        public void TestAssignableFromIEntryItem()
        {
            Assert.IsAssignableFrom<IEntryItem>(this);
        }

        [Fact]
        public void TestAssignableFromIChargeItem()
        {
            Assert.IsAssignableFrom<IChargeItem>(this);
        }

        [Fact]
        public void TestAssignableFromIOfferItem()
        {
            Assert.IsAssignableFrom<IOfferItem>(this);
        }
    }

    public class TestIBidItem : IBidItem
    {
        [Fact]
        public void TestAssignableFromIOfferItem()
        {
            Assert.IsAssignableFrom<IOfferItem>(this);
        }

        [Fact]
        public void TestAssignableFromIBuyChargeItem()
        {
            Assert.IsAssignableFrom<IBuyChargeItem>(this);
        }

        [Fact]
        public void TestAssignableFromIBuyEntryItem()
        {
            Assert.IsAssignableFrom<IBuyEntryItem>(this);
        }
    }

    public class TestIAskItem : IAskItem
    {
        [Fact]
        public void TestAssignableFromIOfferItem()
        {
            Assert.IsAssignableFrom<IOfferItem>(this);
        }

        [Fact]
        public void TestAssignableFromISellChargeItem()
        {
            Assert.IsAssignableFrom<ISellChargeItem>(this);
        }

        [Fact]
        public void TestAssignableFromISellEntryItem()
        {
            Assert.IsAssignableFrom<ISellEntryItem>(this);
        }
    }


    #endregion

    #region Invoice Test Items

    public class TestIInvoiceItem : IInvoiceItem
    {
        [Fact]
        public void TestAssignableFromIInvoiceItem()
        {
            Assert.IsAssignableFrom<IInvoiceItem>(this);
        }

        [Fact]
        public void TestAssignableFromIOfferItem()
        {
            Assert.IsAssignableFrom<IOfferItem>(this);
        }

        [Fact]
        public void TestAssignableFromIChargeItem()
        {
            Assert.IsAssignableFrom<IChargeItem>(this);
        }

    }

    public class TestIBuyItem : IBuyItem
    {
        [Fact]
        public void TestAssignableFromIBuyItem()
        {
            Assert.IsAssignableFrom<IBuyItem>(this);
        }

        [Fact]
        public void TestAssignableFromIInvoiceItem()
        {
            Assert.IsAssignableFrom<IInvoiceItem>(this);
        }

        [Fact]
        public void TestAssignableFromIBidItem()
        {
            Assert.IsAssignableFrom<IBidItem>(this);
        }
    }

    public class TestISellItem : ISellItem
    {
        [Fact]
        public void TestAssignableFromISellItem()
        {
            Assert.IsAssignableFrom<ISellItem>(this);
        }

        [Fact]
        public void TestAssignableFromIInvoiceItem()
        {
            Assert.IsAssignableFrom<IInvoiceItem>(this);
        }

        [Fact]
        public void TestAssignableFromIAskItem()
        {
            Assert.IsAssignableFrom<IAskItem>(this);
        }
    }


    #endregion

    #region Delivery Test Items

    public class TestIDeliveryItem : IDeliveryItem
    {
        [Fact]
        public void TestAssignableFromIEntryItem()
        {
            Assert.IsAssignableFrom<IEntryItem>(this);
        }

        [Fact]
        public void TestAssignableFromIChargeItem()
        {
            Assert.IsAssignableFrom<IChargeItem>(this);
        }

        [Fact]
        public void TestAssignableFromIOfferItem()
        {
            Assert.IsAssignableFrom<IOfferItem>(this);
        }

        [Fact]
        public void TestAssignableFromIInvoiceItem()
        {
            Assert.IsAssignableFrom<IDischargeItem>(this);
        }

        [Fact]
        public void TestAssignableFromIDeliveryItem()
        {
            Assert.IsAssignableFrom<IDeliveryItem>(this);
        }
    }

    public class TestIPaymentItem : IPaymentItem
    {
        [Fact]
        public void TestAssignableFromIPaymentItem()
        {
            Assert.IsAssignableFrom<IPaymentItem>(this);
        }

        [Fact]
        public void TestAssignableFromIDeliveryItem()
        {
            Assert.IsAssignableFrom<IDeliveryItem>(this);
        }

        [Fact]
        public void TestAssignableFromIBuyItem()
        {
            Assert.IsAssignableFrom<IBuyItem>(this);
        }
    }

    public class TestICashingItem : ICashingItem
    {
        [Fact]
        public void TestAssignableFromICashingItem()
        {
            Assert.IsAssignableFrom<ICashingItem>(this);
        }

        [Fact]
        public void TestAssignableFromIDeliveryItem()
        {
            Assert.IsAssignableFrom<IDeliveryItem>(this);
        }

        [Fact]
        public void TestAssignableFromISellItem()
        {
            Assert.IsAssignableFrom<ISellItem>(this);
        }
    }


    #endregion

    #region Receipt Test Items

    public class TestIReceiptItem : IReceiptItem
    {
        [Fact]
        public void TestAssignableFromIEntryItem()
        {
            Assert.IsAssignableFrom<IEntryItem>(this);
        }

        [Fact]
        public void TestAssignableFromIChargeItem()
        {
            Assert.IsAssignableFrom<IChargeItem>(this);
        }

        [Fact]
        public void TestAssignableFromIOfferItem()
        {
            Assert.IsAssignableFrom<IOfferItem>(this);
        }

        [Fact]
        public void TestAssignableFromIInvoiceItem()
        {
            Assert.IsAssignableFrom<IDischargeItem>(this);
        }

        [Fact]
        public void TestAssignableFromIDeliveryItem()
        {
            Assert.IsAssignableFrom<IDeliveryItem>(this);
        }

        [Fact]
        public void TestAssignableFromIReceiptItem()
        {
            Assert.IsAssignableFrom<IReceiptItem>(this);
        }
    }

    public class TestIExpenseItem : IExpenseItem
    {
        [Fact]
        public void TestAssignableFromIExpenseItem()
        {
            Assert.IsAssignableFrom<IExpenseItem>(this);
        }

        [Fact]
        public void TestAssignableFromIRecieptItem()
        {
            Assert.IsAssignableFrom<IReceiptItem>(this);
        }

        [Fact]
        public void TestAssignableFromIPaymentItem()
        {
            Assert.IsAssignableFrom<IPaymentItem>(this);
        }
    }

    public class TestIIncomeItem : IIncomeItem
    {
        [Fact]
        public void TestAssingableFromIIncomeItem()
        {
            Assert.IsAssignableFrom<IIncomeItem>(this);
        }

        [Fact]
        public void TestAssignableFromIDischareItem()
        {
            Assert.IsAssignableFrom<IReceiptItem>(this);
        }

        [Fact]
        public void TestAssignableFromICashingItem()
        {
            Assert.IsAssignableFrom<ICashingItem>(this);
        }
    }

    #endregion

    #region Order Test Items

    public class TestIOrderItem : IOrderItem
    {
        [Fact]
        public void TestAssignableFromIEntryItem()
        {
            Assert.IsAssignableFrom<IEntryItem>(this);
        }

        [Fact]
        public void TestAssignableFromIChargeItem()
        {
            Assert.IsAssignableFrom<IChargeItem>(this);
        }

        [Fact]
        public void TestAssignableFromIOfferItem()
        {
            Assert.IsAssignableFrom<IOfferItem>(this);
        }

        [Fact]
        public void TestAssignableFromIInvoiceItem()
        {
            Assert.IsAssignableFrom<IInvoiceItem>(this);
        }

        [Fact]
        public void TestAssignableFromIDischareItem()
        {
            Assert.IsAssignableFrom<IDischargeItem>(this);
        }

        [Fact]
        public void TestAssignableFromIDeliveryItem()
        {
            Assert.IsAssignableFrom<IDeliveryItem>(this);
        }

        [Fact]
        public void TestAssignableFromIReceiptItem()
        {
            Assert.IsAssignableFrom<IReceiptItem>(this);
        }

        [Fact]
        public void TestAssignableFromIOrderItem()
        {
            Assert.IsAssignableFrom<IOrderItem>(this);
        }
    }

    public class TestIBuyOrderItem : IBuyOrderItem
    {
        [Fact]
        public void TestAssignableFromIBuyOrderItem()
        {
            Assert.IsAssignableFrom<IBuyOrderItem>(this);
        }

        [Fact]
        public void TestAssignableFromIOrderItem()
        {
            Assert.IsAssignableFrom<IOrderItem>(this);
        }

        [Fact]
        public void TestAssignableFromIExpenseItem()
        {
            Assert.IsAssignableFrom<IExpenseItem>(this);
        }
    }

    public class TestISellOrderItem : ISellOrderItem
    {
        [Fact]
        public void TestAssignableFromISellOrderItem()
        {
            Assert.IsAssignableFrom<ISellOrderItem>(this);
        }

        [Fact]
        public void TestAssignableFromIOrderItem()
        {
            Assert.IsAssignableFrom<IOrderItem>(this);
        }

        [Fact]
        public void TestAssignableFromIIncomeItem()
        {
            Assert.IsAssignableFrom<IIncomeItem>(this);
        }
    }

    #endregion
}

