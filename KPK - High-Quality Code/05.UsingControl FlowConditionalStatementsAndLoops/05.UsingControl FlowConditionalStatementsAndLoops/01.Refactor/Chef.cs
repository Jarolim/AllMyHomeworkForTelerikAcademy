/*Code to refactor*/

//      public void Cook() 
//      public class Chef
//      {
//          private Bowl GetBowl()
//          {   
//              //... 
//          }
//          private Carrot GetCarrot()
//          {
//              //...
//          }
//          private void Cut(Vegetable potato)
//          {
//              //...
//          }  
//          public void Cook()
//          {
//              Potato potato = GetPotato();
//              Carrot carrot = GetCarrot();
//              Bowl bowl;
//              Peel(potato);
//                      
//              Peel(carrot);
//              bowl = GetBowl();
//              Cut(potato);
//              Cut(carrot);
//              bowl.Add(carrot);
//                      
//              bowl.Add(potato);
//          }
//          private Potato GetPotato()
//          {
//              //...
//          }
//      }

using System;

public class Chef
{
    public void Cook()
    {
        Bowl bowl = GetBowl();

        Potato potato = GetPotato();
        Cut(potato);
        Peel(potato);
        bowl.Add(potato);

        Carrot carrot = GetCarrot();
        Cut(carrot);
        Peel(carrot);
        bowl.Add(carrot);
    }

    private Bowl GetBowl()
    {
        return new Bowl();
    }

    private Carrot GetCarrot()
    {
        return new Carrot();
    }

    private Potato GetPotato()
    {
        return new Potato();
    }

    private void Cut(Vegetable vegetable)
    {
        //...
    }
}