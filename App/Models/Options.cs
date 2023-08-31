using CommandLine;

namespace LeaveRequest.App.Models;
public class Options
{
    private const string _inputFileNameHelpText = "勤怠表のファイル名をパスから入力する。";
    private const string _outputFilePathHelpText = "LeaveRequestを出力するディレクトリパスを入力する。指定がない場合は、実行している場所に出力される。";
    private const string _yearMonthHelpText = "年月を数値６桁で入力する。指定がない場合は、現在の年月が入る。";

    [Option('i', "input", Required = true, HelpText = _inputFileNameHelpText)]
    public string? InputFileName { get; set; }
    [Option('o', "output", Required = false, HelpText = _outputFilePathHelpText)]
    public string? OutputFilePath { get; set; }
    [Option('m', "month", Required = false, HelpText = _yearMonthHelpText)]
    public int? YearMonth { get; set; }
}