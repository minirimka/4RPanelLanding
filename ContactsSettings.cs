namespace PromoSite;

/// <summary>
/// Контакты для связи, задаются в <c>wwwroot/appsettings.json</c> (секция "Contacts").
/// Значения можно править в любой момент без пересборки.
/// </summary>
public sealed class ContactsSettings
{
    public ContactLink Sales { get; set; } = new();
    public ContactLink News { get; set; } = new();
}

public sealed class ContactLink
{
    /// <summary>Подпись ссылки, например «Отдел продаж».</summary>
    public string Label { get; set; } = "";

    /// <summary>Telegram-хэндл, например «@TestSales».</summary>
    public string Telegram { get; set; } = "";

    /// <summary>Готовая ссылка вида https://t.me/TestSales.</summary>
    public string Url => "https://t.me/" + Telegram.TrimStart('@');
}
