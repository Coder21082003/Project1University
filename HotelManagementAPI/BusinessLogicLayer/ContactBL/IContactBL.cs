using CommonDataLayer.DTO;
using CommonDataLayer.Entities;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;

namespace BusinessLogicLayer
{
    public interface IContactBL : IBaseBL<Contact>
    {
        /// <summary>
        /// Lấy tất cả các bản ghi contact.
        /// </summary>
        /// <returns>Danh sách tất cả các bản ghi contact.</returns>
        IEnumerable<Contact> GetAllContacts();

        /// <summary>
        /// Lọc các bản ghi contact theo các điều kiện được chỉ định.
        /// </summary>
        /// <param name="filter">Thông tin lọc.</param>
        /// <returns>Danh sách các bản ghi contact phù hợp với điều kiện lọc.</returns>
        IEnumerable<Contact> GetFilteredContacts(FilterContacts filter);

        /// <summary>
        /// Thêm một bản ghi contact mới.
        /// </summary>
        /// <param name="contact">Bản ghi contact cần thêm.</param>
        /// <returns>ID của bản ghi contact đã thêm.</returns>
        int InsertContact(Contact contact);

        /// <summary>
        /// Cập nhật thông tin của một bản ghi contact dựa trên ID.
        /// </summary>
        /// <param name="id">ID của bản ghi contact cần cập nhật.</param>
        /// <param name="contact">Thông tin cập nhật.</param>
        /// <returns>True nếu cập nhật thành công, false nếu không tìm thấy bản ghi.</returns>
        bool UpdateContact(int id, Contact contact);

        /// <summary>
        /// Xóa một bản ghi contact dựa trên ID.
        /// </summary>
        /// <param name="id">ID của bản ghi contact cần xóa.</param>
        /// <returns>True nếu xóa thành công, false nếu không tìm thấy bản ghi.</returns>
        bool DeleteContact(int id);
    }
}
