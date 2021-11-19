using CSSAccess.Abstract.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSSAccess.ViewModels
{
    public class BrandViewModel : BaseViewModel, IBaseViewModel<int>
    {
        public int Id { get; set; }
    }
}
