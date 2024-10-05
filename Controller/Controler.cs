using EFcoreWebAPi.Models;
using EFcoreWebAPi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MainApp.Controller;

[ApiController]
[Route("api/employees")]
public class EmployeeController:ControllerBase
{
    private readonly IDoctor _doctorService;
    public EmployeeController(IDoctor doctorService)
    {
        _doctorService = doctorService;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Doctors>>> GetDoctors()
    {
        return Ok(await _doctorService.GetAllDoctors());
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Doctors?>> GetDoctorById([FromRoute]int id)
    {
        Doctors? doctors = await _doctorService.GetDoctorById(id);
        if (doctors == null)
            return NotFound("ничего не найдено");
        return Ok(await _doctorService.GetDoctorById(id));
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Doctors>> CreateDoctors([FromBody]Doctors? doctors)
    {
        if (doctors == null)
            return BadRequest("Необходимо передать данные employee");
        return Ok(await _doctorService.CreateDoctor(doctors));
    }
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Doctors>> UpdateBook([FromBody]Doctors? doctors)
    {
        if (doctors == null)
            return BadRequest("Необходимо передать данные employee");
        return Ok(await _doctorService.UpdateDoctor(doctors));
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteBook(int id)
    {
        bool res = await _doctorService.DeleteDoctor(id);
        if (res!=true)
        {
            return NotFound("ничего не найдено");
        }
        return Ok(res);
    }
}
