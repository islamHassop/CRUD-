namespace CRECT2.Interface
{
    public interface Interface_Segragation<T> where T : class
    {
        List<T> GetItemByIdDept(int id);
    }
}
