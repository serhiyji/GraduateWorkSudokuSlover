using System;

namespace GraduateWorkSudokuSlover.SudokuSloverHendler.Coordinates
{
    public class PosSquare
    {
        private int From(int v) { return v >= 0 && v <= 2 ? 0 : v >= 3 && v <= 5 ? 1 : 2; }
        public int i { get; set; }
        public int j { get; set; }

        // Ctor
        #region Ctor
        public PosSquare(int i_ = 0, int j_ = 0)
        {
            i = i_;
            j = j_;
        }
        public PosSquare(PosPoint pos)
        {
            i = From(pos.i);
            j = From(pos.j);
        }
        #endregion

        // operators ==, !=
        #region operators ==, !=
        public static bool operator ==(PosSquare pos1, PosSquare pos2)
        {
            return pos1.Equals(pos2);
        }
        public static bool operator !=(PosSquare pos1, PosSquare pos2)
        {
            return !pos1.Equals(pos2);
        }
        public override bool Equals(object obj)
        {
            return obj is PosSquare pos && i == pos.i && j == pos.j;
        }
        #endregion
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
