using Company.App.Core.DTOs;

namespace Company.App.Core.Contracts
{
    public interface IManagerController
    {
        void SetManager(int employeeId, int managerId);

        ManagerDTO ManagerInfo(int employeeId);
    }
}
