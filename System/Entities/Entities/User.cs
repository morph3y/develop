namespace Entities.Entities
{
    public class User : BusinessObject
    {
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
    }
}
