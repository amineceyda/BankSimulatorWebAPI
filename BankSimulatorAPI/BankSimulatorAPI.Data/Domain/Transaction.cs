using BankSimulatorAPI.Base.BaseModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSimulatorAPI.Data.Domain
{
    [Table("Transaction", Schema = "dbo")]
    public class Transaction : IdBaseModel
    {
        public int AccountId { get; set; } //FK
        public virtual Account Account { get; set; } //To establish relationships between models


        public decimal CreditAmount { get; set; } // -
        public decimal DebitAmount { get; set; } // +
        public string Description { get; set; }
        public DateTime TransactionDate { get; set; }

        // public int TranDate { get; set; } // e.g. 20230715 - for optimization
        public string ReferenceNumber { get; set; } // to track the transaction

    }
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {   // I prefer to follow the standard here 

            //Base field
            builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn();
            builder.Property(x => x.InsertUser).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.InsertDate).IsRequired(true);

            //
            builder.Property(x => x.TransactionDate).IsRequired(true);
            builder.Property(x => x.ReferenceNumber).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.AccountId).IsRequired(true);
            builder.Property(x => x.CreditAmount).IsRequired(true).HasPrecision(15, 4).HasDefaultValue(0);
            builder.Property(x => x.DebitAmount).IsRequired(true).HasPrecision(15, 4).HasDefaultValue(0);
            builder.Property(x => x.Description).IsRequired(true).HasMaxLength(250);

            //index
            builder.HasIndex(x => x.ReferenceNumber);
            builder.HasIndex(x => x.AccountId);


        }
    }
}
