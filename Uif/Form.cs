using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;

namespace Uif
{
    public partial class mainForm : Form
    {
        private List<Student> students = new List<Student>();

        public mainForm()
        {
            InitializeComponent();
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            if (txbID.Text.Trim().Length == 0 ||
                txbCity.Text.Trim().Length == 0 ||
                txbCountry.Text.Trim().Length == 0 ||
                txbLastName.Text.Trim().Length == 0 ||
                txbFirstName.Text.Trim().Length == 0 ||
                txbScore4.Text.Trim().Length == 0 ||
                txbScore3.Text.Trim().Length == 0 ||
                txbScore2.Text.Trim().Length == 0 ||
                txbScore1.Text.Trim().Length == 0)
            {
                MessageBox.Show("You must fill all fields!");
            }
            else
            {
                int id; int score_1; int score_2;
                int score_3; int score_4;

                string firstName = txbFirstName.Text;
                string lastName = txbLastName.Text;
                string city = txbCity.Text;
                string country = txbCountry.Text;

                if (int.TryParse(txbID.Text, out id) &&
                    int.TryParse(txbScore1.Text, out score_1) &&
                    int.TryParse(txbScore2.Text, out score_2) &&
                    int.TryParse(txbScore3.Text, out score_3) &&
                    int.TryParse(txbScore4.Text, out score_4))
                {
                    students.Add(new Student
                    {
                        First = firstName,
                        Last = lastName,
                        City = city,
                        Country = country,
                        ID = id,
                        Scores = new List<int> { score_1, score_2, score_3, score_4 }
                    });

                    MessageBox.Show("Record was successfully added!");
                    clearFields();
                }
                else
                {
                    MessageBox.Show("Failed to parse integer values!\n" +
                    "Please fill ID and Score fields only with integer values");
                }
            }
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            if (students.Count == 0)
            {
                txbResult.Text = "";
                txbResult.AppendText("There is no data to display");
            }
            else
            {
                txbResult.Text = "";

                if (rbtn1.Checked)
                {
                    var studentQuery = from student in students
                                       from score in student.Scores
                                       where score > 90
                                       select new
                                       {
                                           FirstName = student.First,
                                           LastName = student.Last
                                       };

                    foreach (var student in studentQuery)
                    {
                        txbResult.AppendText("" + student.LastName
                            + ", " + student.FirstName + "\n");
                    }
                }
                else if (rbtn2.Checked)
                {
                    var studentQuery = from student in students
                                       where student.City == "London"
                                       from score in student.Scores
                                       where score > 90
                                       select new
                                       {
                                           FirstName = student.First,
                                           LastName = student.Last,
                                           City = student.City
                                       };

                    foreach (var student in studentQuery)
                    {
                        txbResult.AppendText("" + student.LastName
                            + ", " + student.FirstName + ", " + student.City + "\n");
                    }

                }
                else if (rbtn3.Checked)
                {
                    var studentQuery = from student in students
                                       where student.Country == "Finland"
                                       from score in student.Scores
                                       where score > 90
                                       select new
                                       {
                                           FirstName = student.First,
                                           LastName = student.Last,
                                           Country = student.Country
                                       };

                    foreach (var student in studentQuery)
                    {
                        txbResult.AppendText("" + student.LastName
                            + ", " + student.FirstName + ", " + student.Country + "\n");
                    }

                }
                else if (rbtn4.Checked)
                {
                    var studentQuery = from student in students
                                       where student.Country == "Finland"
                                       orderby student.First ascending
                                       from score in student.Scores
                                       where score > 90
                                       select new
                                       {
                                           FirstName = student.First,
                                           LastName = student.Last,
                                           Country = student.Country
                                       };

                    foreach (var student in studentQuery)
                    {
                        txbResult.AppendText("" + student.LastName
                            + ", " + student.FirstName + ", " + student.Country + "\n");
                    }

                }
            }
        }

        private void clearFields()
        {
            txbID.Text = "";
            txbCity.Text = "";
            txbCountry.Text = "";
            txbLastName.Text = "";
            txbFirstName.Text = "";
            txbScore4.Text = "";
            txbScore3.Text = "";
            txbScore2.Text = "";
            txbScore1.Text = "";
        }

        private void aboutLINQApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.Show();
        }

        private void helpContentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "help.chm");
        }
    }
}
