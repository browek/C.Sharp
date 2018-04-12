using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BazaSamochodow
{
    public partial class Form1 : Form
    {
        public List<Samochod> databazeList = new List<Samochod>();
        int index = 1;
        public Form1 (List<Samochod> lista)
        {
            InitializeComponent();

            comboBox1.Text = "wybierz";
            comboBox1.Items.Add("Benzynowy");
            comboBox1.Items.Add("Diesel");
            comboBox1.Items.Add("Elektryczny");
            comboBox1.Items.Add("Hybrydowy");

            comboBox2.Text = "wybierz";
            comboBox2.Items.Add("Na przednie koła");
            comboBox2.Items.Add("Na tylne koła");
            comboBox2.Items.Add("4x4 (stały)");
            comboBox2.Items.Add("4x4 dołączany automatycznie");

            comboBox3.Text = "wybierz";
            comboBox3.Items.Add("Manualna");
            comboBox3.Items.Add("Automatyczna (Hydrauliczna)");
            comboBox3.Items.Add("Automatyczna bezstopniowa (CVT)");
            comboBox3.Items.Add("Automatyczna dwusprzęgłowa (DCT, DSG)");

          

                if (lista != null)
                {
                    foreach (Samochod p in lista)
                    {
                        addInList(p); 
                    }
                    index = lista.Count;
                }
            
        }


        private void addButton_Click(object sender, EventArgs e)
        {
            if (FieldsIsNotEmpty())
            {
                Samochod temp = new Samochod(index++, markaBox.Text, modelBox.Text, Int16.Parse(rokBox.Text), comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString(), comboBox3.SelectedItem.ToString());
               

                addInList(temp);
                labelx.Text = "Dodano do listy";
                labelx.Show();
            }
            else
            {
                labelx.Text = "Wszystkie pola musza zostac wypelnione prawidlowo";
                labelx.Show();
            }
        }
        private Boolean FieldsIsNotEmpty()
        {
            try
            {
                return
                    (!(markaBox.Text == null || markaBox.Text.Trim().Equals(""))) &&
                    (!(modelBox.Text == null || modelBox.Text.Trim().Equals(""))) &&
                    (!(rokBox.Text == null || Int16.Parse(rokBox.Text) <= 0)) &&
                    (!(comboBox1.Text == null || comboBox1.Text.Trim().Equals(""))) &&
                    (!(comboBox2.Text == null || comboBox2.Text.Trim().Equals(""))) &&
                    (!(comboBox3.Text == null || comboBox3.Text.Trim().Equals(""))) ;
            }
            catch (Exception)
            {

            }
            return false;
        }

        public void addInList(Samochod temp)
        {
            databazeList.Add(temp);
            dataGridView1.Rows.Add(temp.index, temp.marka, temp.model, temp.rok, temp.silnik, temp.naped, temp.skrzynia);
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            XDocument xml = XDocument.Load("Samochod.xml");
            List<Samochod> lista = (
                from temp in xml.Root.Elements("samochod")
                select new Samochod(
                    index++,
                    temp.Element("marka").Value,
                    temp.Element("model").Value,
                    Convert.ToInt16(temp.Element("rok").Value),
                    temp.Element("silnik").Value,
                    temp.Element("naped").Value,
                    temp.Element("skrzynia").Value
                    )
                    ).ToList<Samochod>();
            foreach (Samochod p in lista)
            {
                addInList(p);
            }
        }

        public void saveButton_Click(object sender, EventArgs e)
        {
            XDocument xml = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("samochody",
                        from temp in databazeList
                        select new XElement("samochod",
                                new XElement("marka", temp.marka),
                                new XElement("model", temp.model),
                                new XElement("rok", temp.rok.ToString()),
                                new XElement("silnik", temp.silnik),
                                new XElement("naped", temp.naped),
                                new XElement("skrzynia", temp.skrzynia)
                                )

                            )
             );
            xml.Save("Samochod.xml");
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1 != null)
            {
                int id = dataGridView1.CurrentCell.RowIndex;
                Samochod samochod = databazeList[id];
                Form2 form2 = new Form2(samochod.index, samochod.marka, samochod.model, Convert.ToString(samochod.rok), samochod.silnik, samochod.naped, samochod.skrzynia, databazeList);
                

                form2.Show();

                this.Visible = false;
                    
                
            }
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            int id = dataGridView1.CurrentCell.RowIndex;
            databazeList.RemoveAt(id);
            dataGridView1.Rows.RemoveAt(id);
        }


        private void Close(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
