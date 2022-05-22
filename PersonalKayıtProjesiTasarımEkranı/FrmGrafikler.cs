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
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-HKM3292\\MSSQL;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand frmg = new SqlCommand("Select PerSehir, count(*) from personelid group by persehir", baglanti);
            SqlDataReader frg = frmg.ExecuteReader();
            while (frg.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(frg[0], frg[1]);
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand frmg2 = new SqlCommand("Select Permeslek, avg(permaas) from personelid group by permeslek", baglanti);
            SqlDataReader frg2 = frmg2.ExecuteReader();
            while (frg2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(frg2[0], frg2[1]);
            }
            baglanti.Close();
        }
    }
}
