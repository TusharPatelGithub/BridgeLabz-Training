using Microsoft.VisualStudio.TestTools.UnitTesting;
using ListUtilities;
using System.Collections.Generic;

namespace ListUtilities.Tests.MSTest
{
    [TestClass]
    public class ListManagerTests
    {
        private ListManager _listManager;
        private List<int> _list;

        [TestInitialize]
        public void Setup()
        {
            _listManager = new ListManager();
            _list = new List<int>();
        }

        [TestMethod]
        public void AddElement_AddsElementToList()
        {
            _listManager.AddElement(_list, 10);

            Assert.IsTrue(_list.Contains(10));
            Assert.AreEqual(1, _list.Count);
        }

        [TestMethod]
        public void RemoveElement_RemovesElementFromList()
        {
            _list.Add(10);
            _list.Add(20);

            _listManager.RemoveElement(_list, 10);

            Assert.IsFalse(_list.Contains(10));
            Assert.AreEqual(1, _list.Count);
        }

        [TestMethod]
        public void GetSize_ReturnsCorrectSize()
        {
            _list.Add(5);
            _list.Add(15);
            _list.Add(25);

            int size = _listManager.GetSize(_list);

            Assert.AreEqual(3, size);
        }
    }
}
