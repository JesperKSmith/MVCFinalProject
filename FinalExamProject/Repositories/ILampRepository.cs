using FinalExamProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExamProject.Repositories
{
    public interface ILampRepository
    {
        IEnumerable<Lamp> GetAll(string search);
        Lamp Find(int id);
        void Delete(int id);
        void InsertOrUpdate(Lamp lamp);
    }
}
