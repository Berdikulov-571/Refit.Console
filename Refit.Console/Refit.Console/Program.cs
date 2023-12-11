namespace Refit.Console
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var userApi = RestService.For<IUserAPI>("https://localhost:7065/api");
            var users = await userApi.GetUsers();

            foreach(var i in users)
            {
                System.Console.WriteLine($"{i.UserId}) {i.FirstName} {i.LastName}");
            }
        }
    }
    public interface IUserAPI
    {
        [Get("/User/GetAll")]
        Task<List<User>> GetUsers();
    }
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}