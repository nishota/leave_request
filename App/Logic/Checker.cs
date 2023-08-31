using ClosedXML.Excel;
using LeaveRequest.App.Logic.Interface;
using LeaveRequest.App.Models;

namespace LeaveRequest.App.Logic;

public class Checker : IExecutor
{
    private readonly AttendanceData _data;
    private IExecutor? NextExecutor;

    public Checker(AttendanceData data)
    {
        if(data == AttendanceData.Error) throw new ArgumentException();
        _data = data;
    }

    public void SetNext(IExecutor executor)
    {
        NextExecutor = executor;
    }

    /// <summary>
    /// 生成したLeaveRequestの日付が元データに存在するか確認する
    /// </summary>
    /// <param name="options"></param>
    public void Execute(Options options)
    {
        Console.WriteLine("->出力データを再チェック中");
        var inputFile = options.InputFileName ?? throw new ArgumentException();
        var outputPath = options.OutputFilePath;
        var outputFile = string.Format(FileName.OutputFile, _data.Year, _data.Name);
        if (Directory.Exists(outputPath))
        {
            outputFile = Path.Combine(outputPath, outputFile);
        }

        try
        {
            using (var input = new XLWorkbook(inputFile))
            using (var output = new XLWorkbook(outputFile))
            {
                var dates = output.Worksheets.Select(x => DateTime.ParseExact(x.Name, "yyyyMMdd", null));
                var updatedRecords = _data.Records.Where(x => dates.Any(y => y == x.Date));
                if(!updatedRecords.Any()) throw new InvalidOperationException();

                var ws2 = input.Worksheet((int)WorkSheetNameEnum.AttendanceData);
                foreach (var i in Enumerable.Range(AttendanceData.StartRow, AttendanceData.MaxCount))
                {
                    var row = ws2.Row(i);
                    if (!row.Cell((int)ColumnEnum.Date).TryGetValue<DateTime>(out DateTime date))
                    {
                        break;
                    }
                    if (updatedRecords.Any(x => x.Date == date))
                    {
                        row.Cell((int)ColumnEnum.Status).Value = RequestStatus.Parse(RequestStatusEnum.Generated);
                    }
                }
                input.Save();
            }
        }
        catch (IOException)
        {
            Console.WriteLine($"[ERROR]:{inputFile}か{outputFile}かが開かれています。閉じてから再度実行してください。");
            return;
        }
        catch(InvalidOperationException)
        {
            Console.WriteLine("[ERROR]:正しくデータが処理されませんでした。勤怠表の入力値を見直してください。");
            return;
        }
        Console.WriteLine("->出力データを再チェック完了");
        NextExecutor?.Execute(options);
    }
}