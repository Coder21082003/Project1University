using CommonDataLayer.DTO;
using CommonDataLayer.Entities;
using System.Collections.Generic;

namespace BusinessLogicLayer
{
    public interface IReviewBL : IBaseBL<Review>
    {
        /// <summary>
        /// Lấy tất cả các bản ghi review.
        /// </summary>
        /// <returns>Danh sách tất cả các bản ghi review.</returns>
        IEnumerable<Review> GetAllReviews();

        /// <summary>
        /// Lọc các bản ghi review theo các điều kiện được chỉ định.
        /// </summary>
        /// <param name="filter">Thông tin lọc.</param>
        /// <returns>Danh sách các bản ghi review phù hợp với điều kiện lọc.</returns>
        IEnumerable<Review> GetFilteredReviews(FilterReviews filter);

        /// <summary>
        /// Thêm một bản ghi review mới.
        /// </summary>
        /// <param name="review">Bản ghi review cần thêm.</param>
        /// <returns>ID của bản ghi review đã thêm.</returns>
        int InsertReview(Review review);

        /// <summary>
        /// Cập nhật thông tin của một bản ghi review dựa trên ID.
        /// </summary>
        /// <param name="id">ID của bản ghi review cần cập nhật.</param>
        /// <param name="review">Thông tin cập nhật.</param>
        /// <returns>True nếu cập nhật thành công, false nếu không tìm thấy bản ghi.</returns>
        bool UpdateReview(int id, Review review);

        /// <summary>
        /// Xóa một bản ghi review dựa trên ID.
        /// </summary>
        /// <param name="id">ID của bản ghi review cần xóa.</param>
        /// <returns>True nếu xóa thành công, false nếu không tìm thấy bản ghi.</returns>
        bool DeleteReview(int id);
    }
}
