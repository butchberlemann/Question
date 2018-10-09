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
      /// This class can make a triangle using, add a, b or c vertex, compare triangles and identify if a given x and y match a xy on a triangle. 
      /// </remarks>
    public class Triangle
    {
        /// <summary>
        /// The name of the triangle.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The X corner of the A point of the triangle
        /// </summary>
        public int aX { get; set; }
        /// <summary>
        /// The Y corner of the A point of the triangle
        /// </summary>
        public int aY { get; set; }
        /// <summary>
        /// The X corner of the B point of the triangle
        /// </summary>
        public int bX { get; set; }
        /// <summary>
        /// The Y corner of the B point of the triangle
        /// </summary>
        public int bY { get; set; }
        /// <summary>
        /// The X corner of the C point of the triangle
        /// </summary>
        public int cX { get; set; }
        /// <summary>
        /// The Y corner of the C point of the triangle
        /// </summary>
        public int cY { get; set; }

        /// <summary>
        /// Static function used to make a triangle object using integer  values for the x and y values for each side. 
        /// </summary>
        public static Triangle MakeTriangle(int aX, int aY, int bX, int bY, int cX, int cY, string name)
        {
            return new Triangle
            {
                Name = name,
                aX = aX,
                aY = aY,
                bX = bX,
                bY = bY,
                cX = cX,
                cY = cY
            };

        }

        /// <summary>
        /// Static function used to make a triangle object using sting values for the x and y values for each side.  
        /// </summary>
        public static Triangle MakeTriangle(string aX, string aY, string bX, string bY, string cX, string cY, string name)
        {

            return Triangle.MakeTriangle(System.Convert.ToInt32(aX),
                                System.Convert.ToInt32(aY),
                                System.Convert.ToInt32(bX),
                                System.Convert.ToInt32(bY),
                                System.Convert.ToInt32(cX),
                                System.Convert.ToInt32(cY),
                                name);


        }
        /// <summary>
        /// Static function used to make a triangle where the A point is moved and the x value of the new triangle is 
        /// appended to the x of the provided triangle. The y value is provided to the new object without being altered. 
        /// </summary>
        public static Triangle AddA(Triangle tri, int x, int y, string name)
        {
            return new Triangle
            {
                Name = name,
                aX = tri.aX + x,
                aY = y,
                bX = tri.bX,
                bY = tri.bY,
                cX = tri.cX,
                cY = tri.cY
            };

        }
        /// <summary>
        /// Static function used to make a triangle where the B point is moved and the x value of the new triangle is 
        /// appended  to the x of the provided triangle. The y value is provided to the new object without being altered. 
        /// </summary>
        public static Triangle AddB(Triangle tri, int x, int y, string name)
        {

            return new Triangle
            {
                Name = name,
                aX = tri.aX,
                aY = tri.aY,
                bX = tri.bX + x,
                bY = y,
                cX = tri.cX,
                cY = tri.cY
            };
        }

        /// <summary>
        /// Static function used to make a triangle where the C point is moved and the x value of the new triangle is 
        /// appended  to the x of the provided triangle. The y value is provided to the new object without being altered. 
        /// </summary>
        public static Triangle AddC(Triangle tri, int x, int y, string name)
        {

            return new Triangle
            {
                Name = name,
                aX = tri.aX,
                aY = tri.aY,
                bX = tri.bX,
                bY = tri.bY,
                cX = tri.cX + x,
                cY = y
            };

        }

        /// <summary>
        /// Static function used to compare two triangles to each other. The comparisons is based only on the 
        /// x and y values for a given point. If the A point x and y match the B point of the second triangles 
        /// x and y and so on for B to C and C to B then the two triangles are said to match. 
        /// </summary>
        public static bool TrianglesMatch(Triangle tri, Triangle tri2)
        {
            bool match = false;
            //See if the A point of the second triangle mataches any of the points on the other triangle
            if (MatchesASide(tri, tri2.aX, tri2.aY))
            {
                //If A matched a point see if the b matches as well. 
                if (MatchesASide(tri, tri2.bX, tri2.bY))
                {
                    //Finally see if the c matches as well. 
                    if (MatchesASide(tri, tri2.cX, tri2.cY))
                    {
                        match = true;
                    }
                }
            }
            return match;
        }

        /// <summary>
        /// Static function used to identify if a given x and y match any point on the provided triangle.  
        /// </summary>
        public static bool MatchesASide(Triangle tri, int x, int y)
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