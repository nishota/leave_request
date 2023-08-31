namespace LeaveRequest.App.Models
{
    public enum RequestStatusEnum
    {
        Generated,
        NotYet
    }

    public static class RequestStatus
    {
        private const string Generated = "作成済み";
        private const string NotYet = "";
        public static string Parse(RequestStatusEnum statusEnum)
        {
            return statusEnum switch
            {
                RequestStatusEnum.Generated => Generated,
                RequestStatusEnum.NotYet => string.Empty,
                _ => throw new ArgumentException()
            };
        }
        public static RequestStatusEnum Parse(string status)
        {
            return status switch
            {
                Generated => RequestStatusEnum.Generated,
                NotYet => RequestStatusEnum.NotYet,
                _ => throw new ArgumentException()
            };
        }
    }
}