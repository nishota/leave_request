using ClosedXML.Excel;
using LeaveRequest.App.Models;

namespace LeaveRequest.App.Logic;

public class Reader
{
    /// <summary>
    /// データを読み込む
    /// </summary>
    /// <param name="options"></param>
    public AttendanceData Read(Options options)
    {
        Console.WriteLine("->データ読み込み中");
        var inputFilePath = options.InputFileName ?? throw new ArgumentException();
        var yearMonth = options.YearMonth?.ToString() ?? DateTime.Today.ToString("yyyyMM");
        try
        {
            using (var workbook = new XLWorkbook(inputFilePath))
            {
                var ws1 = workbook.Worksheet((int)WorkSheetNameEnum.Title);
                var name = ws1.Cell(1, 2).GetValue<string>();
                var data = new AttendanceData(name, yearMonth);

                var ws2 = workbook.Worksheet((int)WorkSheetNameEnum.AttendanceData);
                foreach (var i in Enumerable.Range(AttendanceData.StartRow, AttendanceData.MaxCount))
                {
                    var row = ws2.Row(i);
                    if (!row.Cell((int)ColumnEnum.Date).TryGetValue<DateTime>(out DateTime date))
                    {
                        break;
                    }
                    if (!row.Cell((int)ColumnEnum.Reason).TryGetValue<string?>(out string? reason))
                    {
                        break;
                    }
                    if (!row.Cell((int)ColumnEnum.Period).TryGetValue<string>(out string period))
                    {
                        break;
                    }
                    if (!row.Cell((int)ColumnEnum.Type).TryGetValue<string>(out string type))
                    {
                        break;
                    }
                    if (!row.Cell((int)ColumnEnum.Status).TryGetValue<string>(out string status))
                    {
                        break;
                    }

                    var periodEnum = RequestPeriod.Parse(period);
                    var typeEnum = RequestType.Parse(type);
                    var statusEnum = RequestStatus.Parse(status);

                    data.Records.Add(new()
                    {
                        Date = date,
                        PeriodEnum = periodEnum,
                        TypeEnum = typeEnum,
                        Reason = reason,
                        StatusEnum = statusEnum
                    });
                }
                Console.WriteLine("->データ読み込み完了");
                return data;
            }
        }
        catch (IOException)
        {
            Console.WriteLine($"[ERROR]:{inputFilePath}が開かれています。閉じてから再度実行してください。");
            return AttendanceData.Error;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
            return AttendanceData.Error;
        }
    }
}