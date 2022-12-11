using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_crud_api.Entities
{
    [Table("product")]
    public class Product
    {
        [Key, Required]
        public Guid id { get; set; } = Guid.Empty;
        public string name { get; set; } = string.Empty;
        public string slug { get; set; } = string.Empty;
        public string? description { get; set; }
        public int quantity { get; set; } = 0;
        public decimal price { get; set; } = 0;
        public DateTime? manufactred_date { get; set; }
    }

    public class ProductConfiguration: IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasIndex(x => x.id)
                .IsUnique();
                
            builder
                
                .Property(x => x.id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()") 
                .IsRequired();
        }
    }
}



