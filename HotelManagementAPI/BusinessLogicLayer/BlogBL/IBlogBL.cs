using CommonDataLayer.DTO;
using CommonDataLayer.Entities;
using System.Collections.Generic;

namespace BusinessLogicLayer
{
    public interface IBlogBL : IBaseBL<Blog>
    {
        /// <summary>
        /// Lọc các bản ghi blog theo các điều kiện được chỉ định.
        /// </summary>
        /// <param name="filter">Thông tin lọc.</param>
        /// <returns>Danh sách các bản ghi blog phù hợp với điều kiện lọc.</returns>
        IEnumerable<Blog> GetAllBlogs();

        /// <summary>
        /// Lọc các bản ghi blog theo các điều kiện được chỉ định.
        /// </summary>
        /// <param name="filter">Thông tin lọc.</param>
        /// <returns>Danh sách các bản ghi blog phù hợp với điều kiện lọc.</returns>
        IEnumerable<Blog> GetFilteredBlogs(FilterBlog filter);

        /// <summary>
        /// Thêm một bản ghi blog mới.
        /// </summary>
        /// <param name="blog">Bản ghi blog cần thêm.</param>
        /// <returns>ID của bản ghi blog đã thêm.</returns>
        int InsertBlog(Blog blog);

        /// <summary>
        /// Cập nhật thông tin của một bản ghi blog dựa trên ID.
        /// </summary>
        /// <param name="id">ID của bản ghi blog cần cập nhật.</param>
        /// <param name="blog">Thông tin cập nhật.</param>
        /// <returns>True nếu cập nhật thành công, false nếu không tìm thấy bản ghi.</returns>
        bool UpdateBlog(int id, Blog blog);

        /// <summary>
        /// Xóa một bản ghi blog dựa trên ID.
        /// </summary>
        /// <param name="id">ID của bản ghi blog cần xóa.</param>
        /// <returns>True nếu xóa thành công, false nếu không tìm thấy bản ghi.</returns>
        bool DeleteBlog(int id);
    }
}
