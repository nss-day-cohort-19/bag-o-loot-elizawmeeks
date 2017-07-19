using System;
using System.Collections.Generic;
using Xunit;

namespace BagOLoot.Tests
{
    public class ListHelperShould
    {
        private ListHelper _listHelper;
        public ListHelperShould()
        {
            _listHelper = new ListHelper();
        }
        [Fact]
        public void GetListOfChildren()
        {
            var childrenList = _listHelper.GetChildren();

            Assert.IsType<List<string>>(childrenList);
        }
        [Fact]
        public void GetOneChildsToyList()
        {
            List<string> childToyList = _listHelper.GetOneToyList();

            Assert.IsType<List<string>>(childToyList);
        }
    }
}
