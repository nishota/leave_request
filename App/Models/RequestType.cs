namespace LeaveRequest.App.Models
{
    public enum RequestTypeEnum
    {
        PaidLeave,
        CompensatoryLeave,
        Absence,
        Others
    }

    public static class RequestType
    {
        private const string PaidLeave = "有給休暇";
        private const string CompensatoryLeave = "代休";
        private const string Absence = "欠勤（有給消化でない）";
        private const string Others = "その他（特別休暇など）";
        public static string Parse(RequestTypeEnum typeEnum)
        {
            return typeEnum switch
            {
                RequestTypeEnum.PaidLeave => PaidLeave,
                RequestTypeEnum.CompensatoryLeave => CompensatoryLeave,
                RequestTypeEnum.Absence => Absence,
                RequestTypeEnum.Others => Others,
                _ => throw new ArgumentException()
            };
        }

        public static RequestTypeEnum Parse(string type)
        {
            return type switch
            {
                PaidLeave => RequestTypeEnum.PaidLeave,
                CompensatoryLeave => RequestTypeEnum.CompensatoryLeave,
                Absence => RequestTypeEnum.Absence,
                Others => RequestTypeEnum.Others,
                _ => throw new ArgumentException()
            };
        }
    }
}