﻿using FarmerCoopWebUI.Dtos.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmerCoopWebUI.Dtos.ProductDto
{
	public class CreateProductDto
	{
		public string ProductName { get; set; }
		public string Description { get; set; }
		public int AppUserId { get; set; }
		public string CityName { get; set; }
		public double Price { get; set; }
		public string ImageURL { get; set; }
		public bool StockStatus { get; set; }
		public string PhoneNumber { get; set; }
	}
}
