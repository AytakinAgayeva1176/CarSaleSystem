using CSSEntity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CSSEntity.Concrete
{
    public class Car : BaseEntity, IBaseEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public string ProductionYear { get; set; }
        public string Engine { get; set; }
        public int TransmissionId { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }

        public Brand Brand { get; set; }
        public Model Model { get; set; }
        public Transmission Transmission { get; set; }
    }
}
