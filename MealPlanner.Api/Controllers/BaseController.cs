using Microsoft.AspNetCore.Mvc;

namespace JGL.Globals.Api.Controllers
{
    public class BaseController : ControllerBase
    {

        internal string GetLanguage() { return "en"; }
    }
}
