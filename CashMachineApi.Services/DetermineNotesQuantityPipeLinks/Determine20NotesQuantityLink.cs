using CashMachineApi.Models.PipeModels;
using CashMachineApi.Services.PipeService;

namespace CashMachineApi.Services.DetermineNotesQuantityPipeLinks
{
    public class Determine20NotesQuantityLink : IPipeLink<NotesModel>
    {
        private const int NoteValue = 20;

        public void Execute(NotesModel pipeModel)
        {
            int quantity = pipeModel.Amount / NoteValue;

            if (quantity == 0)
                return;

            pipeModel._20NotesQty = quantity;
            pipeModel.Amount -= quantity * NoteValue;
        }
    }
}

