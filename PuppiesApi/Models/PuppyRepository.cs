using Microsoft.EntityFrameworkCore;

namespace PuppiesApi.Models
{
    public class PuppyRepository : IPuppyRepository
    {
        private readonly PuppiesContext _context;
        public PuppyRepository(PuppiesContext context)
        {
            _context = context;
        }

        public Puppy Create(string name, string breed, DateTime birthDate)
        {
            var puppy = new Puppy
            {
                Name = name,
                Breed = breed,
                BirthDate = birthDate
            };

            _context.Puppy.Add(puppy);
            SaveChanges();
            return puppy;
        }


        public void Delete(int id)
        {
            var puppy = GetOne(id);
            if (puppy == null)
                return;

            _context.Puppy.Remove(puppy);
            SaveChanges();
        }

        public IEnumerable<Puppy> GetAll() => _context.Puppy.ToList();

        public Puppy? GetOne(int id) =>
          _context.Puppy.FirstOrDefault(c => c.PuppyId == id);

        public void SaveChanges() => _context.SaveChanges();
        public Puppy Update(int id, string name, string breed, DateTime birthDate)
        {
            var puppy = GetOne(id);

            puppy.Name = name;
            puppy.BirthDate = birthDate;
            puppy.Breed = breed;

            var updatedPuppy = _context.Puppy.Update(puppy);
            _context.SaveChanges();
            return updatedPuppy.Entity;
        }



    }
}
