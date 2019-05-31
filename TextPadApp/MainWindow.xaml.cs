using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Threading;
using System.Windows.Shapes;

namespace TextPadApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public  partial class MainWindow : Window
    {
        private string text = null;

         public MainWindow()
         {
            InitializeComponent();
            for (var i = 1; i <= 72; i++)
            {
                if(i%2==0)
                Fontsize.Items.Add((double)i);
            }
        }

        private void SaveAs(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.ShowDialog();
            string filename = saveFileDialog.FileName + ".txt";
            File.WriteAllText(filename, textBox.Text);
            MessageBox.Show("Файл сохранен", "Успешно!");
        }

        private void SaveFile(object textbox)
        {
            
            string filename = "autoSavedFile" + ".txt";
            File.WriteAllText(filename, text);

        }

        private void OpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            string filename = openFileDialog.FileName;
            string fileText = File.ReadAllText(filename);
            textBox.Text = fileText;
        }

        private void ChangeFont(object sender, SelectionChangedEventArgs e)
        {           
            textBox.FontFamily = Fonttype.SelectedItem as FontFamily;
        }

      
    }
}
