using System;
using System.Collections.Generic;
using System.Text;

namespace CSSAccess.Abstract.ViewModels
{
    public interface IBaseViewModel<T>
    {
        T Id { get; set; }
    }
}
