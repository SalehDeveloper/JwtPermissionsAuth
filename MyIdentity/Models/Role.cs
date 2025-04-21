namespace MyIdentity.Models
{
    public class Role 
    {
        public Role( string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

      public Guid Id { get; set; } 

      public string Name { get; set; } 

      public List<User> Users { get; set; }   = new List<User>();
      public List<Permission> Permissions { get; set; }
    
    
    }
}
