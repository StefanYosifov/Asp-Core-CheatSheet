namespace _Project_CheatSheet.Features.Resources.Interfaces
{
    using Common.Pagination;
    using Models;

    public interface IResourceService
    {
        public int GetTotalPage();
        public Task<ResourceCollectionModel> GetPublicResources(int id, ResourceQueryModel queryModel);
        public Task<IEnumerable<ResourceModel>> GetMyResources();
        public Task<string> AddResources(ResourceAddModel resourceModel);
        public Task<ResourceDetailModel> GetResourceById(string? resourceId);
        public Task<EditResources> GetMyResourceToEdit(Guid id);
        public Task<string> EditResource(string id, ResourceEditModel resourceEdit);
        public Task<string> RemoveResource(string id);
        public Task<string> ChangeVisibility(string id);
    }
}