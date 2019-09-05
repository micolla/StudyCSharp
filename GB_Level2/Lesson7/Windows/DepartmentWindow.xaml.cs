using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;

namespace EmployeeCard
{
    /// <summary>
    /// Логика взаимодействия для DepartmentWindow.xaml
    /// </summary>
    public partial class DepartmentWindow : Window
    {
        public DataRow DepartmentRow { get; set; }
        private DepartmentWindow()
        {
            InitializeComponent();
        }
        public DepartmentWindow(DataRow departmentRow):this()
        {
            DepartmentRow = departmentRow;
            tbDeparmentName.Text = this.DepartmentRow["DepartmentName"].ToString();
            btnAddDepartment.Click += BtnAddDepartment_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void BtnAddDepartment_Click(object sender, RoutedEventArgs e)
        {
            this.DepartmentRow["DepartmentName"] = this.tbDeparmentName.Text;
            this.DialogResult = true;
            this.Close();
        }
    }
}
