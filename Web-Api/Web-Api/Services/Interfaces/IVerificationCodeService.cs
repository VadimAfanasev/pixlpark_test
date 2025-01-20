namespace Web_Api.Services.Interfaces;

/// <summary>
/// Сервис генерации кода подтверждения.
/// </summary>
public interface IVerificationCodeService
{
    /// <summary>
    /// Генерация кода подтверждения.
    /// </summary>
    /// <returns>Код подтверждения.</returns>
    string GenerateVerificationCode();
}