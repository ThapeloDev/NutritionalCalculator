using Microsoft.VisualStudio.TestTools.UnitTesting;
using NutritionalCalculator.Classes;
using NutritionalCalculator.Classes.Interfaces;
using NutritionalCalculator.Model;
using NutritionalCalculator.Model.Entities;
using NutritionalCalculator.Unit.Test.Mocks;

namespace NutritionalCalculator.Unit.Test.Api.Classes
{
    [TestClass]
    public class UserManagerTests
    {
        private IUnitOfWork unitOfWork = new UnitOfWorkMock();
        private IRoles roles = new RolesMock();

        [TestMethod]
        public void Create_ok_test()
        {
            IUserManager userManager = new UserManager(unitOfWork, roles);
            EditedUser user = UserValid();
            var response = userManager.Create(user);
            Assert.IsTrue(response.IsValid);
            Assert.AreEqual(user.UserName, response.User.UserName);
        }

        [TestMethod]
        public void Create_bad_test()
        {
            IUserManager userManager = new UserManager(unitOfWork, roles);
            EditedUser user = UserValid();
            user.UserName = "RegisteredUser";
            var response = userManager.Create(user);
            Assert.IsFalse(response.IsValid);
            Assert.IsNull(response.User);
        }

        private EditedUser UserValid()
        {
            return new EditedUser()
            {
                UserName = "UserNameTest",
                FirstName = "First name test",
                LastName = "Last name test",
                Email = "email@test",
                Password = "P@ssw0rd"
            };
        }
    }
}
