using System.Text.Json.Serialization;
namespace Osc2024Online.Domain.Aggregates.Conferences.ValueObjects;

public static class ConferenceDates
{
    [JsonDerivedType(typeof(OneDay), nameof(OneDay))]
    [JsonDerivedType(typeof(MultiDays), nameof(MultiDays))]
    public interface IConferenceDates
    {
        DateTime GetStartDate();
        DateTime GetEndDate();
    }
    public record OneDay(DateTime Date) : IConferenceDates
    {
        public static OneDay Empty => new(DateTime.MinValue);
        public DateTime GetStartDate() => Date;
        public DateTime GetEndDate() => Date;
    }
    public record MultiDays(DateTime StartDate, DateTime EndDate) : IConferenceDates
    {
        public DateTime GetStartDate() => StartDate;
        public DateTime GetEndDate() => EndDate;
    }
}
