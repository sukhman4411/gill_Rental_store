using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gill_Rental_store
{
    public class cost
    {
        //this method is used to calculate the cost of the video at the register time of return time 
        public int calcualteCost(int Year) {
            int totalcost = 0;

            DateTime dateNow = DateTime.Now;

            // get the year 
            int Currentyear = dateNow.Year;

            //get the difference between year 
            int diffYear = Currentyear - Convert.ToInt32(Year);

            //get the difference if the difference is greater then 5 then the cost is 2 dollar otherwise 5 dollar 
            if (diffYear >= 5)
            {
                totalcost = 2;
            }
            if (diffYear >= 0 && diffYear < 5)
            {
                totalcost = 5;
            }


            return totalcost;
        }

        //this method is used to calculate the charges of the cost 
        public int calcualteCharges(String oldDate,int year)
        {
            int Videocost=calcualteCost(year);



            DateTime new_date = DateTime.Now;

            //convert the old date from string to Date fromat
            DateTime prev_date = Convert.ToDateTime(oldDate);


            //get the difference in the days fromat
            String Daysdiff = (new_date - prev_date).TotalDays.ToString();


            // calculate the round off value 
            Double DaysInterval = Math.Round(Convert.ToDouble(Daysdiff));



            int videocharges = Convert.ToInt32(DaysInterval) * Videocost;


            return videocharges;
        }
    }
}
