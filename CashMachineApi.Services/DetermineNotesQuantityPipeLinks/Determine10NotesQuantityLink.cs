using CashMachineApi.Models.PipeModels;
using CashMachineApi.Services.PipeService;

namespace CashMachineApi.Services.DetermineNotesQuantityPipeLinks
{
    public class Determine10NotesQuantityLink : IPipeLink<NotesModel>
    {
        private const int NoteValue = 10;

        public void Execute(NotesModel pipeModel)
        {
            int quantity = pipeModel.Amount / NoteValue;

            if (quantity == 0)
                return;

            pipeModel.QuantityOf10Notes = quantity;
            pipeModel.Amount -= quantity * NoteValue;
        }
    }
}
