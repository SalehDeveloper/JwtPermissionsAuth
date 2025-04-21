namespace MyIdentity.Models
{
    public class Permission
    {
        public Permission( string name)
        {
            Id = Guid.NewGuid  ();
            Name = name;
        }

        public Guid Id { get; set; }    

        public string Name { get; set; }

        public List<Role> Roles { get; set; }
    }
}
