using PDTCoreAPI.UserClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PDTCoreAPI.UserClient.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            IEnumerable<NhanVienModel> userlist;
            HttpResponseMessage response = ClientConfiguration.WebApiClient.GetAsync("NhanVien").Result;
            userlist = response.Content.ReadAsAsync<IEnumerable<NhanVienModel>>().Result;
            return Json(userlist, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetNhanVien(Guid ID)
        {
            HttpResponseMessage response = ClientConfiguration.WebApiClient.GetAsync("NhanVien/" + ID.ToString()).Result;
            return Json(response.Content.ReadAsAsync<NhanVienModel>().Result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult InsertOrUpdate(NhanVienModel nhanvien)
        {
            HttpResponseMessage response;
            if (nhanvien.ID == null || nhanvien.ID == Guid.Empty)
            {
                response = ClientConfiguration.WebApiClient.PostAsJsonAsync("NhanVien", nhanvien).Result;
            }
            else
            {//update
                response = ClientConfiguration.WebApiClient.PutAsJsonAsync("NhanVien/" + nhanvien.ID, nhanvien).Result;
            }

            return Json(response.Content.ReadAsAsync<NhanVienModel>().Result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(Guid ID)
        {
            if (ID == null || ID == Guid.Empty)
                //return View(new NhanVienModel());
                return Json("", JsonRequestBehavior.AllowGet);
            else
            {
                HttpResponseMessage response = ClientConfiguration.WebApiClient.DeleteAsync("NhanVien/" + ID.ToString()).Result;
                return Json(response.Content.ReadAsAsync<NhanVienModel>().Result, JsonRequestBehavior.AllowGet);
            }
        }
    }
}