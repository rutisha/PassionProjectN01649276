﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using PassionProjectN01649276.Models;

namespace PassionProjectN01649276.Controllers
{
    public class TourController : Controller
    {
        public static readonly HttpClient client;
        public JavaScriptSerializer jss = new JavaScriptSerializer();

        static TourController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44344/api/tourdata/");
        }
        // GET: Tour/List
        public ActionResult List()
        {
          
            string url = "listtours";

            HttpResponseMessage response = client.GetAsync(url).Result;

            IEnumerable<TourDto> TourDtos = response.Content.ReadAsAsync<IEnumerable<TourDto>>().Result;

            return View(TourDtos);
        }

        //GET: Tour/Show/3
        public ActionResult Show(int id)
        {
            string url = "findtour/" + id;

            HttpResponseMessage response = client.GetAsync(url).Result;

            TourDto Selectedtour = response.Content.ReadAsAsync<TourDto>().Result;

            return View(Selectedtour);
        }

        // POST: Tour/Create
        [HttpPost]
        
        public ActionResult Create (Tour Tour)
        {
            Debug.WriteLine("the json payload is :");
          
            string url = "addtour";


            string jsonpayload = jss.Serialize(Tour);

            Debug.WriteLine(jsonpayload);

            HttpContent content = new StringContent(jsonpayload);


            content.Headers.ContentType.MediaType = "application/json";

            HttpResponseMessage response = client.PostAsync(url, content).Result;

            Debug.WriteLine(response);

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

        // GET: Tour/Edit/5
        public ActionResult Edit(int id)
        {
            string url = "findtour/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            //Debug.WriteLine("The response code is ");
            //Debug.WriteLine(response.StatusCode);

            TourDto selectedtour = response.Content.ReadAsAsync<TourDto>().Result;
          
            return View(selectedtour);
        }

        // POST: Tour/Update/5
        [HttpPost]
        public ActionResult Update(int id, Tour tour)
        {
            try
            {
                Debug.WriteLine("The new tour info is:");
                Debug.WriteLine(id);
                Debug.WriteLine(tour.Tourname);
                Debug.WriteLine(tour.Description);
                Debug.WriteLine(tour.Location);
                Debug.WriteLine(tour.Price);

                //serialize into JSON
                //Send the request to the API

                string url = "updatetour/" + id;


                string jsonpayload = jss.Serialize(tour);
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

        // GET: Tour/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tour/Delete/5
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