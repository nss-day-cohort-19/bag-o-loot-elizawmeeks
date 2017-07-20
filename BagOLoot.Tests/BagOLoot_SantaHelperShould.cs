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
            int toyId = 15;
            int childId = _helper.RemoveToyFromBag(toyId);
            List<int> toys = _listMaster.GetChildsToyIds(childId);
            Assert.DoesNotContain(toyId, toys);
        }
    }
}
