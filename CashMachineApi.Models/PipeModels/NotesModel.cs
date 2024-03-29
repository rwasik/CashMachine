﻿namespace CashMachineApi.Models.PipeModels
{
    public class NotesModel
    {
        // input / updated in pipe
        public int Amount { get; set; }

        // updated in pipe
        public int QuantityOf100Notes { get; set; }
        public int QuantityOf50Notes { get; set; }
        public int QuantityOf20Notes { get; set; }
        public int QuantityOf10Notes { get; set; }
    }
}
