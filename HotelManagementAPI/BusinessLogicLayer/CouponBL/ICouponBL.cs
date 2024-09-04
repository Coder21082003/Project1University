using CommonDataLayer.DTO;
using CommonDataLayer.Entities;
using System.Collections.Generic;

namespace BusinessLogicLayer
{
    public interface ICouponBL : IBaseBL<Coupon>
    {
        /// <summary>
        /// Lấy tất cả các bản ghi coupon.
        /// </summary>
        /// <returns>Danh sách tất cả các bản ghi coupon.</returns>
        IEnumerable<Coupon> GetAllCoupons();

        /// <summary>
        /// Lọc các bản ghi coupon theo các điều kiện được chỉ định.
        /// </summary>
        /// <param name="filter">Thông tin lọc.</param>
        /// <returns>Danh sách các bản ghi coupon phù hợp với điều kiện lọc.</returns>
        IEnumerable<Coupon> GetFilteredCoupons(FilterCoupon filter);

        /// <summary>
        /// Thêm một bản ghi coupon mới.
        /// </summary>
        /// <param name="coupon">Bản ghi coupon cần thêm.</param>
        /// <returns>ID của bản ghi coupon đã thêm.</returns>
        int InsertCoupon(Coupon coupon);

        /// <summary>
        /// Cập nhật thông tin của một bản ghi coupon dựa trên ID.
        /// </summary>
        /// <param name="id">ID của bản ghi coupon cần cập nhật.</param>
        /// <param name="coupon">Thông tin cập nhật.</param>
        /// <returns>True nếu cập nhật thành công, false nếu không tìm thấy bản ghi.</returns>
        bool UpdateCoupon(int id, Coupon coupon);

        /// <summary>
        /// Xóa một bản ghi coupon dựa trên ID.
        /// </summary>
        /// <param name="id">ID của bản ghi coupon cần xóa.</param>
        /// <returns>True nếu xóa thành công, false nếu không tìm thấy bản ghi.</returns>
        bool DeleteCoupon(int id);
    }
}
