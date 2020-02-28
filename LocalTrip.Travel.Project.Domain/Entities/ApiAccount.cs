namespace LocalTrip.Travel.Project.Domain.Entities
{
    public class ApiAccount
    {
        public string UserCode { get; private set; }
        public string AccessKey { get; private set; }

        public ApiAccount(string userCode, string accessKey)
        {
            UserCode = userCode;
            AccessKey = accessKey;
        }
    }
}