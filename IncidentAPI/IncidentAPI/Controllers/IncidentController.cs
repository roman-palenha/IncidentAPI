﻿using Business.DTO;
using Business.Interfaces;
using Business.Validation;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IncidentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly IIncidentService _incidentService;

        public IncidentController(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var incidents = await _incidentService.GetAllAsync();
            if(incidents == null)
                return NotFound();
            return Ok(incidents);
        }

        // GET api/<IncidentController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var incident = await _incidentService.GetByIdAsync(id);
            if (incident == null)
                return NotFound();
            return Ok(incident);
        }

        // POST api/<IncidentController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IncidentDto incidentDto)
        {
            try
            {
                await _incidentService.AddAsync(incidentDto);
            }
            catch (IncidentException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return StatusCode(201);
        }

        // PUT api/<IncidentController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] IncidentUpdateDto incidentDto)
        {
            var incident = await _incidentService.GetByIdAsync(id);
            if (incident == null)
                return NotFound();
            await _incidentService.UpdateAsync(incidentDto);
            return StatusCode(204);

        }

        // DELETE api/<IncidentController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var incident = await _incidentService.GetByIdAsync(id);
            try
            {
                await _incidentService.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return StatusCode(204);
        }
    }
}
