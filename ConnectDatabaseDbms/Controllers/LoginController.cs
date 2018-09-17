using System;
using System.Data.SqlClient;
using System.Web.Mvc;
using ConnectDatabaseDbms.Models.BusinessModels;
using ConnectDatabaseDbms.Models.ViewModels;

namespace ConnectDatabaseDbms.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ServerLoginDetail detail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string constr = $"server={detail.ServerName};database=QuanLySinhVien;user id={detail.Username};pwd={detail.Password}";
                    SqlConnection testConn = new SqlConnection(constr);
                    testConn.Open();
                    testConn.Close();

                    DatabaseAccessor.InitDatabase(constr);
                    return new RedirectResult("/Home");
                }
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Không thể kết nối với server, hãy kiểm tra lại.";
            }
            return View(detail);
        }
    }
}