using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Question.Models
{
    public class Triangles
    {

        public string FindCoordinatesForNameTURBO(string name)
        {
            //Initialize response with negative response. 
            string coordinates = "Sorry... No triangles found";
            string[] alpha = new string[] { "F", "E", "D", "C", "B", "A" };

            string alphaValue = name.Substring(0,1);
            int numberValue = Int32.Parse(name.Substring(1,(name.Length - 1)));

            int minY = 0;

            for (int i = 0; i <= alpha.Length ; i++)
            {
                if (alpha[i].StartsWith(alphaValue)) {
                    minY = 10 * i;
                    break;
                }
            }

            int x = 0;
            int y = 0;

            if (numberValue % 2 == 0)
            {
                y = minY + 10;
                x = (numberValue / 2) * 10; 
            }
            else{
                y = minY;
                x = ((numberValue - 1)/2) * 10 ;
            }


            coordinates = x + " " + y;




            return coordinates;
        }
        /// <summary>
        /// Function to 
        /// </summary>
        public string FindCoordinatesForName(string name) {
            //Initialize response with negative response. 
            string coordinates = "Sorry... No triangles found";

            //Create local variable with data structure.
            List<Triangle> triangles = BuildGrid();

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

        public string FindNameForCoordinates(string v2X, string v2Y, string v3X, string v3Y, string v1X, string v1Y)
        {
            //Initialize response with negative response. 
            string triangleName = "Sorry... No triangles found";

            //Create a triangle with the values provided and name it QUERY
            Triangle queryTriangle = new Triangle(v2X, v2Y, v3X, v3Y, v1X, v1Y, "QUERY");

            //Create local variable with data structure.
            List<Triangle> triangles = BuildGrid();


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


        public List<Triangle> BuildGrid()
        {

            //Create a list of Triangles that is empty. 
            List<Triangle> tris = new List<Triangle> { };

            //The alpha area is used to name each row. If you wanted to enlarge or shrink the number of row available this could be 
            //done so here without adjusting any of the other code. 
            string[] alpha = new string[] { "F", "E", "D", "C", "B", "A" };

            Triangle baseTriangle = new Triangle(0, 10, 0, 0, 10, 0, "Base");

            //For every alpha value processed the y value for each point must be increased by 10. 
            //For the first row yJump is 0 but at the end of each iteration of the loop it is incremented by
            //10 the height of the triangle. 
            int yJump = 0;

            int currentRowIndex = 0;

            //Loop  all of the alpha values or rows requried for the data structure . 
            for (int i = 0; i < alpha.Length; i++)
            {

              
                if (tris.Count() < 1)
                {
                    baseTriangle.Name = alpha[i] + "1";
                    tris.Add(baseTriangle);
                }
                else {
                    
                    Triangle nextBaseTriangle = new Triangle(0, baseTriangle.aY + 10, 0, baseTriangle.bY + 10, 10, baseTriangle.cY + 10, alpha[i] + "1");
                    tris.Add(nextBaseTriangle);
                    //Add to the yJump
                    yJump = yJump + 10;
                    currentRowIndex = (yJump / 10) * 12; 
                }

                //tris.Add -- Adding a new triangle to the data structure  
                //tris.Add(tris[0 + currentRowIndex].MoveB -- spawn a new triangle using the one before it but move one vertex
                //tris.Add(tris[0 + currentRowIndex].MoveB(10, 10 + yJump, -- see the pattern for B,C,A where a x and y pattern is found as well, see diagram  on Github. 
                //tris.Add(tris[0 + currentRowIndex].MoveB(10, 10 + yJump, alpha[i] + "2"))  -- Add the alpha value and the triangle number. 

                tris.Add(tris[0 + currentRowIndex].MoveB(10, 10 + yJump, alpha[i] + "2"));
                tris.Add(tris[1 + currentRowIndex].MoveA(20, 0 + yJump, alpha[i] + "3"));
                tris.Add(tris[2 + currentRowIndex].MoveC(10, 10 + yJump, alpha[i] + "4"));
                tris.Add(tris[3 + currentRowIndex].MoveB(20, 0 + yJump, alpha[i] + "5"));
                tris.Add(tris[4 + currentRowIndex].MoveA(10, 10 + yJump, alpha[i] + "6"));
                tris.Add(tris[5 + currentRowIndex].MoveC(20, 0 + yJump, alpha[i] + "7"));
                tris.Add(tris[6 + currentRowIndex].MoveB(10, 10 + yJump, alpha[i] + "8"));
                tris.Add(tris[7 + currentRowIndex].MoveA(20, 0 + yJump, alpha[i] + "9"));
                tris.Add(tris[8 + currentRowIndex].MoveC(10, 10 + yJump, alpha[i] + "10"));
                tris.Add(tris[9 + currentRowIndex].MoveB(20, 0 + yJump, alpha[i] + "11"));
                tris.Add(tris[10 + currentRowIndex].MoveA(10, 10 + yJump, alpha[i] + "12"));

            }

            return tris;

        }

        
    }
}