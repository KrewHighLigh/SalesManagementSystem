using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesMgrSystem.Data.Models;

[Keyless]
public partial class VwProductSale
{
    [StringLength(200)]
    public string ProductName { get; set; } = null!;

    [StringLength(100)]
    public string CategoryName { get; set; } = null!;

    public int? TotalSold { get; set; }

    [Column(TypeName = "decimal(38, 2)")]
    public decimal? TotalRevenue { get; set; }

    public int StockQuantity { get; set; }
}
