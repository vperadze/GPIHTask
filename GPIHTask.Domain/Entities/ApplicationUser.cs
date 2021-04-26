namespace GPIHTask.Domain.Entities
{
    public class ApplicationUser
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string PasswordHash { get; set; }
    }
}
