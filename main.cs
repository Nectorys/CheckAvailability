using System;
using System.Linq;
using System.Collections.Generic;
using System.Text; 
using System.Text.RegularExpressions;
using System.Globalization;

/*need figure out how I can refer array from Main to CheckAvailability function like List-type. Every time I have CS1525. Bad*( 
  When I use List for input dates - all's good*/
class Program 
{
    public static string CheckAvailability(List<string> schedule, string currentTime)
    {
      string x = "";  
      string[] stringDate;
      
      DateTime currentDate = DateTime.ParseExact(currentTime, "HH:mm",  System.Globalization.CultureInfo.InvariantCulture);
    
      string shablonTime = @"\-";

      foreach(string i in schedule)

        {
          List<DateTime> textTime = new List<DateTime>{};  

          stringDate = Regex.Split(i, shablonTime);  
            
          foreach (string value in stringDate)  
          {  
            DateTime myDate = DateTime.ParseExact(value, "HH:mm",  System.Globalization.CultureInfo.InvariantCulture);
            textTime.Add(myDate);  
          } 
          
          int resultBefore = DateTime.Compare(textTime[0], currentDate);//должно быть меньше 0
          int resultAfter = DateTime.Compare(currentDate, textTime[1]);//должно быть больше 0

              if( resultBefore<0 && resultAfter<0 || textTime[0]==currentDate)
              {
                x = textTime[1].ToString("t", CultureInfo.CreateSpecificCulture("es-ES"));
                break;
              } 
              else
              { 
                x = "available";
              }
        }
      return x;
    }  
    


    static void Main(string[] args) 
    {
      
      CheckAvailability(["09:30-10:15", "12:20-15:50"], "11:00");
      Console.WriteLine(x);
      CheckAvailability(["09:30-10:15", "12:20-15:50"], "10:00");
      Console.WriteLine(x);
      
      /*List<string> time = new List<string>(){"09:30-10:15", "12:20-15:50"};
      CheckAvailability(time, "09:30");*/
    }
}