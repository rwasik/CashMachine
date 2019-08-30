using CashMachineApi.Models.PipeModels;
using CashMachineApi.Services.PipeService;

namespace CashMachineApi.Services.DetermineNotesQuantityPipeLinks
{
    public class Determine100NotesQuantityLink : IPipeLink<NotesModel>
    {
        private const int NoteValue = 100;

        public void Execute(NotesModel pipeModel)
        {
            int quantity = pipeModel.Amount / NoteValue;

            if (quantity == 0)
                return;

            pipeModel._100NotesQty = quantity;
            pipeModel.Amount -= quantity * NoteValue;
        }
    }
}
