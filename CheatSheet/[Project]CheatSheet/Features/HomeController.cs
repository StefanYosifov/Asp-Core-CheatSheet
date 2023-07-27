namespace _Project_CheatSheet.Features
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : ApiController
    {
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("WorksDoesIt?");
        }
    }
}