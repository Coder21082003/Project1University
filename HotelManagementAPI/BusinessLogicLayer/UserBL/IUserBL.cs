using CommonDataLayer.DTO;
using CommonDataLayer.Entities;
using System.Collections.Generic;

namespace BusinessLogicLayer
{
    public interface IUserBL : IBaseBL<User>
    {
        /// <summary>
        /// Lấy tất cả các bản ghi user.
        /// </summary>
        /// <returns>Danh sách tất cả các bản ghi user.</returns>
        IEnumerable<User> GetAllUsers();

        /// <summary>
        /// Lọc các bản ghi user theo các điều kiện được chỉ định.
        /// </summary>
        /// <param name="filter">Thông tin lọc.</param>
        /// <returns>Danh sách các bản ghi user phù hợp với điều kiện lọc.</returns>
        IEnumerable<User> GetFilteredUsers(FilterUser filter);

        /// <summary>
        /// Thêm một bản ghi user mới.
        /// </summary>
        /// <param name="user">Bản ghi user cần thêm.</param>
        /// <returns>ID của bản ghi user đã thêm.</returns>
        int InsertUser(User user);

        /// <summary>
        /// Cập nhật thông tin của một bản ghi user dựa trên ID.
        /// </summary>
        /// <param name="id">ID của bản ghi user cần cập nhật.</param>
        /// <param name="user">Thông tin cập nhật.</param>
        /// <returns>True nếu cập nhật thành công, false nếu không tìm thấy bản ghi.</returns>
        bool UpdateUser(int id, User user);

        /// <summary>
        /// Xóa một bản ghi user dựa trên ID.
        /// </summary>
        /// <param name="id">ID của bản ghi user cần xóa.</param>
        /// <returns>True nếu xóa thành công, false nếu không tìm thấy bản ghi.</returns>
        bool DeleteUser(int id);
    }
}
