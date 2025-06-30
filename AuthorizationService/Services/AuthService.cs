using AuthorizationService.Models;
using AuthorizationService.Models.DTO;
using AuthorizationService.Repository;

namespace AuthorizationService.Services
{
    public class AuthService
    {
        private readonly UserRepository userRepo;
        private readonly JwtService jwtService;

        public AuthService(UserRepository userRepository, JwtService jwtService)
        {
            this.userRepo = userRepository;
            this.jwtService = jwtService;
        }

        public async Task<string> Register(RegisterDto registerDto)
        {
            if (await userRepo.GetByEmail(registerDto.Email) != null)
                throw new Exception("User already exist!");

            var user = new User 
            {
                Email = registerDto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password),
                Role = registerDto.Role ?? "User"
            };

            await userRepo.Create(user);
            return jwtService.GenerateToken(user);
        }

        public async Task<string> Login(LoginDto loginDto)
        {
            var user = userRepo.GetByEmail(loginDto.Email).Result;
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
                throw new Exception("Invalid credentials");

            return jwtService.GenerateToken(user);
        }
    }
}
