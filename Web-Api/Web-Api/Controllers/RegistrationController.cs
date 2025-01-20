namespace Web_Api.Controllers;

using Microsoft.AspNetCore.Mvc;

using Web_Api.DTOs;
using Web_Api.Services.Interfaces;

/// <summary>
/// Контроллер регистрации пользователя в системе.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class RegistrationController : ControllerBase
{
    /// <summary>
    /// Сервис для отправки сообщений через RabbitMQ.
    /// </summary>
    private readonly IRabbitMqMessageBusService _messageBus;

    /// <summary>
    /// Сервис генерации кода подтверждения.
    /// </summary>
    private readonly IVerificationCodeService _verificationService;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="messageBus">Сервис для отправки сообщений через RabbitMQ.</param>
    /// <param name="verificationService">Сервис генерации кода подтверждения.</param>
    public RegistrationController(IRabbitMqMessageBusService messageBus, IVerificationCodeService verificationService)
    {
        _messageBus = messageBus;
        _verificationService = verificationService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto request)
    {
        var code = _verificationService.GenerateVerificationCode();
        await _messageBus.SendEmailAsync(request.Email, code);
        return Ok(new { Message = "Verification code sent." });
    }
}