namespace CashMachineApi.Services.PipeService
{
    public interface IPipeLink<TPipeModel>
    {
        void Execute(TPipeModel pipeModel);        
    }
}
