using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeterminantFinder
{
	class Matrix3X3
	{
		public int[,] matrix3X3 = new int[3, 3];
		public int number = 0;
		public int determinant = 0;

		public Matrix3X3(int[,] matrix, int number, int x)
		{
			bool tempBool = false;
			this.number = number;
			Fill3X3Matrix(matrix, x, tempBool);
			this.determinant = Matrix5X5Determinant.DeterminantOf3X3Matrix(this.matrix3X3);
		}

		private void Fill3X3Matrix(int[,] matrix, int x, bool tempBool)
		{
			for (int i = 1; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					if (j == x)
					{
						tempBool = true;
					}
					else
					{
						this.matrix3X3[i - 1, (tempBool) ? j - 1 : j] = matrix[i, j];
					}
				}
				tempBool = false;
			}
		}
	}
}
