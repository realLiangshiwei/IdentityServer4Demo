using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IS4Demo.Controllers
{
    [Produces("application/json")]
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        public async Task<IActionResult> Get(string userName,string passWord)
        {
            var disco = await DiscoveryClient.GetAsync("http://localhost:51627");
            var tokenClient = new TokenClient(disco.TokenEndpoint, "ro.client", "secret");
            var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync(userName, passWord, "api1");
            return new JsonResult(tokenResponse.Json);
        }
    }
}