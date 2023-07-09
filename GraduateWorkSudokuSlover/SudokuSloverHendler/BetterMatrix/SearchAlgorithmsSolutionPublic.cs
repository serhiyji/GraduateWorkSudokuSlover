using System;
using GraduateWorkSudokuSlover.SudokuSloverHendler.Coordinates;
using GraduateWorkSudokuSlover.SudokuSloverHendler.Matrix;
using GraduateWorkSudokuSlover.SudokuSloverHendler.Points;

namespace GraduateWorkSudokuSlover.SudokuSloverHendler.BetterMatrix
{
    public partial class BetterMatrix : Matrix<Point>
    {
        public Intersections GetLockedPairInHorizontalLine(int index)
        { return this.GetLockedPairInRange(new PosPoint(index, 0), new PosPoint(index, size - 1)); }
        public Intersections GetLockedPairInVerticalLine(int index)
        { return this.GetLockedPairInRange(new PosPoint(0, index), new PosPoint(size - 1, index)); }
        public Intersections GetLockedPairInSquare(PosSquare pos_s)
        { return this.GetLockedPairInRange(new PosPoint(pos_s.i * 3, pos_s.j * 3), new PosPoint(pos_s.i * 3 + 2, pos_s.j * 3 + 2)); }
        // Locked Triple
        public Intersections GetLockedTripleInHorizontalLine(int index)
        { return this.GetLockedTripleInRange(new PosPoint(index, 0), new PosPoint(index, size - 1)); }
        public Intersections GetLockedTripleInVerticalLine(int index)
        { return this.GetLockedTripleInRange(new PosPoint(0, index), new PosPoint(size - 1, index)); }
        public Intersections GetLockedTripleInSquare(PosSquare pos_s)
        { return this.GetLockedTripleInRange(new PosPoint(pos_s.i * 3, pos_s.j * 3), new PosPoint(pos_s.i * 3 + 2, pos_s.j * 3 + 2)); }
        // Hiden pair
        public Intersections GetHiddenPairInHorizontalLine(int index)
        { return this.GetHiddenPairInRange(new PosPoint(index, 0), new PosPoint(index, size - 1)); }
        public Intersections GetHiddenPairInVerticalLine(int index)
        { return this.GetHiddenPairInRange(new PosPoint(0, index), new PosPoint(size - 1, index)); }
        public Intersections GetHiddenPairInSquare(PosSquare pos_s)
        { return this.GetHiddenPairInRange(new PosPoint(pos_s.i * 3, pos_s.j * 3), new PosPoint(pos_s.i * 3 + 2, pos_s.j * 3 + 2)); }
        // Hiden Truple
        public Intersections GetHiddenTripleInHorizontalLine(int index)
        { return this.GetHiddenTripleInRange(new PosPoint(index, 0), new PosPoint(index, size - 1)); }
        public Intersections GetHiddenTripleInVerticalLine(int index)
        { return this.GetHiddenTripleInRange(new PosPoint(0, index), new PosPoint(size - 1, index)); }
        public Intersections GetHiddenTripleInSquare(PosSquare pos_s)
        { return this.GetHiddenTripleInRange(new PosPoint(pos_s.i * 3, pos_s.j * 3), new PosPoint(pos_s.i * 3 + 2, pos_s.j * 3 + 2)); }
        // Naked Quadruple
        public Intersections GetNakedQuadrupleInHorizontalLine(int index)
        { return this.GetNakedQuadrupleInRange(new PosPoint(index, 0), new PosPoint(index, size - 1)); }
        public Intersections GetNakedQuadrupleInVerticalLine(int index)
        { return this.GetNakedQuadrupleInRange(new PosPoint(0, index), new PosPoint(size - 1, index)); }
        public Intersections GetNakedQuadrupleInSquare(PosSquare pos_s)
        { return this.GetNakedQuadrupleInRange(new PosPoint(pos_s.i * 3, pos_s.j * 3), new PosPoint(pos_s.i * 3 + 2, pos_s.j * 3 + 2)); }
        // Hiden Quadruple
        public Intersections GetHiddenQuadrupleInHorizontalLine(int index)
        { return this.GetHiddenQuadrupleInRange(new PosPoint(index, 0), new PosPoint(index, size - 1)); }
        public Intersections GetHiddenQuadrupleInVerticalLine(int index)
        { return this.GetHiddenQuadrupleInRange(new PosPoint(0, index), new PosPoint(size - 1, index)); }
        public Intersections GetHiddenQuadrupleInSquare(PosSquare pos_s)
        { return this.GetHiddenQuadrupleInRange(new PosPoint(pos_s.i * 3, pos_s.j * 3), new PosPoint(pos_s.i * 3 + 2, pos_s.j * 3 + 2)); }
    }
}
