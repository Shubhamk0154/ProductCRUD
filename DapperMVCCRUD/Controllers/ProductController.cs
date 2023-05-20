using Dapper;
using DapperMVCCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DapperMVCCRUD.Controllers
{
    public class ProductController : Controller
    {

        //GET:/Product/
        public ActionResult Index()
        {
            return View(DapperORM.ReturnList<ProductModel>("ProductViewAll"));
        }


        //      ..../Product/AddOrEdit    -- Insert
        //      ..../Product/AddOrEdit/id  --  update
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddOrEdit(ProductModel prod)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ProducctId", prod.ProductId);
            param.Add("@ProducctName", prod.ProductName);
            param.Add("@ProducctPrice", prod.ProductPrice);

            DapperORM.ExecuteWithoutReturn("ProductAddOrEdit", param);

            return RedirectToAction("Employee List");
        }
        /*
        //
        // GET: /Employee/
        public ActionResult Index()
        {
            return View(DapperORM.ReturnList<ProductModel>("EmployeeViewAll"));
        }


        //        .. /Employee/AddOrEdit  -insert
        //        .. /Employee/AddOrEdit/id
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if(id==0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@EmployeeID",id);
                return View(DapperORM.ReturnList<ProductModel>("EmployeeViewByID",param).FirstOrDefault<ProductModel>());
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(ProductModel emp)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@EmployeeID", emp.EmployeeID);
            param.Add("@Name", emp.Name);
            param.Add("@Position", emp.Position);
            param.Add("@Age", emp.Age);
            param.Add("@Salary", emp.Salary);
            DapperORM.ExecuteWithoutReturn("EmployeeAddOrEdit", param);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@EmployeeID", id);
            DapperORM.ExecuteWithoutReturn("EmployeeDeleteByID", param);
            return RedirectToAction("Index");
        }

    }*/
    }
}