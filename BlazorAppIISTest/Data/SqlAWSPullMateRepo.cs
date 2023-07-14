using BlazorAppIISTest.Model;

namespace BlazorAppIISTest.Data
{
    public class SqlAWSPullMateRepo : IAWSPullMateRepo
    {
        private readonly AWSPullMateContext _context;
        public SqlAWSPullMateRepo(AWSPullMateContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await Task.FromResult(_context.User.ToList());
        }
        public async Task<User> GetUser(string name)
        {
            var user = _context.User.FirstOrDefault(u => u.WindowsLogin.ToLower() == name.ToLower()) ?? new User();
            return await Task.FromResult(user);
        }
    }
}
