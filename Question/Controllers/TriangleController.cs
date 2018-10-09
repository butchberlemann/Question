using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Question.Models;

namespace Question.Controllers
{
    public class TriangleController : ApiController
    {
        /// <summary>
        /// TriangleController class defines the entry point to the API as well as creating the data structure used by the API. 
        /// </summary>
        /// /// <remarks>
        /// This class will accept calls with a single name as the parameter or three sets of x,y values to form a triangle to query for. 
        /// </remarks>

            /// <summary>
            /// Private function that creates the data structure of triangles used when the API is queried. 
            /// </summary>
            private List<Triangle> BuiltGrid()
            {

                //Create a list of Triangles that is empty. 
                List<Triangle> tris = new List<Triangle> { };

                //The alpha area is used to name each row. If you wanted to enlarge or shrink the number of row available this could be 
                //done so here without adjusting any of the other code. 
                string[] alpha = new string[] { "F", "E", "D", "C", "B", "A" };

                //This triangle represent the first one used.
                Triangle baseTri = new Triangle(0, 10, 0, 0, 10, 0, alpha[0] + "1");

                // Add the base triangle to the collection. 
                tris.Add(baseTri);

                //Since each of the triangles are built off of the one before it the currentRowColumnZeroZero variable is used to 
                //mark the point in the current row. This is why it is incremented by 12 at the end of the loop. 
                int currentRowColumnZeroZero = 0;

                //For every alpha value processed the y value for each point must be increased by 10. 
                //For the first row yJump is 0 but at the end of each iteration of the loop it is incremented by
                //10 the height of the triangle. 
                int yJump = 0;

                //Loop  all of the alpha values or rows requried for the data structure . 
                for (int i = 0; i < alpha.Length; i++)
                {
                //tris.Add -- Adding a new triangle to the data structure  
                //tris.Add(Triangle.AddB -- a pattern  can be seen where points can be added the pattern is called B,A,C see diagram on Github. 
                //tris.Add(Triangle.AddBtris[0 + currentRowColumnZeroZero] -- since were building on the triangle before us find the index + the currentRow 00 and add 0 - 10
                //tris.Add(Triangle.AddBtris[0 + currentRowColumnZeroZero], 10, 10 + yJump -- see the pattern for B,C,A where a x and y pattern is found as well, see diagram  on Github. 
                //tris.Add(Triangle.AddBtris[0 + currentRowColumnZeroZero], 10, 10 + yJump, alpha[i] + "2"))  -- Add the alpha value and the triangle number. 

                tris.Add(tris[0 + currentRowColumnZeroZero].AddB(10, 10 + yJump, alpha[i] + "2"));
                
                tris.Add(tris[1 + currentRowColumnZeroZero].AddA(20, 0 + yJump, alpha[i] + "3"));
                tris.Add(tris[2 + currentRowColumnZeroZero].AddC(10, 10 + yJump, alpha[i] + "4"));
                tris.Add(tris[3 + currentRowColumnZeroZero].AddB(20, 0 + yJump, alpha[i] + "5"));
                tris.Add(tris[4 + currentRowColumnZeroZero].AddA(10, 10 + yJump, alpha[i] + "6"));
                tris.Add(tris[5 + currentRowColumnZeroZero].AddC(20, 0 + yJump, alpha[i] + "7"));
                tris.Add(tris[6 + currentRowColumnZeroZero].AddB(10, 10 + yJump, alpha[i] + "8"));
                tris.Add(tris[7 + currentRowColumnZeroZero].AddA(20, 0 + yJump, alpha[i] + "9"));
                tris.Add(tris[8 + currentRowColumnZeroZero].AddC(10, 10 + yJump, alpha[i] + "10"));
                tris.Add(tris[9 + currentRowColumnZeroZero].AddB(20, 0 + yJump, alpha[i] + "11"));
                tris.Add(tris[10 + currentRowColumnZeroZero].AddA(10, 10 + yJump, alpha[i] + "12"));

                    //So we don't want to get an index out of bounds so make sure the next iteration of the loop will find a value. 
                    if (i + 1 < alpha.Length)
                    {
                        //Set the currentRowColumnZeroZero to the current value plus 12 
                        currentRowColumnZeroZero = currentRowColumnZeroZero + 12;

                        //Add to the yJump
                        yJump = yJump + 10;

                        //Using the base of the previous row create a new triangle base for the next row. 
                        int baseIndex = (int)tris.LongCount() - 12;

                        Triangle newBase = new Triangle(tris[baseIndex].aX, tris[baseIndex].aY + 10, tris[baseIndex].bX, tris[baseIndex].bY + 10, tris[baseIndex].cX, tris[baseIndex].cY + 10, alpha[i + 1] + "1");
                        tris.Add(newBase);

                        //Ready to process again :) 
                    }

                }

                return tris;

            }



            /// <summary>
            /// API Get used to query the data structure  for a triangle's  names and return the coordinates. 
            /// </summary>
            public string Get([FromUri] string name)
            {
                //Initialize response with negative response. 
                string coordinates = "Sorry... No triangles found";

                //Create local variable with data structure.
                List<Triangle> triangles = BuiltGrid();

                //Loop  all the triangles and find coordinates of the matching name
                foreach (var triangle in triangles)
                {
                    //See if the names match
                    if (triangle.Name.Equals(name))
                    {
                        //if they do return the coordinates, overwriting the negative response. 
                        coordinates = "{v2X:" + triangle.aX +
                                       ",v2Y:" + triangle.aY + "}" +
                                       "{v3X:" + triangle.bX +
                                       ",v3Y:" + triangle.bY + "}" +
                                       "{v1X:" + triangle.cX +
                                       ",v1Y:" + triangle.cY + "}";
                        break;
                    }
                }

                return coordinates;
            }


            /// <summary>
            /// API Get used to query the data structure  for a triangles XY and return the name
            /// </summary>
            public string Get([FromUri] string v2X, string v2Y, string v3X, string v3Y, string v1X, string v1Y)
            {
                //Initialize response with negative response. 
                string triangleName = "Sorry... No triangles found";

                //Create a triangle with the values provided and name it QUERY
                Triangle queryTriangle = new Triangle(v2X, v2Y, v3X, v3Y, v1X, v1Y, "QUERY");

                //Create local variable with data structure.
                List<Triangle> triangles = BuiltGrid();


                //Loop threw all the triangles and find coordinates of the matching xy
                foreach (var triangle in triangles)
                {
                    //Since we cannot assume that the A, B and C or the Name properties will match
                    //a X and Y comparison only is requried. 
                    if (triangle.TrianglesMatch(queryTriangle))
                    {
                        //If the triangles match return the name. 
                        triangleName = triangle.Name;
                        break;
                    }
                }

                return triangleName;
            }

        
    }
}