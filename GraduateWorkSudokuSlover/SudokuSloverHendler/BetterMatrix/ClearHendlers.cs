using GraduateWorkSudokuSlover.SudokuSloverHendler.Collections;
using GraduateWorkSudokuSlover.SudokuSloverHendler.Coordinates;
using GraduateWorkSudokuSlover.SudokuSloverHendler.Matrix;
using GraduateWorkSudokuSlover.SudokuSloverHendler.Points;
using System;

using System.Linq;

namespace GraduateWorkSudokuSlover.SudokuSloverHendler.BetterMatrix
{
    public partial class BetterMatrix : Matrix<Point>
    {
        private bool ClearValueInSetInRange(PosPoint pos1, PosPoint pos2, byte value, Arrange<PosPoint> arr = default(Arrange<PosPoint>))
        {
            arr = (arr is null) ? new Arrange<PosPoint>() : arr;
            bool total = false;
            for (int i = pos1.i; i <= pos2.i; i++)
            {
                for (int j = pos1.j; j <= pos2.j; j++)
                {
                    if ((this.matrix[i, j].value == 0) && !(arr.Contains(new PosPoint(i, j))))
                    {
                        int size_start = this.matrix[i, j].set.Count();
                        this.matrix[i, j].set -= new Set<byte>(value);
                        if (size_start != this.matrix[i, j].set.Count())
                        {
                            total = true;
                        }
                    }
                }
            }
            return total;
        }
        private bool ClearValuesInSetInRange(PosPoint pos1, PosPoint pos2, Set<byte> values, Arrange<PosPoint> arr = default(Arrange<PosPoint>))
        {
            bool total = false;
            for (int i = 0; i < values.Count(); i++)
            {
                total = this.ClearValueInSetInRange(pos1, pos2, values[i], arr) || total;
            }
            return total;
        }

        public bool ClearValueInSetInHorizontalLine(int index, byte value, Arrange<PosPoint> arr = default(Arrange<PosPoint>))
        { return this.ClearValueInSetInRange(new PosPoint(index, 0), new PosPoint(index, size - 1), value, arr); }
        public bool ClearValueInSetInVerticalLine(int index, byte value, Arrange<PosPoint> arr = default(Arrange<PosPoint>))
        { return this.ClearValueInSetInRange(new PosPoint(0, index), new PosPoint(size - 1, index), value, arr); }
        public bool ClearValueInSetInSquare(PosSquare pos_s, byte value, Arrange<PosPoint> arr = default(Arrange<PosPoint>))
        { return this.ClearValueInSetInRange(new PosPoint(pos_s.i * 3, pos_s.j * 3), new PosPoint(pos_s.i * 3 + 2, pos_s.j * 3 + 2), value, arr); }
        public bool ClearValueInPosPoint(PosPoint pos_p, byte value)
        { return this.ClearValueInSetInRange(pos_p, pos_p, value); }

        public bool ClearValuesInSetInHorizontalLine(int index, Set<byte> values, Arrange<PosPoint> arr = default(Arrange<PosPoint>))
        { return this.ClearValuesInSetInRange(new PosPoint(index, 0), new PosPoint(index, size - 1), values, arr); }
        public bool ClearValuesInSetInVerticalLine(int index, Set<byte> values, Arrange<PosPoint> arr = default(Arrange<PosPoint>))
        { return this.ClearValuesInSetInRange(new PosPoint(0, index), new PosPoint(size - 1, index), values, arr); }
        public bool ClearValuesInSetInSquare(PosSquare pos_s, Set<byte> values, Arrange<PosPoint> arr = default(Arrange<PosPoint>))
        { return this.ClearValuesInSetInRange(new PosPoint(pos_s.i * 3, pos_s.j * 3), new PosPoint(pos_s.i * 3 + 2, pos_s.j * 3 + 2), values, arr); }
        public bool ClearValuesInSetInPosPoint(PosPoint pos_p, Set<byte> values)
        { return this.ClearValuesInSetInRange(pos_p, pos_p, values); }

        public void SettingPosibleValue(PosPoint pos_p, byte value)
        {
            this.SettingPosibleValueInHorizontalLine(pos_p.i, value);
            this.SettingPosibleValueInVerticalLine(pos_p.j, value);
            this.SettingPosibleValueInSquare(new PosSquare(pos_p), value);
            this.matrix[pos_p.i, pos_p.j].set = GetPossibleValuesInPosPoint(pos_p);
        }
        private void SettingPosibleValue(PosPoint pos1, PosPoint pos2, byte value)
        {
            for (int i = pos1.i; i <= pos2.i; i++)
            {
                for (int j = pos1.j; j <= pos2.j; j++)
                {
                    if (matrix[i, j].value == 0 && this.GetPossibleValuesInPosPoint(new PosPoint(i, j)).Contains(value))
                    {
                        this.matrix[i, j].set += new Set<byte>(value);
                    }
                }
            }
        }
        private void SettingPosibleValueInHorizontalLine(int index, byte value)
        { this.SettingPosibleValue(new PosPoint(index, 0), new PosPoint(index, size - 1), value); }
        private void SettingPosibleValueInVerticalLine(int index, byte value)
        { this.SettingPosibleValue(new PosPoint(0, index), new PosPoint(size - 1, index), value); }
        private void SettingPosibleValueInSquare(PosSquare pos_s, byte value)
        { this.SettingPosibleValue(new PosPoint(pos_s.i * 3, pos_s.j * 3), new PosPoint(pos_s.i * 3 + 2, pos_s.j * 3 + 2), value); }
    }
}
