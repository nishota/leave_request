using LeaveRequest.App.Models;

namespace LeaveRequest.UnitTest.Models;
public class RequestStatusTest
{
    [Theory]
    [InlineData(RequestStatusEnum.Generated, "作成済み")]
    [InlineData(RequestStatusEnum.NotYet, "")]
    public void ParseTest(RequestStatusEnum statusEnum, string expectedData)
    {
        RequestStatus.Parse(statusEnum).Is(expectedData);
    }

    [Theory]
    [InlineData("作成済み", RequestStatusEnum.Generated)]
    [InlineData("", RequestStatusEnum.NotYet)]
    public void ParseTestReverse(string status, RequestStatusEnum expectedData)
    {
        RequestStatus.Parse(status).Is(expectedData);
    }

    [Fact]
    public void ParseArgimentExceptionTest()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var invalidData = (RequestStatusEnum)100;
            RequestStatus.Parse(invalidData);
        });
    }

    [Fact]
    public void ParseArgimentExceptionTestReverse()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var invalidData = "ほげほげ";
            RequestStatus.Parse(invalidData);
        });
    }
}