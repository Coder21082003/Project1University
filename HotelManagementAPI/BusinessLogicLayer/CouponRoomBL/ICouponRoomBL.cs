using CommonDataLayer.DTO;
using CommonDataLayer.Entities;
using System.Collections.Generic;

namespace BusinessLogicLayer
{
    public interface ICouponRoomBL : IBaseBL<CouponRoom>
    {
        /// <summary>
        /// Lấy tất cả các bản ghi coupon-room.
        /// </summary>
        /// <returns>Danh sách tất cả các bản ghi coupon-room.</returns>
        IEnumerable<CouponRoom> GetAllCouponRooms();

        /// <summary>
        /// Lọc các bản ghi coupon-room theo các điều kiện được chỉ định.
        /// </summary>
        /// <param name="filter">Thông tin lọc.</param>
        /// <returns>Danh sách các bản ghi coupon-room phù hợp với điều kiện lọc.</returns>
        IEnumerable<CouponRoom> GetFilteredCouponRooms(FilterCouponRooms filter);

        /// <summary>
        /// Thêm một bản ghi coupon-room mới.
        /// </summary>
        /// <param name="couponRoom">Bản ghi coupon-room cần thêm.</param>
        /// <returns>ID của bản ghi coupon-room đã thêm.</returns>
        int InsertCouponRoom(CouponRoom couponRoom);

        /// <summary>
        /// Cập nhật thông tin của một bản ghi coupon-room dựa trên ID.
        /// </summary>
        /// <param name="couponId">ID của bản ghi coupon-room cần cập nhật (coupon_id).</param>
        /// <param name="roomId">ID của bản ghi coupon-room cần cập nhật (room_id).</param>
        /// <param name="couponRoom">Thông tin cập nhật.</param>
        /// <returns>True nếu cập nhật thành công, false nếu không tìm thấy bản ghi.</returns>
        bool UpdateCouponRoom(int couponId, int roomId, CouponRoom couponRoom);

        /// <summary>
        /// Xóa một bản ghi coupon-room dựa trên ID.
        /// </summary>
        /// <param name="couponId">ID của bản ghi coupon-room cần xóa (coupon_id).</param>
        /// <param name="roomId">ID của bản ghi coupon-room cần xóa (room_id).</param>
        /// <returns>True nếu xóa thành công, false nếu không tìm thấy bản ghi.</returns>
        bool DeleteCouponRoom(int couponId, int roomId);
    }
}
