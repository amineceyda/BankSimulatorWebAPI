using BankSimulatorAPI.Base.BaseModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSimulatorAPI.DataAccess.Domain
{
    [Table("Account", Schema = "dbo")]
    public class Account : BaseModel
    {
        public int CustomerId { get; set; } //FK
        public virtual Customer Customer { get; set; } ////To establish relationships between models


        public string Name { get; set; }
        public DateTime OpenDate { get; set; }
        public string CurrencyCode { get; set; } 
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public bool IsActive { get; set; }


        //Accounts have transactions // 1-N
        public virtual List<Transaction> Transactions { get; set; }

    }

    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {   // I prefer to follow the standard here 

            //Base field
            builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn();
            builder.Property(x => x.InsertUser).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.InsertDate).IsRequired(true);

            //
            builder.Property(x => x.CurrencyCode).IsRequired(true).HasMaxLength(4);
            builder.Property(x => x.AccountNumber).IsRequired(true);
            builder.Property(x => x.Balance).IsRequired(true).HasPrecision(15, 4).HasDefaultValue(0);
            builder.Property(x => x.CustomerId).IsRequired(true);
            builder.Property(x => x.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(100);
            builder.Property(x => x.OpenDate).IsRequired(true);

            //index
            builder.HasIndex(x => x.AccountNumber).IsUnique(true);
            builder.HasIndex(x => x.CustomerId);

            //Foreign Keys
            builder.HasMany(x => x.Transactions) //1-N
                .WithOne(x => x.Account)
                .HasForeignKey(x => x.AccountId)
                .IsRequired(true);

        }
    }
}
