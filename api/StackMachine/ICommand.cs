using System;
using System.Collections.Generic;

namespace SimpleStackMachine
{
    public interface ICommand
    {
        void Run(IndexStack<object> stack);
    }
}
