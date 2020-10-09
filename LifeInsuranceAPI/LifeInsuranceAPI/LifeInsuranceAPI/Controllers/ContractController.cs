using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LifeInsurance.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LifeInsuranceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private readonly ILogger<ContractController> _logger;
        public ContractController(IUnitOfWork unitOfWork, ILogger<ContractController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
      
        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<Contracts>> GetAll(string search, string sortCol, string sortDir, int? skip, int? take)
        {
            try
            {
                _logger.LogCritical("" + "{Date}" + DateTime.Now);
                return await _unitOfWork.Contracts.GetAll(search, sortCol, sortDir, skip, take);
            }
            catch (Exception e)
            {
                _logger.LogCritical(e, e.Message.ToString() + "{Date}" + DateTime.Now);
                throw;
            }
        }
    
        [HttpPost]
        [Route("Create")]
        public async Task<int> Create([FromBody] ContractModel entity)
        {
            try
            {
                return await _unitOfWork.Contracts.Create(entity);
            }
            catch (Exception e)
            {
                _logger.LogCritical(e, e.Message.ToString() + "{Date}" + DateTime.Now);
                throw;
            }
        }
               
        [HttpPut]
        [Route("Update")]
        public async Task<int> Update([FromBody] ContractModel entity)
        {
            try
            {
                return await _unitOfWork.Contracts.Update(entity);
            }
            catch (Exception e)
            {
                _logger.LogCritical(e, e.Message.ToString() + "{Date}" + DateTime.Now);
                throw;
            }
        }
       
        [HttpGet()]
        [Route("Delete")]
        public async Task<int> Delete(int id)
        {
            try
            {
                return await _unitOfWork.Contracts.Delete(id);
            }
            catch (Exception e)
            {
                _logger.LogCritical(e, e.Message.ToString() + "{Date}" + DateTime.Now);
                throw;
            }
        }
    }
}