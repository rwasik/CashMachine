using CashMachineApi.Models.PipeModels;
using CashMachineApi.Services.PipeService;

namespace CashMachineApi.Services.DetermineNotesQuantityPipeLinks
{
    public class Determine50NotesQuantityLink : IPipeLink<NotesModel>
    {
        private const int NoteValue = 50;

        public void Execute(NotesModel pipeModel)
        {
            int quantity = pipeModel.Amount / NoteValue;

            if (quantity == 0)
                return;

            pipeModel._50NotesQty = quantity;
            pipeModel.Amount -= quantity * NoteValue;
        }
    }
}
