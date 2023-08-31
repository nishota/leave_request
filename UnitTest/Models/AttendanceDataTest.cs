using LeaveRequest.App.Models;

namespace LeaveRequest.UnitTest.Models;

public class AttendanceDataTest
{
    [Fact]
    public void CreateInstanceTest()
    {
        var attendanceData = new AttendanceData("hoge", "202210");
        attendanceData.Name.Is("hoge");
        attendanceData.Year.Is("202210");
        attendanceData.Records.IsNotNull();
        attendanceData.Records.Count.Is(0);
    }

    [Fact]
    public void CreateInstanceArgimentExceptionTest()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var attendanceData = new AttendanceData("hoge", "20220911");
        });
    }

    [Fact]
    public void CreateInstanceArgimentExceptionTest2()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var attendanceData = new AttendanceData("hoge", "hogeho");
        });
    }

    [Fact]
    public void CreateInstanceArgimentExceptionTest3()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var attendanceData = new AttendanceData("hoge", "200109");
        });
    }
}