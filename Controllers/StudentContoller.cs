using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XYZUniversityPaymentsAPI.Data;
using XYZUniversityPaymentsAPI.Models;

namespace XYZUniversityPaymentsAPI.Controllers;

[ApiController]
[ApiVersion("1.0")] 
[Route("api/v{version:apiVersion}/students")]
[Authorize]

public class StudentController : ControllerBase
{

    private readonly AppDbContext _context;

    private readonly ILogger<StudentController> _logger;

    public StudentController(ILogger<StudentController> logger, AppDbContext dbContext)
    {
        _context = dbContext;
        _logger = logger;
    }

    [MapToApiVersion("1.0")]
    [HttpGet("validation")]
    public async Task<IActionResult> ValidateStudent(String AdmNo)
    {
        Student? existingStudent = null;
        try
        {
            //Check if the student exists in the database based on admission number
            existingStudent = await _context.Students
                .FirstOrDefaultAsync(s => s.AdmNo == AdmNo);
        }
        catch (Exception ex)
        {
            _logger.LogError("Student validation error: {Error}", ex.Message);
        }

        if (existingStudent != null)
        {
            // Student found, return success
            return Ok(new
            {
                status = "success",
                statusCode = "00",
                message = "Student is valid.",
                studentName = $"{existingStudent.FirstName} {existingStudent.LastName}"
            });
        }
        else
        {
            // Student not found, return failed
            return NotFound(new
            {
                status = "failed",
                statusCode = "01",
                message = "Student details not found."
            });
        }
    }

}
