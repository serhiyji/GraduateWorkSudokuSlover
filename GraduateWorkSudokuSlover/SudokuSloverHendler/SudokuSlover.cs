using GraduateWorkSudokuSlover.SudokuSloverHendler.Collections;
using GraduateWorkSudokuSlover.SudokuSloverHendler.Coordinates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkSudokuSlover.SudokuSloverHendler
{
    public class SudokuSlover
    {
        public BetterMatrix.BetterMatrix matrix { get; set; }
        private List<Func<Intersections>> solution_methods;
        public SudokuSlover(ref SudokuSloverHendler.BetterMatrix.BetterMatrix matrix)
        {
            this.matrix = matrix;
            this.matrix.SetPossibleValues();
            this.AddSolutionMethods();
        }
        private void AddSolutionMethods()
        {
            solution_methods = new List<Func<Intersections>>() 
            {
                new Func<Intersections>(this.Full_House),
                new Func<Intersections>(this.Naked_Single),
                new Func<Intersections>(this.Hidden_Single),
                new Func<Intersections>(this.Locked_Pair),
                new Func<Intersections>(this.Locked_Triple),
                new Func<Intersections>(this.Locked_Candidates_Type_Pointing),
                new Func<Intersections>(this.Locked_Candidates_Type_Claiming),
                new Func<Intersections>(this.Naked_Pair),
                new Func<Intersections>(this.Naked_Triple),
                new Func<Intersections>(this.Naked_Quadruple),
                new Func<Intersections>(this.Hidden_Pair),
                new Func<Intersections>(this.Hidden_Triple),
                new Func<Intersections>(this.Hidden_Quadruple),
            };
        }

        #region Intersections_Handler
        public static bool IsPosPointsInHorizontalLine(Arrange<PosPoint> arr)
        {
            if(arr.Count() == 1 || arr.Count() == 0) { return true; };
            bool total_i = true;
            for (int i = 0; i < arr.Count() - 1; i++)
            {
                total_i = ((arr[i].i == arr[i + 1].i) && total_i);
            }
            return total_i;
        }
        public static bool IsPosPointsInVerticalLine(Arrange<PosPoint> arr)
        {
            if (arr.Count() == 1 || arr.Count() == 0) { return true; };
            bool total_j = true;
            for (int i = 0; i < arr.Count() - 1; i++)
            {
                total_j = ((arr[i].j == arr[i + 1].j) && total_j);
            }
            return total_j;
        }
        public static bool IsOneSquareInArrPospoint(Arrange<PosPoint> arr)
        {
            if (arr.Count() == 1 || arr.Count() == 0) { return true; };
            bool total = true;
            for (int i = 0; i < arr.Count() - 1; i++)
            {
                total = (new PosSquare(arr[i]) == new PosSquare(arr[i + 1])) && total;
            }
            return total;
        }
        public bool Intersections_Handler(Intersections inter, bool pos = true, bool sq = true, bool lh = true, bool lv = true)
        {
            if (inter.IsSingleValue)
            {
                this.matrix.SetValue(inter.PosPointNewValue, inter.NewValue);
                return true;
            }
            else
            {
                bool total = false;
                if (pos && inter.IS.pos)
                {
                    for (int i = 0; i < inter.PosPoints.Count(); i++)
                    {
                        total = this.matrix.ClearValuesInSetInPosPoint(inter.PosPoints[i], this.matrix.GetPossValueInPosPoint(inter.PosPoints[i]) - inter.values) || total;
                    }
                }

                total = (sq && inter.IS.sq) ? (IsOneSquareInArrPospoint(inter.PosPoints)) ?
                    this.matrix.ClearValuesInSetInSquare(new PosSquare(inter.PosPoints[0]), inter.values, inter.PosPoints) || total : total : total;

                total = (lh && inter.IS.hl) ? (IsPosPointsInHorizontalLine(inter.PosPoints)) ?
                    this.matrix.ClearValuesInSetInHorizontalLine(inter.PosPoints[0].i, inter.values, inter.PosPoints) || total : total : total;

                total = (lv && inter.IS.vl) ? (IsPosPointsInVerticalLine(inter.PosPoints)) ?
                    this.matrix.ClearValuesInSetInVerticalLine(inter.PosPoints[0].j, inter.values, inter.PosPoints) || total : total : total;

                return total;
            }
            return false;
        }
        #endregion

        private Intersections Full_House()
        {
            // Horizontal Line
            for (int i = 0; i < 9; i++)
            {
                if (this.matrix.IsOneNullInHorizontalLine(i))
                {
                    PosPoint pos_p = this.matrix.GetPosPointNullHorizontalLine(i);
                    byte NewValue_ = this.matrix.GetFirstValueSetInPosPoint(pos_p);
                    if (NewValue_ == 0) continue;
                    return new Intersections()
                    {
                        algorithm = AlgorithmSudokuSlover.Full_House,
                        NameMethodSlover = "Full_House",
                        IsSingleValue = true,
                        NewValue = NewValue_,
                        PosPointNewValue = pos_p
                    };
                }
            }
            // Verticall Line
            for (int i = 0; i < 9; i++)
            {
                if (this.matrix.IsOneNullInVerticallLine(i))
                {
                    PosPoint pos_p = this.matrix.GetPosPointNullVerticalLine(i);
                    byte NewValue_ = this.matrix.GetFirstValueSetInPosPoint(pos_p);
                    if (NewValue_ == 0) continue;
                    return new Intersections()
                    {
                        algorithm = AlgorithmSudokuSlover.Full_House,
                        NameMethodSlover = "Full_House",
                        IsSingleValue = true,
                        NewValue = NewValue_,
                        PosPointNewValue = pos_p
                    };
                }
            }
            // Square
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    PosSquare pos_s = new PosSquare(i, j);
                    if (this.matrix.IsOneNullInSquare(pos_s))
                    {
                        PosPoint pos_p = this.matrix.GetPosPointNullSquare(pos_s);
                        byte NewValue_ = this.matrix.GetFirstValueSetInPosPoint(pos_p);
                        if (NewValue_ == 0) continue;
                        return new Intersections()
                        {
                            algorithm = AlgorithmSudokuSlover.Full_House,
                            NameMethodSlover = "Full_House",
                            IsSingleValue = true,
                            NewValue = NewValue_,
                            PosPointNewValue = pos_p
                        };
                    }
                }
            }
            return null;
        }
        private Intersections Naked_Single()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    PosPoint pos_p = new PosPoint(i, j);
                    if (this.matrix.IsNullInPosPoint(pos_p) && this.matrix.IsOnePossibleValueInPosPoint(pos_p))
                    {
                        byte NewValue_ = this.matrix.GetFirstValueSetInPosPoint(pos_p);
                        if (NewValue_ == 0) continue;
                        return new Intersections()
                        {
                            algorithm = AlgorithmSudokuSlover.Naked_Single,
                            NameMethodSlover = "Naked_Single",
                            IsSingleValue = true,
                            NewValue = NewValue_,
                            PosPointNewValue = pos_p
                        };
                    }
                }
            }
            return null;
        }
        private Intersections Hidden_Single()
        {
            for (byte value = 1; value < 10; value++)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (this.matrix.GetCountPossiblePosPointInHorizontalLine(i, value) == 1)
                    {
                        return new Intersections()
                        {
                            algorithm = AlgorithmSudokuSlover.Hidden_Single,
                            NameMethodSlover = "Hidden_Single",
                            IsSingleValue = true,
                            NewValue = value,
                            PosPointNewValue = this.matrix.GetFirstPossiblePosPointInHorizontalLine(i, value)
                        };
                    }
                }
                for (int i = 0; i < 9; i++)
                {
                    if (this.matrix.GetCountPossiblePosPointInVerticalLine(i, value) == 1)
                    {
                        return new Intersections()
                        {
                            algorithm = AlgorithmSudokuSlover.Hidden_Single,
                            NameMethodSlover = "Hidden_Single",
                            IsSingleValue = true,
                            NewValue = value,
                            PosPointNewValue = this.matrix.GetFirstPossiblePosPointInVerticalLine(i, value)
                        };
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (this.matrix.GetCountPossiblePosPointInSquare(new PosSquare(i, j), value) == 1)
                        {
                            return new Intersections()
                            {
                                algorithm = AlgorithmSudokuSlover.Hidden_Single,
                                NameMethodSlover = "Hidden_Single",
                                IsSingleValue = true,
                                NewValue = value,
                                PosPointNewValue = this.matrix.GetFirstPossiblePosPointInSquare(new PosSquare(i, j), value)
                            };
                        }
                    }
                }
            }
            return null;
        }
        private Intersections Locked_Pair()
        {
            for (int si = 0; si < 3; si++)
            {
                for (int sj = 0; sj < 3; sj++)
                {
                    PosSquare pos_s = new PosSquare(si, sj);
                    Intersections pair = this.matrix.GetLockedPairInSquare(pos_s);
                    if (!(pair is null))
                    {
                        return pair;
                    }
                }
            }
            return null;
        }
        private Intersections Locked_Triple()
        {
            for (int si = 0; si < 3; si++)
            {
                for (int sj = 0; sj < 3; sj++)
                {
                    PosSquare pos_s = new PosSquare(si, sj);
                    Intersections tripl = this.matrix.GetLockedTripleInSquare(pos_s);
                    if (!(tripl is null)) { return tripl; };
                }
            }
            return null;
        }
        private Intersections Locked_Candidates_Type_Pointing()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    PosSquare pos_s = new PosSquare(i, j);
                    for (byte value = 1; value < 10; value++)
                    {
                        int size_ = this.matrix.GetCountPossiblePosPointInSquare(pos_s, value);
                        if (size_ == 3 || size_ == 2)
                        {
                            Intersections intersection = new Intersections()
                            {
                                algorithm = AlgorithmSudokuSlover.Locked_Candidates_Type_Pointing,
                                NameMethodSlover = "Locked_Candidates_Type_Pointing",
                                IsSingleValue = false,
                                PosPoints = this.matrix.GetPossPosPointsInSquare(pos_s, value),
                                values = new Set<byte>(value),
                                IS = (false, false, true, true)
                            };
                            if (intersection.IsValid(this.matrix))
                            {
                                return intersection;
                            }
                        }
                    }
                }
            }
            return null;
        }
        private Intersections Locked_Candidates_Type_Claiming()
        {
            for (byte value = 1; value < 10; value++)
            {
                for (int i = 0; i < 9; i++)
                {
                    int count_h = this.matrix.GetCountPossiblePosPointInHorizontalLine(i, value);
                    if (count_h <= 3 && count_h >= 2)
                    {
                        Intersections intersection = new Intersections()
                        {
                            algorithm = AlgorithmSudokuSlover.Locked_Candidates_Type_Claiming,
                            NameMethodSlover = "Locked_Candidates_Type_Claiming",
                            IsSingleValue = false,
                            PosPoints = this.matrix.GetPossPosPointsInHorizontalLine(i, value),
                            values = new Set<byte>(value),
                            IS = (false, true, false, false)
                        };
                        if (intersection.IsValid(this.matrix))
                        {
                            return intersection;
                        }
                    }

                    int count_v = this.matrix.GetCountPossiblePosPointInVerticalLine(i, value);
                    if (count_v <= 3 && count_v >= 2)
                    {
                        Intersections intersection = new Intersections()
                        {
                            NameMethodSlover = "Locked_Candidates_Type_Claiming",
                            IsSingleValue = false,
                            PosPoints = this.matrix.GetPossPosPointsInVerticalLine(i, value),
                            values = new Set<byte>(value),
                            IS = (false, true, false, false)
                        };
                        if (intersection.IsValid(this.matrix))
                        {
                            return intersection;
                        }
                    }
                }
            }
            return null;
        }
        private Intersections Naked_Pair()
        {
            for (int i = 0; i < 9; i++)
            {
                Intersections pair_h = this.matrix.GetLockedPairInHorizontalLine(i);
                if (!(pair_h is null)) { return pair_h; }
                Intersections pair_v = this.matrix.GetLockedPairInVerticalLine(i);
                if (!(pair_v is null)) { return pair_v; }
            }
            return null;
        }
        private Intersections Naked_Triple()
        {
            for (int i = 0; i < 9; i++)
            {
                Intersections triple_h = this.matrix.GetLockedTripleInHorizontalLine(i);
                if (!(triple_h is null)) { return triple_h; }
                Intersections triple_v = this.matrix.GetLockedTripleInVerticalLine(i);
                if (!(triple_v is null)) { return triple_v; }
            }
            return null;
        }
        private Intersections Naked_Quadruple()
        {
            for (int i = 0; i < 9; i++)
            {
                Intersections quadruple_h = this.matrix.GetNakedQuadrupleInHorizontalLine(i);
                if (!(quadruple_h is null)) { return quadruple_h; }
                Intersections quadruple_v = this.matrix.GetNakedQuadrupleInVerticalLine(i);
                if (!(quadruple_v is null)) { return quadruple_v; }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Intersections quadruple_s = this.matrix.GetNakedQuadrupleInSquare(new PosSquare(i, j));
                    if (!(quadruple_s is null)) { return quadruple_s; }
                }
            }
            return null;
        }
        private Intersections Hidden_Pair()
        {
            for (int i = 0; i < 9; i++)
            {

                Intersections pair_h = this.matrix.GetHiddenPairInHorizontalLine(i);
                if (!(pair_h is null)) { return pair_h; }
                Intersections pair_v = this.matrix.GetHiddenPairInVerticalLine(i);
                if (!(pair_v is null)) { return pair_v; }
            }
            for (int si = 0; si < 3; si++)
            {
                for (int sj = 0; sj < 3; sj++)
                {
                    Intersections pair = this.matrix.GetHiddenPairInSquare(new PosSquare(si, sj));
                    if (!(pair is null)) { return pair; }
                }
            }
            return null;
        }
        private Intersections Hidden_Triple()
        {
            for (int i = 0; i < 9; i++)
            {
                Intersections triple_h = this.matrix.GetHiddenTripleInHorizontalLine(i);
                if (!(triple_h is null)) { return triple_h; };
                Intersections triple_v = this.matrix.GetHiddenTripleInVerticalLine(i);
                if (!(triple_v is null)) { return triple_v; };
            }
            for (int si = 0; si < 3; si++)
            {
                for (int sj = 0; sj < 3; sj++)
                {
                    Intersections triple = this.matrix.GetHiddenTripleInSquare(new PosSquare(si, sj));
                    if (!(triple is null)) { return triple; };
                }
            }
            return null;
        }
        private Intersections Hidden_Quadruple()
        {
            for (int i = 0; i < 9; i++)
            {
                Intersections quadruple_h = this.matrix.GetHiddenQuadrupleInHorizontalLine(i);
                if (!(quadruple_h is null)) { return quadruple_h; };
                Intersections quadruple_v = this.matrix.GetHiddenQuadrupleInVerticalLine(i);
                if (!(quadruple_v is null)) { return quadruple_v; };
            }
            for (int si = 0; si < 3; si++)
            {
                for (int sj = 0; sj < 3; sj++)
                {
                    Intersections quadruple_s = this.matrix.GetHiddenQuadrupleInSquare(new PosSquare(si, sj));
                    if(!(quadruple_s is null)) { return quadruple_s; };
                }
            }
            return null;
        }

        public Intersections NextSlover()
        {
            foreach (Func<Intersections> item in solution_methods)
            {
                Intersections intersection = item.Invoke();
                if (!(intersection is null))
                {
                    return intersection;
                }
            }
            return null;
        }
    }
}
