using CashMachineApi.Models.PipeModels;
using CashMachineApi.Services.DetermineNotesQuantityPipeLinks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CashMachineApi.Tests.Services.DetermineNotesQuantityPipeLinks
{
    [TestClass]
    public class Determine100NotesQuantityLinkTests
    {
        [TestMethod]
        public void Execute_WhenRequestedAmountIsLessThan100_100NotesQuantityShouldBe0_AmountSholdNotBeChanged()
        {
            var amount = 90;
            var pipeModel = new NotesModel { Amount = amount };

            new Determine100NotesQuantityLink().Execute(pipeModel);

            Assert.AreEqual(0, pipeModel._100NotesQty);
            Assert.AreEqual(amount, pipeModel.Amount);
        }

        [TestMethod]
        public void Execute_WhenRequestedAmountIs150_100NotesQuantityShouldBe1_RemainingAmountShouldBe50()
        {
            var amount = 150;
            var pipeModel = new NotesModel { Amount = amount };

            new Determine100NotesQuantityLink().Execute(pipeModel);

            Assert.AreEqual(1, pipeModel._100NotesQty);
            Assert.AreEqual(50, pipeModel.Amount);
        }

        [TestMethod]
        public void Execute_WhenRequestedAmountIs290_100NotesQuantityShouldBe2_RemainingAmountShouldBe90()
        {
            var amount = 290;
            var pipeModel = new NotesModel { Amount = amount };

            new Determine100NotesQuantityLink().Execute(pipeModel);

            Assert.AreEqual(2, pipeModel._100NotesQty);
            Assert.AreEqual(90, pipeModel.Amount);
        }
    }
}
