using Web_Api.Services.Interfaces;

namespace Web_Api.Services;

/// <inheritdoc/>
public class VerificationCodeService : IVerificationCodeService
{
    /// <inheritdoc/>
    public string GenerateVerificationCode()
    {
        return new Random().Next(1000, 9999).ToString();
    }
}