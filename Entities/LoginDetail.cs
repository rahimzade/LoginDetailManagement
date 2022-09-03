using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginDetailManagement.Entities
{
    public class LoginDetail
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Title { get; set; }
    }

    public class LoginDetailConfiguration : IEntityTypeConfiguration<LoginDetail>
    {
        public void Configure(EntityTypeBuilder<LoginDetail> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.UserName).IsRequired();
            builder.Property(p => p.Password).IsRequired();
            builder.Property(p => p.Title).IsRequired();
        }
    }
}
