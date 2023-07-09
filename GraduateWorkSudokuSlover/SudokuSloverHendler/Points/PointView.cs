using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Media;
using System.Windows;

namespace GraduateWorkSudokuSlover.SudokuSloverHendler.Points
{
    [AddINotifyPropertyChangedInterface]
    public partial class Point
    {
        public static SolidColorBrush EmptyColor = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
        public static SolidColorBrush SelectedColor = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));

        public static SolidColorBrush GreenColor = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
        public static SolidColorBrush RedColor = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
        public static SolidColorBrush BlueColor = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));

        public bool IsSelected { get; set; }
        public string Value => (value == 0) ? "" : value.ToString();
        public SolidColorBrush Selected => IsSelected ? SelectedColor : EmptyColor;
        public string Val1 => (this.set.Contains(1)) ? "1" : "";
        public string Val2 => (this.set.Contains(2)) ? "2" : "";
        public string Val3 => (this.set.Contains(3)) ? "3" : "";
        public string Val4 => (this.set.Contains(4)) ? "4" : "";
        public string Val5 => (this.set.Contains(5)) ? "5" : "";
        public string Val6 => (this.set.Contains(6)) ? "6" : "";
        public string Val7 => (this.set.Contains(7)) ? "7" : "";
        public string Val8 => (this.set.Contains(8)) ? "8" : "";
        public string Val9 => (this.set.Contains(9)) ? "9" : "";

        public ObservableCollection<SolidColorBrush> PossibleValues { get; set; }
        private void SetViewProp()
        {
            this.IsSelected = false;
            this.PossibleValues = new ObservableCollection<SolidColorBrush>();
            for (int i = 0; i < 9; i++)
            {
                this.PossibleValues.Add(EmptyColor);
            }
        }
        public void SetToDefoltStatusItem()
        {
            for (int i = 0; i < this.PossibleValues.Count; i++)
            {
                this.PossibleValues[i] = EmptyColor;
            }
        }
    }
}
