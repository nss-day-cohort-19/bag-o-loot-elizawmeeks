using System;
using System.Collections.Generic;
using Xunit;

namespace BagOLoot.Tests
{
    public class ChildRegisterShould
    {
        private readonly ChildRegister _register;
        private ListHelper _list;

        public ChildRegisterShould()
        {
            _register = new ChildRegister();
            _list = new ListHelper();
        }

        [Theory]
        [InlineData("Sarah")]
        [InlineData("Jamal")]
        [InlineData("Kelly")]
        public void AddChildren(string child)
        {
            var result = _register.AddChild(child);
            Assert.True(result);
        }

        [Fact]
        public void ReturnListOfChildren()
        {
            var result = _list.GetChildren();
            Assert.IsType<List<string>>(result);
        }

        
    }
}
