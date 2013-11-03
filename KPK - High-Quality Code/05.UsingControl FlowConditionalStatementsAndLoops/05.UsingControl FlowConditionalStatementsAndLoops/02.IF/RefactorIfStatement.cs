/*Code to refactor*/

//      Potato potato;
//      //... 
//      if (potato != null)
//         if(!potato.HasNotBeenPeeled && !potato.IsRotten)
//      	Cook(potato);


//      if (x >= MIN_X && (x =< MAX_X && ((MAX_Y >= y && MIN_Y <= y) && !shouldNotVisitCell)))
//      {
//         VisitCell();
//      }

using System;

public class RefactorIfStatement
{
    public static void Main()
    {
        //First if statement to refactor
        Potato potato = new Potato();
        if (potato != null)
        {
            if (potato.isPeeled && potato.isNotRotten)
            {
                Cook(potato);
            }
        }

        //Second if statement to refactor
        if ((x >= minX && x <= maxX) && (y >= minY && y <= maxY) && isNotVisitedCell)
        {
            VisitCell();
        }
    }
}