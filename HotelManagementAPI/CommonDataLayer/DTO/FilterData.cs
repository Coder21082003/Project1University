using System;
using System.Collections.Generic;

namespace CommonDataLayer.DTO
{
    public class Pagination
    {
        public int Page { get; set; } = 1;
        public int Limit { get; set; } = 20;
    }

    public class FilterBase : Pagination
    {
        public string? Name { get; set; }
    }

    // Lọc dữ liệu chung
    public class FilterData : Pagination
    {
        public string? Condition { get; set; }
        public string? Sort { get; set; } = "ModifiedDate DESC";
    }

    // Lọc cho bảng Account
    public class FilterUser : Pagination
    {
        public string? FullName { get; set; }
        public string? PhoneNo { get; set; }
        public DateTime? DoB { get; set; }
        public string? Email { get; set; }
    }

    // Lọc cho bảng Blog
    public class FilterBlog : Pagination
    {
        public string? BlogTitle { get; set; }
        public string? BlogAuthor { get; set; }
        public DateTime? BlogTime { get; set; }
        public string? BlogDescription { get; set; }
    }

    // Lọc cho bảng Contacts
    public class FilterContacts : Pagination
    {
        public string? ContactsName { get; set; }
        public string? ContactsEmail { get; set; }
        public string? ContactsTitle { get; set; }
        public string? ContactsComment { get; set; }
    }

    // Lọc cho bảng Rooms
    public class FilterRoom : Pagination
    {
        public string? RoomType { get; set; }
        public string? Description { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? Amenities { get; set; }
    }

    // Lọc cho bảng Bookings
    public class FilterBooking : Pagination
    {
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public int? Status { get; set; }
        public decimal? MinTotalPrice { get; set; }
        public decimal? MaxTotalPrice { get; set; }
    }

    // Lọc cho bảng Payments
    public class FilterPayment : Pagination
    {
        public string? PaymentMethod { get; set; }
        public int? PaymentStatus { get; set; }
        public decimal? MinAmount { get; set; }
        public decimal? MaxAmount { get; set; }
    }

    // Lọc cho bảng Coupon
    public class FilterCoupon : Pagination
    {
        public string? CouponName { get; set; }
        public string? CouponCode { get; set; }
        public int? Status { get; set; }
    }

    // Lọc cho bảng CouponRooms (không có nhiều thuộc tính để lọc, nên để trống hoặc thêm nếu cần)
    public class FilterCouponRooms : Pagination
    {
        // Có thể thêm thuộc tính lọc nếu cần
    }

    public class FilterReviews : Pagination
    {
        // Có thể thêm thuộc tính lọc nếu cần
    }

    public class UpdateStatusValue
    {
        public int Status { get; set; }
    }

    public class UpdateIsPaidValue
    {
        public int IsPaid { get; set; }
    }
}
