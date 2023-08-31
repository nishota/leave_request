using CommandLine;
using LeaveRequest.App.Logic;
using LeaveRequest.App.Models;

Parser.Default.ParseArguments<Options>(args)
.WithParsed(opt =>
{
    var reader = new Reader();
    var data = reader.Read(opt);
    if(data == AttendanceData.Error) return;

    var generator = new Generator(data);
    generator.SetNext(new Checker(data));
    generator.Execute(opt);
});