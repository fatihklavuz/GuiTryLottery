using System;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace SayisalTahmin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random r = new Random();
        Random rr = new Random();

        SqlConnection connection = new SqlConnection("Data Source=pcnizinadı;Initial Catalog=sayisal;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int rastgele;
            int sayac = 0;
            int[] sayilar = new int[6];
            while (sayac < 6)
            {
                rastgele = r.Next(1, 50);
                if (Array.IndexOf(sayilar, rastgele) == -1)
                {
                    sayilar[sayac] = rastgele;
                    sayac++;
                }
            }
            Array.Sort(sayilar);
            label1.Text = sayilar[0].ToString();
            label2.Text = sayilar[1].ToString();
            label3.Text = sayilar[2].ToString();
            label4.Text = sayilar[3].ToString();
            label5.Text = sayilar[4].ToString();
            label6.Text = sayilar[5].ToString();

            int on_numara;
            int counter = 0;
            int[] numbers = new int[10];

            while (counter < 10)
            {
                on_numara = rr.Next(1, 81);
                if (Array.IndexOf(numbers, on_numara) == -1)
                {
                    numbers[counter] = on_numara;
                    counter++;
                }

            }

            Array.Sort(numbers);
            label8.Text = numbers[0].ToString();
            label9.Text = numbers[1].ToString();
            label10.Text = numbers[2].ToString();
            label11.Text = numbers[3].ToString();
            label12.Text = numbers[4].ToString();
            label13.Text = numbers[5].ToString();
            label14.Text = numbers[6].ToString();
            label15.Text = numbers[7].ToString();
            label16.Text = numbers[8].ToString();
            label17.Text = numbers[9].ToString();


            connection.Open();



            SqlCommand sqlCommand = new SqlCommand("insert into tahmin (s1,s2,s3,s4,s5,s6) values (@s1,@s2,@s3,@s4,@s5,@s6)", connection);
            sqlCommand.Parameters.AddWithValue(@"s1", label1.Text);
            sqlCommand.Parameters.AddWithValue(@"s2", label2.Text);
            sqlCommand.Parameters.AddWithValue(@"s3", label3.Text);
            sqlCommand.Parameters.AddWithValue(@"s4", label4.Text);
            sqlCommand.Parameters.AddWithValue(@"s5", label5.Text);
            sqlCommand.Parameters.AddWithValue(@"s6", label6.Text);
            sqlCommand.ExecuteNonQuery();


            SqlCommand sql = new SqlCommand("select count (s1) from tahmin", connection);
            label7.Text = sql.ExecuteScalar().ToString();
            sql.ExecuteNonQuery();

            SqlCommand sqlCommand1 = new SqlCommand("insert into on_numara (s1,s2,s3,s4,s5,s6,s7,s8,s9,s10) values (@s8,@s9,@s10,@s11,@s12,@s13,@s14,@s15,@s16,@s17)", connection);
            sqlCommand1.Parameters.AddWithValue(@"s8", label8.Text);
            sqlCommand1.Parameters.AddWithValue(@"s9", label9.Text);
            sqlCommand1.Parameters.AddWithValue(@"s10", label10.Text);
            sqlCommand1.Parameters.AddWithValue(@"s11", label11.Text);
            sqlCommand1.Parameters.AddWithValue(@"s12", label12.Text);
            sqlCommand1.Parameters.AddWithValue(@"s13", label13.Text);
            sqlCommand1.Parameters.AddWithValue(@"s14", label14.Text);
            sqlCommand1.Parameters.AddWithValue(@"s15", label15.Text);
            sqlCommand1.Parameters.AddWithValue(@"s16", label16.Text);
            sqlCommand1.Parameters.AddWithValue(@"s17", label17.Text);

            sqlCommand1.ExecuteNonQuery();



          


            connection.Close();

            float a = float.Parse(label7.Text);
            label7.Text = a.ToString("n2");




        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}
