using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly object date;
        private object HTotal;

        public object avg { get; private set; }
        public string H { get; private set; }
        public string M { get; private set; }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult CalculateAreaOfRectangle(int height, int width)
        {
            int result = height * width;
            string resultString = result.ToString();
            ContentResult test = new ContentResult();
            test.Content = resultString;
            return test;
        }
        public IActionResult FindIndex([FromBody]FindIndexModel model)
        {

            int findIndex = -1;
            for (int i = 0; i < model.values.Count; i++)
            {
                int value = model.values[i];
                if (value == model.valueToFind)
                {
                    findIndex = i;
                    break;
                }
            }
            string resultString = findIndex.ToString();
            ContentResult test = new ContentResult();
            test.Content = resultString;
            return test;
        }
        public IActionResult Concat([FromBody]Concats model)
        {
            List<string> result = new List<string>();
            result.Add("q");
            result.Add("q");
            result.Add("q");
            result.Add("q");
            JsonResult jsonResult = new JsonResult(result);
            return jsonResult;

        }

        //5 CalculateMin
        public IActionResult CalculateMin([FromBody]FindIndexModel model)
        {
            int min = model.values[0];
            for (int i = 0; i < model.values.Count; i++)
            {
                int values = model.values[i];
                if (values < min);
                {
                    min = model.values[i]; 
                   
                    break;
                }
            }
            string resultString = min.ToString();
            ContentResult test = new ContentResult();
            test.Content = resultString;
            return test;
        }


        //6 CalculateMax
        public IActionResult CalculateMax([FromBody]FindIndexModel model)
        {
            int max = model.values[0];
            for (int i = 0; i < model.values.Count; i++)
            {
                int values = model.values[i];
                if (values > max) 
                {
                    max = model.values[i];

                }
            }
            string resultString = max.ToString();
            ContentResult test = new ContentResult();
            test.Content = resultString;
            return test;
        }

        //7 CalculateAvg
        public IActionResult CalculateMa([FromBody]List<int> input)
        {
            //int max = model.values[0];
            //int n = sizeof(model.values[]) / sizeof(model.values);

            var sizeOf = input.Count;
            int sum = 0;
            int avg = 0;
            for (int i = 0; i < sizeOf; i++)
            { 
                sum = sum + input[i];
                avg = sum / sizeOf;
                break;
                
            }
            string resultString = Convert.ToString(avg);
            ContentResult test = new ContentResult();
            test.Content = resultString;
            return test;
        }



        //8.sum sequence
        public IActionResult sequence(FindIndexModel model)
        {
            double sum = 0;

            for (int i = 1; i < 10; i++)
            {
               
                sum = sum + i ;
            }
            string resultString = sum.ToString();
            ContentResult test = new ContentResult();
            test.Content = resultString;
            return test;
        }


        //10.

        public ContentResult GetUppercase(string str1)
        {
            string upperstr1 = str1.ToUpper();


            string resultString = upperstr1;
            //ContentResult test = new ContentResult();
            //test.Content = resultString;
            ContentResult test = Content(resultString);
            //ViewResult vr = View();
            //ViewResult vr2 = new ViewResult();
            return test;
        }

        //11.

        public ContentResult GetLowercase(string str2)
        {
            string upperstr2 = str2.ToLower();

            string resultString = upperstr2;
            //ContentResult test = new ContentResult();
            //test.Content = resultString;
            ContentResult test1 = Content(resultString);
            return test1;
        }


        //12.Modulo
        public IActionResult Calculatemod(int numeratort, int denominatorh)
        {
            int results = numeratort % denominatorh;
            string resultString = results.ToString();
            ContentResult tests = Content(resultString);
            tests.Content = resultString;
            return tests;
        }

        //13.RemoveOdd
      
        public IActionResult Calculatere([FromBody]FindIndexModel model)
        {
            int Odd = 0;
           
            for (int i = 0; i < model.values.Count; i++)
            {
                int values = model.values[i];
                if ((values % 2)==0) ;
                {
                     Odd = model.values[i];

                }
            }
            string resultString = Odd.ToString();
            ContentResult test = new ContentResult();
            test.Content = resultString;
            return test;
        }

        //14.RemoveEven


        //15.Time Addition
        //public IActionResult CalculateTime(int h1, int m1, int h2, int m2)
        //{
        //    TimeSpan t1 = TimeSpan.Parse("00:h1:m1");
        //    TimeSpan t2 = TimeSpan.Parse("00:h2:m2");
        //    TimeSpan t3 = t1.Add(t2);


        //    string resultString = t3.ToString();
        //    ContentResult test = new ContentResult();
        //    test.Content = resultString;
        //    return test;
        //}
        //15.1.Time Addition



        //        int rowTotal = 241;
        //int rowPerPage = 15;
        //float pageTotal = 0;
        //int pTotal = 0;
        //if (rowTotal % rowPerPage == 0)
        //{
        //pTotal = rowTotal / rowPerPage;
        //}
        //else
        //{ 
        //pageTotal = rowTotal / rowPerPage;
        //pTotal = (int) Math.Floor(pageTotal) + 1;
        //}

        //15.Time Addition
        public ActionResult Addition(int H1, int min1, int H2, int min2)
        {
            int result = H1 + H2;
            int result2;

            for (result2 = min1 + min2 ; result2 > 60; result2 = result2 - 60)
            {
                if (result2>60)
                {
                    result += 1;
                }
            }
   
            string resultString = "Hour=" + result.ToString() + " Minute=" + result2.ToString();
            ContentResult test = new ContentResult();
            test.Content = resultString;
            return test;
        }


        //16.Time Multiplication
        public ActionResult CalculateTe(int hour, int minute, int Multipli)
        {
            int result = hour * Multipli;
            int result2; 
            for (result2 = minute * Multipli; result2 > 60; result2 = result2 - 60)
            {

                if ((result2 % 60) > 0)
                {
                    result += 1;

                   
                }
            }

          
            string resultString = "Hour=" + result.ToString() + " Minute=" + result2.ToString();
            ContentResult test = new ContentResult();
            test.Content = resultString;
            return test;
        }

        //17.Year and Month Addition
        public ActionResult jjjj(int Year1, int Month1, int Year2, int Month2)
        {
            int result = Year1 + Year2;
            int result2;

            for (result2 = Month1 + Month2; result2 > 12; result2 = result2 - 12)
            {
                if ((result2 % 12) > 0)
                {
                    result += 1;

                }
            }
            
            string resultString = "year="+result.ToString() + " month=" + result2.ToString();
            ContentResult test = new ContentResult();
            test.Content = resultString;
            return test;
        }





        //18.Year and Month Multiplication

        public ActionResult CalculateTime1(int Month, int Multipli, int Year)
        {
            int result = Year * Multipli;
            int result2;
            for ( result2 = Month * Multipli; result2 > 12; result2 = result2 - 12)
            {

                if ((result2 % 12) > 0)
                {
                    result += 1;

                }
            }


            string resultString = "year=" + result.ToString() +  " month=" + result2.ToString();
            ContentResult test = new ContentResult();
            test.Content = resultString;
            return test;
        }








    }

}
