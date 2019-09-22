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
    /// Логика взаимодействия для EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        public DataRow EmployeeRow { get; set; }
        private EmployeeWindow()
        {
            InitializeComponent();
        }
        public EmployeeWindow(DataRow employeeRow,DataTable departs) : this()
        {
            EmployeeRow = employeeRow;
            tbFirstName.Text = this.EmployeeRow["FirstName"].ToString();
            tbSecondName.Text = this.EmployeeRow["SecondName"].ToString();
            if(this.EmployeeRow["BirthDay"].ToString()!=String.Empty)
                dpBirthDay.SelectedDate = (DateTime)this.EmployeeRow["BirthDay"];
            DataView dv= departs.DefaultView;
            DataRowView drv;
            cbDepartment.ItemsSource = dv;
            foreach (DataRowView item in dv)
            {
                if(item["deptId"].ToString()== employeeRow["deptid"].ToString())
                {
                    drv = item;
                    cbDepartment.SelectedItem = drv;
                    break;
                }
            }
            btnAddEmployee.Click += BtnAddEmployee_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void BtnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(tbFirstName.Text) && !String.IsNullOrEmpty(tbSecondName.Text)
                  && dpBirthDay.SelectedDate.HasValue)
            {
                this.EmployeeRow["FirstName"] = this.tbFirstName.Text;
                this.EmployeeRow["SecondName"] = this.tbSecondName.Text;
                this.EmployeeRow["BirthDay"] = this.dpBirthDay.SelectedDate.Value;
                this.EmployeeRow["deptId"] = (this.cbDepartment.SelectedItem as DataRowView)["deptid"];
                this.DialogResult = true;
                this.Close();
            }
            else
                MessageBox.Show("Заполнены не все поля");
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
