using Microsoft.AspNetCore.Identity;

namespace TechTreeWebApplication.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string PostCode { get; set; }

        public ICollection<UserCategoryEntity> UserCategories { get; set; } = new List<UserCategoryEntity>();
    }
}
