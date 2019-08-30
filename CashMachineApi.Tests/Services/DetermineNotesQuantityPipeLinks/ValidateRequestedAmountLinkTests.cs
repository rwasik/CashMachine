using System;
using CashMachineApi.Models.PipeModels;
using CashMachineApi.Services.DetermineNotesQuantityPipeLinks;
using CashMachineApi.Services.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CashMachineApi.Tests.Services.DetermineNotesQuantityPipeLinks
{
    [TestClass]
    public class ValidateRequestedAmountLinkTests
    {
        [TestMethod]
        public void Execute_IfAmountIsLessThan0_ArgumentExceptionShouldBeThrown()
        {
            var amount = -130;
            var pipeModel = new NotesModel { Amount = amount };

            Assert.ThrowsException<ArgumentException>(() => new ValidateRequestedAmountLink().Execute(pipeModel));
        }

        [TestMethod]
        public void Execute_IfAmountIsGreaterThan0ButDoesNotEndWith0_NoteUnavailableExceptionShouldBeThrown()
        {
            var amount = 125;
            var pipeModel = new NotesModel { Amount = amount };

            Assert.ThrowsException<NoteUnavailableException>(() => new ValidateRequestedAmountLink().Execute(pipeModel));
        }

        [TestMethod]
        public void Execute_IfAmountIsGreaterThan0AndEndsWith0_NoExceptionShouldBeThrown()
        {
            var amount = 120;
            var pipeModel = new NotesModel { Amount = amount };

            new ValidateRequestedAmountLink().Execute(pipeModel);            
        }

    }
}
