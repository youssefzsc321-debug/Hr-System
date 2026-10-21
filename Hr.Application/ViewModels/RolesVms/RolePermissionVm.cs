namespace Hr.Application.ViewModels.RolesVms
{
    public class RolePermissionVm
    {
        public string PageName { get; set; }
        public bool CanRead { get; set; }
        public bool CanAdd { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
    }
}