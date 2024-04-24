namespace CarSelling.Common
{
    public static class AppConstants
    {
        public const int ReleaseYear = 2023;
        public const int DefaultPage = 1;
        public const int DefaultCarsPPage = 3;


        public const string AdminAreaName = "Admin";
        public const string AdminRoleName = "Administrator";
        public const string DevelopmentAdminEmail = "admin@automoto.com";

        public const string UsersCacheKey = "UsersCache";
        public const string BuysCacheKey = "BuysCache";
        public const int UsersCacheDurationMinutes = 5;
        public const int BuysCacheDurationMinutes = 10;

        public const string OnlineUsersCookieName = "IsOnline";
        public const int LastActivityBeforeOfflineMinutes = 10;
    }
}