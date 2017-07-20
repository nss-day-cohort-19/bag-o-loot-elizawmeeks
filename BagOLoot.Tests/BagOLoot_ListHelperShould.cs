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

            Assert.IsType<Dictionary<int, string>>(childrenList);
        }
        [Fact]
        public void GetOneChildsListOfToyIds()
        {
            int childId = 4;
            List<int> childToyList = _listHelper.GetChildsToyIds(childId);

            Assert.IsType<List<int>>(childToyList);
        }

        [Fact]
        public void GetOneChildsListOfToyNames()
        {
            int childId = 5;
            List<string> childToyList = _listHelper.GetChildsToys(childId);
            Assert.IsType<List<string>>(childToyList);
        }
    }
}
