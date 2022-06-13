using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace IphonesStore.Models
{
    public class MyCart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();
        public virtual void AddItem(Iphone iphone, int quantity)
        {
            CartLine line = Lines
            .Where(b => b.Iphone.IphoneID == iphone.IphoneID)
            .FirstOrDefault(); if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Iphone = iphone,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public virtual void RemoveLine(Iphone iphone) =>
        Lines.RemoveAll(l => l.Iphone.IphoneID == iphone.IphoneID);
        public decimal ComputeTotalValue() =>
        Lines.Sum(e => e.Iphone.Price * e.Quantity);
        public virtual void Clear() => Lines.Clear();
    }
    public class CartLine
    {
        public int CartLineID { get; set; }
        public Iphone Iphone { get; set; }
        public int Quantity { get; set; }
    }
}