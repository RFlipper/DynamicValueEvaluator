using System;
using System.Activities;
using System.Activities.Expressions;
using System.Windows;
using System.Windows.Input;
using Microsoft.Activities;

namespace DynamicValueEval
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            EvaluateDynamicvaluePath();
        }

        private void txtPath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                EvaluateDynamicvaluePath();
            }
        }

        private void EvaluateDynamicvaluePath()
        {
            try
            {
                var dv  = DynamicValue.Parse(txtWebPayload.Text);
                var act = new EvaluateDynamicValuePath
                {
                    Input = new LambdaValue<DynamicValue>(c => dv),
                    Path  = txtPath.Text
                };

                var result = WorkflowInvoker.Invoke(act);

                txtResults.Text = result.Count == 0 ? "< No Results >" : result.ToString();
            }
            catch (Exception ex)
            {
                txtResults.Text = string.Format("ERROR\r\n{0}", ex);
            }
        }
    }
}