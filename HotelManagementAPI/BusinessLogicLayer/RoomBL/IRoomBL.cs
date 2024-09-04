using CommonDataLayer.DTO;
using CommonDataLayer.Entities;
using System.Collections.Generic;

namespace BusinessLogicLayer
{
    public interface IRoomBL : IBaseBL<Room>
    {
        /// <summary>
        /// Lấy tất cả các bản ghi room.
        /// </summary>
        /// <returns>Danh sách tất cả các bản ghi room.</returns>
        IEnumerable<Room> GetAllRooms();

        /// <summary>
        /// Lọc các bản ghi room theo các điều kiện được chỉ định.
        /// </summary>
        /// <param name="filter">Thông tin lọc.</param>
        /// <returns>Danh sách các bản ghi room phù hợp với điều kiện lọc.</returns>
        IEnumerable<Room> GetFilteredRooms(FilterRoom filter);

        /// <summary>
        /// Thêm một bản ghi room mới.
        /// </summary>
        /// <param name="room">Bản ghi room cần thêm.</param>
        /// <returns>ID của bản ghi room đã thêm.</returns>
        int InsertRoom(Room room);

        /// <summary>
        /// Cập nhật thông tin của một bản ghi room dựa trên ID.
        /// </summary>
        /// <param name="id">ID của bản ghi room cần cập nhật.</param>
        /// <param name="room">Thông tin cập nhật.</param>
        /// <returns>True nếu cập nhật thành công, false nếu không tìm thấy bản ghi.</returns>
        bool UpdateRoom(int id, Room room);

        /// <summary>
        /// Xóa một bản ghi room dựa trên ID.
        /// </summary>
        /// <param name="id">ID của bản ghi room cần xóa.</param>
        /// <returns>True nếu xóa thành công, false nếu không tìm thấy bản ghi.</returns>
        bool DeleteRoom(int id);
    }
}
