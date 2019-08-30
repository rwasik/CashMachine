using System;

namespace CashMachineApi.Services.PipeService
{
    public interface IPipeService<TPipeModel>
    {
        IPipeService<TPipeModel> Add(Action<TPipeModel> pipeAction);
        void Execute(TPipeModel pipeModel);
    }
}
