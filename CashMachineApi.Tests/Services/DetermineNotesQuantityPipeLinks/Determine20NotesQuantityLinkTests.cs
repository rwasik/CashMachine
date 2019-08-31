using CashMachineApi.Models.PipeModels;
using CashMachineApi.Services.DetermineNotesQuantityPipeLinks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CashMachineApi.Tests.Services.DetermineNotesQuantityPipeLinks
{
    [TestClass]
    public class Determine20NotesQuantityLinkTests
    {
        [TestMethod]
        public void Execute_WhenRequestedAmountIsLessThan20_20NotesQuantityShouldBe0_AmountSholdNotBeChanged()
        {
            var amount = 10;
            var pipeModel = new NotesModel { Amount = amount };

            new Determine20NotesQuantityLink().Execute(pipeModel);

            Assert.AreEqual(0, pipeModel.QuantityOf20Notes);
            Assert.AreEqual(amount, pipeModel.Amount);
        }

        [TestMethod]
        public void Execute_WhenRequestedAmountIs100_20NotesQuantityShouldBe5_RemainingAmountShouldBe0()
        {
            var amount = 100;
            var pipeModel = new NotesModel { Amount = amount };

            new Determine20NotesQuantityLink().Execute(pipeModel);

            Assert.AreEqual(5, pipeModel.QuantityOf20Notes);
            Assert.AreEqual(0, pipeModel.Amount);
        }

        [TestMethod]
        public void Execute_WhenRequestedAmountIs110_20NotesQuantityShouldBe5_RemainingAmountShouldBe10()
        {
            var amount = 110;
            var pipeModel = new NotesModel { Amount = amount };

            new Determine20NotesQuantityLink().Execute(pipeModel);

            Assert.AreEqual(5, pipeModel.QuantityOf20Notes);
            Assert.AreEqual(10, pipeModel.Amount);
        }
    }
}
