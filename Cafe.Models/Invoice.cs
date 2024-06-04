using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Models;

public class Invoice
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string DocumentNumber { get; set; }
    public string Seler { get; set; }
    public string Bayer { get;set; }
    //public double Total { get; set; }
    public IEnumerable<InvoiceDetail> Items { get; set; }
}

public class InvoiceDetail
{
    public Guid Id { get; set; }
    public Invoice? Invoice { get; set; }
    public Guid InvoiceId { get; set; }
    public Nomenclature? Nomenclature { get; set; }
    public int NomenclatureId { get; set; }
    public string UnitOfMeasurement { get; set; }
    public double Count { get; set; }
    public double Price { get; set; }
    public double Sum { get; set; }
}