using Microsoft.AspNetCore.Mvc;

namespace Avtotest.Api.Controllers;

[Route("tickets")]
[ApiController]
public class TicketsController : ControllerBase
{
    [HttpGet("create-ticket")]
    public int[] CreateTicket(int from, int count = 5)
    {
        int[] arr = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        return arr.Skip(from).Take(count).ToArray();
    }
}