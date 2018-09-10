using OOS.Models;
using OOS.Repositories;
using OOS.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOS.Services
{
    public class ImageService : BaseService<Image, ImageRepository>
    {
        ImageRepository imageRepository = new ImageRepository();
        public override Image Save(Image image)
        {
            Guid id = new Guid(image.Id.ToString());
            if (id == Guid.Empty)
            {
                return imageRepository.Create(image);
            }
            else
            {
                return repository.Update(image);
            }
        }
    }
}
