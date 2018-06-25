using System;

namespace Ruanmou.Model
{
    /// <summary>
    /// LM_User
    /// UserModel
    /// </summary>

    public class User : BaseModel
    {
        public string Name { set; get; }

        public string Account { set; get; }

        public string Password { set; get; }

        public string Email { set; get; }

        public string Mobile { set; get; }

        public int CompanyId { set; get; }

        public string CompanyName { set; get; }

        /// <summary>
        /// User status: 0- Normal 1-Freeze 2-Deleted
        /// </summary>
        public int State { set; get; }

        /// <summary>
        /// Type of users:  1- normal 2- Admin 4- Super Admin
        /// </summary>
        public int UserType { set; get; }

        public DateTime LastLoginTime { set; get; }

        public DateTime CreateTime { set; get; }

        public int CreatorId { set; get; }

        public int LastModifierId { set; get; }

        public DateTime LastModifyTime { set; get; }

    }
}
