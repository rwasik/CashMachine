using CashMachineApi.Models.Dtos;

namespace CashMachineApi.Services
{
    public interface INotesInfoService
    {
        NotesInfo DetermineNotesQuantity(int amount);
    }
}
