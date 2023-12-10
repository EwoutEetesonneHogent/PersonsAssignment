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

namespace PersonsAssignment.WPF
{
	/// <summary>
	/// Interaction logic for PersonWindow.xaml
	/// </summary>
	public partial class PersonWindow : Window
	{
        public event EventHandler SavingNewPerson;
		public string NewPersonName
		{ get => newPersonName.Text;
		}
        public string NewPersonEmail
        {
            get => newPersonEmail.Text; 
        }
        public DateTime NewPersonBirthDay
        {
            get => newPersonBirthDay.DisplayDate;
        }
        public PersonWindow()
		{
			InitializeComponent();
		}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SavingNewPerson?.Invoke(this, EventArgs.Empty);

        }
    }
}
