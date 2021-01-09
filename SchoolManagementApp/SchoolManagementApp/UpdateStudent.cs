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
    public partial class UpdateStudent : Form
    {
        private List<Group> Groups;
        private ComboBox _cmb;
        private DataGridView _dgv;

        public UpdateStudent(List<Group> groups, ComboBox cmb, DataGridView dgv)
        {
            Groups = groups;
            _cmb = cmb;
            _dgv = dgv;

            InitializeComponent();

            cmbGroupsUpdate.Items.AddRange(groups.ToArray());
        }

        private void FillStudentsDropdown(object sender, EventArgs e)
        {
            cmbStudentsUpdate.Items.Clear();
            txtStudentName.Text = "";
            txtStudentSurname.Text = "";

            Group selectedGroup = (Group)cmbGroupsUpdate.SelectedItem;

            cmbStudentsUpdate.Items.AddRange(selectedGroup.GetStudentList().ToArray());
        }

        private void GetSelectedStudent(object sender, EventArgs e)
        {
            Student selectedStudent = (Student)cmbStudentsUpdate.SelectedItem;

            txtStudentName.Text = selectedStudent.Name;
            txtStudentSurname.Text = selectedStudent.Surname;
        }

        private void UpdateStudentInfo(object sender, EventArgs e)
        {
            string name = txtStudentName.Text.Trim();
            string surname = txtStudentSurname.Text.Trim();

            if (name == "" || surname == "")
            {
                MessageBox.Show("Please, fill out all the fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Group selectedGroup = (Group)cmbGroupsUpdate.SelectedItem;
            Student selectedStudent = (Student)cmbStudentsUpdate.SelectedItem;
            selectedStudent.Name = name;
            selectedStudent.Surname = surname;

            MessageBox.Show($"You have successfully updated student {selectedStudent}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtStudentName.Text = "";
            txtStudentSurname.Text = "";

            cmbGroupsUpdate.Items.Clear();
            cmbGroupsUpdate.Items.AddRange(Groups.ToArray());

            cmbStudentsUpdate.Items.Clear();

            if (selectedGroup == (Group)_cmb.SelectedItem)
            {
                _dgv.DataSource = null;
                _dgv.DataSource = selectedGroup.GetStudentList();
            }
        }
    }
}
