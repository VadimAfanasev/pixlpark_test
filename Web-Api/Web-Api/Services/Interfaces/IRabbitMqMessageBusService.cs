namespace Web_Api.Services.Interfaces;

/// <summary>
/// Сервис для отправки сообщений через RabbitMQ.
/// </summary>
public interface IRabbitMqMessageBusService
{
    /// <summary>
    /// Асинхронная отправка сообщения с данными электронной почты в очередь RabbitMQ.
    /// </summary>
    /// <param name="email">Адрес электронной почты получателя.</param>
    /// <param name="code">Код подтверждения для отправки.</param>
    Task SendEmailAsync(string email, string code);
}