using CSSEntity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CSSEntity.Concrete
{
    public class Transmission : BaseEntity, IBaseEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
