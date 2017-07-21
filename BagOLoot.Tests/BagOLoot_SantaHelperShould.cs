using System;
using System.Collections.Generic;
using Xunit;

namespace BagOLoot.Tests
{
    public class SantaHelperShould
    {
        private readonly SantaHelper _helper;
        private ListHelper _listMaster;
        public SantaHelperShould()
        {
             _helper = new SantaHelper();
             _listMaster = new ListHelper();
        }

        [Fact]
        public void AddToyToChildsBag()
        {
            string toyName = "Skateboard";
            int childId = 715;
            int toyId = _helper.AddToyToBag(toyName, childId);
            List<int> toys = _listMaster.GetChildsToyIds(childId);

            Assert.Contains(toyId, toys);
        }

        [Fact]
        public void RemoveToyFromBagPerChild()
        {
            int toyId = 1;
            int kidId = 4;
            int childId = _helper.RemoveToyFromBag(toyId, kidId);
            List<int> toys = _listMaster.GetChildsToyIds(childId);
            Assert.DoesNotContain(toyId, toys);
        }

        [Fact]
        public void MarkToysAsDelivered()
        {
            int childId = 3;
            int boo = _helper.MarkAsDelivered(childId);
            Assert.Equal(boo, 1);
        }
    }
}
