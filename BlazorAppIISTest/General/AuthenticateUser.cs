using BlazorAppIISTest.Data;

namespace BlazorAppIISTest.General
{
    public class AuthenticateUser
    {
        private readonly AWSPullMateContext _context;
        public bool _hasAccess = false;
        public string? UserName;
        public int User_ID;
        public AuthenticateUser(AWSPullMateContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckAccessAsync(string userName)
        {
            UserName = userName;
            return await CheckUserPermissionInDatabaseAsync(userName);
        }

        public string GetUsernameWithoutDomain(string fullUsername)
        {

            string usernameWithoutDomain = fullUsername;
            int lastBackslashIndex = fullUsername.LastIndexOf('\\');
            if (lastBackslashIndex >= 0)
            {
                usernameWithoutDomain = fullUsername.Substring(lastBackslashIndex + 1);
            }
            return usernameWithoutDomain;
        }

        public async Task<bool> CheckUserPermissionInDatabaseAsync(string userName)
        {
            IAWSPullMateRepo repo = new SqlAWSPullMateRepo(_context);
            //   var users = await repo.GetAllUsers();
            var user = await repo.GetUser(userName);

            if (user.WindowsLogin?.Equals(userName, StringComparison.OrdinalIgnoreCase) == true)
            {
                _hasAccess = true;
                User_ID = user.User_ID;

            }

            return await Task.FromResult(_hasAccess);
        }
    }
}

