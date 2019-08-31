using CashMachineApi.Models.PipeModels;
using CashMachineApi.Services.DetermineNotesQuantityPipeLinks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CashMachineApi.Tests.Services.DetermineNotesQuantityPipeLinks
{
    [TestClass]
    public class Determine50NotesQuantityLinkTests
    {
        [TestMethod]
        public void Execute_WhenRequestedAmountIsLessThan50_50NotesQuantityShouldBe0_AmountSholdNotBeChanged()
        {
            var amount = 40;
            var pipeModel = new NotesModel { Amount = amount };

            new Determine50NotesQuantityLink().Execute(pipeModel);

            Assert.AreEqual(0, pipeModel.QuantityOf50Notes);
            Assert.AreEqual(amount, pipeModel.Amount);
        }

        [TestMethod]
        public void Execute_WhenRequestedAmountIs110_50NotesQuantityShouldBe2_RemainingAmountShouldBe10()
        {
            var amount = 110;
            var pipeModel = new NotesModel { Amount = amount };

            new Determine50NotesQuantityLink().Execute(pipeModel);

            Assert.AreEqual(2, pipeModel.QuantityOf50Notes);
            Assert.AreEqual(10, pipeModel.Amount);
        }        
    }
}
