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
        // Locked / Naked
        private Intersections GetLockedPairInRange(PosPoint pos1, PosPoint pos2)
        {
            Arrange<PosPoint> pos = this.GetPosPointsInRange(pos1, pos2);
            for (int i = 0; i < pos.Count(); i++)
            {
                for (int j = 0; j < pos.Count(); j++)
                {
                    if ((pos[i] != pos[j]) && (this.matrix[pos[i].i, pos[i].j].set == this.matrix[pos[j].i, pos[j].j].set) 
                        && (this.matrix[pos[i].i, pos[i].j].set.Count() == 2))
                    {
                        Intersections intersection = new Intersections()
                        {
                            algorithm = AlgorithmSudokuSlover.Locked_Pair,
                            NameMethodSlover = $"Locked Pair {new Arrange<PosPoint>(pos[i], pos[j])} : {this.GetPossValueInPosPoint(pos[i])}",
                            IsSingleValue = false,
                            PosPoints = new Arrange<PosPoint>(pos[i], pos[j]),
                            values = this.GetPossValueInPosPoint(pos[i])
                        };
                        if (intersection.IsValid(this))
                        {
                            return intersection;
                        }
                    }
                }
            }
            return null;
        }
        private Intersections GetLockedTripleInRange(PosPoint pos1, PosPoint pos2)
        {
            Arrange<PosPoint> pos = this.GetPosPointsInRange(pos1, pos2);
            for (int i1 = 0; i1 < pos.Count(); i1++)
            {
                for (int i2 = 0; i2 < pos.Count(); i2++)
                {
                    for (int i3 = 0; i3 < pos.Count(); i3++)
                    {
                        if (pos[i1] != pos[i2] && pos[i2] != pos[i3] && pos[i1] != pos[i3])
                        {
                            Set<byte> set1 = this.matrix[pos[i1].i, pos[i1].j].set;
                            Set<byte> set2 = this.matrix[pos[i2].i, pos[i2].j].set;
                            Set<byte> set3 = this.matrix[pos[i3].i, pos[i3].j].set;
                            Set<byte> all = set1 + set2 + set3;
                            if ((set1.Count() >= 2 && set1.Count() <= 3) && (set2.Count() >= 2 && set2.Count() <= 3) && (set3.Count() >= 2 && set3.Count() <= 3) && all.Count() == 3)
                            {
                                Intersections intersection = new Intersections()
                                {
                                    algorithm = AlgorithmSudokuSlover.Locked_Triple,
                                    NameMethodSlover = "Locked Triple",
                                    IsSingleValue = false,
                                    PosPoints = new Arrange<PosPoint>(pos[i1], pos[i2], pos[i3]),
                                    values = all
                                };
                                if (intersection.IsValid(this))
                                {
                                    return intersection;
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }
        // Naked
        private Intersections GetNakedQuadrupleInRange(PosPoint pos1, PosPoint pos2)
        {
            Arrange<PosPoint> pos = this.GetPosPointsInRange(pos1, pos2);
            for (int i1 = 0; i1 < pos.Count(); i1++)
            {
                for (int i2 = 0; i2 < pos.Count(); i2++)
                {
                    for (int i3 = 0; i3 < pos.Count(); i3++)
                    {
                        for (int i4 = 0; i4 < pos.Count(); i4++)
                        {
                            if (pos[i1] != pos[i2] && pos[i2] != pos[i3] && pos[i1] != pos[i3]
                             && pos[i3] != pos[i4] && pos[i1] != pos[i4] && pos[i2] != pos[i4])
                            {
                                Set<byte> set1 = this.matrix[pos[i1].i, pos[i1].j].set;
                                Set<byte> set2 = this.matrix[pos[i2].i, pos[i2].j].set;
                                Set<byte> set3 = this.matrix[pos[i3].i, pos[i3].j].set;
                                Set<byte> set4 = this.matrix[pos[i4].i, pos[i4].j].set;
                                Set<byte> all = set1 + set2 + set3 + set4;
                                if ((set1.Count() >= 2 && set1.Count() <= 4) && (set2.Count() >= 2 && set2.Count() <= 4)
                                 && (set3.Count() >= 2 && set3.Count() <= 4) && (set4.Count() >= 2 && set4.Count() <= 4) && all.Count() == 4)
                                {
                                    Intersections intersection = new Intersections()
                                    {
                                        algorithm = AlgorithmSudokuSlover.Naked_Quadruple,
                                        NameMethodSlover = "Naked Quadruple",
                                        IsSingleValue = false,
                                        PosPoints = new Arrange<PosPoint>(pos[i1], pos[i2], pos[i3], pos[i4]),
                                        values = all
                                    };
                                    if (intersection.IsValid(this))
                                    {
                                        return intersection;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }
        // Hidden
        private Intersections GetHiddenPairInRange(PosPoint pos1, PosPoint pos2)
        {
            for (byte num1 = 1; num1 < 10; num1++)
            {
                for (byte num2 = 1; num2 < 10; num2++)
                {
                    if (num1 != num2)
                    {
                        int count_num1 = this.GetCountPossiblePosPointInRange(pos1, pos2, num1), count_num2 = this.GetCountPossiblePosPointInRange(pos1, pos2, num2);
                        if (count_num1 == 2 && count_num2 == 2)
                        {
                            Arrange<PosPoint> arr1 = this.GetPossPosPointsInRange(pos1, pos2, num1), arr2 = this.GetPossPosPointsInRange(pos1, pos2, num2);
                            if (arr1 == arr2)
                            {
                                Intersections intersection = new Intersections()
                                {
                                    algorithm = AlgorithmSudokuSlover.Hidden_Pair,
                                    NameMethodSlover = "Hidden Pair",
                                    IsSingleValue = false,
                                    PosPoints = new Arrange<PosPoint>(arr1[0], arr1[1]),
                                    values = new Set<byte>(num1, num2),
                                    IsForcibly = (true, false, false, false),
                                };
                                if (intersection.IsValid(this))
                                {
                                    return intersection;
                                }
                            }
                        }
                    }

                }
            }
            return null;
        }
        private Intersections GetHiddenTripleInRange(PosPoint pos1, PosPoint pos2)
        {
            for (byte num1 = 0; num1 < 10; num1++)
            {
                for (byte num2 = 0; num2 < 10; num2++)
                {
                    for (byte num3 = 0; num3 < 10; num3++)
                    {
                        int count_num1 = this.GetCountPossiblePosPointInRange(pos1, pos2, num1);
                        int count_num2 = this.GetCountPossiblePosPointInRange(pos1, pos2, num2);
                        int count_num3 = this.GetCountPossiblePosPointInRange(pos1, pos2, num3);
                        if (num1 != num2 && num2 != num3 && num1 != num3 && count_num1 <= 3 && count_num1 >= 2 && count_num2 <= 3 && count_num2 >= 2 && count_num3 <= 3 && count_num3 >= 2)
                        {
                            Set<PosPoint> poss_num = new Set<PosPoint>(this.GetPossPosPointsInRange(pos1, pos2, num1)) + new Set<PosPoint>(this.GetPossPosPointsInRange(pos1, pos2, num2)) + new Set<PosPoint>(this.GetPossPosPointsInRange(pos1, pos2, num3));
                            if (poss_num.Count() == 3)
                            {
                                Set<byte> set_other = new Set<byte>();
                                Set<byte> values = new Set<byte>();
                                for (int i = pos1.i; i <= pos2.i; i++)
                                {
                                    for (int j = pos1.j; j <= pos2.j; j++)
                                    {
                                        PosPoint pos = new PosPoint(i, j);
                                        if (this.matrix[i, j].value == 0 && !poss_num.Contains(pos))
                                        {
                                            set_other += this.matrix[i, j].set;
                                        }
                                        if (poss_num.Contains(pos))
                                        {
                                            values += this.matrix[i, j].set;
                                        }
                                    }
                                }
                                values = values - set_other;
                                if (values.Count() == 3)
                                {
                                    Intersections intersection = new Intersections()
                                    {
                                        algorithm = AlgorithmSudokuSlover.Hidden_Triple,
                                        NameMethodSlover = "Hidden Triple",
                                        IsSingleValue = false,
                                        PosPoints = poss_num, 
                                        values = values
                                    };
                                    if (intersection.IsValid(this))
                                    {
                                        return intersection;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }
        private Intersections GetHiddenQuadrupleInRange(PosPoint pos1, PosPoint pos2)
        {
            for (byte num1 = 1; num1 < 10; num1++)
            {
                for (byte num2 = 1; num2 < 10; num2++)
                {
                    for (byte num3 = 1; num3 < 10; num3++)
                    {
                        for (byte num4 = 1; num4 < 10; num4++)
                        {
                            int count_num1 = this.GetCountPossiblePosPointInRange(pos1, pos2, num1);
                            int count_num2 = this.GetCountPossiblePosPointInRange(pos1, pos2, num2);
                            int count_num3 = this.GetCountPossiblePosPointInRange(pos1, pos2, num3);
                            int count_num4 = this.GetCountPossiblePosPointInRange(pos1, pos2, num4);
                            if (num1 != num2 && num2 != num3 && num1 != num3 && num1 != num4 && num2 != num4 && num3 != num4
                                && count_num1 <= 4 && count_num1 >= 2 && count_num2 <= 4 && count_num2 >= 2
                                && count_num3 <= 4 && count_num3 >= 2 && count_num4 <= 4 && count_num4 >= 2)
                            {
                                Set<PosPoint> poss_num = new Set<PosPoint>(this.GetPossPosPointsInRange(pos1, pos2, num1)) 
                                    + new Set<PosPoint>(this.GetPossPosPointsInRange(pos1, pos2, num2))
                                    + new Set<PosPoint>(this.GetPossPosPointsInRange(pos1, pos2, num3)) 
                                    + new Set<PosPoint>(this.GetPossPosPointsInRange(pos1, pos2, num4));
                                if (poss_num.Count() == 4)
                                {
                                    Set<byte> set_other = new Set<byte>();
                                    Set<byte> values = new Set<byte>();
                                    for (int i = pos1.i; i <= pos2.i; i++)
                                    {
                                        for (int j = pos1.j; j <= pos2.j; j++)
                                        {
                                            PosPoint pos = new PosPoint(i, j);
                                            if (this.matrix[i, j].value == 0 && !poss_num.Contains(pos))
                                            {
                                                set_other += this.matrix[i, j].set;
                                            }
                                            if (poss_num.Contains(pos))
                                            {
                                                values += this.matrix[i, j].set;
                                            }
                                        }
                                    }
                                    values = values - set_other;
                                    if (values.Count() == 4)
                                    {
                                        Intersections intersection = new Intersections()
                                        {
                                            algorithm = AlgorithmSudokuSlover.Hidden_Quadruple,
                                            NameMethodSlover = "Hidden Quadruple",
                                            IsSingleValue = false,
                                            PosPoints = poss_num, 
                                            values = values
                                        };
                                        if (intersection.IsValid(this))
                                        {
                                            return intersection;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }
    }
}
