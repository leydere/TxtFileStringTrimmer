// copyright Eric Leyder 2020

using Microsoft.Win32;
using System;
using System.IO;
using System.Text;
using System.Windows;

namespace TxtFileStringTrimmer
{
    /// <summary>
    /// This simple program removes quotation marks from a txt file.
    /// </summary>
    public partial class MainWindow : Window
    {
        string thisHerePath;
        string filenameWithoutPath;
        string[] lines;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Select a Text File";
                openFileDialog.Filter = "Text files (*.txt) | *.txt";
                if (openFileDialog.ShowDialog() == true)
                {
                    thisHerePath = openFileDialog.FileName;
                    filenameWithoutPath = System.IO.Path.GetFileName(openFileDialog.FileName);
                    DisplayBox1.Text = "This is the path and file you have selected.\nPATH: " + thisHerePath + "\nFILENAME: " + filenameWithoutPath;
                }
                openFileDialog = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            lines = File.ReadAllLines(thisHerePath, Encoding.UTF8);
            
            for (int i = 0; i < lines.Length - 1; i++)
            {
                string untrimmmedString = lines[i];
                lines[i] = untrimmmedString.Replace("\"", string.Empty);
                
            }

            DisplayBox1.Text = lines[0] + "\n" + lines[1] + "\n" + lines[2] + "\n" + lines[3];

            try
            {
                string filePath = thisHerePath;
                int length = lines.Length - 1;
                StringBuilder sb = new StringBuilder();
                for (int index = 0; index < length; index++)
                    sb.AppendLine(lines[index]);

                File.WriteAllText(filePath, sb.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



    }
}
