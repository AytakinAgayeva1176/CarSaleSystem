using CSSEntity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CSSEntity.Concrete
{
    public class Model : BaseEntity, IBaseEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
