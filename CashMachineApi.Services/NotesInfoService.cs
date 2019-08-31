using System;
using CashMachineApi.Models.Dtos;
using CashMachineApi.Models.PipeModels;
using CashMachineApi.Services.Exceptions;
using CashMachineApi.Services.Factories;

namespace CashMachineApi.Services
{
    public class NotesInfoService : INotesInfoService
    {
        private readonly IDetermineNotesQuantityPipeFactory _pipeFactory;

        public NotesInfoService(IDetermineNotesQuantityPipeFactory pipeFactory)
        {
            _pipeFactory = pipeFactory;
        }

        public NotesInfo DetermineNotesQuantity(int amount)
        {
            try
            {
                var pipe = _pipeFactory.CreatePipe();

                var pipeModel = new NotesModel
                {
                    Amount = amount
                };

                pipe.Execute(pipeModel);

                return new NotesInfo
                {
                    QuantityOf100Notes = pipeModel.QuantityOf100Notes,
                    QuantityOf50Notes = pipeModel.QuantityOf50Notes,
                    QuantityOf20Notes = pipeModel.QuantityOf20Notes,
                    QuantityOf10Notes = pipeModel.QuantityOf10Notes
                };
            }
            catch (NoteUnavailableException)
            {
                return new NotesInfo { ErrorMessage = "Note unavailable" };
            }
            catch (ArgumentException)
            {
                return new NotesInfo { ErrorMessage = "Invalid amount" };
            }           
        }
    }
}
