using LeaveRequest.App.Models;

namespace LeaveRequest.UnitTest.Models;
public class RequestTypeTest
{
    [Theory]
    [InlineData(RequestTypeEnum.Absence, "欠勤（有給消化でない）")]
    [InlineData(RequestTypeEnum.CompensatoryLeave, "代休")]
    [InlineData(RequestTypeEnum.Others, "その他（特別休暇など）")]
    [InlineData(RequestTypeEnum.PaidLeave, "有給休暇")]
    public void ParseTest(RequestTypeEnum typeEnum, string expectedData)
    {
        RequestType.Parse(typeEnum).Is(expectedData);
    }

    [Theory]
    [InlineData("欠勤（有給消化でない）",RequestTypeEnum.Absence)]
    [InlineData("代休", RequestTypeEnum.CompensatoryLeave)]
    [InlineData("その他（特別休暇など）", RequestTypeEnum.Others)]
    [InlineData("有給休暇", RequestTypeEnum.PaidLeave)]
    public void ParseTestReverse(string type, RequestTypeEnum expectedData)
    {
        RequestType.Parse(type).Is(expectedData);
    }

    [Fact]
    public void ParseArgimentExceptionTest()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var invalidData = (RequestTypeEnum)100;
            RequestType.Parse(invalidData);
        });
    }

    [Fact]
    public void ParseArgimentExceptionTestReverse()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var invalidData = "ほげほげ";
            RequestType.Parse(invalidData);
        });
    }
}