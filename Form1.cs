using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.BuilderBurger;
using WindowsFormsApp1.DBCon;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Model1 model1 = new Model1();

        private void button1_Click(object sender, EventArgs e)
        {
            BurgerBuilder burgerBuilder = new BurgerBuilder();
            BurgerDirector burgerDirector = new BurgerDirector(burgerBuilder);
            if (comboBoxBurger.SelectedItem.ToString()=="Бургер стандартный")
            burgerDirector.BuildDefault();
            else
                burgerDirector.BuildWithBeacon();
            try 
            {
                model1.Burgers.Add(burgerBuilder.GetBurgers());
                model1.SaveChanges();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            LoadData();
        }
        private void LoadData()
        {
            comboBoxBurger.SelectedIndex = 0;
            dataGridView1.DataSource = model1.Burgers.ToList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
