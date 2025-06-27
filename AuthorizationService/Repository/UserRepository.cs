using AuthorizationService.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationService.Repository
{
    public class UserRepository
    {
        private readonly AppDbContext.AppDbContext context;

        public UserRepository(AppDbContext.AppDbContext context)
        {
            this.context = context;
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task Create(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }
    }
}
