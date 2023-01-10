namespace PuppiesApi.Models
{
    public interface IPuppyRepository
    {
        void SaveChanges();
        Puppy? GetOne(int id);
        IEnumerable<Puppy> GetAll();
        Puppy Create(string name, string breed, DateTime birthDate);
        void Delete(int id);
        Puppy Update(int id, string name, string breed, DateTime birthDate);
    }
}
