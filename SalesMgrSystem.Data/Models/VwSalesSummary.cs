using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesMgrSystem.Data.Models;

[Keyless]
public partial class VwSalesSummary
{
    [Column("OrderID")]
    public int OrderId { get; set; }

    [StringLength(201)]
    public string CustomerName { get; set; } = null!;

    [StringLength(150)]
    public string SalesRep { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? OrderDate { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? TotalAmount { get; set; }

    [StringLength(50)]
    public string? Status { get; set; }

    public int? ItemsCount { get; set; }
}
