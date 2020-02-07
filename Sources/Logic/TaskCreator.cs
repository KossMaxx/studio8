using System;
using System.Threading.Tasks;
using Logic.Interfaces;

namespace Logic
{
    public class TaskCreator:ITaskCreator
    {
        public async Task<TResult> Create<TResult>(Func<TResult> functor)
        {
            return await Task<TResult>.Factory.StartNew(functor);
        }
    }
}
