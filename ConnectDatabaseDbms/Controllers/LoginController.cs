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
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            return View(detail);
        }
    }
}