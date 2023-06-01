using System;
using BikeRepair_backend.DTO;
using BikeRepair_backend.Models;

namespace BikeRepair_backend.Interfaces
{
	public interface IBikeReportActionsBL
	{
		Task<bool> AddNewReport(AddNewReportModel model);

        bool CheckModel(AddNewReportModel model);
        
        Task<List<BikeReportDTO>> GetAllReports();
    }
}

