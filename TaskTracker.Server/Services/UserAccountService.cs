using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskTracker.Server.Data;
using TaskTracker.Server.DataTranfer;
using TaskTracker.Server.DataTranferObjects;
using TaskTracker.Server.Interfaces;
using static TaskTracker.Server.DataTranferObjects.ServerResponses;

namespace TaskTracker.Server.Services
{
    public class UserAccountService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration) : IUserAccount
    {
        public async Task<GeneralResponse> CreateAccount(RegisterDTO registerDTO)
        {
            if (registerDTO == null) return new GeneralResponse(false, "Model is empty");

            var newUser = new ApplicationUser()
            {
                UserName = registerDTO.Email,
                Email = registerDTO.Email,
                PasswordHash = registerDTO.Password
            };

            var user = await userManager.FindByEmailAsync(newUser.Email);
            if (user is not null) return new GeneralResponse(false, "User already exists");

            var createUser = await userManager.CreateAsync(newUser, registerDTO.Password);
            if (createUser.Succeeded) return new GeneralResponse(false, "Error occured.. Please try again");

            var checkAdmin = await roleManager.FindByNameAsync("Admin");
            if (checkAdmin is null)
            {
                await roleManager.CreateAsync(new IdentityRole() { Name = "Admin" });
                await userManager.AddToRoleAsync(newUser, "Admin");
                return new GeneralResponse(true, "Account Created");
            }
            else
            {
                var checkUser = await roleManager.FindByNameAsync("User");
                if (checkUser is null) 
                    await roleManager.CreateAsync(new IdentityRole() { Name = "User" });

                await userManager.AddToRoleAsync(newUser, "User");
                return new GeneralResponse(true, "Account Created");

            }

        }

        public async Task<LoginResponse> LoginAccount(LoginDTO loginDTO)
        {
            if (loginDTO == null)
                return new LoginResponse(false, null!, "Credentials are empty");

            var user = await userManager.FindByEmailAsync(loginDTO.Email);
            if (user is null)
                return new LoginResponse(false, null!, "User not found");

            bool passwordFlag = await userManager.CheckPasswordAsync(user, loginDTO.Password);
            if (!passwordFlag)
                return new LoginResponse(false, null!, "Wrong login or password");

            var userRole = await userManager.GetRolesAsync(user);
            var userSession = new UserSession(user.Id, user.UserName, user.Email, userRole.First());

            string token = GenerateToken(userSession);

            return new LoginResponse(true, token, "Logged in");

        }

        private string GenerateToken(UserSession session)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, session.Id.ToString()),
                new Claim(ClaimTypes.Name, session.Name),
                new Claim(ClaimTypes.Email, session.Email),
                new Claim(ClaimTypes.Role, session.Role),
            };

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
