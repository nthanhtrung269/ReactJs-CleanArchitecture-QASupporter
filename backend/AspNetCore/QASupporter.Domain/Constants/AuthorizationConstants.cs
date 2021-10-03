namespace QASupporter.Domain.Constants
{
    public static class AuthorizationConstants
    {
        public const string ACCESS_TOKEN_HEADER = "X-MCMAccessToken";

        public const string SUPER_ADMIN_ROLE = "Super Administrators";

        public const string SITE_ADMIN_ROLE = "Site Administrators";

        public const string EMAIL_TOKEN_REGEX = "({[^}]+})";

        public static readonly string[] EMAIL_SEPARATORS = { ",", "|", ";", "\n", "\r", "\t" };

        public const int DEFAULT_PAGE_INDEX = 1;

        public const int DEFAULT_PAGE_SIZE = 10;
    }
}
