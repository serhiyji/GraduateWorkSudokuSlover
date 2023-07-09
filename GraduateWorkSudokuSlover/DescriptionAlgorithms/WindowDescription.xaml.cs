using PropertyChanged;
using GraduateWorkSudokuSlover.DescriptionAlgorithms;
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
using GraduateWorkSudokuSlover.SudokuSloverHendler;
using Sudoku_Slover.DescriptionAlgorithms;

namespace GraduateWorkSudokuSlover.DescriptionAlgorithms
{
    [AddINotifyPropertyChangedInterface]
    public partial class WindowDescription : Window
    {
        public string Description { get; set; }
        public AlgorithmSudokuSlover Algorithm { get; set; }
        public string AlgorithmString => this.Algorithm.ToString();
        public WindowDescription(AlgorithmSudokuSlover algorithm)
        {
            InitializeComponent();
            this.DataContext = this;
            this.Description = DescriptionsForAlgorithmSudokuSlover.Instance.GetDescription(algorithm);
            this.Algorithm = algorithm;
        }
    }
}
