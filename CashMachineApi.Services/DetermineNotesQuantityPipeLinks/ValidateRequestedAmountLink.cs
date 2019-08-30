using System;
using CashMachineApi.Models.PipeModels;
using CashMachineApi.Services.Exceptions;
using CashMachineApi.Services.PipeService;

namespace CashMachineApi.Services.DetermineNotesQuantityPipeLinks
{
    public class ValidateRequestedAmountLink : IPipeLink<NotesModel>
    {
        public void Execute(NotesModel pipeModel)
        {
            if (pipeModel.Amount < 0)
                throw new ArgumentException();

            if (pipeModel.Amount % 10 != 0)
                throw new NoteUnavailableException();
        }
    }
}
