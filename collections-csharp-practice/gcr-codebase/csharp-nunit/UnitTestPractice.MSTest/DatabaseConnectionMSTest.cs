using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseUtilities;

namespace DatabaseUtilities.Tests.MSTest
{
    [TestClass]
    public class DatabaseConnectionTests
    {
        private DatabaseConnection _dbConnection;

        [TestInitialize]
        public void Setup()
        {
            _dbConnection = new DatabaseConnection();
            _dbConnection.Connect();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _dbConnection.Disconnect();
        }

        [TestMethod]
        public void Connect_ShouldEstablishConnection()
        {
            Assert.IsTrue(_dbConnection.IsConnected);
        }

        [TestMethod]
        public void Disconnect_ShouldCloseConnection()
        {
            _dbConnection.Disconnect();
            Assert.IsFalse(_dbConnection.IsConnected);
        }
    }
}
