using Master.ViewModels;
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

namespace Master.Views.DevicesViews
{
    /// <summary>
    /// Interaction logic for StepView.xaml
    /// </summary>
    public partial class StepView : Window
    {
        public StepView()
        {
            InitializeComponent();
        }

        public StepView(StepViewModel dataContext):this()
        {
            this.DataContext = dataContext;
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ProcessView cw = new ProcessView(dgSteps.SelectedItem as ProcessViewModel);
            cw.Owner = this;
            cw.ShowDialog();
        }
    }
}
