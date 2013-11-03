/*Code to refactor*/

//      public class Size
//      {
//        public double wIdTh, Viso4ina;
//        public Size(double w, double h)
//        {
//          this.wIdTh = w;
//          this.Viso4ina = h;
//        }
//      }
//      
//      public static Size GetRotatedSize(
//        Size s, double angleOfTheFigureThatWillBeRotaed)
//      {
//        return new Size(
//          Math.Abs(Math.Cos(angleOfTheFigureThatWillBeRotaed)) * s.wIdTh + 
//            Math.Abs(Math.Sin(angleOfTheFigureThatWillBeRotaed)) * s.Viso4ina,
//          Math.Abs(Math.Sin(angleOfTheFigureThatWillBeRotaed)) * s.wIdTh + 
//            Math.Abs(Math.Cos(angleOfTheFigureThatWillBeRotaed)) * s.Viso4ina);
//      }

using System;

public class Figure
{
    //Fields:
    private double width;
    private double height;

    //Constructor:
    public Figure(double Width, double Heigth)
    {
        this.width = Width;
        this.height = Heigth;
    }

    //Properites:
    public double Width
    {
        get
        {
            return this.width;
        }

        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Width must be a positive number!");
            }

            this.width = value;
        }
    }

    public double Height
    {
        get
        {
            return this.height;
        }

        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Height must be a positive number!");
            }

            this.height = value;
        }
    }

    //Methods:
    public static Figure GetRotatedFigure(Figure size, double angle)
    {
        double cosWidth = Math.Abs(Math.Cos(angle)) * size.Width;
        double sinHeight = Math.Abs(Math.Sin(angle)) * size.Height;
        double sinWidth = Math.Abs(Math.Sin(angle)) * size.Width;
        double cosHeight = Math.Abs(Math.Cos(angle)) * size.Height;

        double newWidth = cosWidth + sinHeight;
        double newHeight = sinWidth + cosHeight;

        return new Figure(newWidth, newHeight);
    }
}

