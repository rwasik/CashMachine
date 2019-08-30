using CashMachineApi.Models.PipeModels;
using CashMachineApi.Services.DetermineNotesQuantityPipeLinks;
using CashMachineApi.Services.PipeService;

namespace CashMachineApi.Services.Factories
{
    public class DetermineNotesQuantityPipeFactory : IDetermineNotesQuantityPipeFactory
    {
        public IPipeService<NotesModel> CreatePipe()
        {
            return new PipeService<NotesModel>()
                .Add(new ValidateRequestedAmountLink().Execute)
                .Add(new Determine100NotesQuantityLink().Execute)
                .Add(new Determine50NotesQuantityLink().Execute)
                .Add(new Determine20NotesQuantityLink().Execute)
                .Add(new Determine10NotesQuantityLink().Execute);
        }
    }
}
