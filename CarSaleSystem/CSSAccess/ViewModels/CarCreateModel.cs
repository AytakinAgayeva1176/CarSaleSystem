using System;
using System.Collections.Generic;
using System.Text;

namespace CSSAccess.ViewModels
{
    public class CarCreateModel
    {
		public int BrandId { get; set; }
		public int ModelId { get; set; }
		public string ProductionYear { get; set; }
		public string Engine { get; set; }
		public int TransmissionId { get; set; }
		public string Color { get; set; }
		public decimal Price { get; set; }
	}
}
