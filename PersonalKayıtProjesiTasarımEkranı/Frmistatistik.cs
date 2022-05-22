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

namespace PersonalKayıtProjesiTasarımEkranı
{
    public partial class Frmistatistik : Form
    {
        public Frmistatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-HKM3292\\MSSQL;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        private void Frmistatistik_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select count(*) from personelid", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lbltoplampersonel.Text = dr1[0].ToString();
            } 
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select count(*) from personelid where permedenidurum=1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblevliper.Text = dr2[0].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select count(*) from personelid where permedenidurum=0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblbekarper.Text = dr3[0].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("select count(distinct(persehir)) from personelid", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblsehir.Text = dr4[0].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("select sum(permaas) from personelid", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lbltoplammaas.Text = dr5[0].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("select avg(permaas) from personelid", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblortalamamaas.Text = dr6[0].ToString();
            }
            baglanti.Close();

        }
        
            
    }
}
