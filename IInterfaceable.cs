using System;

namespace swop
{
    namespace Order
    {
        public interface IOrder { IOrder New(); }

        public interface IOrderable { IOrdered Order(IOrder order); }

        public interface IOrdered : IVerifiable{ }

        public interface IVerifiable { IVerified Order(IOrder order); }

        public interface IVerified : ISignable { }

        public interface ISignable { ISigned Sign(IVerified order); }

        public interface ISigned : ISubmittable { }

        public interface ISubmittable { ISubmitted Submit(ISigned order); }

        public interface ISubmitted : IConfirmable{ }

        public interface IConfirmable { IConfirmed Confirm(ISubmitted order); }

        public interface IConfirmed : IOrdered { }

        namespace Charge //IAMHERE
        {
            public interface IExecutable { }

            public interface IExecuted { }

            namespace Offer
            {
                public interface IOfferable { }

                public interface IOffered { }
            }

            namespace Invoice
            {
                public interface Invoiceable { }

                public interface Invoiced { }
            }

        }

        namespace Discharge
        {
            public interface IAdministratable { }

            public interface IAdministated { }

            namespace Deliver
            {
                public interface IDeliverable { }

                public interface IDelivered { }
            }

            namespace Receipt
            {
                public interface IReceiptable { }

                public interface IReceipted { }
            }
        }
    }
}