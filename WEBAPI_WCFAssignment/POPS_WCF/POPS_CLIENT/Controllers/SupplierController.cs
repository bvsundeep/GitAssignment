using POPS_CLIENT.SupplierServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POPS_CLIENT.Controllers
{
    public class SupplierController : Controller
    {
        Service1Client supplier = new Service1Client();

        // GET: Supplier/Details/5
        [Route("Supplier/DisplaySupplier/{id}")]
        [HttpGet]
        public ActionResult DisplaySupplier(string SUPLNO)
        {
            return View(supplier.GetSupplier(SUPLNO));
        }

        // GET: Supplier/Create
        [HttpGet]
        //[Route("Supplier/GetAll")]
        public ActionResult DisplaySuppliers()
        {
            try
            {
                return View(supplier.GetAllSuppliers());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        [HttpGet]
        public ActionResult AddSupplier()
        {
            return View();
        }
        // POST: Supplier/Create
        //[Route("Supplier/Create")]
        [HttpPost]
        public ActionResult AddSupplier(SUPPLIER item)
        {
            try
            {
                // TODO: Add insert logic here
                //SupplierServiceReference.Service1Client sr = new SupplierServiceReference.Service1Client();
                supplier.AddSupplier(item);

                return RedirectToAction("DisplaySuppliers");
            }
            catch
            {
                ;
                return View();
                throw new Exception();
            }
        }

        [HttpGet]
        //[Route("Supplier/EditSupplier/{id}")]
        public ActionResult EditSupplier(string SUPLNO)
        {
            SUPPLIER sup = supplier.GetAllSuppliers().ToList().Where(e => e.SUPLNO.Equals(SUPLNO)).FirstOrDefault();
            return View(sup);
        }
        // GET: Supplier/Edit/5
        [Route("Supplier/Edit/{id}")]
        [HttpPost]
        public ActionResult EditSupplier(SUPPLIER item)
        {
            if (ModelState.IsValid)
            {
                supplier.UpdateSupplier(item);
                return RedirectToAction("DisplaySuppliers");
            }
            return View();
        }

        [HttpGet]
        public ActionResult DeleteSupplier(string SUPLNO)
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteSupplier(SUPPLIER _supplier)
        {
            if (ModelState.IsValid)
            {
                supplier.DeleteSupplier(_supplier.SUPLNO);
                return RedirectToAction("DisplaySuppliers");
            }
            return View();
        }
    }
}
