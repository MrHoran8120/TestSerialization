using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using TestSerialization.Properties;

namespace TestSerialization
{
    public partial class Form1 : Form
    {
        List<Car> Cars = new List<Car>();



        public Form1()
        {
            InitializeComponent();
            populateRichTextBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text==null) return;
            Car theCar = new Car(colorDialog1.Color, textBox1.Text, textBox2.Text);
            Cars.Add(theCar);
            populateRichTextBox();
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void populateRichTextBox()
        {
            richTextBox1.Clear();
            foreach (var theCar in Cars)
            {
                richTextBox1.AppendText(theCar.Rego + " ( " + theCar.DateOfManufacture + " ) " + Environment.NewLine);  
            }
        }

        private void saveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create an XmlSerializer
            XmlSerializer serializer = new XmlSerializer(typeof(List<Car>));

            // Serialize the List<Car> to an XML file
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string theFile = Path.Combine(path, "cars.xml");
            using (StreamWriter writer = new StreamWriter(theFile))
            {
                serializer.Serialize(writer, Cars);
            }
        }

        private void loadFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create an XmlSerializer
            XmlSerializer serializer = new XmlSerializer(typeof(List<Car>));

            // Deserialize the XML file to a List<Car>
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string theFile = Path.Combine(path, "cars.xml");
            using (StreamReader reader = new StreamReader(theFile))
            {
                Cars = (List<Car>)serializer.Deserialize(reader);
            }

            populateRichTextBox();
            Console.WriteLine("List is now " + Cars.Count + Environment.NewLine);

        }
    }
}
