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
        }

        private void GetSelectedItem(object sender, EventArgs e)
        {
            Group selectedGroup = (Group)cmbGroups.SelectedItem;
            RefreshDataGridView(selectedGroup);
        }

        private void AddNewStudent(object sender, EventArgs e)
        {
            string name = txtStuName.Text.Trim();
            string surname = txtStuSurname.Text.Trim();

            if (name == "" || surname == "")
            {
                MessageBox.Show("Please, fill out all the fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Student student = new Student(name, surname);

            Group selectedGroup = (Group)cmbGroups.SelectedItem;
            selectedGroup.AddStudent(student);
            RefreshDataGridView(selectedGroup);

            ClearInputFields();
            MessageBox.Show($"{name} {surname} successfully added to the group {selectedGroup}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RefreshDataGridView(Group group)
        {
            dgv.DataSource = null;
            dgv.DataSource = group.GetStudentList();
        }

        private void ClearInputFields()
        {
            txtStuName.Text = "";
            txtStuSurname.Text = "";
        }

        private void OpenDeleteStudentForm(object sender, EventArgs e)
        {
            DeleteStudent deletePage = new DeleteStudent(Groups, cmbGroups, dgv);
            deletePage.ShowDialog();
        }

        private void OpenUpdateStudentForm(object sender, EventArgs e)
        {
            UpdateStudent updatePage = new UpdateStudent(Groups);
            updatePage.Show();
        }
    }
}
