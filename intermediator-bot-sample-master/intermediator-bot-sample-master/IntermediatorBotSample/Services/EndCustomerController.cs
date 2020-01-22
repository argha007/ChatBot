using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntermediatorBotSample.EF.Models;
using IntermediatorBotSample.EF.Models.Dto;
using IntermediatorBotSample.EF.Models.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IntermediatorBotSample.Services
{
    [Route("api/[controller]")]
    public class EndCustomerController : Controller
    {
        private readonly IDataRepository<EndCustomer, EndCustomerDto> _dataRepository;
        public EndCustomerController(IDataRepository<EndCustomer, EndCustomerDto> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            var endCustomers = _dataRepository.GetAll();
            return Ok(endCustomers);
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetEndCustomer")]
        public EndCustomerDto Get(int id)
        {
            var endCustomers = _dataRepository.GetDto(id);
            return endCustomers;
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
