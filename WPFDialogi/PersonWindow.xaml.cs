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

namespace WPFDialogi
{
    /// <summary>
    /// Logika interakcji dla klasy PersonWindow.xaml
    /// </summary>
    public partial class PersonWindow : Window
    {
        public Person person;
        public PersonWindow()
        {
            InitializeComponent();
            education.ItemsSource = Enum.GetValues(typeof(EducationLevel)).Cast<EducationLevel>();
          
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
