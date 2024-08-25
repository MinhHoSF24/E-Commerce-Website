using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models
{
    public class ShoppingCart
    {
        public List<ShoppingCartItem> items { get; set; }
        public ShoppingCart()
        {
            this.items = new List<ShoppingCartItem>();   
        }

        public void AddToCart(ShoppingCartItem item, int Quantity)
        {
            var checkExists = items.FirstOrDefault(x => x.ProductId == item.ProductId);
            if (checkExists != null)
            {
                checkExists.Quantity += Quantity;
                checkExists.TotalPrice = checkExists.Price * checkExists.Quantity;
            }
            else
            {
                items.Add(item);
            }
        }

        public void Remove(int id)
        {
            var checkExists = items.SingleOrDefault(x=>x.ProductId == id);
            if (checkExists != null)
            {
                items.Remove(checkExists);
            }
        }

        public void UpdateQuantity(int id, int quantity)
        {
            var checkExists = items.SingleOrDefault(x => x.ProductId == id);
            if (checkExists != null)
            {
                checkExists.Quantity = quantity;
                checkExists.TotalPrice = checkExists.Price * checkExists.Quantity;
            }
        }
        public decimal GetTotalPrice()
        {
            return items.Sum(x => x.TotalPrice);
        }
        public decimal GetTotalQuantity()
        {
            return items.Sum(x => x.Quantity);
        }
        public void ClearCart()
        {
            items.Clear();
        }
    }
    public class ShoppingCartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Alias { get; set; }
        public string CategoryName { get; set; }
        public string ProductImg { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
    }
}