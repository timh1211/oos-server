using OOS.Models;
using OOS.Repositories;
using OOS.Services.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOS.Services
{
    public class CartDetailService : BaseService<CartDetail, CartDetailRepository>
    {
        CartDetailRepository cartdetailRepository = new CartDetailRepository();
        public IEnumerable AddProductToCart(CartDetail entity)
        {
            return cartdetailRepository.AddProductToCart(entity);
        }

        public IEnumerable GetCart(Guid id)
        {
            return cartdetailRepository.GetCart(id);
        }

        public int GetTotalQuantity(Guid CId)
        {
            return cartdetailRepository.GetTotalQuantity(CId);
        }

        public float GetTotalPrice(Guid CId)
        {
            return cartdetailRepository.GetTotalPrice(CId);
        }

        public CartDetail DeleteCart(Guid CustomerId, Guid ProductId)
        {
            return cartdetailRepository.Delete(CustomerId, ProductId);
        }

        public CartDetail DeleteCartAll(Guid CustomerId)
        {
            return cartdetailRepository.DeleteAll(CustomerId);
        }

        public CartDetail UpDownQuantity(dynamic properties)
        {
            CartDetail cart = new CartDetail
            {
                CustomerId = new Guid(properties.CustomerId.ToString()),
                ProductId = new Guid(properties.ProductId.ToString()),
                Quantity = Int32.Parse(properties.Quantity.ToString()),
                Price = float.Parse(properties.Price.ToString()),
                Discount = float.Parse(properties.Price.ToString())
            };
            string status = properties.status.ToString();
            return cartdetailRepository.UpDownQuantity(cart, status);
        }

        public CartDetail EditQuantity(CartDetail cartDetail)
        {
            return cartdetailRepository.EditQuantity(cartDetail);
        }
    }
}
