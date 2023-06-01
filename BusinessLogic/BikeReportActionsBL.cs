using System;
using BikeRepair_backend.Context;
using BikeRepair_backend.Db;
using BikeRepair_backend.DTO;
using BikeRepair_backend.Interfaces;
using BikeRepair_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeRepair_backend.BusinessLogic
{
	public class BikeReportActionsBL : IBikeReportActionsBL
    {
        private readonly ReportContext _context;

        public BikeReportActionsBL(ReportContext context)
        {
            _context = context;
        }
        public async Task<bool> AddNewReport(AddNewReportModel model)
        {
            await _context.AddAsync(new BikeReport {
                Email = model.Email,
                Problem = model.Problem,
                Name = model.Name });
            await _context.SaveChangesAsync();

            return true;
        }

        public bool CheckModel(AddNewReportModel model)
        {
            return !string.IsNullOrEmpty(model.Email) && !string.IsNullOrEmpty(model.Name) && !string.IsNullOrEmpty(model.Problem);
        }

        public async Task<List<BikeReportDTO>> GetAllReports()
        {
            var reportsDTO = new List<BikeReportDTO>();

            var reports = await _context.BikeReports.ToListAsync();

            if (reports != null)
            {
                foreach (var report in reports)
                {
                    reportsDTO.Add(new BikeReportDTO
                    {
                        Email = report.Email,
                        Name = report.Name,
                        Problem = report.Problem
                    });
                }
            }
            
            return reportsDTO;
        }


    }
}

