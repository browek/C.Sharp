using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazaSamochodow
{
    public partial class Form2 : Form
    {
        private int eindex = 0;

        DataGridView dataList = new DataGridView(); 
        List<Samochod> list = new List<Samochod>();
        public Form2(int index, String marka, String model, String rok, String silnik, String naped, String skrzynia, List<Samochod> lista)
        {
            InitializeComponent();
            ecomboBox1.Text = "wybierz";
            ecomboBox1.Items.Add("Benzynowy");
            ecomboBox1.Items.Add("Diesel");
            ecomboBox1.Items.Add("Elektryczny");
            ecomboBox1.Items.Add("Hybrydowy");

            ecomboBox2.Text = "wybierz";
            ecomboBox2.Items.Add("Na przednie koła");
            ecomboBox2.Items.Add("Na tylne koła");
            ecomboBox2.Items.Add("4x4 (stały)");
            ecomboBox2.Items.Add("4x4 dołączany automatycznie");

            ecomboBox3.Text = "wybierz";
            ecomboBox3.Items.Add("Manualna");
            ecomboBox3.Items.Add("Automatyczna (Hydrauliczna)");
            ecomboBox3.Items.Add("Automatyczna bezstopniowa (CVT)");
            ecomboBox3.Items.Add("Automatyczna dwusprzęgłowa (DCT, DSG)");

            emarkaBox.Text = marka;
            emodelBox.Text = model;
            erokBox.Text = rok;
            ecomboBox1.Text = silnik;
            ecomboBox2.Text = naped;
            ecomboBox3.Text = skrzynia;
            eindex = index;

            list = lista;
        }

        private void editeButton_Click(object sender, EventArgs e)
        {
            Samochod temp = new Samochod(eindex, emarkaBox.Text, emodelBox.Text, Int16.Parse(erokBox.Text),  ecomboBox1.SelectedItem.ToString(), ecomboBox2.SelectedItem.ToString(), ecomboBox3.SelectedItem.ToString());

            list.RemoveAt(eindex - 1);
            list.Insert(eindex - 1, temp);
            
            Form1 form1 = new Form1(list);
            form1.Show();
            this.Close();
        }
    }
}
