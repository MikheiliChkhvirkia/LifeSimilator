
using LifeSimilator.Enums;

namespace LifeSimilator.Interfaces
{
    public interface IJob
    {
        JobEnum Job { get; }
        decimal GetSalary();
        void ChangeJob(JobEnum newJob);
    }
}
