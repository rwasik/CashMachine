namespace CashMachineApi.Models.Dtos
{
    public class NotesInfo
    {        
        public int QuantityOf100Notes { get; set; }
        public int QuantityOf50Notes { get; set; }
        public int QuantityOf20Notes { get; set; }
        public int QuantityOf10Notes { get; set; }

        public string ErrorMessage { get; set; }
    }
}
