using FinalExamProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExamProject.Repositories
{
    public interface IImageRepository
    {
        IEnumerable<Image> GetAll(string search);
        Image Find(int id);
        void Delete(int id);
        int InsertOrUpdate(Image image);
    }
}
