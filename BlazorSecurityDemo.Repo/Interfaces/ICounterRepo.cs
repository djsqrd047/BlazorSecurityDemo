using BlazorSecurityDemo.Shared;

namespace BlazorSecurityDemo.Repo.Interfaces
{
    public interface ICounterRepo
    {
        IEnumerable<CurrentCount> GetCurrentCount();
        IEnumerable<CurrentCount> IncrementCount(int id);
        bool InsertNewCountRecord();
        bool Save();
    }
}