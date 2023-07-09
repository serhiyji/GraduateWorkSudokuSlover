using System;
using System.Collections.Generic;

namespace GraduateWorkSudokuSlover.SudokuSloverHendler.Collections
{
    public class Arrange<T> : List<T>
    {
        public Arrange() : base() { }
        public Arrange(params T[] arrs) : base(arrs) { }
        public Arrange(params Arrange<T>[] arr)
        {
            foreach (Arrange<T> item in arr)
            {
                AddRange(item);
            }
        }
        public override bool Equals(object obj)
        {
            if (obj == null) { return false; }
            if (!(obj is Arrange<T>)) { return false; }
            Arrange<T> arr = (Arrange<T>)obj;
            if (arr.Count != Count) { return false; }
            arr.Sort();
            Sort();
            for (int i = 0; i < arr.Count; i++)
            {
                if (!EqualityComparer<T>.Default.Equals(arr[i], this[i]))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool operator ==(Arrange<T> arr1, Arrange<T> arr2)
        {
            if (arr1 is null || arr2 is null) { return false; }
            return arr1.Equals(arr2);
        }
        public static bool operator !=(Arrange<T> arr1, Arrange<T> arr2)
        {
            if (arr1 is null || arr2 is null) { return false; }
            return arr1.Equals(arr2);
        }
        public static Arrange<T> operator +(Arrange<T> arr1, Arrange<T> arr2)
        {
            return new Arrange<T>(arr1, arr2);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return string.Join(", ", this);
        }
    }
}
