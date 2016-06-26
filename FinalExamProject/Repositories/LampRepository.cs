using FinalExamProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FinalExamProject.Repositories
{
    public class LampRepository : ILampRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();
        
        public void Delete(int id)
        {
            Lamp lamp = db.Lamps.Find(id);
            db.Lamps.Remove(lamp);
            db.SaveChanges();
        }

        public Lamp Find(int id)
        {
            return db.Lamps.Find(id);
        }

        public Lamp AddLikeToLamp(int id)
        {
            Lamp lamp = db.Lamps.Find(id);
            lamp.Likes++;
            db.SaveChanges();
            return lamp;
        }

        public IEnumerable<Lamp> GetAll(string search)
        {
            var selectedLamps = (from i in db.Lamps
                                 where i.LampName.Contains(search)
                                 select i).ToList();
            return selectedLamps;
        }

        public void InsertOrUpdate(Lamp lamp)
        {
            if(lamp.LampId == 0)
            {
                db.Lamps.Add(lamp);
            }
            else
            {
                db.Entry(lamp).State = EntityState.Modified;
            }
            db.SaveChanges();
        }
    }
}