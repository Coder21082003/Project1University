using CommonDataLayer.DTO;
using CommonDataLayer.Entities;
using System.Collections.Generic;

namespace BusinessLogicLayer
{
    public interface IPaymentBL : IBaseBL<Payment>
    {
        /// <summary>
        /// Lấy tất cả các bản ghi payment.
        /// </summary>
        /// <returns>Danh sách tất cả các bản ghi payment.</returns>
        IEnumerable<Payment> GetAllPayments();

        /// <summary>
        /// Lọc các bản ghi payment theo các điều kiện được chỉ định.
        /// </summary>
        /// <param name="filter">Thông tin lọc.</param>
        /// <returns>Danh sách các bản ghi payment phù hợp với điều kiện lọc.</returns>
        IEnumerable<Payment> GetFilteredPayments(FilterPayment filter);

        /// <summary>
        /// Thêm một bản ghi payment mới.
        /// </summary>
        /// <param name="payment">Bản ghi payment cần thêm.</param>
        /// <returns>ID của bản ghi payment đã thêm.</returns>
        int InsertPayment(Payment payment);

        /// <summary>
        /// Cập nhật thông tin của một bản ghi payment dựa trên ID.
        /// </summary>
        /// <param name="id">ID của bản ghi payment cần cập nhật.</param>
        /// <param name="payment">Thông tin cập nhật.</param>
        /// <returns>True nếu cập nhật thành công, false nếu không tìm thấy bản ghi.</returns>
        bool UpdatePayment(int id, Payment payment);

        /// <summary>
        /// Xóa một bản ghi payment dựa trên ID.
        /// </summary>
        /// <param name="id">ID của bản ghi payment cần xóa.</param>
        /// <returns>True nếu xóa thành công, false nếu không tìm thấy bản ghi.</returns>
        bool DeletePayment(int id);
    }
}
