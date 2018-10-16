using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Question.Models
{
    /// <summary>
    /// Triangle class defines the properties of a triangle and utility functions commonly needed with working with triangles
    /// </summary>
    /// /// <remarks>
    /// This class can create triangles with all string parameters, int parameters for the vertex and string for the name
    /// and create triangles with just a name or vertexes and spawn a new triangle by moving the a, b or c vertex of the current 
    /// triangle, and verify if another triangle matches this one.
    /// </remarks>
    public class Triangle
    {
        /// <summary>
        /// The name of the triangle.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// The X corner of the A point of the triangle
        /// </summary>
        public int aX { get; private set; }
        /// <summary>
        /// The Y corner of the A point of the triangle
        /// </summary>
        public int aY { get; private set; }
        /// <summary>
        /// The X corner of the B point of the triangle
        /// </summary>
        public int bX { get; private set; }
        /// <summary>
        /// The Y corner of the B point of the triangle
        /// </summary>
        public int bY { get; private set; }
        /// <summary>
        /// The X corner of the C point of the triangle
        /// </summary>
        public int cX { get; private set; }
        /// <summary>
        /// The Y corner of the C point of the triangle
        /// </summary>
        public int cY { get; private set; }


        /// <summary>
        ///  Constructors using ints
        /// </summary>
        public Triangle(int aX, int aY, int bX, int bY, int cX, int cY, string name)
        {
            Initialize(aX, aY, bX, bY, cX, cY, name);
        }

        /// <summary>
        ///  Constructors using strings
        /// </summary>
        public Triangle(string aX, string aY, string bX, string bY, string cX, string cY, string name)
        {

            Initialize(System.Convert.ToInt32(aX),
                System.Convert.ToInt32(aY),
                System.Convert.ToInt32(bX),
                System.Convert.ToInt32(bY),
                System.Convert.ToInt32(cX),
                System.Convert.ToInt32(cY),
                name);


        }

        /// <summary>
        ///  Constructor using name only
        /// </summary>
        public Triangle(string name)
        {
            //Set up array of alpha to find the row
            string[] alpha = new string[] { "F", "E", "D", "C", "B", "A" };

            //Parse the incoming values to get the alpha and numbers
            string alphaValue = name.Substring(0, 1);
            int numberValue = Int32.Parse(name.Substring(1, (name.Length - 1)));

            //Init the minY to 0 
            int minY = 0;

            //Loop the array and find the alpha's value min y value. 
            for (int i = 0; i <= alpha.Length; i++)
            {
                if (alpha[i].StartsWith(alphaValue))
                {
                    minY = 10 * i;
                    break;
                }
            }

            //variables used to define the triangle's edges 
            int x1 = 0;
            int y1 = 0;
            int x2 = 0;
            int y2 = 0;
            int x3 = 0;
            int y3 = 0;

            //Now find the shared vertex...
            //If the number value is even...
            if (numberValue % 2 == 0)
            {
                //The shared vertex for positive values are always the larger of the two y values available so add 10 to the min.
                y1 = minY + 10;
                //Divide the number provided by 2 and multiple by ten to get the correct x
                x1 = (numberValue / 2) * 10;

                //Since we now know the shared vertex subtract 10 from the y to create the next vertex and 10 from the x to create the last vertex. 
                y2 = y1 - 10;
                x2 = x1;
                y3 = y1;
                x3 = x1 - 10;
            }
            else
            {
                //If the number value is odd...
                //The shared vertex for odd values are always the smaller of the two y values available so use what was found in the loop.
                y1 = minY;
                //Subtract 1 from the number provided and divide the result by 2 finally multiple by 10 to get the correct x 
                x1 = ((numberValue - 1) / 2) * 10;

                //Since we now know the shared vertex add 10 from the y to create the next vertex and 10 to the x to create the last vertex. 
                y2 = y1 + 10;
                x2 = x1;
                y3 = y1;
                x3 = x1 + 10;
            }

            //Create a new triangle
            Initialize(x1,y1,x2,y2,x3,y3,name);


        }

    
        /// <summary>
        ///  Constructor using vertex only
        /// </summary>
        public Triangle(string aX, string aY, string bX, string bY, string cX, string cY)
        {

            //Putting the x values and y values into two arrays
            int[] xVertexs = new int[] { int.Parse(aX), int.Parse(bX), int.Parse(cX)};
            int[] yVertexs = new int[] { int.Parse(aY), int.Parse(bY), int.Parse(cY)};
            

            //Set up array of alpha to find the row
            string[] alpha = new string[] { "F", "E", "D", "C", "B", "A" };

            //variables for holding the shared x and y values 
            int sharedX = 0;
            int sharedY = 0;

            //variables for holding the outside x and y values 
            int outsideX = 0;
            int outsideY = 0;

            
            //loop the x vertexs twice to find the duplicate values and the single one
            foreach (var x in xVertexs)
            {
                int match = 0;

                foreach (var searchX in xVertexs)
                {
                    if (x == searchX)
                    {
                        match++;
                    }
                }
                if (match == 2)
                {
                    sharedX = x;
                }
                if (match == 1)
                {
                    outsideX = x;
                }

            }

            //loop the y vertexs twice to find the duplicate values and the single one
            foreach (var y in yVertexs)
            {
                int match = 0;

                foreach (var searchY in yVertexs)
                {
                    if (y == searchY)
                    {
                        match++;
                    }
                }
                if (match == 2)
                {
                    sharedY = y;
                }
                if (match == 1)
                {
                    outsideY = y;
                }

            }



            int triangleNumber = 0;
            //Larger y values are always the even numbers
            if (outsideY < sharedY)
            {
                triangleNumber = sharedX * 2 / 10;
            }
            else
            {
                triangleNumber = (sharedX * 2 / 10) + 1;
            }

            int letterIndex = 0; 
            
            //Dividing the larger y value by 10 and substracting 1 results in the correct index for the alpha array
            if (sharedY > outsideY)
            {
                letterIndex = (sharedY / 10) - 1;
            }
            else
            {
                letterIndex = (outsideY / 10) - 1;
            }

            //Concatenate the alpha and number values together
            string triangleName = alpha[letterIndex] + triangleNumber;


            //Create a new triangle
            Initialize(sharedX, sharedY, outsideX, sharedY, sharedX, outsideY, triangleName);


        }

        /// <summary>
        ///  Private function used to support two differnt constructors
        /// </summary>
        private void Initialize(int aX, int aY, int bX, int bY, int cX, int cY, string name)
        {
            this.Name = name;
            this.aX = aX;
            this.aY = aY;
            this.bX = bX;
            this.bY = bY;
            this.cX = cX;
            this.cY = cY;
        }


        /// <summary>
        /// Overloaded ToString Method used to return the triangles coordinates
        /// </summary>
        public override string ToString()

        {

            string coordinates = "{v2X:" + this.aX +
                                  ",v2Y:" + this.aY + "}" +
                                  "{v3X:" + this.bX +
                                  ",v3Y:" + this.bY + "}" +
                                  "{v1X:" + this.cX +
                                  ",v1Y:" + this.cY + "}";

            return coordinates;
        }

       
        /// <summary>
        /// Function used to spawn a new triangle moving the A point of the current triangle. The x value provided is appended 
        /// to the current triangle and the y value provided is used for the y. 
        /// </summary>
        public Triangle MoveA( int x, int y, string name)
        {
            return new Triangle(aX + x, y, bX, bY, cX,cY, name);

        }
        /// <summary>
        /// Function used to spawn a new triangle moving the B point of the current triangle. The x value provided is appended 
        /// to the current triangle and the y value provided is used for the y. 
        /// </summary>
        public Triangle MoveB( int x, int y, string name)
        {
            return new Triangle(aX,aY,bX + x,y,cX,cY, name);
        }

        /// <summary>
        /// Function used to spawn a new triangle moving the C point of the current triangle. The x value provided is appended 
        /// to the current triangle and the y value provided is used for the y. 
        /// </summary>
        public Triangle MoveC(int x, int y, string name)
        {
            return new Triangle(aX,aY,bX,bY,cX + x, y, name);
        }

        /// <summary>
        /// Function used to compare a triangle to this triangle. The comparisons is based only on the 
        /// x and y values for a given point. If the A point x and y match the B point of the second triangles 
        /// x and y and so on for B to C and C to B then the two triangles are said to match. 
        /// </summary>
        public bool TrianglesMatch(Triangle tri)
        {
            bool match = false;
            //See if the A point of the second triangle mataches any of the points on the other triangle
            if (MatchesASide(tri, this.aX, this.aY))
            {
                //If A matched a point see if the b matches as well. 
                if (MatchesASide(tri, this.bX, this.bY))
                {
                    //Finally see if the c matches as well. 
                    if (MatchesASide(tri, this.cX, this.cY))
                    {
                        match = true;
                    }
                }
            }
            return match;
        }

        /// <summary>
        /// Function used to identify if a given x and y match any point on the provided triangle.  
        /// </summary>
        private bool MatchesASide(Triangle tri, int x, int y)
        {
            bool match = false;

            //Does the x and y match the A point ? 
            if (tri.aX == x && tri.aY == y)
            {
                match = true;
            }

            //Does the x and y match the B point ? 
            if (tri.bX == x && tri.bY == y)
            {
                match = true;
            }

            //Does the x and y match the C point ? 
            if (tri.cX == x && tri.cY == y)
            {
                match = true;
            }

            return match;

        }
    }
}