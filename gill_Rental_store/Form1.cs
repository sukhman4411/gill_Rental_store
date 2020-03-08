using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gill_Rental_store
{
    public partial class Form1 : Form
    {

        //Conn Instance Object of SQl Connection Class
        SqlConnection sqlCon;

        //String ConnectionString for Making the Connection between the Class and Database
       public String conStr = "Data Source=SIMRAN;Initial Catalog=gill_rental_DB;Integrated Security=True";
        //Cmd Instance Object to Create the Relation between  the Commad to execute the sql Command 
        SqlCommand sqlcmd;
        // DReader is instance to read the data from the database and pass to the Class
        SqlDataReader DReader;

        int RentID = 0,btn=0,copies=0,year=0;

        //this method is used to execute the sql query like insert delete update in the database tables
        public void SqlQuery(String query)
        {
            sqlCon = new SqlConnection(conStr);
            sqlCon.Open();
            sqlcmd = new SqlCommand(query, sqlCon);
            sqlcmd.ExecuteNonQuery();
            sqlCon.Close();
        }


        // this method is used to search the record from the data base and then pass the whole record to the query using where clause of the sql
        public DataTable srchRecord(String qry)
        {
            DataTable tbl = new DataTable();


            sqlCon = new SqlConnection(conStr);

            sqlCon.Open();
            sqlcmd = new SqlCommand(qry, sqlCon);

            DReader = sqlcmd.ExecuteReader();

            tbl.Load(DReader);

            sqlCon.Close();

            return tbl;
        }







        public Form1()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (CustomerName.Text.ToString().Equals("") && CustomerEmail.Text.ToString().Equals("") && CustomerMobile.Text.ToString().Equals("") && CustomerAddress.Text.ToString().Equals(""))
            {
                MessageBox.Show("Fill all the Details First ");
            }
            else {

                SqlQuery("insert into customer_data(name,email,mobile,address) values ('"+CustomerName.Text.ToString()+"','"+CustomerEmail.Text+"','"+CustomerMobile.Text+"','"+CustomerAddress.Text+"')");
                MessageBox.Show("Record Saved ");
                CustomerAddress.Text = "";
                CustomerName.Text = "";
                CustomerEmail.Text = "";
                CustomerMobile.Text = "";
            }
        }

        private void CustomerDelete_Click(object sender, EventArgs e)
        {
            if (CustomerID.Text.ToString().Equals(""))
            {
                MessageBox.Show("Select the Customer First ");
            }
            else {

                DataTable tbl = new DataTable();
                tbl = srchRecord("select * from rental_data where csm_id='" + CustomerID.Text + "' and return_date='booked'");
                //check weather the customer has an video on rent or not 
                if (tbl.Rows.Count > 0)
                {
                    //if he has a video on rent 
                    MessageBox.Show("you already have an video on rent ");
                }
                else
                {                                                                                          
                    //if the cusotmer didnot have an video on rent 
                    SqlQuery("delete from customer_data where id=" + Convert.ToInt32(CustomerID.Text.ToString()) + "");

                    MessageBox.Show("Customer record is deleted");
                }
                //reset the boxes 
                CustomerAddress.Text = "";
                CustomerName.Text = "";
                CustomerEmail.Text = "";
                CustomerMobile.Text = "";
                CustomerID.Text = "";

            }
        }

        private void CustomerUpdate_Click(object sender, EventArgs e)
        {
            if (CustomerID.Text.ToString().Equals(""))
            {
                MessageBox.Show("Select the Customer First ");
            }
            else
            {
                SqlQuery("update customer_data set name='"+CustomerName.Text+"',email='"+CustomerEmail.Text+"',mobile='"+CustomerMobile.Text+"',address='"+CustomerAddress.Text+"' where id="+Convert.ToInt32(CustomerID.Text.ToString())+"" );
                MessageBox.Show("Record is updated ");
                CustomerAddress.Text = "";
                CustomerName.Text = "";
                CustomerEmail.Text = "";
                CustomerMobile.Text = "";
                CustomerID.Text = "";

            }
         }

        private void VideoAdd_Click(object sender, EventArgs e)
        {
            if (VideoName.Text.ToString().Equals("") && VideoPoints.Text.ToString().Equals("") && VideoYear.Text.ToString().Equals("") && VideoCopies.Text.ToString().Equals("") && VideoGenre.Text.ToString().Equals("")) {
                MessageBox.Show("Fill all the details of the video ");
            }
            else {

                SqlQuery("insert into video_data(name,points,year,copies,genre) values('"+VideoName.Text+"','"+VideoPoints.Text+"','"+VideoYear.Text+"','"+VideoCopies.Text+"','"+VideoGenre.Text+"')");
                MessageBox.Show("record is added ");
                VideoName.Text = "";
                VideoPoints.Text = "";
                VideoYear.Text = "";
                VideoCopies.Text = "";
                VideoGenre.Text = "";


            }


        }

        private void VideoDelete_Click(object sender, EventArgs e)
        {

            if (VideoID.Text.ToString().Equals(""))
            {
                MessageBox.Show("Select the video id ");
            }
            else {
                DataTable tbl = new DataTable();
                tbl = srchRecord("select * from rental_data where mov_id='" + VideoID.Text + "' and return_date='booked'");
                //check weather the customer has an video on rent or not 
                if (tbl.Rows.Count > 0)
                {
                    //message displaying the record that video is on rent 
                    MessageBox.Show("this video is alrady issued on rent ");
                }
                else
                {
                    //the below given query is deleting video from database according to the ID


                    SqlQuery("delete from video_data where id=" + Convert.ToInt32(VideoID.Text.ToString()) + "");
                    MessageBox.Show("Video record is delete ");
                }
                VideoName.Text = "";
                VideoPoints.Text = "";
                VideoYear.Text = "";
                VideoCopies.Text = "";
                VideoGenre.Text = "";
                VideoID.Text = "";

            }
        }
        //for updating the video record from the table of viedo data
        private void VideoUpdate_Click(object sender, EventArgs e)
        {
            if (VideoID.Text.ToString().Equals(""))
            {
                MessageBox.Show("Select the video id ");
            }
            else
            {
                SqlQuery("update video_data set name='"+VideoName.Text+"',points='"+VideoPoints.Text+"',year='"+VideoYear.Text+"',copies='"+VideoCopies.Text+"',genre='"+VideoGenre.Text+"' where id="+VideoID.Text.ToString()+"");
                MessageBox.Show("Video is Updated ");
                VideoName.Text = "";
                VideoPoints.Text = "";
                VideoYear.Text = "";
                VideoCopies.Text = "";
                VideoGenre.Text = "";
                VideoID.Text = "";



            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        //below code is issue button 
        private void Issue_Click(object sender, EventArgs e)
        {
            if (CustomerID.Text.ToString().Equals("") && VideoID.Text.ToString().Equals(""))
            {
                MessageBox.Show("Select Cusotomer and Video to get it on rent ");
            }
            else {
       //selecting the  data from  renttal table according to customer id
                DataTable tbl = new DataTable();
                tbl = srchRecord("select * from rental_data where csm_id="+CustomerID.Text+" and return_date='booked'");
                int count =tbl.Rows.Count;

                tbl = new DataTable();
                tbl = srchRecord("select * from rental_data where mov_id=" + VideoID.Text + " and return_date='booked'");
                // message acording to the conditions
                if (count > 2)
                {
                    MessageBox.Show("Customer already have enough video on rent ");
                }
                else if (copies == tbl.Rows.Count)
                {
                    MessageBox.Show("all the video are alrady on rent ");

                }
                else 
                { 
                    SqlQuery("insert into rental_data(mov_id,csm_id,issue_date,return_date) values('" + VideoID.Text + "','" + CustomerID.Text + "','" + VideoIssue.Text + "','booked')");
                    MessageBox.Show("Video is issued ON rent ");
                }
                VideoName.Text = "";
                VideoPoints.Text = "";
                VideoYear.Text = "";
                VideoCopies.Text = "";
                VideoGenre.Text = "";
                VideoID.Text = "";
                CustomerAddress.Text = "";
                CustomerName.Text = "";
                CustomerEmail.Text = "";
                CustomerMobile.Text = "";
                CustomerID.Text = "";






            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
        // for deleting the movie from the database
        private void MovieDelete_Click(object sender, EventArgs e)
        {
            if (RentID == 0)
            {
                MessageBox.Show("Select the Video to Delete ");

            }
            else {
                SqlQuery("delete from rental_data where id="+RentID+"");

                MessageBox.Show("Selected Rental video is deleted ");
                VideoName.Text = "";
                VideoPoints.Text = "";
                VideoYear.Text = "";
                VideoCopies.Text = "";
                VideoGenre.Text = "";
                VideoID.Text = "";
                CustomerAddress.Text = "";
                CustomerName.Text = "";
                CustomerEmail.Text = "";
                CustomerMobile.Text = "";
                CustomerID.Text = "";

            }
        }

        private void MovieReturn_Click(object sender, EventArgs e)
        {
            if (RentID == 0)
            {
                MessageBox.Show("select the rental video  to return");
            }
            else {

                DataTable tbl = new DataTable();
                //get the year  of the video so thus we can genreate the charges 
                tbl = srchRecord("select * from video_data where id=" + Convert.ToInt32(VideoID.Text.ToString()) + "");
                year = Convert.ToInt32(tbl.Rows[tbl.Rows.Count-1]["year"].ToString());

                cost obj = new cost();




                SqlQuery("update rental_data set mov_id='" + VideoID.Text + "',csm_id='"+CustomerID.Text+"',issue_date='"+VideoIssue.Text+"',return_date='"+VideoReturn.Text+"' where id="+RentID+"");

                int totalcharges=obj.calcualteCharges(VideoIssue.Text.ToString(), year);


                MessageBox.Show("Video is reutrn and total charges is $"+totalcharges );

            
                VideoName.Text = "";
                VideoPoints.Text = "";
                VideoYear.Text = "";
                VideoCopies.Text = "";
                VideoGenre.Text = "";
                VideoID.Text = "";
                CustomerAddress.Text = "";
                CustomerName.Text = "";
                CustomerEmail.Text = "";
                CustomerMobile.Text = "";
                CustomerID.Text = "";


            }


        }

       
       

      // for displaying best customers

        private void btnBestCustomer_Click(object sender, EventArgs e)
        {
            DataTable tblData = new DataTable();
            tblData = srchRecord("select * from customer_data");
            int x = 0, y = 0, cunt = 0;
            String Title = "";
            for (x = 0; x < tblData.Rows.Count; x++)
            {
                DataTable tblData1 = new DataTable();
                tblData1 = srchRecord("select * from rental_data where csm_id='" + tblData.Rows[x]["id"].ToString() + "'");

                if (tblData1.Rows.Count > cunt)
                {
                    Title = tblData.Rows[x]["name"].ToString();
                    cunt = tblData1.Rows.Count;
                }

            }
            MessageBox.Show("Best Customer Name is =" + Title);
        }

        private void btnCustomerData_Click(object sender, EventArgs e)
        {
            //get the data from the data base 
            DataTable tbl = new DataTable();
            tbl = srchRecord("select * from customer_data");
            dataGridView1.DataSource = tbl;
            btn = 1;
        }

        private void btnRentalData_Click(object sender, EventArgs e)
        {
            //get the data from the data base 
            DataTable tbl = new DataTable();
            tbl = srchRecord("select * from rental_data");
            dataGridView1.DataSource = tbl;
            btn = 3;
        }

        private void btnVideoData_Click(object sender, EventArgs e)
        {
            //get the data from the data base 
            DataTable tbl = new DataTable();
            tbl = srchRecord("select * from video_data");
            dataGridView1.DataSource = tbl;
            btn = 2;
        }
        //for displaying best video 
        private void btnBestVideo_Click(object sender, EventArgs e)
        {
            DataTable tblData = new DataTable();
            tblData = srchRecord("select * from video_data");
            int x = 0, y = 0, cunt = 0;
            String Title = "";
            for (x = 0; x < tblData.Rows.Count; x++)
            {
                DataTable tblData1 = new DataTable();
                tblData1 = srchRecord("select * from rental_data where mov_id='" + tblData.Rows[x]["id"].ToString() + "'");

                if (tblData1.Rows.Count > cunt)
                {
                    Title = tblData.Rows[x]["name"].ToString();
                    cunt = tblData1.Rows.Count;
                }

            }
            MessageBox.Show("Best Video is =" + Title);
        }

       

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (btn==1) {
                CustomerID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                CustomerName.Text= dataGridView1.CurrentRow.Cells[1].Value.ToString();
                CustomerEmail.Text= dataGridView1.CurrentRow.Cells[2].Value.ToString();
                CustomerMobile.Text= dataGridView1.CurrentRow.Cells[3].Value.ToString();
                CustomerAddress.Text= dataGridView1.CurrentRow.Cells[4].Value.ToString();
            }

            if (btn == 2) {
                VideoID.Text= dataGridView1.CurrentRow.Cells[0].Value.ToString();
                VideoName.Text= dataGridView1.CurrentRow.Cells[1].Value.ToString();
                VideoPoints.Text= dataGridView1.CurrentRow.Cells[2].Value.ToString();
                VideoYear.Text= dataGridView1.CurrentRow.Cells[3].Value.ToString();
                VideoCopies.Text= dataGridView1.CurrentRow.Cells[4].Value.ToString();
                copies = Convert.ToInt32(VideoCopies.Text);
                year = Convert.ToInt32(VideoYear.Text);
                VideoGenre.Text=dataGridView1.CurrentRow.Cells[0].Value.ToString();


            }

            if (btn==3) {

                RentID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                VideoID.Text= dataGridView1.CurrentRow.Cells[1].Value.ToString();
                CustomerID.Text= dataGridView1.CurrentRow.Cells[2].Value.ToString();
                VideoIssue.Text= dataGridView1.CurrentRow.Cells[3].Value.ToString();


            }

            btn = 0;

        }

       
    }
}
