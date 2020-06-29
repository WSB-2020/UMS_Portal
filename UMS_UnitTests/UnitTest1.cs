using System;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UMS_Portal.DAL;
using UMS_Portal.Services;

namespace UMS_UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private MainDataAccessService das = new MainDataAccessService( new ApplicationDbContext());
        [TestMethod]
        public async Task TestMethod1()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;

            var x = await das.GetUserList();

            // Act
            account.Debit(debitAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }
    }
}
