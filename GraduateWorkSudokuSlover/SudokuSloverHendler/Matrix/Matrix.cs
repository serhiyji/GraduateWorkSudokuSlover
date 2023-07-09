using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using GraduateWorkSudokuSlover.SudokuSloverHendler.Coordinates;
using PropertyChanged;

namespace GraduateWorkSudokuSlover.SudokuSloverHendler.Matrix
{
    [AddINotifyPropertyChangedInterface]
    public class Matrix<T> where T : new()
    {
        public T[,] matrix { get; set; }
        public const int size = 9;
        public Matrix(bool IsSetDefaultValues = true)
        {
            this.matrix = new T[size, size];
            if (IsSetDefaultValues)
            {
                SetDelfaultValues();
            }
        }
        public void SetDelfaultValues()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    System.Reflection.ConstructorInfo constructor = typeof(T).GetConstructor(Type.EmptyTypes);
                    T obj = ReferenceEquals(constructor, null) ? default : (T)constructor.Invoke(new object[0]);
                    matrix[i, j] = obj;
                }
            }
        }
        public void SetValue(PosPoint pos, T value)
        {
            matrix[pos.i, pos.j] = value;
        }
        public T this[int i, int j]
        {
            get
            {
                return matrix[i, j];
            }
            set
            {
                matrix[i, j] = value;
            }
        }
        public T this[PosPoint pos_p]
        {
            get
            {
                return matrix[pos_p.i, pos_p.j];
            }
            set
            {
                matrix[pos_p.i, pos_p.j] = value;
            }
        }
        private void SwapCollomsInMatrix(int col1, int col2)
        {
            if (col1 == col2) return;
            if (col1 < 0 || col2 < 0 || col1 > 8 || col2 > 8) return;
            for (int i = 0; i < 9; i++)
            {
                (this.matrix[i, col1], this.matrix[i, col2]) = (this.matrix[i, col2], this.matrix[i, col1]);
            }
        }
        private void SwapRowsInMatrix(int row1, int row2)
        {
            if (row1 == row2) return;
            if (row1 < 0 || row2 < 0 || row1 > 8 || row2 > 8) return;
            for (int i = 0; i < 9; i++)
            {
                (this.matrix[row1, i], this.matrix[row2, i]) = (this.matrix[row2, i], this.matrix[row1, i]);
            }
        }
        private void SwapColBlocksMatrix(int col1, int col2)
        {
            if(col1 == col2) return;
            if (col1 < 0 || col2 < 0 || col1 > 2 || col2 > 2) return;
            int icol1 = col1 * 3 + 2;
            for (int i = col1 * 3, j = col2 * 3; i <= icol1; i++, j++)
            {
                this.SwapCollomsInMatrix(i, j);
            }
        }
        private void SwapRowBlocksMatrix(int row1, int row2)
        {
            if (row1 == row2) return;
            if (row1 < 0 || row2 < 0 || row1 > 2 || row2 > 2) return;
            int irow1 = row1 * 3 + 2;
            for (int i = row1 * 3, j = row2 * 3; i <= irow1; i++, j++)
            {
                this.SwapRowsInMatrix(i, j);
            }
        }
        private int Rand(Random rand, int start, int stop, int not)
        {
            int val;
            do
            {
                val = rand.Next(start, stop);
            } while (val == not);
            return val;
        }
        public void ToMixMatrix()
        {
            Random random = new Random();
            for (int i = 0; i < 3; i++)
            {
                int jr = this.Rand(random, 0, 3, i);
                this.SwapRowBlocksMatrix(jr, i);
                int jc = this.Rand(random, 0, 3, i);
                this.SwapColBlocksMatrix(jc, i);
            }
            for (int block = 0; block < 3; block++)
            {
                int start = block * 3, stop = block * 3 + 3;
                for (int i = start; i < stop; i++)
                {
                    int jr = this.Rand(random, start, stop, i);
                    this.SwapRowsInMatrix(jr, i);
                    int jc = this.Rand(random, start, stop, i);
                    this.SwapCollomsInMatrix(jc, i);
                }
            }
        }
        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    res += matrix[i, j].ToString() + "  ";
                }
                res += "\n";
            }
            return res;
        }
    }
}
