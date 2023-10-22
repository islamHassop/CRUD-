using CRECT2.Models;

namespace CRECT2.Interface
{
    public interface G_Interface<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        T GetByName(string name);
         void Create(T item );
        T Edite(T item, int id);
        void Delete(int id);

    }
}
