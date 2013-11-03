using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Animal:ISound
    {
        private int age;
        private string name;
        private string sex;

        public int Age { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }

        public Animal(int age, string name, string sex)
        {
            this.age = age;
            this.name = name;
            this.sex = sex;
        }
   
        public virtual void MakeSound()
        {
            Console.WriteLine("Animal says: grrrr");
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("{0} is {1} years old {2}       ",
                this.name.ToString(), this.age.ToString(), this.sex.ToString());
            return output.ToString();
        }

        public static void GetAverageAge(List<Animal> list)
        {
            int cats = 0;
            int dogs = 0;
            int frogs = 0;
            int kittens = 0;
            int toms = 0;
            double catsAge = 0;
            double dogsAge = 0;
            double frogsAge = 0;
            double kittensAge = 0;
            double tomcatsAge = 0;
            foreach (var item in list)
            {
                if (item.GetType().Name == "Cat")
                {
                    cats++; catsAge += item.age;
                }
                if (item.GetType().Name == "Dog")
                {
                    dogs++; dogsAge += item.age;
                }
                if (item.GetType().Name == "Frog")
                {
                    frogs++; frogsAge += item.age;
                }
                if (item.GetType().Name == "Kitten")
                {
                    kittens++;kittensAge += item.age;
                }
                if (item.GetType().Name == "Tomcat")
                {
                    toms++;tomcatsAge += item.age;
                }
            }

            StringBuilder output = new StringBuilder();
            output.AppendLine  ("\n\nAnimals | average Age\n");
            output.AppendFormat("Cats    |  {0}\n",catsAge / cats);
            output.AppendFormat("Dogs    |  {0}\n", dogsAge / dogs);
            output.AppendFormat("Frogs   |  {0}\n", frogsAge / frogs);
            output.AppendFormat("Kittens |  {0}\n", kittensAge / kittens);
            output.AppendFormat("Tomcats |  {0}\n", tomcatsAge / toms);

            Console.WriteLine(output);
        }
      
      
    }
}
