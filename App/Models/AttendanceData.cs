namespace LeaveRequest.App.Models;
public class AttendanceData
{
    /// <summary>
    /// Excel上の開始行
    /// </summary>
    public const int StartRow = 2;
    /// <summary>
    /// 最大データ個数
    /// </summary>
    public const int MaxCount = 100;
    public static AttendanceData Error = new AttendanceData("Error", "999999");
    public string Name { get; }
    public string Year { get; }
    public IList<AttendanceRecord> Records { get; }
    public AttendanceData(string name, string year)
    {
        if(year.Length != 6) throw new ArgumentException();
        if(!int.TryParse(year, out int result)) throw new ArgumentException();
        if(result < 200110) throw new ArgumentException();

        Name = name;
        Year = year;
        Records = new List<AttendanceRecord>();
    }

    public override bool Equals(object? obj)
    {
        if(obj is not AttendanceData data) return false;

        return data.Name == this.Name && data.Year == this.Year;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}