namespace CashMachineApi.Models.PipeModels
{
    public class NotesModel
    {
        // input / updated in pipe
        public int Amount { get; set; }

        // updated in pipe
        public int _100NotesQty { get; set; }
        public int _50NotesQty { get; set; }
        public int _20NotesQty { get; set; }
        public int _10NotesQty { get; set; }
    }
}
