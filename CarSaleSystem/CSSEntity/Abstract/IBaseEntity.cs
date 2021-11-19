using System;
using System.Collections.Generic;
using System.Text;

namespace CSSEntity.Abstract
{
    public interface IBaseEntity<T>
    {
         T Id { get; set; }
    }
}
