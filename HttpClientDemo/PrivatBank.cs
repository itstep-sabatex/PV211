using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientDemo
{
    internal class PrivatBank
    {
    }

    public record CurrencyDescriptor ( string BaseCurrency,string Currency,double SaleRateNB,double PurchaseRateNB);
    public record ExchangeDescriptor(CurrencyDescriptor[] ExchangeRate);
}
