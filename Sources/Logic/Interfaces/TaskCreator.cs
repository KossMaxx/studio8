using System;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface ITaskCreator
    {
        Task<TResult> Create<TResult>(Func<TResult> functor);
    }
}
