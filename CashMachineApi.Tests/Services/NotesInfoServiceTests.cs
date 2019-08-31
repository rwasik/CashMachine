using CashMachineApi.Services;
using CashMachineApi.Services.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CashMachineApi.Tests.Services
{
    [TestClass]
    public class NotesInfoServiceTests
    {        
        [TestMethod]
        public void DetermineNotesQuantity_WhenAmountIs290_ShouldHave2Of100And1Of50And2Of20()
        {
            var amount = 290;
            var service = new NotesInfoService(new DetermineNotesQuantityPipeFactory());

            var notesInfo = service.DetermineNotesQuantity(amount);

            Assert.AreEqual(2, notesInfo.QuantityOf100Notes);
            Assert.AreEqual(1, notesInfo.QuantityOf50Notes);
            Assert.AreEqual(2, notesInfo.QuantityOf20Notes);
            Assert.AreEqual(0, notesInfo.QuantityOf10Notes);
            Assert.IsNull(notesInfo.ErrorMessage);
        }

        [TestMethod]
        public void DetermineNotesQuantity_WhenAmountIs260_ShouldHave2Of100And1Of50And1Of10()
        {
            var amount = 260;
            var service = new NotesInfoService(new DetermineNotesQuantityPipeFactory());

            var notesInfo = service.DetermineNotesQuantity(amount);

            Assert.AreEqual(2, notesInfo.QuantityOf100Notes);
            Assert.AreEqual(1, notesInfo.QuantityOf50Notes);
            Assert.AreEqual(0, notesInfo.QuantityOf20Notes);
            Assert.AreEqual(1, notesInfo.QuantityOf10Notes);
            Assert.IsNull(notesInfo.ErrorMessage);
        }

        [TestMethod]
        public void DetermineNotesQuantity_WhenAmountIsLessThan0_ShouldReturnInvalidAmountErrorMessage()
        {
            var amount = -10;
            var service = new NotesInfoService(new DetermineNotesQuantityPipeFactory());

            var notesInfo = service.DetermineNotesQuantity(amount);

            Assert.AreEqual(0, notesInfo.QuantityOf100Notes);
            Assert.AreEqual(0, notesInfo.QuantityOf50Notes);
            Assert.AreEqual(0, notesInfo.QuantityOf20Notes);
            Assert.AreEqual(0, notesInfo.QuantityOf10Notes);
            Assert.AreEqual("Invalid amount", notesInfo.ErrorMessage);
        }

        [TestMethod]
        public void DetermineNotesQuantity_WhenAmountDoesNotEndWith0_ShouldReturnNoteUnavailableErrorMessage()
        {
            var amount = 125;
            var service = new NotesInfoService(new DetermineNotesQuantityPipeFactory());

            var notesInfo = service.DetermineNotesQuantity(amount);

            Assert.AreEqual(0, notesInfo.QuantityOf100Notes);
            Assert.AreEqual(0, notesInfo.QuantityOf50Notes);
            Assert.AreEqual(0, notesInfo.QuantityOf20Notes);
            Assert.AreEqual(0, notesInfo.QuantityOf10Notes);
            Assert.AreEqual("Note unavailable", notesInfo.ErrorMessage);
        }
    }
}
