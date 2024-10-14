using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XYZUniversityPaymentsAPI.Data;
using XYZUniversityPaymentsAPI.Models;

namespace XYZUniversityPaymentsAPI.Controllers;

[ApiController]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/payments")]
[Authorize]

public class PaymentController : ControllerBase
{
    private readonly AppDbContext _context;

    private readonly ILogger<StudentController> _logger;


    public PaymentController(ILogger<StudentController> logger, AppDbContext dbContext)
    {
        _context = dbContext;
        _logger = logger;

    }

    [MapToApiVersion("1.0")]
    [HttpPost("notification")]
    public async Task<IActionResult> ReceivePaymentNotification([FromBody] PaymentNotification paymentNotification)
    {
        if (paymentNotification == null)
        {
            return BadRequest(new
            {
                status = "failed",
                statusCode = "01",
                message = "Payment notification is empty"
            });
        }

        // Optionally validate the paymentNotification here (e.g., check if the student exists)

        _context.PaymentNotifications.Add(paymentNotification);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex) when (ex.InnerException != null)
        {
            _logger.LogError("Payment processing error: {Error}", ex.Message);
            var innerMessage = ex.InnerException.Message;

            // Check for specific foreign key violation keywords
            if (innerMessage.Contains("FOREIGN KEY", StringComparison.OrdinalIgnoreCase))
            {
                // Customize error message for foreign key constraint failure
                return BadRequest(new
                {
                    status = "failed",
                    statusCode = "01",
                    message = "Student details not found."
                });
            }
            else
            {

                // Default message for other database errors
                return StatusCode(500, new
                {
                    message = "Oops! Something went wrong on our end. We're working to fix it. Please try again later.",
                    status = "failed",
                    statusCode = "500"
                });
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("Payment processing error: {Error}", ex.Message);
        }

        return Ok(new
        {
            status = "success",
            statusCode = "00",
            message = "Payment notification received successfully"
        });


    }

    [MapToApiVersion("2.0")]
    [HttpPost("notification")]
    public async Task<IActionResult> ReceivePaymentNotification2([FromBody] PaymentNotification paymentNotification)
    {
        if (paymentNotification == null)
        {
            return BadRequest(new
            {
                status = "failed",
                statusCode = "01",
                message = "Payment notification is empty"
            });
        }

        // Optionally validate the paymentNotification here (e.g., check if the student exists)

        _context.PaymentNotifications.Add(paymentNotification);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex) when (ex.InnerException != null)
        {
            _logger.LogError("Payment processing error: {Error}", ex.Message);
            var innerMessage = ex.InnerException.Message;

            // Check for specific foreign key violation keywords
            if (innerMessage.Contains("FOREIGN KEY", StringComparison.OrdinalIgnoreCase))
            {
                // Customize error message for foreign key constraint failure
                return BadRequest(new
                {
                    status = "failed",
                    statusCode = "01",
                    message = "Student details not found."
                });
            }
            else
            {

                // Default message for other database errors
                return StatusCode(500, new
                {
                    message = "Oops! Something went wrong on our end. We're working to fix it. Please try again later.",
                    status = "failed",
                    statusCode = "500"
                });
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("Payment processing error: {Error}", ex.Message);
        }

        return Ok(new
        {
            status = "success",
            statusCode = "00",
            message = "Payment notification received successfully"
        });


    }
}

