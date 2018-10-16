using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Question.Models;
using System.Diagnostics;

namespace Question.Controllers
{
    /// <summary>
    /// TriangleController class defines the entry point to the API
    /// </summary>
    /// /// <remarks>
    /// This class will accept calls with a single name as the parameter or three sets of x,y values to form a triangle to query for. 
    /// </remarks>
    public class TriangleController : ApiController
    {
      
        /// <summary>
        /// API Get used to query the data structure  for a triangle's  names and return the coordinates. 
        /// </summary>
        public string Get([FromUri] string name)
        {
            Triangles triangleList = new Triangles();
            return triangleList.FindCoordinatesForName(name);
        }

        /// <summary>
        /// API Get used to query the data structure  for a triangles XY and return the name
        /// </summary>
        public string Get([FromUri] string v2X, string v2Y, string v3X, string v3Y, string v1X, string v1Y)
        {
            Triangles triangleList = new Triangles();
            return triangleList.FindNameForCoordinates(v2X, v2Y, v3X, v3Y, v1X, v1Y);
        }

        /// <summary>
        /// API Get used to return the coordinate on the fly. 
        /// </summary>
        public string Get([FromUri] string name, string turbo)
        {
            string turboResult = "";
            try
            {
                Triangle triangle = new Triangle(name);
                turboResult = triangle.FormatedCoordinates();
            }
            catch (Exception)
            {
                turboResult = "Something went wrong... Couldn't create a TURBO triangle with your input";
            }
            
            return "TURBO:" + turboResult; 
        }

        /// <summary>
        /// API  Get used to return the name on the fly from x and y values
        /// </summary>
        public string Get([FromUri] string v2X, string v2Y, string v3X, string v3Y, string v1X, string v1Y, string turbo)
        {

            string turboResult = "";

            try
            {
                Triangle triangle = new Triangle(v2X, v2Y, v3X, v3Y, v1X, v1Y);
                turboResult = triangle.Name;
            }
            catch (FormatException)
            {
                turboResult = "Looks like all the values you provided were not intergers. Please check your x y values. ";
            }
            catch (Exception)
            {

                turboResult = "Something went wrong... Couldn't create a TURBO triangle with your input";
            }
            
            return "TURBO:" + turboResult;
        }

    }
}