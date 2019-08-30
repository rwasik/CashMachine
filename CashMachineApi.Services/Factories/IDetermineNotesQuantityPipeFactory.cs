using CashMachineApi.Models.PipeModels;
using CashMachineApi.Services.PipeService;

namespace CashMachineApi.Services.Factories
{
    public interface IDetermineNotesQuantityPipeFactory
    {
        IPipeService<NotesModel> CreatePipe();
    }
}
