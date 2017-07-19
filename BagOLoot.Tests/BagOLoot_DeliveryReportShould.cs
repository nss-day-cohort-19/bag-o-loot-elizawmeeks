using System;
using System.Collections.Generic;
using Xunit;

namespace BagOLoot.Tests
{
    public class DeliveryReportShould
    {
        private DeliveryReport _delivery;
        public DeliveryReportShould()
        {
            _delivery = new DeliveryReport();
        }
        public void ConfirmDelivery()
        {
            int toy = 13;
            Boolean result = _delivery.DeliverToy(toy);
            Assert.True(result);
        }
    }
}
