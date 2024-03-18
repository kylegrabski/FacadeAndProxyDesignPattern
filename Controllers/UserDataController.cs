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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("userData/{requester}/{userId}")]
    public async Task<IActionResult> GetUserData([FromRoute] string requester, string userId)
    {
        try
        {
            var userData = await _userDataService.GetUserData(requester, userId);

            if (userData == null)
            {
                _logger.LogError($"{nameof(UserDataController)}.{nameof(GetUserData)}: Failed while retrieving user data. UserId: {userId} - Requester: {requester}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred while processing the request.");
            }
            
            return StatusCode(StatusCodes.Status200OK, userData);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"{nameof(UserDataController)}.{nameof(GetUserData)}: Failed while retrieving user data. UserId: {userId} - Requester: {requester}");
            return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred while processing the request");
        }
    }
}