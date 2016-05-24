using FinalExamProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FinalExamProject.Repositories
{
    public class ImageRepository : IImageRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public void Delete(int id)
        {
            Image image = db.Images.Find(id);
            db.Images.Remove(image);
            db.SaveChanges();
        }

        public Image Find(int id)
        {
            return db.Images.Find(id);
        }

        public IEnumerable<Image> GetAll(string search)
        {
            var selectedImages = (from i in db.Images where i.ImageName.Contains(search) select i).ToList();
            return selectedImages;
        }

        public void InsertOrUpdate(Image image)
        {
            if (image.ImageId == 0)
            {
                db.Images.Add(image);
            }
            else
            {
                db.Entry(image).State = EntityState.Modified;
            }
            db.SaveChanges();
        }
    }
}