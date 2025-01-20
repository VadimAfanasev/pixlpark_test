using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace ConsoleApp;

using ConsoleApp.Common;
using System.Net;
using System.Net.Mail;

public class Program
{
    /// <summary>
    /// строка для подключения к rabbitMq.
    /// </summary>
    private const string RABBIT_MQ_URI = "amqp://guest:guest@localhost:5672/";
    /// <summary>
    /// Название очереди.
    /// </summary>
    private const string EMAIL_QUEUE = "emailQueue";
    /// <summary>
    /// Smtp хост Яндекса.
    /// </summary>
    private const string SMTP_HOST = "smtp.yandex.ru";
    /// <summary>
    /// Smtp порт Яндекса.
    /// </summary>
    private const int SMTP_PORT = 587;
    /// <summary>
    /// Пользователь от имени которого будет отправлено сообщение.
    /// </summary>
    private const string SMTP_USER = "trim-agency@yandex.ru";
    /// <summary>
    /// Пароль приложения от аккаунта Яндекс.
    /// </summary>
    private const string SMTP_PASSWORD = "avyaemzhqnjezygz";

    static void Main(string[] args)
    {
        var factory = CreateConnectionFactory();
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        InitializeQueue(channel);

        var consumer = CreateConsumer(channel);
        channel.BasicConsume(queue: EMAIL_QUEUE, autoAck: true, consumer: consumer);

        Console.WriteLine("Нажмите [Enter] для выхода.");
        Console.ReadLine();
    }

    /// <summary>
    /// Создание экземпляра ConnectionFactory для подключения к RabbitMq.
    /// </summary>
    /// <returns>Экземпляр ConnectionFactory.</returns>
    private static ConnectionFactory CreateConnectionFactory()
    {
        return new ConnectionFactory { Uri = new Uri(RABBIT_MQ_URI) };
    }

    /// <summary>
    /// Инициализация очереди сообщений в RabbitMQ.
    /// </summary>
    /// <param name="channel">Канал для взаимодействия с RabbitMQ.</param>
    private static void InitializeQueue(IModel channel)
    {
        channel.QueueDeclare(queue: EMAIL_QUEUE, durable: false, exclusive: false, autoDelete: false, arguments: null);
    }

    /// <summary>
    /// Создает подписчика для обработки сообщений из очереди.
    /// </summary>
    /// <param name="channel">Канал для взаимодействия с RabbitMQ.</param>
    /// <returns>Экземпляр EventingBasicConsumer.</returns>
    private static EventingBasicConsumer CreateConsumer(IModel channel)
    {
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += async (model, ea) =>
        {
            var message = Encoding.UTF8.GetString(ea.Body.ToArray());
            var emailData = JsonSerializer.Deserialize<EmailData>(message);
            await SendEmailAsync(emailData.Email, emailData.Code);
        };
        return consumer;
    }

    /// <summary>
    /// Асинхронная отправка электронного письма с кодом подтверждения.
    /// </summary>
    /// <param name="email">Адрес электронной почты получателя.</param>
    /// <param name="code">Код подтверждения для отправки.</param>
    private static async Task SendEmailAsync(string email, string code)
    {
        var message = CreateMailMessage(email, code);

        ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

        using var smtpClient = new SmtpClient(SMTP_HOST, SMTP_PORT);
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtpClient.Credentials = new NetworkCredential(SMTP_USER, SMTP_PASSWORD);
        smtpClient.EnableSsl = true;

        try
        {
            await smtpClient.SendMailAsync(message);
            Console.WriteLine($"{DateTime.Now} Email отправлен по адресу: {email}. Код: {code}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка отправки Email по адресу: {email}: {ex.Message}");
        }
    }

    /// <summary>
    /// Создание объекта MailMessage для отправки.
    /// </summary>
    /// <param name="email">Адрес электронной почты получателя.</param>
    /// <param name="code">Код подтверждения для отправки.</param>
    /// <returns>Созданный объект MailMessage.</returns>
    private static MailMessage CreateMailMessage(string email, string code)
    {
        var message = new MailMessage
        {
            From = new MailAddress(SMTP_USER, "Vadim Afanasiev"),
            Subject = "Verification Code",
            Body = $"Ваш код подтверждения: {code}"
        };
        message.To.Add(new MailAddress(email, "Verification Code"));
        return message;
    }
}