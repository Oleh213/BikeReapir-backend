using System;
namespace BikeRepair_backend.Context
{
	public class BikeReport
	{
		public Guid BikeReportId { get; set; }

		public string Email { get; set; }

		public string Name { get; set; }

		public string Problem { get; set; }
    }
}

