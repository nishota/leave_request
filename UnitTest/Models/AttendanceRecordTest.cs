using LeaveRequest.App.Models;

namespace LeaveRequest.UnitTest.Models;

public class AttendanceRecordTest
{
    [Fact]
    public void CreateInstanceTest1()
    {
        var record = new AttendanceRecord
        {
            Date = new DateTime(2022, 9, 17).Date,
            PeriodEnum = RequestPeriodEnum.All,
            TypeEnum = RequestTypeEnum.PaidLeave,
            Reason = "体調不良",
            StatusEnum = RequestStatusEnum.Generated
        };

        record.Date.Is(new DateTime(2022, 9, 17).Date);
        record.PeriodEnum.Is(RequestPeriodEnum.All);
        record.Count.Is(1);
        record.TypeEnum.Is(RequestTypeEnum.PaidLeave);
        record.Reason.Is("体調不良");
        record.StatusEnum.Is(RequestStatusEnum.Generated);
    }

    [Fact]
    public void CreateInstanceTest2()
    {
        var record = new AttendanceRecord
        {
            Date = new DateTime(2022, 9, 17).Date,
            PeriodEnum = RequestPeriodEnum.AM,
            TypeEnum = RequestTypeEnum.PaidLeave,
            Reason = null,
            StatusEnum = RequestStatusEnum.Generated
        };

        record.Date.Is(new DateTime(2022, 9, 17).Date);
        record.PeriodEnum.Is(RequestPeriodEnum.AM);
        record.Count.Is(0.5);
        record.TypeEnum.Is(RequestTypeEnum.PaidLeave);
        record.Reason.IsNull();
        record.StatusEnum.Is(RequestStatusEnum.Generated);
    }
}