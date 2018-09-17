using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConnectDatabaseDbms.Models.DataModels
{
    public class SinhVien
    {
        [Required(ErrorMessage = "Bạn chưa nhập MSSV")]
        public string MSSV { get; set; }

        [Display(Name = "Tên sinh viên")]
        [Required(ErrorMessage = "Bạn chưa nhập Tên sinh viên")]
        public string TenSV { get; set; }

        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Bạn chưa nhập Ngày sinh")]
        public DateTime NgaySinh { get; set; }

        [Display(Name = "Lớp")]
        [Required(ErrorMessage = "Bạn chưa nhập Lớp")]
        public string Lop { get; set; }

        [Display(Name = "Nữ")]
        [Required(ErrorMessage = "Bạn chưa chọn Giới tính")]
        public bool Nu { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Bạn chưa nhập Địa chỉ")]
        public string DiaChi { get; set; }

        [Display(Name = "Điện thoại")]
        [Required(ErrorMessage = "Bạn chưa nhập Điện thoại liên lạc")]
        public string DienThoai { get; set; }

        [Display(Name = "Điểm")]
        [Required(ErrorMessage = "Bạn chưa nhập Điểm")]
        public float Diem { get; set; }
    }
}