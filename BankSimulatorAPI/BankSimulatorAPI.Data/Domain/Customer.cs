using BankSimulatorAPI.Base.BaseModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;



namespace BankSimulatorAPI.Data.Domain
{
    [Table("Customer", Schema = "dbo")]
    public class Customer : BaseModel
    {
        public int CustomerNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Address { get; set; }
        public bool IsActive { get; set; }

        
        //customers have accounts // 1-N
        public virtual List<Account> Accounts { get; set; }


    }

    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {   // I prefer to follow the standard here 

            //Base field
            builder.Property(x => x.CustomerNumber).IsRequired(true).UseIdentityColumn().ValueGeneratedNever();
            builder.HasKey(x => x.CustomerNumber);
            builder.Property(x => x.InsertUser).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.InsertDate).IsRequired(true);

            //
            builder.Property(x => x.FirstName).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired(true).HasMaxLength(50);

            builder.Property(x => x.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(x => x.Address).IsRequired(true).HasMaxLength(150);


            //index
            builder.HasIndex(x => x.CustomerNumber).IsUnique(true);

            //Foreign Keys
            builder.HasMany(x => x.Accounts) //1-N
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.CustomerNumber)
                .IsRequired(true);

        }


    }

}
