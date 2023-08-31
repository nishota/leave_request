using LeaveRequest.App.Models;

namespace LeaveRequest.UnitTest.Models;
public class WorkSheetNameTest
{
    [Theory]
    [InlineData(WorkSheetNameEnum.Title, "表紙")]
    [InlineData(WorkSheetNameEnum.Archive, "実績")]
    [InlineData(WorkSheetNameEnum.AttendanceData, "勤怠")]
    [InlineData(WorkSheetNameEnum.Template, "yyyyMMdd")]
    [InlineData(WorkSheetNameEnum.List, "list")]
    public void ParseTest(WorkSheetNameEnum wsEnum, string expectedData)
    {
        WorkSheetName.Parse(wsEnum).Is(expectedData);
    }

    [Theory]
    [InlineData("表紙",WorkSheetNameEnum.Title)]
    [InlineData("実績", WorkSheetNameEnum.Archive)]
    [InlineData("勤怠", WorkSheetNameEnum.AttendanceData)]
    [InlineData("yyyyMMdd", WorkSheetNameEnum.Template)]
    [InlineData("list", WorkSheetNameEnum.List)]
    public void ParseTestReverse(string ws, WorkSheetNameEnum expectedData)
    {
        WorkSheetName.Parse(ws).Is(expectedData);
    }

    [Fact]
    public void ParseArgimentExceptionTest()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var invalidData = (WorkSheetNameEnum)100;
            WorkSheetName.Parse(invalidData);
        });
    }

    [Fact]
    public void ParseArgimentExceptionTestReverse()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var invalidData = "ほげほげ";
            WorkSheetName.Parse(invalidData);
        });
    }
}