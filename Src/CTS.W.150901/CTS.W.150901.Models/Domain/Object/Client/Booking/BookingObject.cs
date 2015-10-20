using System;
using CTS.Core.Domain.Helper;

namespace CTS.W._150901.Models.Domain.Object.Client.Booking
{
    /// <summary>
    /// BookingObject
    /// </summary>
    public class BookingObject
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public decimal? RoomQty { get; set; }

        public string TypeCd { get; set; }
        public string TypeName { get; set; }
        public decimal? AdultPerRoom { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string StateCounty { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Request { get; set; }
        public bool? PickUp { get; set; }
        public bool? SeeOff { get; set; }

        public decimal? Total { get; set; }
        public decimal? Days { get; set; }
        public decimal? Price { get; set; }
        public decimal? PickUpPrice { get; set; }
        public decimal? SeeOffPrice { get; set; }

        public decimal GetDays() {
            // Khởi tạo biến cục bộ
            var days = decimal.Zero;
            // Kiểm tra ngày hợp lệ
            if (DataCheckHelper.IsNull(DateFrom)
                || DataCheckHelper.IsNull(DateTo)) {
                return decimal.Zero;
            }
            // Lấy thời gian thuê phòng
            var time = DateTo.Value - DateFrom.Value;
            // Gán giá trị trả về
            days = time.Days;
            // Kết quả trả về
            return days;
        }

        public bool IsCompleteStep1() {
            return !DataCheckHelper.IsNull(DateFrom)
                && !DataCheckHelper.IsNull(DateTo)
                && !DataCheckHelper.IsNull(RoomQty);
        }

        public bool IsCompleteStep2() {
            return !DataCheckHelper.IsNull(TypeCd);
        }

        public bool IsCompleteStep3() {
            return !DataCheckHelper.IsNull(FirstName)
                && !DataCheckHelper.IsNull(LastName)
                && !DataCheckHelper.IsNull(Email)
                && !DataCheckHelper.IsNull(Phone)
                && !DataCheckHelper.IsNull(Address)
                && !DataCheckHelper.IsNull(StateCounty)
                && !DataCheckHelper.IsNull(City)
                && !DataCheckHelper.IsNull(Country)
                && !DataCheckHelper.IsNull(PickUp)
                && !DataCheckHelper.IsNull(SeeOff);
        }

        public void ClearStep1() {
            DateFrom = null;
            DateTo = null;
            RoomQty = null;
        }

        public void ClearStep2() {
            TypeCd = null;
        }

        public void ClearStep3() {
            FirstName = null;
            LastName = null;
            Email = null;
            Phone = null;
            Address = null;
            StateCounty = null;
            City = null;
            Country = null;
            Request = null;
            PickUp = null;
            SeeOff = null;
        }
    }
}
