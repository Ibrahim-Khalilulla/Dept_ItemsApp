using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dept_ItemsApp.Context;
using Dept_ItemsApp.Models;

namespace Dept_ItemsApp.Controllers
{
    public class dept2Controller : Controller
    {
        private MyDbContext db = new MyDbContext();

        public JsonResult InsertDept(dept2 stu_Guard)
        {
            dept2 a = new dept2();
            a.deptid = stu_Guard.deptid;
            a.deptname = stu_Guard.deptname;
            a.location = stu_Guard.location;
            db.dept2s.Add(a);
            db.SaveChanges();
            return Json(a, JsonRequestBehavior.AllowGet);
        }
        public JsonResult InsertItems(items2 stu_Guard)
        {
            items2 a1 = new items2();
            a1.itemcode = stu_Guard.itemcode;
            a1.itemname = stu_Guard.itemname;
            a1.deptid = stu_Guard.deptid;
            a1.date = DateTime.Parse(stu_Guard.date.ToShortDateString());
            a1.picture = stu_Guard.picture;
            a1.cost = (decimal)stu_Guard.cost;
            a1.rate = (decimal)stu_Guard.rate;
            db.items2s.Add(a1);
            db.SaveChanges();
            return Json(a1, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteAll(string id)
        {

            List<items2> st5 = db.items2s.Where(xx => xx.deptid == id).ToList();
            db.items2s.RemoveRange(st5);

            dept2 st6 = db.dept2s.Find(id);
            if (st6 != null)
            {
                db.dept2s.Remove(st6);
            }
            db.SaveChanges();
            return Json("OK", JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetDept(string id)
        {
            var a = (from d in db.dept2s where d.deptid == id select new { d.deptid, d.deptname, d.location });
            return Json(a, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetItems(string id)
        {
            var a = (from d in db.items2s where d.deptid == id select new { d.itemcode, d.itemname, d.cost, d.rate, d.date, d.picture });
            return Json(a, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ShowMe()
        {
            List<dept2> s = db.dept2s.ToList();
            return View(s);
        }
        [ChildActionOnly]
        public ActionResult ShowItems(string sid = "0")
        {
            List<items2> s = db.items2s.Where(xx => xx.deptid == sid).ToList();
            return View(s);
        }
        [ChildActionOnly]
        public ActionResult Create2(string sid = "0")
        {
            ViewBag.sid = sid;
            return View();
        }
        [HttpPost]
        public ActionResult UploadFiles()
        {
            // Checking no of files injected in Request object
            if (Request.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";
                        //string filename = Path.GetFileName(Request.Files[i].FileName);

                        HttpPostedFileBase file = files[i];
                        string fname;

                        // Checking for Internet Explorer
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }

                        // Get the complete folder path and store the file inside it.
                        fname = Path.Combine(Server.MapPath("~/Uploads/"), fname);
                        file.SaveAs(fname);
                    }
                    // Returns message that successfully uploaded
                    return Json("File Uploaded Successfully!");
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }
        public string GenerateCodeDP()
        {
            string a1 = "";
            string b1 = "";

            try
            {
                var a = (from det in db.dept2s select det.deptid.Substring(3)).Max();
                int b = int.Parse(a.ToString()) + 1;
                if (b < 10)
                {
                    b1 = "000" + b.ToString();
                }
                else if (b < 100)
                {
                    b1 = "00" + b.ToString();
                }
                else if (b < 1000)
                {
                    b1 = "0" + b.ToString();
                }
                else
                {
                    b1 = b.ToString();
                }
                a1 = "DP-" + b1.ToString();
            }
            catch (Exception ex)
            {
                a1 = "AC-0001";
            }
            return a1;
        }
        public JsonResult test()
        {
            var a = (from det in db.items2s select det.itemcode.Substring(3, det.itemcode.Length - 1)).Max();
            return Json(a, JsonRequestBehavior.AllowGet);

        }
        public string GenerateCodeItems()
        {
            string a1 = "";
            string b1 = "";

            try
            {
                var a = (from det in db.items2s select det.itemcode.Substring(3, det.itemcode.Length-1)).Max();
                int b = int.Parse(a.ToString()) + 1;
                if (b < 10)
                {
                    b1 = "000" + b.ToString();
                }
                else if (b < 100)
                {
                    b1 = "00" + b.ToString();
                }
                else if (b < 1000)
                {
                    b1 = "0" + b.ToString();
                }
                else
                {
                    b1 = b.ToString();
                }
                a1 = "IT-" + b1.ToString();
            }
            catch (Exception ex)
            {
                a1 = "IT-0001";
            }
            return a1;
        }
    }


}

