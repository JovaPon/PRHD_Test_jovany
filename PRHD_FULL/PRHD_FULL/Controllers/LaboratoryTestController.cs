using PRHD_FULL.Modelos;
using PRHD_FULL.Modelos.Dto;
using PRHD_FULL.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net;
using PRHD_FULL.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace PRHD_FULL.Controllers
{

    
    [Route("api/[controller]")]
    [ApiController]
    public class LaboratoryTestController : ControllerBase
    {
        private readonly ILogger<LaboratoryTestController> _logger;
        private readonly IMapper _mapper;
        private readonly ILaboratoryTestRepositorio _laboratoryTest;
        public LaboratoryTestController(ILogger<LaboratoryTestController> Logger, ILaboratoryTestRepositorio Lab, IMapper Mapper)
        {
            _logger = Logger;
            _mapper = Mapper;
            _laboratoryTest = Lab;
        }

        [HttpGet(Name ="GetLaboratoyTest")]
        [ResponseCache(CacheProfileName = "Default30")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<LaboratoryTestDto>>> GetLaboratoryTest()
        {
            try
            {
                _logger.LogInformation("Get Laboratory Test");

                IEnumerable<LaboratoryTest> labList = await _laboratoryTest.ObtenerTodos();

                IEnumerable <LaboratoryTestDto> lab = _mapper.Map<IEnumerable<LaboratoryTestDto>>(labList);
                

                return Ok(lab);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            } 
        }

        ////////////
        ///
        [HttpGet("GetSampleCase", Name = "GetSampleCase")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<SampleCDateDto>>> GetVilla()
        {
            try
            {
                //List<SampleCDateDto>
                IEnumerable<SampleCDateDto> data = await _laboratoryTest.GetSampleCases();

                if (data == null)
                {
                 
                    return NotFound();
                }


                return Ok(data);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }
    }
}
