using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasData(
                new Contact
                {
                    Email = "abc@gmail",
                    FirstName = "fsd",
                    LastName = "sdff",
                    Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
                });
        }
    }
}
