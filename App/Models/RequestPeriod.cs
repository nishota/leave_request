namespace LeaveRequest.App.Models
{
    public enum RequestPeriodEnum
    {
        All,
        AM,
        PM
    }

    public static class RequestPeriod
    {
        private const string All = "全日";
        private const string AM = "午前";
        private const string PM = "午後";
        private const double AllDay = 1;
        private const double HalfDay = 0.5;

        public static string Parse(RequestPeriodEnum periodEnum)
        {
            return periodEnum switch
            {
                RequestPeriodEnum.All => All,
                RequestPeriodEnum.AM => AM,
                RequestPeriodEnum.PM => PM,
                _ => throw new ArgumentException()
            };
        }

        public static RequestPeriodEnum Parse(string period)
        {
            return period switch
            {
                All => RequestPeriodEnum.All,
                AM => RequestPeriodEnum.AM,
                PM => RequestPeriodEnum.PM,
                _ => throw new ArgumentException()
            };
        }

        public static double GetCount(RequestPeriodEnum periodEnum)
        {
            return periodEnum switch
            {
                RequestPeriodEnum.All => AllDay,
                RequestPeriodEnum.AM => HalfDay,
                RequestPeriodEnum.PM => HalfDay,
                _ => throw new ArgumentException()
            };
        }
    }
}