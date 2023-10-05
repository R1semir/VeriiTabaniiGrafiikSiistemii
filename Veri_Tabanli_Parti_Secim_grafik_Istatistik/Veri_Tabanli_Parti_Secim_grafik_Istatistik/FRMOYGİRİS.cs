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

namespace Veri_Tabanli_Parti_Secim_grafik_Istatistik
{
    public partial class FRMOYGİRİS : Form
    {
        public FRMOYGİRİS()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-BJO2DGU\SQLEXPRESS;Initial Catalog=DBSECIMPROJE;Integrated Security=True");
       
        private void btngirisyap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLILCE (ILCEAD,APARTI,BPARTI,CPARTI,DPARTI,EPARTI) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.Add("@p1", SqlDbType.VarChar).Value = txilcead.Text;
            komut.Parameters.Add("@p2", SqlDbType.TinyInt).Value = Convert.ToInt16(txaparti.Text);
            komut.Parameters.Add("@p3", SqlDbType.TinyInt).Value = Convert.ToInt16(txbparti.Text);
            komut.Parameters.Add("@p4", SqlDbType.TinyInt).Value = Convert.ToInt16(txcparti.Text);
            komut.Parameters.Add("@p5", SqlDbType.TinyInt).Value = Convert.ToInt16(txdparti.Text);
            komut.Parameters.Add("@p6", SqlDbType.TinyInt).Value = Convert.ToInt16(txeparti.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Oy Girişi Gerçekleşti");

        }

        private void FRMOYGİRİS_Load(object sender, EventArgs e)
        {

        }

        private void btngrafik_Click(object sender, EventArgs e)
        {
            FrmGrafikler frg = new FrmGrafikler();
            frg.Show();
            this.Hide();
        }

        private void btnistatis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
