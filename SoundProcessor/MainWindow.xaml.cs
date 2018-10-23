using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SoundProcessor {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        List<string> fnames = new List<string>();
        ObservableCollection<FileItem> files = new ObservableCollection<FileItem>();

        public MainWindow() {
            InitializeComponent();

            //testLbl.Content = PiterProcessor.Process("0111322111k_14days.wav");

            filesList.ItemsSource = files;

            string[] args = Environment.GetCommandLineArgs();

            if (args.Length == 2 && (args[1].Contains("\\") | args[1].Contains("/"))) {
                fnames = Directory.GetFiles(args[1], "*.wav", SearchOption.AllDirectories).ToList();
            }

            foreach (var f in fnames) {
                files.Add(new FileItem(f));
            }

        }

        private async void Button_Click(object sender, RoutedEventArgs e) {
            if (files.Count == 0) return;

            processProgress.Value = 0;
            processProgress.Maximum = files.Count;

            for (int i = 0; i < files.Count; i++) {
                string fileName = Path.GetFileName(files[i].FileName);
                string newFileName = "";

                if ((bool)mskOpt.IsChecked) {
                    newFileName = MoscowProcessor.Process(fileName);
                } else if ((bool)spbOpt.IsChecked) {
                    newFileName = PiterProcessor.Process(fileName);
                } else if ((bool)sibOpt.IsChecked) {
                    newFileName = SiberiaProcessor.Process(fileName);
                } else if ((bool)sthOpt.IsChecked) {
                    newFileName = SouthProcessor.Process(fileName);
                } else if ((bool)urlOpt.IsChecked) {
                    newFileName = UralProcessor.Process(fileName);
                }
                if (fileName.Length < 6) newFileName = fileName;


                await ProcessFileAsync(files[i].FileName, newFileName);
            }

            MessageBoxResult result = MessageBox.Show("DONE", "DONE", MessageBoxButton.OK,MessageBoxImage.Asterisk);
        }

        private Task ProcessFileAsync(string fullPath, string newFileName) {
            return Task.Run(() => {
                string fileName = Path.GetFileName(fullPath);
                string filePath = Path.GetDirectoryName(fullPath);
                var newFormat = new WaveFormat(8000, 16, 1);

                using (var reader = new WaveFileReader(fullPath)) {
                    using (var conversionStream = new WaveFormatConversionStream(newFormat, reader)) {
                        WaveFileWriter.CreateWaveFile(fullPath + "_", conversionStream);
                    }
                }

                File.Delete(fullPath);
                File.Move(fullPath + "_", filePath + Path.DirectorySeparatorChar + newFileName);

                Application.Current.Dispatcher.Invoke(new Action(() => {
                    processProgress.Value++;
                }));
            });
        }
    }
}
