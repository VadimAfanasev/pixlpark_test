# StaffManagement

Управление персоналом https://confluence.tomskasu.ru/pages/viewpage.action?pageId=2273262 

Для тестов нужена строка подключения к Postgres 13
ConnectionStrings__TestContext = 

## Переменные окружения

 - DbConnectionSettings__DatabaseTimeoutSec - Задержка подключения к БД (Дефолт - 30)
 - DbConnectionSettings__ConnectionString - Строка подключения к БД (Стендовая - Server=stuff_db;Port=5432;Database=personal;User ID=personal;Password=personal;Integrated Security=true;Pooling=true;) НА ПРОДЕ ДРУГАЯ
 - SynchronizerSettings__DbConStr - Строка подключения к БД синхронизатора
 - IsAddingTestUsers - Добавлять ли пользователей для тестирования
 - MasterUrl - Основное Url.
 - NotificationMetadata__SmtpServer - Почта Smtp сервера. (Дефолт - mail.tomskasu.ru)
 - NotificationMetadata__Port - Порт Smtp сервера. (Дефолт - 25)
 - ReaddevUser__Role - Роль (Дефолт - 1)
 - ReaddevUser__Login - Логин (Стендовый - readdev) НА ПРОДЕ ДРУГОЙ И ТАЙНЫЙ
 - ReaddevUser__Password - Пароль (Узнаём у держателя паролей) НА ПРОДЕ ДРУГОЙ И ТАЙНЫЙ
 - HrSpace__AncestorId - Id родительской страницы в КФ (Стенд - 85199050, ПРОД - 328035)
 - HrSpace__SpaceName - Название отдела в КФ (Сенд - HRTES, ПРОД - HR)
 - HrSpace__HistoryAncestorId - Id родительской страницы в КФ для получения истории аттестаций (Стенд - 85199050, ПРОД - 328035)
 - HrSpace__HistorySpaceName - Название отдела в КФ, откуда нужно брать историю аттестаций (Сенд - HRTES, ПРОД - HR)
 - AutoDeskMetadata__ClientId - Идентификатор клиента для входа в AutoDesk (Узнаём у держателя паролей)
 - AutoDeskMetadata__ClientSecret - Секретный ключ клиента для входа в AutoDesk (Узнаём у держателя паролей)
 - AutoDeskMetadata__GrantType - Тип входа клиента для входа в AutoDesk (Дефолт - client_credentials)
 - AutoDeskMetadata__Scope - Закодированный URL-адрес, разделенный пробелами список запрошенных областей. (Дефолт - data:read data:write data:create bucket:create bucket:read)
 - AutoDeskMetadata__Server - URL для входа в AutoDesk (Дефолт - https://developer.api.autodesk.com)
 - AutoDeskMetadata__BucketName - Название ведра на сервере AutoDesk (Дефолт - office-map)
 - ConfluenceSettings__Server - URL КФ (Дефолт - https://confluence.tomskasu.ru)
 - ConfluenceSettings__CalendarId - идентификатор календаря в КФ (Стенд - 505c5998-7d16-4671-aea4-3bac59f79707, ПРОД - 631c3433-aaa2-4282-a4ef-d48a3b041298)
 - JiraSettings__Server - URL Jira (Дефолт - https://jira.tomskasu.ru/)
 - JiraSettings__AttestationIssue - задача под списывание ТРЗ за аттестации (Дефолт - HRD-2)
 - RedmineSettings__Server - URL Jira (Дефолт - https://rm.tomskasu.ru/)
 - RedmineSettings__Key - ключ X-Redmine-API-Key (Узнаём у держателя паролей)
 - KeyCloakSettings__Server - URL KeyCloak (Сюда нужно ставить url внутреннего KeyCloak, дефолт - https://keycloak.tomskasu.ru/)
 - KeyCloakSettings__GrantType - Тип авторизации в KeyCloak (Дефолт - password)
 - KeyCloakSettings__ClientId - Название клиента (Дефолт - StaffManagement)
 - KeyCloakSettings__ClientSecret - Идентификатор пользователя в KeyCloak  (Вставляем свой. Узнать его можно в KeyCloak)
 - KeyCloakSettings__UserFederationId - Идентификатор подключения к LDAP с работниками (Берётся из Provider ID в федерации)
 - KeyCloakSettings__DelUserFederationId - Идентификатор подключения к LDAP с удаленными работниками (Берётся из Provider ID в федерации)
 - KeyCloakSettings__Login - Логин (Дефолт - readdev)
 - KeyCloakSettings__Password - Пароль (Узнаём у держателя паролей)
 - MinIoSettings__EndPoint - URL MinIo (Дефолт - minio.tomskasu.ru)
 - MinIoSettings__AccessKey - Пользователь MinIo (Дефолт - staff)
 - MinIoSettings__SecretKey - Пароль MinIo (Узнаём у держателя паролей)
 - MinIoSettings__Bucket - Ведро с файлами MinIo (Cтенд - "staff", для разработчиков - "staff-dev", ПРОД - "staff-production")
 - MinIoSettings__WithSsl - Нужно ли шифрование (https) MinIo
 - TimeZoneSettings__UTC - Локальный часовой пояс. (дефолт - 7)
 - TapMetadata__Chief - Директор (Дефолт - "PonomarevAA@tomskasu.ru")
 - TapMetadata__TechnicalDirector - Технический директор (Дефолт - "Artem@tomskasu.ru")
 - TapMetadata__HeadOfDevelopers - Руководитель отдела разработки (Дефолт - "OnishhenkoMA@tomskasu.ru") 
 - TapMetadata__AisUpProjectManager - РП ответственный за АИС УП(Дефолт - "AxyonovaAM@tomskasu.ru")
 - TapMetadata__HeadOfGis - Руководитель направлния ГИС (Дефолт - "PuzrakovaNV@tomskasu.ru")
 - TapMetadata__HeadOfFront - Руководитель отделения front-end (Дефолт - "SavinAO@tomskasu.ru")
 - TapMetadata__ProjectDepartment - Название отдела управления проектами из АД (Дефолт - "Отдел управления проектами")
 - TapMetadata__HeadTitle - Приписка к должности руководителя в АД (Дефолт - "руководитель")
 - TapMetadata__AisUpTesters - электронные адреса тестировщиков проекта (массив)
 