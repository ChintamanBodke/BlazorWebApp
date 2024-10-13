public interface IAdminServices
{
   Task<List<UserApiResult>> GetAdminUserList();
}