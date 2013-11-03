/*Code to refactor*/

//      public void PrintStatistics(double[] arr, int count)
//      {
//          double max, tmp;
//          for (int i = 0; i < count; i++)
//          {
//              if (arr[i] > max)
//              {
//                  max = arr[i];
//              }
//          }
//          PrintMax(max);
//          tmp = 0;
//          max = 0;
//          for (int i = 0; i < count; i++)
//          {
//              if (arr[i] < max)
//              {
//                  max = arr[i];
//              }
//          }
//          PrintMin(max);
//      
//          tmp = 0;
//          for (int i = 0; i < count; i++)
//          {
//              tmp += arr[i];
//          }
//          PrintAvg(tmp/count);
//      }

using System;

public class Statistic
{
    public void PrintStatistics(double[] array, int count)
    {
        double arrayMax = 0;
        for (int i = 0; i < count; i++)
        {
            if (array[i] > arrayMax)
            {
                arrayMax = array[i];
            }
        }

        PrintMax(arrayMax);

        double arrayMin;
        for (int i = 0; i < count; i++)
        {
            if (array[i] < arrayMin)
            {
                arrayMin = array[i];
            }
        }

        PrintMin(arrayMin);

        double arraySum = 0;
        for (int i = 0; i < count; i++)
        {
            arraySum += array[i];
        }

        PrintAverage(arraySum / count);
    }
}

