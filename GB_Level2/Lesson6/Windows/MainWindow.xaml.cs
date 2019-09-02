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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmployeeCard
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,Views.IDepartmentBaseView,Views.IEmployeeBaseView
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public string FirstName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string SecondName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string DepartmentName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int DepartmentId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
