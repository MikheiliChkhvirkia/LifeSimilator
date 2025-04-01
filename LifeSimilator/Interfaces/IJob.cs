
using LifeSimilator.Enums;

namespace LifeSimilator.Interfaces
{
    public interface IJob
    {
        JobEnum Job { get; set; }
        decimal GetSalary();
        void ChangeJob(JobEnum newJob);
    }
}
