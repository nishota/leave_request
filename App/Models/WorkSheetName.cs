namespace LeaveRequest.App.Models;
public enum WorkSheetNameEnum
{
    Title = 1,
    Archive,
    AttendanceData,
    List,
    Template
}

public static class WorkSheetName
{
    private const string Title = "表紙";
    private const string Archive = "実績";
    private const string AttendanceData = "勤怠";
    private const string List ="list";
    private const string Template = "yyyyMMdd";

    public static string Parse(WorkSheetNameEnum wsNameEnum)
    {
        return wsNameEnum switch
        {
            WorkSheetNameEnum.Archive => Archive,
            WorkSheetNameEnum.AttendanceData => AttendanceData,
            WorkSheetNameEnum.Template => Template,
            WorkSheetNameEnum.Title => Title,
            WorkSheetNameEnum.List => List,
            _ => throw new ArgumentException()
        };
    }

    public static WorkSheetNameEnum Parse(string wsName)
    {
        return wsName switch
        {
            Archive => WorkSheetNameEnum.Archive,
            AttendanceData => WorkSheetNameEnum.AttendanceData,
            Template => WorkSheetNameEnum.Template,
            Title => WorkSheetNameEnum.Title,
            List => WorkSheetNameEnum.List,
            _ => throw new ArgumentException()
        };
    }
}