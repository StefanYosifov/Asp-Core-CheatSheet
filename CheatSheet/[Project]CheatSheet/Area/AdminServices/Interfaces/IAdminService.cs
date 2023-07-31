namespace _Project_CheatSheet.Area.AdminServices.Interfaces
{
    using Models;

    public interface IAdminService
    {

        Task<ICollection<ResourceAdminModel>> GetListOfCourses(ResourceAdminQueryModel query);

    }
}
