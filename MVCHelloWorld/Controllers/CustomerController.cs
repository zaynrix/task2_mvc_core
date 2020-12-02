using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCHelloWorld.Models;

namespace MVCHelloWorld.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult List()
        {

            OurDatabase DB = new OurDatabase();
            List<Customer> Customers;

            
            if (TempData["Datastore"] == null)
            {
            
                //Get the list of Customers from the DB
                Customers = DB.Customers;
                //And Store it in TempData
                TempData["Datastore"] = Customers;
            }
            else
            {
                //Get already stored data from TempData
                Customers = (List<Customer>) TempData["Datastore"];
                //Ask TempData to keep the data till the next request
                TempData.Keep();
            }


            return View(Customers);

        }



        public ActionResult Create()
        {
            //Ask TempData to keep the data till the next request. Otherwise Tempdata will discard it.
            TempData.Keep();

            //Empty Customer Object
            Customer model = new Customer();

            //Pass it to the View
            return View(model);

        }


        [HttpPost]
        public ActionResult Create(Customer m)
        {
            
            List<Customer> Customers;
    if (ModelState.IsValid)
            {   
                Customers = (List<Customer>) TempData["Datastore"];
                Customers.Add(m);
                TempData.Keep();
                return RedirectToAction("List");
            }

            TempData.Keep();
            return View(m);
        }


        public ActionResult Edit(int id)
        {
            List<Customer> Customers;

            Customers = (List<Customer>)TempData["Datastore"];
            Customer model = Customers.FirstOrDefault(x => x.id == id);

            TempData.Keep();
            return View(model);

        }


        [HttpPost]
        public ActionResult Edit(Customer m)
        {
        

            List<Customer> Customers;

            if (ModelState.IsValid)
            {
             
                Customers = (List<Customer>)TempData["Datastore"];

              
                Customer model = Customers.FirstOrDefault(x => x.id == m.id);

        
                model.id=m.id;
                model.CustomerName = m.CustomerName;
                model.CustomerWork= m.CustomerWork;
    model.Country = m.Country;
                model.Address = m.Address;
                
              
                TempData.Keep();
                return RedirectToAction("List");
            }

            TempData.Keep();
            return View(m);
        }



        public ActionResult Details(int id)
        {
         
            List<Customer> Customers;
             Customers = (List<Customer>)TempData["Datastore"];

            Customer model = Customers.FirstOrDefault(x => x.id == id);

            TempData.Keep();

            return View(model);

        }



        public ActionResult Delete(int id)
        {
            List<Customer> Customers;

            Customers = (List<Customer>)TempData["Datastore"];

             Customer model = Customers.FirstOrDefault(x => x.id == id);

            TempData.Keep();

             return View(model);

        }


        [HttpPost]
        public ActionResult Delete(Customer m)
        {

            List<Customer> Customers;

            if (ModelState.IsValid)
            {
                Customers = (List<Customer>)TempData["Datastore"];

                Customer model = Customers.FirstOrDefault(x => x.id == m.id);

                Customers.Remove(model);

                TempData.Keep();
                return RedirectToAction("List");
            }

            TempData.Keep();
            return View(m);
        }

    }
}





