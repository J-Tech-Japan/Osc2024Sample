using System.ComponentModel.DataAnnotations;
namespace Osc2024Online.Domain.Aggregates.Conferences.ValueObjects;

public record ConferenceLocation(
    [property: Range((int)ConferenceLocationValue.Online, (int)ConferenceLocationValue.Okinawa)]
    ConferenceLocationValue Location,
    [property: Required]
    string Name)
{
    public static ConferenceLocation Online => FromValue(ConferenceLocationValue.Online);
    public static ConferenceLocation FromValue(ConferenceLocationValue location) => new(location, GatNameFromValue(location));
    public static string GatNameFromValue(ConferenceLocationValue location) => location switch
    {
        ConferenceLocationValue.Online => "オンライン",
        ConferenceLocationValue.Tokyo => "東京",
        ConferenceLocationValue.Osaka => "大阪",
        ConferenceLocationValue.Nagoya => "名古屋",
        ConferenceLocationValue.Fukuoka => "福岡",
        ConferenceLocationValue.Sapporo => "札幌",
        ConferenceLocationValue.Sendai => "仙台",
        ConferenceLocationValue.Hiroshima => "広島",
        ConferenceLocationValue.Okinawa => "沖縄",
        _ => string.Empty
    };
}
