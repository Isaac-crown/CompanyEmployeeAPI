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
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(
                new Employee
                {
                    Id = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b34"),
                    Name = "John Doe",
                    CompanyId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b34"),
                    Position = "Software Developer",
                    Age = 26
                },
                new Employee
                {
                    Id = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Name = "Jane Doe",
                    CompanyId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b34"),
                    Position = "Software Developer",
                    Age = 30
                },
                new Employee
                {
                    Id = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b36"),
                    Name = "Emmanuel Imion",
                    Age = 35,
                    CompanyId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b34"),
                    Position = "Administration"
                }
                );
        }
    }
}
