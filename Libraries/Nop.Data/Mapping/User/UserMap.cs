using Nop.Core.Domain.User;

namespace Nop.Data.Mapping.User
{
   public partial class UserMap: NopEntityTypeConfiguration<UserEntity>
    {
        public UserMap()
        {
            this.ToTable("UserEntity");
            this.HasKey(u => u.Id);
            this.Property(u => u.Name);
            this.Property(u => u.Gender);
            this.Property(u => u.EmailID);
            this.Property(u => u.Password);
            this.Property(u => u.ConfirmPassword);
        }
    }
}
