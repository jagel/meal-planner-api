using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.Api.Controllers
{
    public class BaseController : ControllerBase
    {

        internal string GetLanguage() { return "en"; }
    }
}
