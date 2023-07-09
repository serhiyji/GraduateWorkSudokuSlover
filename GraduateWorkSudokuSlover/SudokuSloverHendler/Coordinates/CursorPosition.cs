using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkSudokuSlover.SudokuSloverHendler.Coordinates
{
	public enum Side { Up, Down, Left, Right }
    public class CursorPosition
    {
		private int i;
		private int j;
		public int I
		{
			get { return i; }
			set { i = value; }
		}
		public int J
		{
			get { return j; }
			set { j = value; }
		}
		private SudokuSloverHendler.BetterMatrix.BetterMatrix matrix;
		public CursorPosition(ref SudokuSloverHendler.BetterMatrix.BetterMatrix matrix, int _i = 4, int _j = 4)
		{
			this.matrix = matrix;
			I = _i;
			J = _j;
			this.SetPosition(null);
		}
		public void SetPosition(Side? side)
		{
			matrix.matrix[I, J].IsSelected = false;
			try
			{
				switch (side)
				{
					case Side.Up:
						I = (I > 0) ? I - 1 : 8;
						break;
					case Side.Down:
						I = (I < 8) ? I + 1 : 0;
						break;
					case Side.Left:
						J = (J > 0) ? J - 1 : 8;
						break;
					case Side.Right:
						J = (J < 8) ? J + 1 : 0;
						break;
					default:
						break;
				}
			}
			catch (Exception)
			{

				throw;
			}
			matrix.matrix[I, J].IsSelected = true;
		}
	}
}
