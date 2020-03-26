using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppInClassStudentForm.Pages
{
    public partial class StudentForm : System.Web.UI.Page
    {
        private static List<Student> Student = new List<Student>();

        protected void Page_Load(object sender, EventArgs e)
        {
            MessageLabel.Text = "";
        }
        protected void Add_Click(object sender, EventArgs e)
        {
            MessageLabel.Text = "ID = " + int.Parse(ID.Text) + " Name = " + Name.Text;
            if (Page.IsValid)
            {
                bool found = false;
                foreach (var item in Student)
                {
                    if (item.ID == int.Parse(ID.Text))
                    {
                        found = true;
                    }
                }
                if (found)
                {
                    MessageLabel.Text = "Record already exists.";
                }
                else
                {
                    Student newitem = new Student(int.Parse(ID.Text), Name.Text, double.Parse(Credits.Text), Phone.Text);
                    Student.Add(newitem);
                    PeopleGridView.DataSource = Student;
                    PeopleGridView.DataBind();
                }
            }
        }
        protected void Clear_Click(object sender, EventArgs e)
        {
            ID.Text = "";
            Name.Text = "";

            Credits.Text = "";
            Phone.Text = "";
        }
    }
}