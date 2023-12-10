using PersonsAssignment.Domain.Model;
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
        public event EventHandler<PersonIdArgs> SavingEditedPerson;
        public event EventHandler ClosingPersonWindow;
        private bool _IsEdit;
        private int _PersonId;
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

        public PersonWindow(string personName, string personEmail, DateTime personBirthDay, bool isEdit, int id) 
        {
            _IsEdit = isEdit;
            _PersonId = id;
            InitializeComponent();
            newPersonName.Text = personName;
            newPersonEmail.Text = personEmail;
            newPersonBirthDay.SelectedDate = personBirthDay;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_IsEdit)
            {
                SavingEditedPerson?.Invoke(this, new(_PersonId));
            }
            else
            {
                SavingNewPerson?.Invoke(this, EventArgs.Empty);
            }
            

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ClosingPersonWindow?.Invoke(this, EventArgs.Empty);
        }
    }
}
