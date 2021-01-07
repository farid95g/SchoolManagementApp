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
        public DeleteStudent(List<Group> groups)
        {
            InitializeComponent();

            cmbGroupsDelete.Items.AddRange(groups.ToArray());
            cmbGroupsDelete.SelectedIndex = 0;
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
            cmbStudentsDelete.SelectedIndex = 0;
        }
    }
}
