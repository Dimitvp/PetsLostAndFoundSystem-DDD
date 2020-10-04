namespace PetsLostAndFoundSystem.Application.Identity.Commands.LoginUser
{
    public class LoginOutputModel
    {
        public LoginOutputModel(string token, int reporterId)
        {
            this.Token = token;
            this.ReporterId = reporterId;
        }

        public int ReporterId { get; }

        public string Token { get; }
    }
}
