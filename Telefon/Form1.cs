using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Telefon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        DataTable Telefoni = new DataTable();
        string cs = "Data source= LAPTOP-EPEJEUJD; Initial catalog= Telefon; Integrated security=true";

        int red=0;
 
        public void proc( int x)
        {
            txt_id.Text = Telefoni.Rows[x]["id"].ToString();
            txt_model.Text = Telefoni.Rows[x]["model"].ToString();
            txt_marka.Text = Telefoni.Rows[x]["marka"].ToString();
            txt_ram.Text = Telefoni.Rows[x]["ram"].ToString();
            txt_os.Text = Telefoni.Rows[x]["os"].ToString();



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txt_id.Enabled = false;
            SqlConnection veza = new SqlConnection(cs);
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from TELEFONI", veza);
            adapter.Fill(Telefoni);
            proc(red);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txt_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(red!=0)
            {
                red--;
                proc(red);
            }    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            red = 0;
            proc(red);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(red!=Telefoni.Rows.Count-1)
            {
                red++;
                proc(red);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            red = Telefoni.Rows.Count - 1;
            proc(red);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection(cs);
            SqlCommand naredba = new SqlCommand("Delete from TELEFONI where id=" + txt_id.Text, veza);
            veza.Open();
            naredba.ExecuteNonQuery();
            veza.Close();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from TELEFONI", veza);
            Telefoni.Clear();
            adapter.Fill(Telefoni);
            if (red == Telefoni.Rows.Count)
            {
                red--;
            }
            proc(red);


        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection(cs);
            SqlCommand naredba = new SqlCommand("Insert into TELEFONI (model,marka,ram,os) values ('" + txt_model.Text + "' ,'" + txt_marka.Text + "' ,'" + txt_ram.Text + "' ,'" + txt_os.Text + "')", veza);
            veza.Open();
            naredba.ExecuteNonQuery();
            veza.Close();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from TELEFONI", veza);
            Telefoni.Clear();
            adapter.Fill(Telefoni);
            proc(red);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection(cs);
            SqlCommand naredba = new SqlCommand("Update TELEFONI set model='" + txt_model.Text + "' ,marka='" + txt_marka.Text + "',ram='" + txt_ram.Text + "',os='" + txt_os.Text + "' where id=" + txt_id.Text, veza);
            veza.Open();
            naredba.ExecuteNonQuery();
            veza.Close();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from TELEFONI", veza);
            Telefoni.Clear();
            adapter.Fill(Telefoni);
            proc(red);

        }
    }
}
