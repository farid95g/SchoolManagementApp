using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementApp
{
    public partial class Form1 : Form
    {
        private List<Group> Groups = new List<Group>();
        public Form1()
        {
            Student stu1 = new Student { Name = "Nikola", Surname = "Tesla" };
            Student stu2 = new Student { Name = "Albert", Surname = "Einstein" };
            Student stu3 = new Student { Name = "Stephen", Surname = "Hawking" };

            Group grPhysics = new Group("grPhysics");
            Group grMath = new Group("grMath");

            grPhysics.AddStudent(stu1);
            grPhysics.AddStudent(stu2);
            grMath.AddStudent(stu3);

            Groups.Add(grPhysics);
            Groups.Add(grMath);

            InitializeComponent();

            cmbGroups.Items.AddRange(Groups.ToArray());
            cmbGroups.SelectedIndex = 0;

            dgv.DataSource = grPhysics.GetStudentList();
        }

        private void GetSelectedItem(object sender, EventArgs e)
        {
            Group selectedGroup = (Group)cmbGroups.SelectedItem;
            dgv.DataSource = null;
            dgv.DataSource = selectedGroup.GetStudentList();
        }
    }
}
