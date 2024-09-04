using CommonDataLayer.DTO;
using CommonDataLayer.Entities;
using System.Collections.Generic;

namespace BusinessLogicLayer
{
    public interface IBookingBL : IBaseBL<Booking>
    {
        /// <summary>
        /// Lấy tất cả các bản ghi booking.
        /// </summary>
        /// <returns>Danh sách tất cả các bản ghi booking.</returns>
        IEnumerable<Booking> GetAllBookings();

        /// <summary>
        /// Lọc các bản ghi booking theo các điều kiện được chỉ định.
        /// </summary>
        /// <param name="filter">Thông tin lọc.</param>
        /// <returns>Danh sách các bản ghi booking phù hợp với điều kiện lọc.</returns>
        IEnumerable<Booking> GetFilteredBookings(FilterBooking filter);

        /// <summary>
        /// Thêm một bản ghi booking mới.
        /// </summary>
        /// <param name="booking">Bản ghi booking cần thêm.</param>
        /// <returns>ID của bản ghi booking đã thêm.</returns>
        int InsertBooking(Booking booking);

        /// <summary>
        /// Cập nhật thông tin của một bản ghi booking dựa trên ID.
        /// </summary>
        /// <param name="id">ID của bản ghi booking cần cập nhật.</param>
        /// <param name="booking">Thông tin cập nhật.</param>
        /// <returns>True nếu cập nhật thành công, false nếu không tìm thấy bản ghi.</returns>
        bool UpdateBooking(int id, Booking booking);

        /// <summary>
        /// Xóa một bản ghi booking dựa trên ID.
        /// </summary>
        /// <param name="id">ID của bản ghi booking cần xóa.</param>
        /// <returns>True nếu xóa thành công, false nếu không tìm thấy bản ghi.</returns>
        bool DeleteBooking(int id);
    }
}
