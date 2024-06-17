namespace  App.Controllers;

using Microsoft.AspNetCore.Mvc;


[ApiController]

public class HomeController : ControllerBase
{
    [HttpGet]
    [Route("/")]
    public IActionResult Index()
    {
        Dictionary<string,string> map = new Dictionary<string,string> {{"Message","Person and employees head to /swagger/index.html to see operations or api/ endpoints to use the app"}};
        return Ok (map);
    }
}



