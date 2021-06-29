using System;
using StoreDapper.Domain.StoreContext.Enums;

namespace StoreDapper.Domain.StoreContext
{
    public class Delivery
    {
        public DateTime CreateDate { get; private set; }
        public DateTime EstimatedDeliveryDate { get; private set; }
        public EDeliveryStatus Status {get; private set;}
    }
}