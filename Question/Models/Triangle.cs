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
      /// This class can spawn a new triangle by moving the a, b or c vertex of the current triangle, and verify if another triangle matches this one.
      /// </remarks>
    public class Triangle
    {
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