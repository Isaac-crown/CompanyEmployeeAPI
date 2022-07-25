using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{

    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData(
                new Company
                {
                    Id = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b34"),
                    Name = "Microsoft",
                    Address = "583 Wall Dr. Gwyan Oak, MD 21207",
                    Country = "USA"
                },
                new Company
                {
                    Id = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Name = "Google",
                    Address = "1600 Amphitheatre Parkway Mountain View, CA 94043",
                    Country = "USA"
                }

                );
        }
    }
}
