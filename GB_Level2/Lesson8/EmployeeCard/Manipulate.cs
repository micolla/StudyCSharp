using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using System.Configuration;
using System.Net.Http;

namespace EmployeeCard
{
    static class Manipulate
    {
        static MainWindow mainWindow;
        static HttpClient client;
        static string urlLoadDepts = @"https://localhost:44315/GetAllDepartments";
        static string urlLoadEmps = @"https://localhost:44315/GetEmployees/";
        public static void Init(MainWindow window)
        {
            client = new HttpClient();
            mainWindow = window;
            mainWindow.lbDepartments.Items.Add(client.GetStringAsync(urlLoadDepts).Result);
            //mainWindow.lbEmployees.DataContext = empDatatTable.DefaultView;
            //mainWindow.lbDepartments.SelectionChanged += LbDepartments_SelectionChanged;
            //mainWindow.lbEmployees.SelectionChanged += LbEmployees_SelectionChanged;
            //mainWindow.btnAddDepartment.Click += BtnAddDepartment_Click;
            //mainWindow.btnAddEmployee.Click += BtnAddEmployee_Click;
            //mainWindow.btnEditEmployee.Click += BtnEditEmployee_Click;
            //mainWindow.btnEditDepartment.Click += BtnEditDepartment_Click;
        }

        /// <summary>
        /// Редактирование сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void BtnEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Добавить сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void BtnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Добавить отдел
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void BtnAddDepartment_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Редактировать отдел
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void BtnEditDepartment_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Загрузка сотрудников, включение кнопок добавить сотрудника, редактировать отдел
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void LbDepartments_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Включение возможности редактировать сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void LbEmployees_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            mainWindow.btnEditEmployee.IsEnabled = mainWindow.lbEmployees.SelectedItem != null ? true : false;
        }
    }
}