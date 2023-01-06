namespace CleanMovie.UI.Services
{
    public interface IUsersService
    {
        public Task GetUsers(int? id);
        public List<UserLoginDto> Customers { get; set; }

    }
}
