using LCenterDAL.DTOs;

namespace LCenterBLL.Common
{
    public static class Session
    {
        public static UserDTO CurrentUser { get; set; }

        public static bool IsLoggedIn()
        {
            return CurrentUser != null;
        }

        public static void Logout()
        {
            CurrentUser = null;
        }
    }
}