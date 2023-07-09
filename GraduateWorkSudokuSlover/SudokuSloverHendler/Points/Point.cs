using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using GraduateWorkSudokuSlover.SudokuSloverHendler.Collections;
using GraduateWorkSudokuSlover.SudokuSloverHendler.Coordinates;
using PropertyChanged;

namespace GraduateWorkSudokuSlover.SudokuSloverHendler.Points
{
    public partial class Point
    {
        public byte value { get; set; }
        public Set<byte> set { get; set; }
        private PosPoint pos;
        public Point(byte v, PosPoint p)
        {
            this.value = v;
            this.set = new Set<byte>();
            this.pos = p;
            this.SetViewProp();
        }
        public Point(byte value) : this(value, new PosPoint()) { }
        public Point() : this(0, new PosPoint()) { }
        public string SavePoint()
        {
            return $"{this.value}+{this.set.ToString()}";
        }
        public static bool operator ==(Point p1, byte value)
        {
            return p1.Equals(new Point(value));
        }
        public static bool operator !=(Point p1, byte value)
        {
            return !p1.Equals(new Point(value));
        }
        public override string ToString()
        {
            return $"{value}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null) { return false; }
            if (!(obj is Point)) { return false; }
            Point other = (Point)obj;
            return value == other.value;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
