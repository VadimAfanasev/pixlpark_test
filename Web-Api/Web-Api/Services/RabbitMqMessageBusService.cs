namespace Web_Api.Services;

using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Web_Api.Services.Interfaces;

/// <inheritdoc/>
public class RabbitMqMessageBusService : IRabbitMqMessageBusService
{
    /// <summary>
    /// Соединение с RabbitMQ.
    /// </summary>
    private readonly IConnection _connection;

    /// <summary>
    /// Модель канала для взаимодействия с RabbitMQ.
    /// </summary>
    private readonly IModel _channel;

    /// <summary>
    /// Конструктор
    /// </summary>
    public RabbitMqMessageBusService()
    {
        var connectionFactory = new ConnectionFactory();
        var uri = new Uri("amqp://guest:guest@localhost:5672/");
        connectionFactory.Uri = uri;
        _connection = connectionFactory.CreateConnection();

        _channel = _connection.CreateModel();
        _channel.QueueDeclare(queue: "emailQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);
    }

    /// <inheritdoc/>
    public async Task SendEmailAsync(string email, string code)
    {
        var emailData = new { Email = email, Code = code };
        var message = JsonSerializer.Serialize(emailData);
        var body = Encoding.UTF8.GetBytes(message);

        _channel.BasicPublish(exchange: "", routingKey: "emailQueue", basicProperties: null, body: body);
        await Task.CompletedTask;
    }
}