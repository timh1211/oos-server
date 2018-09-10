using OOS.Models;
using OOS.Models.Common;
using OOS.Repositories.Common;
using OOS.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace OOS.Repositories
{
    public class ProductRepository : BaseRepository<Product>
    {
        public IEnumerable GetHighlights()
        {
            using (var context = new OOSContext())
            {
                return context.Products.Select(e => new
                {
                    Id = e.Id,
                    Name = e.Name,
                    Price = e.Price,
                    CreatedDate = e.CreatedDate,
                    Discount = e.Discount,
                    isLastest = e.isLatest,
                    view = e.View,
                    special = e.Special,
                    status = e.Status,
                    fileName = e.Image.name,
                    originName = e.Image.originName,
                    path = e.Image.path,
                    extension = e.Image.extension
                }).Where(e => e.status == true).OrderByDescending(e => e.CreatedDate).Take(8).ToList();
            }
        }

        public PagedListResult GetProducts(string whereClause, int quantity, string orderBy, string orderDirection)
        {
            using (var context = new OOSContext())
            {
                var query = context.Products.
                    Select(e => new
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Price = e.Price,
                        CreatedDate = e.CreatedDate,
                        Discount = e.Discount,
                        isLastest = e.isLatest,
                        view = e.View,
                        special = e.Special,
                        status = e.Status,
                        fileName = e.Image.name,
                        originName = e.Image.originName,
                        path = e.Image.path,
                        extension = e.Image.extension,
                        CategoryID = e.CategoryID.ToString(),
                        CategoryName = e.Category.Name.ToLower(),
                        ManufacturerName = e.Manufacturer.Name,
                        ManufacturerID = e.ManufacturerID.ToString()
                    }).Where(whereClause).OrderBy(string.Format("{0} {1}", orderBy.Trim(), orderDirection.Trim()))
                .Take(quantity)
                .ToList();
                return new PagedListResult(query, query.Count());
            }
        }

        public Product GetProductDetail(string id)
        {
            using (var context = new OOSContext())
            {
                Guid tempId = new Guid(id);
                var product = context.Products.Include("DigitalInformation").Include("Image").Include("Category").Include("Manufacturer").FirstOrDefault(e => e.Id == tempId);
                product.View++;
                context.SaveChanges();
                return product;
            }
        }

        public Product Get(string code)
        {
            using (var context = new OOSContext())
            {
                return context.Products.FirstOrDefault(e => e.Code == code && e.Status == true);
            }
        }

        public override PagedListResult List(string whereClause, string orderBy, string orderDirection, int pageNumber, int pageSize)
        {
            using (var context = new OOSContext())
            {
                var query = context.Products.Select(e => new ProductComplex
                {
                    Id = e.Id,
                    Code = e.Code,
                    Name = e.Name,
                    Quantity = e.Quantity,
                    Price = e.Price,
                    Discount = e.Discount,
                    DeliveryTime = e.DeliveryTime,
                    isLatest = e.isLatest,
                    View = e.View,
                    Special = e.Special,
                    ManufacturerID = e.ManufacturerID,
                    CategoryID = e.CategoryID,
                    Status = e.Status,
                    ManufacturerCode = e.ManufacturerID == null ? string.Empty : context.Manufacturers.FirstOrDefault(a => a.Id == e.ManufacturerID).Code,
                    ManufacturerName = e.ManufacturerID == null ? string.Empty : context.Manufacturers.FirstOrDefault(a => a.Id == e.ManufacturerID).Name,
                    CategoryCode = e.CategoryID == null ? string.Empty : context.Categories.FirstOrDefault(a => a.Id == e.CategoryID).Code,
                    CategoryName = e.ManufacturerID == null ? string.Empty : context.Categories.FirstOrDefault(a => a.Id == e.CategoryID).Name,
                    CreatedDate = e.CreatedDate,
                    CreatedBy = e.CreatedBy,
                    ModifiedDate = e.ModifiedDate == null ? DateTime.MinValue : e.ModifiedDate.Value,
                    ModifiedBy = e.ModifiedBy,
                    CreatorName = e.CreatedBy == null ? string.Empty : context.Employees.FirstOrDefault(a => a.Id == e.CreatedBy).LastName + " " + context.Employees.FirstOrDefault(a => a.Id == e.CreatedBy).FirstName,
                    ModifierName = e.ModifiedBy == null ? string.Empty : context.Employees.FirstOrDefault(a => a.Id == e.ModifiedBy).LastName + " " + context.Employees.FirstOrDefault(a => a.Id == e.ModifiedBy).FirstName
                }).Where(whereClause);
                var entities = query.OrderBy(string.Format("{0} {1}", orderBy.Trim(), orderDirection.Trim()))
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
                return new PagedListResult(entities, query.Count());
            }
        }

        public override IEnumerable All(string whereClause)
        {
            using (var context = new OOSContext())
            {
                return context.Products.Select(e => new ProductComplex
                {
                    Id = e.Id,
                    Code = e.Code,
                    Name = e.Name,
                    Quantity = e.Quantity,
                    Price = e.Price,
                    Discount = e.Discount,
                    DeliveryTime = e.DeliveryTime,
                    isLatest = e.isLatest,
                    View = e.View,
                    Special = e.Special,
                    ManufacturerID = e.ManufacturerID,
                    CategoryID = e.CategoryID,
                    Status = e.Status,
                    ManufacturerCode = e.ManufacturerID == null ? string.Empty : context.Manufacturers.FirstOrDefault(a => a.Id == e.ManufacturerID).Code,
                    ManufacturerName = e.ManufacturerID == null ? string.Empty : context.Manufacturers.FirstOrDefault(a => a.Id == e.ManufacturerID).Name,
                    CategoryCode = e.CategoryID == null ? string.Empty : context.Categories.FirstOrDefault(a => a.Id == e.CategoryID).Code,
                    CategoryName = e.ManufacturerID == null ? string.Empty : context.Categories.FirstOrDefault(a => a.Id == e.CategoryID).Name,
                    CreatedDate = e.CreatedDate,
                    CreatedBy = e.CreatedBy,
                    ModifiedDate = e.ModifiedDate == null ? DateTime.MinValue : e.ModifiedDate.Value,
                    ModifiedBy = e.ModifiedBy,
                    CreatorName = e.CreatedBy == null ? string.Empty : context.Employees.FirstOrDefault(a => a.Id == e.CreatedBy).LastName + " " + context.Employees.FirstOrDefault(a => a.Id == e.CreatedBy).FirstName,
                    ModifierName = e.ModifiedBy == null ? string.Empty : context.Employees.FirstOrDefault(a => a.Id == e.ModifiedBy).LastName + " " + context.Employees.FirstOrDefault(a => a.Id == e.ModifiedBy).FirstName
                }).Where(whereClause).OrderBy("CreatedDate DESC").ToList();
            }
        }

        public override IEnumerable All()
        {
            using (var context = new OOSContext())
            {
                return context.Products.Select(e => new ProductComplex
                {
                    Id = e.Id,
                    Code = e.Code,
                    Name = e.Name,
                    Quantity = e.Quantity,
                    Price = e.Price,
                    Discount = e.Discount,
                    DeliveryTime = e.DeliveryTime,
                    isLatest = e.isLatest,
                    View = e.View,
                    Special = e.Special,
                    ManufacturerID = e.ManufacturerID,
                    CategoryID = e.CategoryID,
                    Status = e.Status,
                    ManufacturerCode = e.ManufacturerID == null ? string.Empty : context.Manufacturers.FirstOrDefault(a => a.Id == e.ManufacturerID).Code,
                    ManufacturerName = e.ManufacturerID == null ? string.Empty : context.Manufacturers.FirstOrDefault(a => a.Id == e.ManufacturerID).Name,
                    CategoryCode = e.CategoryID == null ? string.Empty : context.Categories.FirstOrDefault(a => a.Id == e.CategoryID).Code,
                    CategoryName = e.ManufacturerID == null ? string.Empty : context.Categories.FirstOrDefault(a => a.Id == e.CategoryID).Name,
                    CreatedDate = e.CreatedDate,
                    CreatedBy = e.CreatedBy,
                    ModifiedDate = e.ModifiedDate == null ? DateTime.MinValue : e.ModifiedDate.Value,
                    ModifiedBy = e.ModifiedBy,
                    CreatorName = e.CreatedBy == null ? string.Empty : context.Employees.FirstOrDefault(a => a.Id == e.CreatedBy).LastName + " " + context.Employees.FirstOrDefault(a => a.Id == e.CreatedBy).FirstName,
                    ModifierName = e.ModifiedBy == null ? string.Empty : context.Employees.FirstOrDefault(a => a.Id == e.ModifiedBy).LastName + " " + context.Employees.FirstOrDefault(a => a.Id == e.ModifiedBy).FirstName
                }).OrderBy("CreatedDate DESC").ToList();
            }
        }

        /// <summary>
        /// Create product and add data to 2 tables
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Product Create(Product product, DigitalInformation digital)
        {
            //Guid id = Guid.NewGuid();
            using (var context = new OOSContext())
            {
                Guid id = new Guid(context.Images.OrderByDescending(e => e.CreatedDate).FirstOrDefault().Id.ToString());
                product.Id = id;
                digital.Id = id;
                product.Code = GetCode(product.Name, product.Id);
                product.View = 0;
                product.CreatedDate = DateTime.Now;
                product.CreatedBy = AccountRepository.CurrentUserId;
                product.ModifiedDate = null;
                product.Status = true;

                context.Products.Add(product);
                context.DigitalInformation.Add(digital);
                context.SaveChanges();
                return context.Products.Find(id);
            }
        }

        public Product Update(Product entity, DigitalInformation entity1)
        {
            using (var context = new OOSContext())
            {
                Guid id = new Guid(entity.Id.ToString());
                entity.ModifiedDate = DateTime.Now;
                entity.ModifiedBy = AccountRepository.CurrentUserId;
                Product origin = context.Products.Find(id);
                DigitalInformation origin1 = context.DigitalInformation.Find(id);
                Utility.CloneObject(origin, entity);
                Utility.CloneObject(origin1, entity1);
                context.SaveChanges();
                context.Entry(origin).Reload();
                context.Entry(origin1).Reload();
                return origin;
            }
        }

        public override Product Delete(Guid id)
        {
            using (var context = new OOSContext())
            {
                Product entity = context.Products.Find(id);
                DigitalInformation entity1 = context.DigitalInformation.Find(id);
                Image entity2 = context.Images.Find(id);
                if (entity2 != null)
                {
                    context.Images.Remove(entity2);
                }
                if (entity == null) throw new Exception("ENTITY_INCORRECT_ID");
                context.Products.Remove(entity);
                if (entity1 != null)
                {
                    context.DigitalInformation.Remove(entity1);
                }
                context.SaveChanges();
                return null;
            }
        }

        public string GetCode(string name, Guid id)
        {
            var firstKey = "";
            for (int i = 0; i < name.Split(' ').Length; i++)
            {
                firstKey += name.Split(' ')[i][0].ToString().ToUpper();
            }
            return firstKey + id.ToString().Split('-')[4];
        }
    }
}
