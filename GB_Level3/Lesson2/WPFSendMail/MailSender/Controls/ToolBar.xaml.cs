using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace MailSender.Controls
{
    /// <summary>
    /// Логика взаимодействия для ToolBar.xaml
    /// </summary>
    public partial class ToolBar : UserControl
    {
        /// <summary>
        /// Свойство текста в текстовом блоке
        /// </summary>
        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        public static readonly DependencyProperty LabelTextProperty =
            DependencyProperty.Register("LabelText", typeof(string), typeof(ToolBar), new PropertyMetadata(null));
        /// <summary>
        /// Источник для ComboBox
        /// </summary>
        public IEnumerable ItemSource
        {
            get { return (IEnumerable)GetValue(ItemSourceProperty); }
            set { SetValue(ItemSourceProperty, value); }
        }

        public static readonly DependencyProperty ItemSourceProperty =
            DependencyProperty.Register("ItemSource", typeof(IEnumerable), typeof(ToolBar));
        /// <summary>
        /// наименование поля для выбранного значения в ComboBox
        /// </summary>
        public string SelectedValuePath
        {
            get { return (string)GetValue(SelectedValuePathProperty); }
            set { SetValue(SelectedValuePathProperty, value); }
        }

        public static readonly DependencyProperty SelectedValuePathProperty =
            DependencyProperty.Register("SelectedValuePath", typeof(string), typeof(ToolBar),new PropertyMetadata(null));
        /// <summary>
        /// Отображаемое поле для пользователя в ComboBox
        /// </summary>
        public string cbDisplayMember
        {
            get { return (string)GetValue(cbDisplayMemberProperty); }
            set { SetValue(cbDisplayMemberProperty, value); }
        }

        public static readonly DependencyProperty cbDisplayMemberProperty =
            DependencyProperty.Register("cbDisplayMember", typeof(string), typeof(ToolBar),new PropertyMetadata(null));
        /// <summary>
        /// Всплывающая подсказка при наведении на элемент ComboBox
        /// </summary>
        public string cbToolTip
        {
            get { return (string)GetValue(cbToolTipProperty); }
            set { SetValue(cbToolTipProperty, value); }
        }

        public static readonly DependencyProperty cbToolTipProperty =
            DependencyProperty.Register("cbToolTip", typeof(string), typeof(ToolBar),new PropertyMetadata(null));

        public event RoutedEventHandler AddEvent;
        public event RoutedEventHandler EditEvent;
        public event RoutedEventHandler DeleteEvent;
        private void AddButton_OnClick(object Sender, RoutedEventArgs E)
        {
            AddEvent?.Invoke(Sender, E);
        }
        private void EditButton_OnClick(object Sender, RoutedEventArgs E)
        {
            EditEvent?.Invoke(Sender, E);
        }
        private void DeleteButton_OnClick(object Sender, RoutedEventArgs E)
        {
            DeleteEvent?.Invoke(Sender, E);
        }



        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, SenderBox.SelectedItem); }
        }

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(object), typeof(ToolBar), new PropertyMetadata(null));

        public ToolBar()
        {
            InitializeComponent();
            
        }
    }
}
