﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Serilog;
using StorageServiceLibrary.DTO;
using StorageServiceLibrary.Model;
using StorageServiceLibrary.Services;

namespace apiAC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<ApiUser> _userManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;

        public AccountController(UserManager<ApiUser> userManager,

            ILogger<AccountController> logger,
            IMapper mapper,
            IAuthManager authManager)
        {
            _userManager = userManager;

            _logger = logger;
            _mapper = mapper;
            _authManager = authManager;
        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            _logger.LogInformation($"Registration Attempt for {userDTO.Email}");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            try
            {

                var user = _mapper.Map<ApiUser>(userDTO);
                user.UserName = userDTO.Email;


                var result = await _userManager.CreateAsync(user, userDTO.Password);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {

                        ModelState.AddModelError(error.Code, error.Description);

                    }


                    return BadRequest(ModelState);

                }

                if (userDTO.Roles.Contains("string"))
                {
                    userDTO.Roles = new List<string>() { "User" }; // default role
                }

                    await _userManager.AddToRolesAsync(user, userDTO.Roles);


    

                return Accepted();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(Register)}");
                return Problem($"Something went wrong in the {nameof(Register)}", statusCode: 500);
            }



        }


   

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserDTO userDTO)
        {
            _logger.LogInformation($"Login Attempt for {userDTO.Email}");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            try
            {




                if (!await _authManager.ValidateUser(userDTO))
                {

                    return Unauthorized();
                }

                //var user = await _userManager.FindByEmailAsync(login.Email);
                //var canSignIn = await _signInManager.CanSignInAsync(user);


                //    var claims = new List<Claim>();
                // Resolve the user via their email
                var user = await _userManager.FindByEmailAsync(userDTO.Email);
                // Get the roles for the user
                var role = await _userManager.GetRolesAsync(user);

                string rola = role[0];



                return Accepted(new { email = userDTO.Email, Token = await _authManager.CreateToken(), Roles = rola });


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(Login)}");
                return Problem($"Something went wrong in the {nameof(Login)}", statusCode: 500);
            }



        }
    }



}