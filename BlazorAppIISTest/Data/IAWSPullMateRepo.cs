using BlazorAppIISTest.Model;

namespace BlazorAppIISTest.Data
{
    public interface IAWSPullMateRepo
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUser(string username);
       
    }
}
