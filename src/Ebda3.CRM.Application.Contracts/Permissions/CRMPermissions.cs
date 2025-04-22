namespace Ebda3.CRM.Permissions;

public static class CRMPermissions
{
    public const string GroupName = "CRM";
    public static class Products
    {
        public const string Default = GroupName + ".Products";
        public const string View = Default + ".View";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
        public const string Edit = Default + ".Edit";
    }
    
    public static class Categories
    {
        public const string Default = GroupName + ".Category";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
        public const string Edit = Default + ".Edit";
    }
    
    public static class Contacts
    {
        
    }
}
