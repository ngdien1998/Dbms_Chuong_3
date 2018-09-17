using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConnectDatabaseDbms.Models.ViewModels
{
    public class ServerLoginDetail
    {
        [Required(ErrorMessage = "Bạn chưa chọn Server")]
        public string ServerName { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập tên đăng nhập")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu")]
        public string Password { get; set; }
    }
}