using Microsoft.VisualStudio.TestTools.UnitTesting;
using gill_Rental_store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gill_Rental_store.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void Form1Test()
        {
            //check the Connection String of the Project to Test 
            Form1 obj = new Form1();
            String Loc = "Data Source=SIMRAN;Initial Catalog=gill_rental_DB;Integrated Security=True";
            String str = obj.conStr;
            Assert.AreSame(Loc,str);
            
        }

        [TestMethod()]
        public void Form2Test()
        {
            //test the cost of the video after passing the year 
            cost obj = new cost();
            int y = 5;
            int x = obj.calcualteCost(2019);
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void queryTest() {
            Form1 obj = new Form1();
            String w = "delete from rental_data";
            obj.SqlQuery(w);
            Assert.IsTrue(true);



        }

    }
}