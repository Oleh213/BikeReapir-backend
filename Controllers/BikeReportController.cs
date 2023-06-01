using System;
using BikeRepair_backend.DTO;
using BikeRepair_backend.Interfaces;
using BikeRepair_backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace BikeRepair_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BikeReportController : ControllerBase
    {
        private readonly IBikeReportActionsBL _bikeReportActions;

        public BikeReportController(IBikeReportActionsBL bikeReportActions)
		{
            _bikeReportActions = bikeReportActions;
		}

        [HttpPost("AddNewReport")]
        public async Task<IActionResult> AddNewReport([FromBody] AddNewReportModel model)
        {
            try
            {
                var respons = new Response<string>();

                if ( _bikeReportActions.CheckModel(model))
                {
                    await _bikeReportActions.AddNewReport(model);

                    respons.Data = "The report was successfully sent!";
                    respons.IsError = false;

                    return Ok(respons);

                }
                respons.IsError = true;
                respons.ErrorMessage = "Please, check your input data. Fill all data!";

                return NotFound(respons);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetAllReports")]
        public async Task<IActionResult> GetAllReports()
        {
            try
            {
                var reportsDTO = await _bikeReportActions.GetAllReports();

                if (reportsDTO != null)
                {
                    var respons = new Response<List<BikeReportDTO>>{
                        Data = reportsDTO,
                        IsError = false,
                    };

                    return Ok(respons);

                }
                else
                {
                    var responsError = new Response<string>
                    {
                        ErrorMessage = "Reports list is empty!",
                        IsError = true,
                    };
                    return NotFound(responsError);

                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

