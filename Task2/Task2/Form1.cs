using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myConn = new SqlConnection("Data Source=DESKTOP-ICHGA08\\SQLEXPRESS;Integrated Security=False;User ID=sa;" +
                "Password=1234509876;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;" +
                "ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            myConn.Open();
            SqlCommand myCom = new SqlCommand();
            myCom.Connection = myConn;
            myCom.CommandText = "SELECT name AS DBName FROM sys.databases where name ='superhero'";
            SqlDataReader myReader = myCom.ExecuteReader();
            string tmp = "";
            while (myReader.Read())
                tmp += myReader["DBname"].ToString();
            myReader.Close();

            if (tmp.Length == 0)
                {
                myCom.CommandText = "CREATE DATABASE \"superhero\"";  
                myCom.ExecuteNonQuery();

                myCom.CommandText = "use superhero create table Abilities(" +
                    " id int  check(id > 0)," +
                    "ab_name varchar(30)," +
                    "primary key(id));";
                myCom.ExecuteNonQuery();

                myCom.CommandText = "use superhero create table superhero( " +
                    "id int  check(id > 0), " +
                    "sh_name varchar(30)," +
                    " real_name varchar(30), " +
                    "birth_date date, " +
                    "birthplace varchar(30), " +
                    "primary key(id)); ";
                myCom.ExecuteNonQuery();

                myCom.CommandText = "use superhero create table Sh_Ab(" +
                    " id_sh int references Superhero(id)" +
                    " on delete set null" +
                    " on update cascade," +
                    " id_ab int references Abilities(id)" +
                    " on delete set null" +
                    " on update cascade, " +
                    "mark int check(mark >= 0 and mark <= 10)); ";
                myCom.ExecuteNonQuery();

                myCom.CommandText = "use superhero insert into Abilities values" +
                    "(1,'immortality' )," +
                    "(2, 'forc')," +
                    "(3,'speed')," +
                    "(4, 'agility')," +
                    "(5, 'healing')," +
                    "(6, 'blades')," +
                    "(7, 'fly')";
                myCom.ExecuteNonQuery();

                myCom.CommandText = "use superhero insert into superhero values " +
                    "(1,'Superman', 'Clark Kent', '1939-01-01', 'Krypton')," +
                    "(2,'Wolverine', 'James Howlett', '1974-10-01', null)," +
                    "(3,'Wonder Woman', 'Diana Prince', '1941-10-01', 'Themyscira')," +
                    "(4,'Spider-Man', 'Peter Benjamin Parker', '1962-08-01', null)";
                myCom.ExecuteNonQuery();

                myCom.CommandText = "use superhero insert into Sh_Ab values" +
                    " (1,1,8)," +
                    "(1,2,10)," +
                    "(1,3,7)," +
                    "(2,2,9)," +
                    "(2,3,8)," +
                    "(2,5,4)," +
                    "(2,6,7)," +
                    "(3,2,8)," +
                    "(3,3,3)," +
                    "(3,7,6)," +
                    "(4,4,8)";
                myCom.ExecuteNonQuery();
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand myCom = new SqlCommand();
            myCom.Connection = myConn;
            string com = "use superhero select a.sh_name from " +
                "(select count(Abilities.ab_name) as count_of_ab, " +
                "superhero.sh_name from Sh_Ab " +
                "left join Abilities on Sh_Ab.id_ab = Abilities.id " +
                "left join superhero on Sh_Ab.id_sh = superhero.id group by superhero.sh_name)" +
                " a where a.count_of_ab >= 2";
            

            DataSet ds = new DataSet("ex");
            SqlDataAdapter dataAdapter = new SqlDataAdapter(com, myConn);
            dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            dataAdapter.Fill(ds, "Info");
            dataAdapter.FillSchema(ds, SchemaType.Source, "Info");
            dataGridView1.DataSource = ds.Tables["Info"];
            dataGridView1.Update();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
