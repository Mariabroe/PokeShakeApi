namespace PokeShakes.Api.Controllers;

[ApiController]
[Route("pokemon")]
public class PokeShakeController : ControllerBase
{
    [HttpGet("{idOrName}")]
    public async Task<ActionResult<PokeShakeDto>> Get(string idOrName, [FromServices] IPokeShakeService pokeShakeService)
    {
        try
        {
            var dto = await pokeShakeService.GetPokeShake(idOrName);
            return Ok(dto);
        }
        catch (Exception ex) when (ex.Message is "pokemon_not_found")
        {
            return NotFound(new { error = ex.Message, idOrName });
        }
        catch (HttpRequestException ex)
        {
            return StatusCode(StatusCodes.Status502BadGateway, new { error = "upstream_http_error", detail = ex.Message });
        }
    }
}