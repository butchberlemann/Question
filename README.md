# Coding Question
This project was created to satisfy a requirement for a job application at a software company as a software engineer. The exact requirements can be found [here](https://github.com/butchberlemann/Question/Supporting/CodingQuestion_2018 (1).pdf). 

I developed two approaches to solving this problem one that creates the desired result on the fly (look for TURBO in the code) and a second that uses an in-memory data structure. The diagrams I created below are intended to help explain how the data structure is constructed. 
  
## Data Structure Diagrams
The following three diagrams are referenced in the code and included to help explain how the data structure used in the API is constructed. In the *Triangle vertex first row* diagram we can see the first row of the grid and the triangles used. *BCA Pattern* expands on *Triangle vertex first row* by including the coordinates of the vertex that must be moved to complete the given triangle. Vertex’s that do not move are marked with double double quotes "","". In *BCA Pattern* starting at F2 for B, F3 for A and F4 for C another pattern emerges that *AXY Pattern* is visualizing. *AXY Pattern* visualizes a pattern where X and Y are increased by 10 then the vertex does not move for two triangles but on the third the X increases by 20 and the Y remains at the base value for Y in the current row. In the case for the F row Y returns to 0 and for the E row Y is 10 etc..

![alt text](https://github.com/butchberlemann/Question/blob/master/Supporting/CodingQuestion.jpg)
