using System;

namespace EShop
{
    public struct CustomerInformation
    {
        private ProductsList boughtProducts;
        private decimal spendMoney;
        private int boughtItems;
        
        public CustomerInformation(int boughtItems)
            :this()    
        {
            this.BoughtProducts = new ProductsList();
        }
        public ProductsList BoughtProducts
        {
            get { return this.boughtProducts; }
            set { this.boughtProducts = value; }
        }

        public decimal SpendMoney
        {
            get { return this.spendMoney; }
            set { this.spendMoney = value; }
        }

        public int BoughtItems
        {
            get { return this.boughtItems; }
            set { this.boughtItems = value; }
        }
    }
}