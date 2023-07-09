using PropertyChanged;
using System;

namespace GraduateWorkSudokuSlover.SudokuSloverHendler.Coordinates
{
    [AddINotifyPropertyChangedInterface]
    public class PosPoint : IComparable<PosPoint>
    {
        public int i { get; set; }
        public int j { get; set; }

        // Ctor
        #region Ctor
        public PosPoint(int i_ = 0, int j_ = 0)
        {
            i = i_;
            j = j_;
        }
        #endregion

        // operators ==, !=, <, >
        #region operators ==, !=, <, >
        public static bool operator ==(PosPoint pos1, PosPoint pos2)
        {
            if (pos1 is null || pos2 is null)
            {
                return false;
            }
            return pos1.Equals(pos2);
        }
        public static bool operator !=(PosPoint pos1, PosPoint pos2)
        {
            if (pos1 is null || pos2 is null)
            {
                return false;
            }
            return !pos1.Equals(pos2);
        }
        public override bool Equals(object obj)
        {
            return obj is PosPoint pos && i == pos.i && j == pos.j;
        }
        public static bool operator >(PosPoint pos1, PosPoint pos2)
        {
            return pos1.i > pos2.i || pos1.i == pos2.i && pos1.j > pos2.j;
        }
        public static bool operator <(PosPoint pos1, PosPoint pos2)
        {
            return pos1.i < pos2.i || pos1.i == pos2.i && pos1.j < pos2.j;
        }
        #endregion

        public int CompareTo(PosPoint other)
        {
            return this == other ? 0 : this < other ? -1 : 1;
        }
        public override string ToString()
        {
            return $"{i} : {j}";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
