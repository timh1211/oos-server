using OOS.Models;
using OOS.Repositories;
using OOS.Repositories.Common;
using OOS.Services.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOS.Services
{
    public class ProductService : BaseService<Product, ProductRepository>
    {
        ProductRepository productRepository = new ProductRepository();
        public dynamic Save(ProductDetail productDetail)
        {
            Product product = new Product();
            DigitalInformation digital = new DigitalInformation();
            product.Id = productDetail.Id;
            product.Name = productDetail.Name;
            product.Quantity = productDetail.Quantity;
            product.Price = productDetail.Price;
            product.Discount = productDetail.Discount;
            product.DeliveryTime = productDetail.DeliveryTime;
            product.isLatest = productDetail.isLatest;
            product.Special = productDetail.Special;
            product.ManufacturerID = productDetail.ManufacturerID;
            product.CategoryID = productDetail.CategoryID;
            digital.Monitor = productDetail.Monitor;
            digital.OperatingSystem = productDetail.OperatingSystem;
            digital.CPU = productDetail.CPU;
            digital.RAM = productDetail.RAM;
            digital.InternalMemory = productDetail.InternalMemory;
            digital.HardDrive = productDetail.HardDrive;
            digital.GraphicCard = productDetail.GraphicCard;
            digital.BehindCamera = productDetail.BehindCamera;
            digital.FrontCamera = productDetail.FrontCamera;
            digital.NetworkConnection = productDetail.NetworkConnection;
            digital.Connector = productDetail.Connector;
            digital.Weight = productDetail.Weight;
            digital.Design = productDetail.Design;
            digital.Size = productDetail.Size;
            digital.MemoryCard = productDetail.MemoryCard;
            digital.SIMCard = productDetail.SIMCard;
            digital.Conversation = productDetail.Conversation;
            digital.BatteryCapacity = productDetail.BatteryCapacity;
            Guid id = new Guid(product.Id.ToString());
            if (id == Guid.Empty)
            {
                return productRepository.Create(product, digital);
            }
            else
            {
                return productRepository.Update(product, digital);
            }
        }

        public override PagedListResult List(string whereClause, string orderBy, string orderDirection, int pageNumber, int pageSize)
        {
            return productRepository.List(whereClause, orderBy, orderDirection, pageNumber, pageSize);
        }

        public override PagedListResult List(PagedListRequest request)
        {
            return this.List(request.whereClause, request.orderBy, request.orderDirection, request.pageNumber, request.pageSize);
        }

        public override IEnumerable All(string whereClause)
        {
            return productRepository.All(whereClause);
        }

        public override Product Delete(Guid id)
        {
            return productRepository.Delete(id);
        }

        public IEnumerable GetHighlights()
        {
            return productRepository.GetHighlights();
        }

        public PagedListResult GetProducts(ProductRequest productRequest)
        {
            return productRepository.GetProducts(productRequest.whereClause, productRequest.quantity, productRequest.orderBy, productRequest.orderDirection);
        }

        public dynamic GetProductDetail(string id)
        {
            var product = productRepository.GetProductDetail(id);
            return new
            {
                Id = product.Id,
                Code = product.Code,
                Name = product.Name,
                Quantity = product.Quantity,
                Price = product.Price,
                Discount = product.Discount,
                DeliveryTime = product.DeliveryTime,
                IsLasted = product.isLatest,
                View = product.View,
                Special = product.Special,
                Status = product.Status,
                DigitalId = product.DigitalInformation.Id,
                ImageId = product.Image.Id,
                fileName = product.Image.name,
                originName = product.Image.originName,
                path = product.Image.path,
                extension = product.Image.extension,
                CategoryID = product.Category.Id,
                CategoryName = product.Category.Name,
                ManufacturerID = product.Manufacturer.Id,
                ManufacturerName = product.Manufacturer.Name,
                Monitor = product.DigitalInformation.Monitor,
                OS = product.DigitalInformation.OperatingSystem,
                CPU = product.DigitalInformation.CPU,
                RAM = product.DigitalInformation.RAM,
                InternalMemory = product.DigitalInformation.InternalMemory,
                HardDrive = product.DigitalInformation.HardDrive,
                GraphicCard = product.DigitalInformation.GraphicCard,
                BehindCamera = product.DigitalInformation.BehindCamera,
                FrontCamera = product.DigitalInformation.FrontCamera,
                NetworkConnection = product.DigitalInformation.NetworkConnection,
                Connector = product.DigitalInformation.Connector,
                Weight = product.DigitalInformation.Weight,
                Design = product.DigitalInformation.Design,
                Size = product.DigitalInformation.Size,
                MemoryCard = product.DigitalInformation.MemoryCard,
                SIMCard = product.DigitalInformation.SIMCard,
                Conversation = product.DigitalInformation.Conversation,
                Battery = product.DigitalInformation.BatteryCapacity
            };
        }
    }
}
