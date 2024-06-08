using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using PassionProjectN01649276.Models;
using System.Web.Script.Serialization;

namespace PassionProjectN01649276.Controllers
{
    public class BookingController : Controller
    {
        private static readonly HttpClient client;
        private JavaScriptSerializer jss = new JavaScriptSerializer();

        static BookingController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44344/api/bookingdata/");
        }
        // GET: Booking/List
        public ActionResult List()
        {

            string url = "listbookings";

            HttpResponseMessage response = client.GetAsync(url).Result;

            IEnumerable<BookingDto> BookingDtos = response.Content.ReadAsAsync<IEnumerable<BookingDto>>().Result;

            return View(BookingDtos);
        }

        //GET: Booking/Show/3
        public ActionResult Show(int id)
        {
            string url = "findbooking/" + id;

            HttpResponseMessage response = client.GetAsync(url).Result;

            BookingDto Selectedbooking = response.Content.ReadAsAsync<BookingDto>().Result;

            return View(Selectedbooking);
        }

        // POST: Booking/Create
        [HttpPost]
        public ActionResult Create(Booking booking)
        {
            Debug.WriteLine("the json payload is :");

            string url = "addbooking";


            string jsonpayload = jss.Serialize(booking);

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

        // GET: Booking/Edit/5
        public ActionResult Edit(int id)
        {
            string url = "findbooking/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            //Debug.WriteLine("The response code is ");
            //Debug.WriteLine(response.StatusCode);

            BookingDto selectedbooking = response.Content.ReadAsAsync<BookingDto>().Result;

            return View(selectedbooking);
        }

        // POST: Booking/Update/5
        [HttpPost]
        public ActionResult Update(int id, Booking booking)
        {
            try
            {
                Debug.WriteLine("The new booking info is:");
                Debug.WriteLine(booking.Bookingdate);
                Debug.WriteLine(booking.Status);
                Debug.WriteLine(booking.CustomerId);
                Debug.WriteLine(booking.TourId);


                //serialize into JSON
                //Send the request to the API

                string url = "UpdateBooking/" + id;


                string jsonpayload = jss.Serialize(booking);
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

        // GET: Booking/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Booking/Delete/5
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