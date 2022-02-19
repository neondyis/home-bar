using Microsoft.AspNetCore.Mvc;
using src.Models;
using src.Repositories.Interfaces;

namespace src.Controllers;
[ApiController]
[Route("[controller]")]
public class MeasurementController : ControllerBase
{
    private readonly IMeasurementRepository _measurementRepository;
    
    public MeasurementController(IMeasurementRepository measurementRepository)
    {
        _measurementRepository = measurementRepository;
    }
    
    [HttpGet("/api/[controller]/all",Name = "GetMeasurements")]
    public IEnumerable<Measurement> GetAll()
    {
        return _measurementRepository.GetAll();
    }
    
    [HttpGet(Name = "GetMeasurementByID")]
    public IEnumerable<Measurement> Get(int id)
    {
        return _measurementRepository.Find(x => x.MeasurementId == id);
    }
    
    [HttpPost(Name = "PostMeasurement")]
    public async Task<ActionResult<Measurement>> Post([FromBody] Measurement measurement)
    {
        await _measurementRepository.Add(measurement);

        //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
        return CreatedAtAction(nameof(Get), new { id = measurement.MeasurementId }, measurement);
    }
    
    [HttpPut("{id}", Name = "PutMeasurement")]
    public async Task<IActionResult> Put(long id,[FromBody] Measurement measurement)
    {
        if (id != measurement.MeasurementId)
        {
            return BadRequest();
        }else
        {
            await _measurementRepository.Put(measurement);
        }
        return NoContent();
    }
}