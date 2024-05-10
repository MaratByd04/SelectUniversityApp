using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SelectUniversityApp
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            LoadUniversities();
            LoadCities();
        }

        private void LoadUniversities()
        {
            var universities = new List<University>();
            try
            {
                using (var reader = new StreamReader("Universities.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 3 && int.TryParse(parts[1].Trim(), out int id) && int.TryParse(parts[2].Trim(), out int code))
                        {
                            universities.Add(new University { Name = parts[0].Trim(), Id = id, Code = code });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading universities: " + ex.Message);
            }

            dataGridView1.DataSource = universities;
        }

        private void LoadCities()
        {
            var cities = new List<string>();
            try
            {
                using (var reader = new StreamReader("City.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        cities.Add(line.Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading cities: " + ex.Message);
            }

            comboBox1.DataSource = cities;
        }
    }
}