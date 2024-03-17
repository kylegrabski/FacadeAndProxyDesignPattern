using FacadeAndProxyDesignPattern.Common.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FacadeAndProxyDesignPattern.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserDataController : ControllerBase
{
    private readonly ILogger<UserDataController> _logger;
    private readonly IUserDataService _userDataService;

    public UserDataController(ILogger<UserDataController> logger, IUserDataService userDataService)
    {
        _logger = logger;
        _userDataService = userDataService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("userData/{requester}")]
    public async Task<IActionResult> GetUserData([FromRoute] string requester)
    {
        try
        {
            var getUserData = await _userDataService.GetUserData(requester);
            return StatusCode(StatusCodes.Status200OK, "YOU DID IT");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"{nameof(UserDataController)}.{nameof(GetUserData)}: Failed while retrieving user data");
            return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred while processing the request");
        }
    }
}