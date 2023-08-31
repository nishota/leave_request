using ClosedXML.Excel;
using LeaveRequest.App.Logic.Interface;
using LeaveRequest.App.Models;

namespace LeaveRequest.App.Logic;

public class Generator : IExecutor
{
    private readonly AttendanceData _data;
    private IExecutor? NextExecutor;
    public Generator(AttendanceData data)
    {
        if(data == AttendanceData.Error) throw new ArgumentException();
        _data = data;
    }

    public void SetNext(IExecutor executor)
    {
        NextExecutor = executor;
    }

    /// <summary>
    /// テンプレートをコピーして、xlsxを出力
    /// </summary>
    /// <param name="options"></param>
    public void Execute(Options options)
    {
        Console.WriteLine("->LeaveRequest出力中");
        var inputFilePath = options.InputFileName ?? throw new ArgumentException();
        var outputPath = options.OutputFilePath;
        try
        {
            using (var workbook = new XLWorkbook(inputFilePath))
            using (var newWorkBook = new XLWorkbook())
            {
                var ws4 = workbook.Worksheet((int)WorkSheetNameEnum.Template);
                var notGeneraterdRecords = _data.Records.Where(x => x.StatusEnum == RequestStatusEnum.NotYet);

                if (!notGeneraterdRecords.Any()) throw new InvalidOperationException();

                foreach (var r in notGeneraterdRecords)
                {
                    var nws = ws4.CopyTo(newWorkBook, r.Date.ToString("yyyyMMdd"));
                    nws.Cell(5, 4).Value = _data.Name;
                    nws.Cell(7, 4).Value = r.Date;
                    nws.Cell(7, 5).Value = RequestPeriod.Parse(r.PeriodEnum);
                    nws.Cell(9, 4).Value = r.Count;
                    nws.Cell(11, 4).Value = RequestType.Parse(r.TypeEnum);
                    nws.Cell(13, 4).Value = r.Reason;
                }

                var file = string.Format(FileName.OutputFile, _data.Year, _data.Name);
                if (Directory.Exists(outputPath))
                {
                    file = Path.Combine(outputPath, file);
                }
                newWorkBook.SaveAs(file);
            }
        }
        catch (IOException)
        {
            Console.WriteLine($"[ERROR]:{inputFilePath}が開かれています。閉じてから再度実行してください。");
            return;
        }
        catch(InvalidOperationException)
        {
            Console.WriteLine("[WARNING]:出力する勤怠データがありませんでした。");
            return;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
            return;
        }
        Console.WriteLine("->LeaveRequest出力完了");
        NextExecutor?.Execute(options);
    }
}