using Microsoft.VisualStudio.TestTools.UnitTesting;
using Snacklager.Data;
using Snacklager.Logic.Contracts;
using Snacklager.Logic.Enums;

namespace Snacklager.Logic.Tests
{
    [TestClass]
    public class LogicTests
    {
        // Arrange
        private readonly ISnackRepository _snackRepo = new SnackRepository();

        [TestMethod]
        public void SnackRepository_Should_Create_Snack()
        {
            // Arrange
            Snack snack = new Snack
            {
                Name = "Bounty",
                GewichtProEinheit = 12.34,
                SnackArtId = (int)SnackArtEnum.Schokolade
            };

            // Act
            _snackRepo.Insert(snack);
            bool result = _snackRepo.SaveAll();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SnackRepository_Should_Delete_Snack()
        {
            // Arrange
            int id = 1;

            // Act
            _snackRepo.Remove(id);
            _snackRepo.SaveAll();
            Snack snack = _snackRepo.FindById(id);

            // Assert
            Assert.IsNull(snack, "Snack is deleted.");
        }
    }
}
