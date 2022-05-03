using JGL.Infra.Globals.API.Domain.Interfaces;

namespace JGL.Infra.Globals.API.Domain.Services
{
    public class TimeService : ITimeService
    {
        public DateTime GetDateTime()
        {
            return DateTime.Now;
        }
    }
}
