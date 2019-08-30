using System;
using System.Collections.Generic;

namespace CashMachineApi.Services.PipeService
{
    public class PipeService<TPipeModel> : IPipeService<TPipeModel>
    {
        private readonly IList<Action<TPipeModel>> _pipeActions;

        public PipeService()
        {
            _pipeActions = new List<Action<TPipeModel>>();
        }
        
        public IPipeService<TPipeModel> Add(Action<TPipeModel> pipeAction)
        {
            _pipeActions.Add(pipeAction);
            return this;
        }

        public void Execute(TPipeModel pipeModel)
        {
            foreach (var linkAction in _pipeActions)
            {
                linkAction.Invoke(pipeModel);
            }
        }
    }
}
