namespace MyIdentity.Models
{
    public class User
    {
        public User( string name, string email, string password)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Password = password;
        }

        public Guid Id {  get; set; }   

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }    

        //
        public Guid RoleId { get; set; }    

        public Role Role { get; set; }



    }
}
