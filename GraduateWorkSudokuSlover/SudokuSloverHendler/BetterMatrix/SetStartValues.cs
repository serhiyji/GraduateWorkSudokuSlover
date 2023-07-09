using System;
using GraduateWorkSudokuSlover.SudokuSloverHendler.Collections;
using GraduateWorkSudokuSlover.SudokuSloverHendler.Coordinates;
using GraduateWorkSudokuSlover.SudokuSloverHendler.Matrix;
using GraduateWorkSudokuSlover.SudokuSloverHendler.Points;

namespace GraduateWorkSudokuSlover.SudokuSloverHendler.BetterMatrix
{
    public partial class BetterMatrix : Matrix<Point>
    {
        public void SetPossibleValues()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (this.matrix[i, j].value == 0)
                    {
                        this.matrix[i, j].set = this.GetPossibleValuesInPosPoint(new PosPoint(i, j));
                    }
                }
            }
        }
        public void ClearMatrix()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    this.matrix[i, j].SetToDefoltStatusItem();
                    this.SetValue(new PosPoint(i, j), 0);
                }
            }
            this.SetPossibleValues();
        }
        private Set<byte> GetPossibleValuesInPosPoint(PosPoint pos_p)
        {
            Set<byte> set1 = new Set<byte>(this.GetSetHorizontalLine(pos_p.i));
            Set<byte> set2 = new Set<byte>(this.GetSetVerticalLine(pos_p.j));
            Set<byte> set3 = new Set<byte>(this.GetSetSquare(new PosSquare(pos_p)));
            return (new Set<byte>(1, 2, 3, 4, 5, 6, 7, 8, 9) - (set1 + set2 + set3));
        }
        private Set<byte> GetSetInRange(PosPoint pos1, PosPoint pos2)
        {
            Set<byte> set = new Set<byte>();
            for (int i = pos1.i; i <= pos2.i; i++)
            {
                for (int j = pos1.j; j <= pos2.j; j++)
                {
                    if (matrix[i, j].value != 0)
                    {
                        set.Add(matrix[i, j].value);
                    }
                }
            }
            return set;
        }
        private Set<byte> GetSetHorizontalLine(int index)
        { return this.GetSetInRange(new PosPoint(index, 0), new PosPoint(index, size - 1)); }
        private Set<byte> GetSetVerticalLine(int index)
        { return this.GetSetInRange(new PosPoint(0, index), new PosPoint(size - 1, index)); }
        private Set<byte> GetSetSquare(PosSquare pos_s)
        { return this.GetSetInRange(new PosPoint(pos_s.i * 3, pos_s.j * 3), new PosPoint(pos_s.i * 3 + 2, pos_s.j * 3 + 2)); }
    }
}
