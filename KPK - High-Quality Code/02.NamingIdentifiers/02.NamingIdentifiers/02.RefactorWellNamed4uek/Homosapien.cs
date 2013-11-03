/*Code to refactor*/

//      class Hauptklasse
//      {
//        enum Пол { ултра_Батка, Яка_Мацка };
//      
//        class чуек
//        {
//          public Пол пол { get; set; }
//          public string име_на_Чуека { get; set; }
//          public int Възраст { get; set; }
//        }
//            public void Make_Чуек(int магическия_НомерНаЕДИНЧОВЕК)
//        {
//          чуек new_Чуек = new чуек();
//          new_Чуек.Възраст = магическия_НомерНаЕДИНЧОВЕК;
//          if (магическия_НомерНаЕДИНЧОВЕК%2 == 0)
//          {
//            new_Чуек.име_на_Чуека = "Батката";
//            new_Чуек.пол = Пол.ултра_Батка;
//          }
//          else
//          {
//            new_Чуек.име_на_Чуека = "Мацето";
//            new_Чуек.пол = Пол.Яка_Мацка;
//          }
//        }
//      }

using System;

public class Homosapien
{
    public enum Gender
    {
        Male, Female
    }
    
    public class Human
    {
        public Gender Sex { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }
       
    public static Human CreateHuman(int age)
    {
        Human newHuman = new Human();
        newHuman.Age = age;

        if (age % 2 == 0)
        {
            newHuman.Name = "Adam";
            newHuman.Sex = Gender.Male;
        }
        else
        {
            newHuman.Name = "Eve";
            newHuman.Sex = Gender.Female;
        }

        return newHuman;
    }

    //Used only to test the Human Class
    public static void Main(string[] args)
    {
        Human man = CreateHuman(20);
        Console.WriteLine("Name: {0} , Age: {1} , Sex: {2}", man.Name, man.Age, man.Sex);

        Human woman = CreateHuman(19);
        Console.WriteLine("Name: {0} , Age: {1} , Sex: {2}", woman.Name, woman.Age, woman.Sex);
    }
}
