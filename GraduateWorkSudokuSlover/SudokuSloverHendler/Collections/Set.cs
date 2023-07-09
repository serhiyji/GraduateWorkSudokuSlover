using System;
using System.Linq;

namespace GraduateWorkSudokuSlover.SudokuSloverHendler.Collections
{
    public class Set<T> : Arrange<T>
    {
        public Set() : base() { }
        public Set(params T[] arrs) : base(arrs) { }
        public Set(params Arrange<T>[] arr) : base(arr) { }
        public Set(params Set<T>[] arr) : base(arr) { }

        // Logic operators
        #region Logic operators
        // -
        public static Set<T> operator -(Set<T> set1, Set<T> set2)
        {
            Set<T> set = new Set<T>(set1);
            set.RemoveAll(i => set2.Contains(i));
            return set;
        }
        // +
        public static Set<T> operator +(Set<T> set1, Set<T> set2)
        {
            Set<T> temp = new Set<T>(set1);
            temp.AddRange(set2.Where(i => !set1.Contains(i)));
            return temp;
        }
        // *
        public static Set<T> operator *(Set<T> set1, Set<T> set2)
        {
            Set<T> temp = new Set<T>();
            temp.AddRange(set1.Where(i => set2.Contains(i)));
            return temp;
        }
        #endregion

        public override string ToString()
        {
            return string.Join("-", this);
        }
    }
}
