using NUnit.Framework;
using DatabaseUtilities;

namespace DatabaseUtilities.Tests.NUnit
{
    public class DatabaseConnectionTests
    {
        private DatabaseConnection _dbConnection;

        [SetUp]
        public void Setup()
        {
            _dbConnection = new DatabaseConnection();
            _dbConnection.Connect();
        }

        [TearDown]
        public void TearDown()
        {
            _dbConnection.Disconnect();
        }

        [Test]
        public void Connect_ShouldEstablishConnection()
        {
            Assert.IsTrue(_dbConnection.IsConnected);
        }

        [Test]
        public void Disconnect_ShouldCloseConnection()
        {
            _dbConnection.Disconnect();
            Assert.IsFalse(_dbConnection.IsConnected);
        }
    }
}
