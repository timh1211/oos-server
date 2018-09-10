using OOS.Models;
using OOS.Models.Common;
using OOS.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOS.Repositories
{
    public class CartDetailRepository : BaseRepository<CartDetail>
    {
        public IEnumerable GetCart(Guid id)
        {
            using (var context = new OOSContext())
            {
                return context.CartDetails.Select(e => new
                {
                    CustomerId = e.CustomerId,
                    ProductId = e.ProductId,
                    Quantity = e.Quantity,
                    Price = e.Price,
                    Total = e.Quantity * e.Price * (1 - e.Discount / 100),
                    Discount = e.Discount,
                    DeliveryTime = e.Product.DeliveryTime,
                    ProductName = e.Product.Name,
                    Image = e.Product.Image.path + e.Product.Image.name + e.Product.Image.extension,
                    FirstName = e.Customer.FirstName,
                    LastName = e.Customer.LastName,
                    FullName = e.Customer.LastName + e.Customer.FirstName,
                    Phone = e.Customer.Phone,
                    Email = e.Customer.Email,
                    Address = e.Customer.Address,
                    Status = e.Customer.Status
                }).Where(e => e.CustomerId == id && e.Status == true).ToList();
            }
        }

        public int GetTotalQuantity(Guid CId)
        {
            using (var context = new OOSContext())
            {
                var listCart = context.CartDetails.Where(e => e.CustomerId == CId).ToList();
                return listCart.Sum(e => e.Quantity);
            }
        }

        public float GetTotalPrice(Guid CId)
        {
            using (var context = new OOSContext())
            {
                var listCart = context.CartDetails.Where(e => e.CustomerId == CId).ToList();

                return listCart.Sum(e => e.Quantity * e.Price * (1 - e.Discount / 100));
            }
        }

        public IEnumerable AddProductToCart(CartDetail entity)
        {
            using (var context = new OOSContext())
            {
                var CustomerAndProduct = context.CartDetails.FirstOrDefault(e => e.CustomerId == entity.CustomerId && e.ProductId == entity.ProductId);
                //var Customer = context.CartDetails.FirstOrDefault(e => e.CustomerId == entity.CustomerId && e.ProductId != entity.ProductId);
                if (CustomerAndProduct == null)
                {
                    context.CartDetails.Add(entity);
                    context.SaveChanges();
                }
                else if (CustomerAndProduct != null)
                {
                    entity.Quantity += CustomerAndProduct.Quantity;
                    Utility.CloneObject(CustomerAndProduct, entity);
                    context.SaveChanges();
                    context.Entry(CustomerAndProduct).Reload();
                }
                return context.CartDetails.Where(e => e.CustomerId == entity.CustomerId).ToList();
            }
        }

        public CartDetail Delete(Guid CustomerId, Guid ProductId)
        {
            using (var context = new OOSContext())
            {
                CartDetail origin = context.CartDetails.FirstOrDefault(e => e.CustomerId == CustomerId && e.ProductId == ProductId);
                context.CartDetails.Remove(origin);
                context.SaveChanges();
            }
            return new CartDetail();
        }

        public CartDetail DeleteAll(Guid CustomerId)
        {
            using (var context = new OOSContext())
            {
                var listProductInCart = context.CartDetails.Where(e => e.CustomerId == CustomerId).ToList();
                foreach (var i in listProductInCart)
                {
                    context.CartDetails.Remove(i);
                }
                context.SaveChanges();
            }
            return new CartDetail();
        }

        public CartDetail UpDownQuantity(CartDetail entity, string status)
        {
            using (var context = new OOSContext())
            {
                CartDetail origin = context.CartDetails.FirstOrDefault(e => e.CustomerId == entity.CustomerId && e.ProductId == entity.ProductId);
                CartDetail origin1 = context.CartDetails.FirstOrDefault(e => e.CustomerId == entity.CustomerId && e.ProductId == entity.ProductId);
                if (status == "up")
                {
                    origin1.Quantity += 1;
                }
                else if (status == "down")
                {
                    origin1.Quantity -= 1;
                }
                if (origin1.Quantity <= 0)
                {
                    origin1.Quantity = 0;
                }
                Utility.CloneObject(origin, origin1);
                context.SaveChanges();
                context.Entry(origin).Reload();
                return origin;
            }
        }

        public CartDetail EditQuantity(CartDetail entity)
        {
            using (var context = new OOSContext())
            {
                CartDetail origin = context.CartDetails.FirstOrDefault(e => e.CustomerId == entity.CustomerId && e.ProductId == entity.ProductId);
                if (entity.Quantity <= 0)
                {
                    entity.Quantity = 0;
                }
                Utility.CloneObject(origin, entity);
                context.SaveChanges();
                context.Entry(origin).Reload();
                return origin;
            }
        }
    }
}
