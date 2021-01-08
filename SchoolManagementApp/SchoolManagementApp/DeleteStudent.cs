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
    public partial class DeleteStudent : Form
    {
        private ComboBox _cmbMainPage;
        private DataGridView _dgvMainPage;
        public DeleteStudent(List<Group> groups, ComboBox cmb, DataGridView dgv)
        {
            InitializeComponent();

            cmbGroupsDelete.Items.AddRange(groups.ToArray());
            _cmbMainPage = cmb;
            _dgvMainPage = dgv;
        }

        private void GetStudents(object sender, EventArgs e)
        {
            Group selectedGroup = (Group)cmbGroupsDelete.SelectedItem;
            FillStudentsDropdown(selectedGroup);
        }

        private void FillStudentsDropdown(Group group)
        {
            cmbStudentsDelete.Items.Clear();
            cmbStudentsDelete.Items.AddRange(group.GetStudentList().ToArray());
        }

        private void DeleteStu(object sender, EventArgs e)
        {
            Group selectedGroup = (Group)cmbGroupsDelete.SelectedItem;
            Student selectedStudent = (Student)cmbStudentsDelete.SelectedItem;

            DialogResult result = MessageBox.Show($"Are you sure to delete {selectedStudent} from {selectedGroup}?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                selectedGroup.DeleteStudent(selectedStudent);
                MessageBox.Show($"You have successfully deleted {selectedStudent} from {selectedGroup}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbGroupsDelete.Items.Clear();
                cmbStudentsDelete.Items.Clear();

                if (_cmbMainPage.SelectedItem == selectedGroup)
                {
                    _dgvMainPage.DataSource = null;
                    _dgvMainPage.DataSource = selectedGroup.GetStudentList();
                }
            }
        }
    }
}
