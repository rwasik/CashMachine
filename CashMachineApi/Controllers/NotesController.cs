using CashMachineApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CashMachineApi.Controllers
{
    [Route("api/notes")]
    public class NotesController : Controller
    {
        private readonly INotesInfoService _notesInfoService;

        public NotesController(INotesInfoService notesInfoService)
        {
            _notesInfoService = notesInfoService;
        }

        [HttpGet("GetNotesQuantity")]
        public IActionResult GetNotesQuantity(int amount)
        {
            var notesInfo = _notesInfoService.DetermineNotesQuantity(amount);

            return Ok(notesInfo);
        }
    }
}