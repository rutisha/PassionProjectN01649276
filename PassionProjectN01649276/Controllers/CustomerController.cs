using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using PassionProjectN01649276.Models;

namespace PassionProjectN01649276.Controllers
{
    public class CustomerController : Controller
    {
        private static readonly HttpClient client;
        private JavaScriptSerializer jss = new JavaScriptSerializer();

        static CustomerController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44344/api/customerdata/");
        }
        // GET: Customer/List
        public ActionResult List()
        {

            string url = "listcustomers";

            HttpResponseMessage response = client.GetAsync(url).Result;

            IEnumerable<CustomerDto> CustomerDtos = response.Content.ReadAsAsync<IEnumerable<CustomerDto>>().Result;

            return View(CustomerDtos);
        }

        //GET: Customer/Show/3
        public ActionResult Show(int id)
        {
            string url = "findcustomer/" + id;

            HttpResponseMessage response = client.GetAsync(url).Result;

            CustomerDto Selectedcustomer = response.Content.ReadAsAsync<CustomerDto>().Result;

            return View(Selectedcustomer);
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer Customer)
        {
            Debug.WriteLine("the json payload is :");

            string url = "addcustomer";


            string jsonpayload = jss.Serialize(Customer);

            Debug.WriteLine(jsonpayload);

            HttpContent content = new StringContent(jsonpayload);

            content.Headers.ContentType.MediaType = "application/json";

            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }


        }
        public ActionResult Error()
        {
            return View();
        }
        public ActionResult New()
        {
            return View();
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            string url = "findcustomer/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            //Debug.WriteLine("The response code is ");
            //Debug.WriteLine(response.StatusCode);

            CustomerDto selectedcustomer = response.Content.ReadAsAsync<CustomerDto>().Result;

            return View(selectedcustomer);
        }

        // POST: Customer/Update/5
        [HttpPost]
        public ActionResult Update(int id, Customer customer)
        {
            try
            {
                Debug.WriteLine("The new customer info is:");
                Debug.WriteLine(customer.CustomerName);
                Debug.WriteLine(customer.Email);
                

                //serialize into JSON
                //Send the request to the API

                string url = "UpdateCustomer/" + id;


                string jsonpayload = jss.Serialize(customer);
                Debug.WriteLine(jsonpayload);

                HttpContent content = new StringContent(jsonpayload);
                content.Headers.ContentType.MediaType = "application/json";

                HttpResponseMessage response = client.PostAsync(url, content).Result;


                return RedirectToAction("Show/" + id);
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}