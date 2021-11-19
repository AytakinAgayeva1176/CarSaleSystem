using System;
using System.Collections.Generic;
using System.Text;

namespace CSSAccess.ViewModels
{
    public class CarSearchModel
    {
		
		public int? BrandId { get; set; }
		public int? ModelId { get; set; }
		public int ?TransmissionId { get; set; }
		public string Color { get; set; }
		public decimal? lowPrice { get; set; }
		public decimal? highPrice { get; set; }
	}
}
