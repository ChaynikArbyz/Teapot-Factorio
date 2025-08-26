using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeapotFactorio.Resources;

namespace TeapotFactorio
{
    internal class MarketResource
    {
        public ISellable resource { get; private set; }
        public double price { get; private set; }
        public double buyCount { get; private set; }

        public MarketResource(ISellable resource)
        {
            this.resource = resource;
            this.price = resource.GetPrice();
            buyCount = 0;
        }

        public void ChangeBuyCount(double count)
        {
            buyCount += count;
            if (buyCount < 0) { buyCount = 0; }
            price = resource.GetPrice() * (1 + buyCount / 10);
        }
    }
}
