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
    public class CaseController : Controller
    {
        private readonly ILogger<CaseController> _logger;
        private readonly IMapper _mapper;
        private readonly ICaseRepositorio _case;
        public CaseController(ILogger<CaseController> Logger, ICaseRepositorio Case, IMapper Mapper)
        {
            _logger = Logger;
            _mapper = Mapper;
            _case = Case;
        }

        [HttpGet(Name = "GetCase")]
        [ResponseCache(CacheProfileName = "Default30")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<CaseDto>>> GetLaboratoryTest()
        {
            try
            {
                _logger.LogInformation("Get Laboratory Test");

                IEnumerable<Case> caseList = await _case.ObtenerTodos();

                IEnumerable<CaseDto> casel = _mapper.Map<IEnumerable<CaseDto>>(caseList);

                return Ok(casel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
