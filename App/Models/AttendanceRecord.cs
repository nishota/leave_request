namespace LeaveRequest.App.Models;
public record AttendanceRecord
{
    public DateTime Date { get; init; }
    public RequestPeriodEnum PeriodEnum { get; init; }
    public double Count => RequestPeriod.GetCount(PeriodEnum);
    public RequestTypeEnum TypeEnum { get; init; }
    public string? Reason { get; init; }
    public RequestStatusEnum StatusEnum { get; init; }
}