using CommonDataLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface IBaseBL<T>
    {
        /// <summary>
        /// Hàm lấy danh sách bản ghi theo phân trang và tìm kiếm
        /// Author: LHNAM (28/6/2023)
        /// </summary>
        /// <param name="condition">Chuỗi tìm kiếm</param>
        /// <param name="page">Trang cần lọc</param>
        /// <param name="limit">Số bản ghi trên 1 trang</param>
        /// <returns>
        ///     Một đối tượng gồm:
        ///         + Danh sách bản ghi thảo mãn điều kiện phân trang và tìm kiếm
        ///         + Tổng số bản ghi thảo mãn điều kiện tìm kiếm
        /// </returns>
        public PagingData<T> FilterRecord(FilterBase filterData);

        /// <summary>
        /// Hàm lấy bản ghi theo ID
        /// Author: LHNAM (28/6/2023)
        /// </summary>
        /// <param name="id">ID của bản ghi cần tìm</param>
        /// <returns>
        ///     Đối tượng cần tìm
        /// </returns>
        public T GetRecordById(Guid id);

        /// <summary>
        /// Hàm xóa những bản ghi
        /// Author: LHNAM (28/6/2023)
        /// </summary>
        /// <param name="ids">Danh sách các ID của những bản ghi cần xóa</param>
        /// <returns>
        ///     Số bản ghi bị xóa
        /// </returns>
        public int DeleteRecords(List<Guid> ids);

        /// <summary>
        /// Hàm tạo mới 1 bản ghi
        /// Author: LHNAM (28/6/2023)
        /// </summary>
        /// <param name="record">Bản ghi cần thêm mới</param>
        /// <returns>
        ///     ID của bản ghi được thêm mới thành công
        /// </returns>
        public Guid InsertOneRecord(T record);

        /// <summary>
        /// Hàm sửa 1 bản ghi
        /// Author: LHNAM (28/6/2023)
        /// </summary>
        /// <param name="id">ID của bản ghi cần sửa</param>
        /// <param name="record">Dữ liệu của bản ghi cần sửa</param>
        /// <returns>
        ///     ID của bản ghi đã được sửa thành công
        /// </returns>
        public Guid UpdateOneRecord(Guid id, T record);
    }
}
