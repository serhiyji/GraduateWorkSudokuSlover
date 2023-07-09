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
        public int GetCountValues()
        {
            int total = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    total += (matrix[i, j].value != 0) ? 1 : 0;
                }
            }
            return total;
        }
        private int GetNullValues(PosPoint pos1, PosPoint pos2)
        {
            int count = 0;
            for (int i = pos1.i; i <= pos2.i; i++)
            {
                for (int j = pos1.j; j <= pos2.j; j++)
                {
                    if (this.matrix[i, j].value == 0)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private bool IsOneNullInRange(PosPoint pos1, PosPoint pos2)
        {
            return this.GetNullValues(pos1, pos2) == 1;
        }
        public bool IsOneNullInHorizontalLine(int index)
        { return this.IsOneNullInRange(new PosPoint(index, 0), new PosPoint(index, size - 1)); }
        public bool IsOneNullInVerticallLine(int index)
        { return this.IsOneNullInRange(new PosPoint(0, index), new PosPoint(size - 1, index)); }
        public bool IsOneNullInSquare(PosSquare pos_s)
        { return this.IsOneNullInRange(new PosPoint(pos_s.i * 3, pos_s.j * 3), new PosPoint(pos_s.i * 3 + 2, pos_s.j * 3 + 2)); }

        public Set<byte> GetPossValueInPosPoint(PosPoint pos_p)
        { return new Set<byte>(this.matrix[pos_p.i, pos_p.j].set); }
        public bool IsNullInPosPoint(PosPoint pos_p)
        { return this.matrix[pos_p.i, pos_p.j].value == 0; }
        public bool IsPossibleValueInPos(PosPoint pos_p, byte value)
        { return this.matrix[pos_p.i, pos_p.j].set.Contains(value); }
        public bool IsOnePossibleValueInPosPoint(PosPoint pos_p)
        { return this.matrix[pos_p.i, pos_p.j].set.Count() == 1; }
        public byte GetFirstValueSetInPosPoint(PosPoint pos_p)
        { return this.matrix[pos_p.i, pos_p.j].set.Count > 0 ? this.matrix[pos_p.i, pos_p.j].set[0] : (byte)0; }

        private Arrange<PosPoint> GetPossPosPointsInRange(PosPoint pos1, PosPoint pos2, byte value)
        {
            Arrange<PosPoint> arr = new Arrange<PosPoint>();
            for (int i = pos1.i; i <= pos2.i; i++)
            {
                for (int j = pos1.j; j <= pos2.j; j++)
                {
                    if (matrix[i, j].value == 0)
                    {
                        if (this.matrix[i, j].set.Contains(value))
                        {
                            arr.Add(new PosPoint(i, j));
                        }
                    }
                }
            }
            return arr;
        }

        public Arrange<PosPoint> GetPossPosPointsInHorizontalLine(int index, byte value)
        { return this.GetPossPosPointsInRange(new PosPoint(index, 0), new PosPoint(index, size - 1), value); }
        public Arrange<PosPoint> GetPossPosPointsInVerticalLine(int index, byte value)
        { return this.GetPossPosPointsInRange(new PosPoint(0, index), new PosPoint(size - 1, index), value); }
        public Arrange<PosPoint> GetPossPosPointsInSquare(PosSquare pos_s, byte value)
        { return this.GetPossPosPointsInRange(new PosPoint(pos_s.i * 3, pos_s.j * 3), new PosPoint(pos_s.i * 3 + 2, pos_s.j * 3 + 2), value); }

        private byte GetCountPossiblePosPointInRange(PosPoint pos1, PosPoint pos2, byte value)
        {
            byte count = 0;
            for (int i = pos1.i; i <= pos2.i; i++)
            {
                for (int j = pos1.j; j <= pos2.j; j++)
                {
                    if (this.matrix[i, j].set.Contains(value))
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public byte GetCountPossiblePosPointInHorizontalLine(int index, byte value)
        { return this.GetCountPossiblePosPointInRange(new PosPoint(index, 0), new PosPoint(index, size - 1), value); }
        public byte GetCountPossiblePosPointInVerticalLine(int index, byte value)
        { return this.GetCountPossiblePosPointInRange(new PosPoint(0, index), new PosPoint(size - 1, index), value); }
        public byte GetCountPossiblePosPointInSquare(PosSquare pos_s, byte value)
        { return this.GetCountPossiblePosPointInRange(new PosPoint(pos_s.i * 3, pos_s.j * 3), new PosPoint(pos_s.i * 3 + 2, pos_s.j * 3 + 2), value); }

        private PosPoint GetOneNullPosPointInRange(PosPoint pos1, PosPoint pos2)
        {
            for (int i = pos1.i; i <= pos2.i; i++)
            {
                for (int j = pos1.j; j <= pos2.j; j++)
                {
                    if (this.matrix[i, j].value == 0)
                    {
                        return new PosPoint(i, j);
                    }
                }
            }
            return new PosPoint(0, 0);
        }

        public PosPoint GetPosPointNullHorizontalLine(int index)
        { return this.GetOneNullPosPointInRange(new PosPoint(index, 0), new PosPoint(index, size - 1)); }
        public PosPoint GetPosPointNullVerticalLine(int index)
        { return this.GetOneNullPosPointInRange(new PosPoint(0, index), new PosPoint(size - 1, index)); }
        public PosPoint GetPosPointNullSquare(PosSquare pos_s)
        { return this.GetOneNullPosPointInRange(new PosPoint(pos_s.i * 3, pos_s.j * 3), new PosPoint(pos_s.i * 3 + 2, pos_s.j * 3 + 2)); }

        private PosPoint GetFirstPossiblePosPointInRange(PosPoint pos1, PosPoint pos2, byte value)
        {
            for (int i = pos1.i; i <= pos2.i; i++)
            {
                for (int j = pos1.j; j <= pos2.j; j++)
                {
                    if (this.matrix[i, j].value == 0)
                    {
                        if (this.matrix[i, j].set.Contains(value))
                        {
                            return new PosPoint(i, j);
                        }
                    }
                }
            }
            return new PosPoint(0, 0);
        }

        public PosPoint GetFirstPossiblePosPointInHorizontalLine(int index, byte value)
        { return this.GetFirstPossiblePosPointInRange(new PosPoint(index, 0), new PosPoint(index, size - 1), value); }
        public PosPoint GetFirstPossiblePosPointInVerticalLine(int index, byte value)
        { return this.GetFirstPossiblePosPointInRange(new PosPoint(0, index), new PosPoint(size - 1, index), value); }
        public PosPoint GetFirstPossiblePosPointInSquare(PosSquare pos_s, byte value)
        { return this.GetFirstPossiblePosPointInRange(new PosPoint(pos_s.i * 3, pos_s.j * 3), new PosPoint(pos_s.i * 3 + 2, pos_s.j * 3 + 2), value); }

        private Arrange<PosPoint> GetPosPointsInRange(PosPoint pos1, PosPoint pos2)
        {
            Arrange<PosPoint> arr = new Arrange<PosPoint>();
            for (int i = pos1.i; i <= pos2.i; i++)
            {
                for (int j = pos1.j; j <= pos2.j; j++)
                {
                    if (matrix[i, j].value == 0)
                    {
                        arr.Add(new PosPoint(i, j));
                    }
                }
            }
            return arr;
        }
    }

}
