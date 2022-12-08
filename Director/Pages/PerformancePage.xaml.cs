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
using Director.Model;

namespace Director.Pages
{
    /// <summary>
    /// Логика взаимодействия для PerformancePage.xaml
    /// </summary>
    public partial class PerformancePage : Page
    {
        Performance contextPerfomance;
        List<SchedulePerformance> timeTables = new List<SchedulePerformance>();
        List<SchedulePerformance> oldTimeTables = new List<SchedulePerformance>();
        public PerformancePage(Performance perfomance)
        {
            InitializeComponent();
            CBAnimals.ItemsSource = App.DB.Animal.ToList();
            CBEmployees.ItemsSource = App.DB.Employee.ToList();
            contextPerfomance = perfomance;
            DataContext = contextPerfomance;
            if (contextPerfomance.Id != 0)
            {
                timeTables = contextPerfomance.SchedulePerformance.ToList();
                oldTimeTables = contextPerfomance.SchedulePerformance.ToList();
            }
        }

        private void BSave_Click(object sender, RoutedEventArgs e)
        {
            var selectedDate = DPDate.SelectedDate;
            var selectedTime = TBTime.Text;
            if (string.IsNullOrWhiteSpace(contextPerfomance.Name))
            {
                MessageBox.Show("введите название");
                return;
            }
            if (selectedDate == null)
            {
                MessageBox.Show("выберите дату");
                return;
            }
            if (TimeSpan.TryParse(selectedTime, out TimeSpan resultTime) == false)
            {
                MessageBox.Show("введите корректное время");
                return;
            }
            contextPerfomance.DateTime = selectedDate.Value.Add(resultTime);
            if (contextPerfomance.Id == 0)
            {
                App.DB.Performance.Add(contextPerfomance);
                App.DB.SchedulePerformance.AddRange(timeTables);
            }

            App.DB.SaveChanges();
        }

        private void BAddTimeTable_Click(object sender, RoutedEventArgs e)
        {
            var time = TBDuration.Text;
            var selectedAnimal = CBAnimals.SelectedItem as Animal;
            var selectedEmployee = CBEmployees.SelectedItem as Employee;
            if (TimeSpan.TryParse(time, out TimeSpan resultTime) == false)
            {
                MessageBox.Show("введите корректное время");
                return;
            }
            if (selectedAnimal == null && selectedEmployee == null)
            {
                MessageBox.Show("Выберите животное и/или актера");
                return;
            }

            var timeTable = new SchedulePerformance();
            timeTable.Animal = selectedAnimal;
            timeTable.Employee = selectedEmployee;
            timeTable.Time = resultTime;
            timeTable.Performance = contextPerfomance;
            timeTables.Add(timeTable);
            Refresh();
        }

        private void Refresh()
        {
            DGTimeTable.ItemsSource = timeTables.ToList();
        }
    }
}
