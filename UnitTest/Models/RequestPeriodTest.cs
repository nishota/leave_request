using LeaveRequest.App.Models;

namespace LeaveRequest.UnitTest.Models;
public class RequestPeriodTest
{
    [Theory]
    [InlineData(RequestPeriodEnum.All, "全日")]
    [InlineData(RequestPeriodEnum.AM, "午前")]
    [InlineData(RequestPeriodEnum.PM, "午後")]
    public void ParseTest(RequestPeriodEnum periodEnum, string expectedData)
    {
        RequestPeriod.Parse(periodEnum).Is(expectedData);
    }

    [Theory]
    [InlineData( "全日",RequestPeriodEnum.All)]
    [InlineData("午前",RequestPeriodEnum.AM)]
    [InlineData("午後",RequestPeriodEnum.PM)]
    public void ParseTestReverse(string period, RequestPeriodEnum expectedData)
    {
        RequestPeriod.Parse(period).Is(expectedData);
    }

    [Fact]
    public void ParseArgimentExceptionTest()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var invalidData = (RequestPeriodEnum)100;
            RequestPeriod.Parse(invalidData);
        });
    }

    [Fact]
    public void ParseArgimentExceptionTestReverse()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var invalidData = "ほげほげ";
            RequestPeriod.Parse(invalidData);
        });
    }

    [Theory]
    [InlineData(RequestPeriodEnum.All, 1)]
    [InlineData(RequestPeriodEnum.AM, 0.5)]
    [InlineData(RequestPeriodEnum.PM, 0.5)]
    public void GetCountTest(RequestPeriodEnum periodEnum, double expectedData)
    {
        RequestPeriod.GetCount(periodEnum).Is(expectedData);
    }

    [Fact]
    public void GetCountArgimentExceptionTest()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var invalidData = (RequestPeriodEnum)100;
            RequestPeriod.GetCount(invalidData);
        });
    }
}