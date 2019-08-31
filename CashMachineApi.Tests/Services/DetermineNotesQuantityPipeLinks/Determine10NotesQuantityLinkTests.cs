using CashMachineApi.Models.PipeModels;
using CashMachineApi.Services.DetermineNotesQuantityPipeLinks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CashMachineApi.Tests.Services.DetermineNotesQuantityPipeLinks
{
    [TestClass]
    public class Determine10NotesQuantityLinkTests
    {
        [TestMethod]
        public void Execute_WhenRequestedAmountIsLessThan10_10NotesQuantityShouldBe0_AmountSholdNotBeChanged()
        {
            var amount = 9;
            var pipeModel = new NotesModel { Amount = amount };

            new Determine10NotesQuantityLink().Execute(pipeModel);

            Assert.AreEqual(0, pipeModel.QuantityOf10Notes);
            Assert.AreEqual(amount, pipeModel.Amount);
        }

        [TestMethod]
        public void Execute_WhenRequestedAmountIs50_10NotesQuantityShouldBe5_RemainingAmountShouldBe0()
        {
            var amount = 50;
            var pipeModel = new NotesModel { Amount = amount };

            new Determine10NotesQuantityLink().Execute(pipeModel);

            Assert.AreEqual(5, pipeModel.QuantityOf10Notes);
            Assert.AreEqual(0, pipeModel.Amount);
        }

        [TestMethod]
        public void Execute_WhenRequestedAmountIs55_10NotesQuantityShouldBe5_RemainingAmountShouldBe5()
        {
            var amount = 55;
            var pipeModel = new NotesModel { Amount = amount };

            new Determine10NotesQuantityLink().Execute(pipeModel);

            Assert.AreEqual(5, pipeModel.QuantityOf10Notes);
            Assert.AreEqual(5, pipeModel.Amount);
        }
    }
}
