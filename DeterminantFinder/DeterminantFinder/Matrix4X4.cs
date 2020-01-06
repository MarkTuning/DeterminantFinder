using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeterminantFinder
{
	class Matrix4X4
	{
		public int[,] matrix4X4 = new int[4, 4];
		public int number = 0;

		public Matrix4X4(int[,] matrix, int number, int x)
		{
			bool tempBool = false;
			if (Matrix5X5Determinant.addition)
			{
				this.number = number;
				Matrix5X5Determinant.addition = false;
			}
			else
			{
				this.number = -number;
				Matrix5X5Determinant.addition = true;
			}
			Fill4X4Matrix(matrix, x, tempBool);
		}

		private void Fill4X4Matrix(int[,] matrix, int x, bool tempBool)
		{
			for (int i = 1; i < 5; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					if (j == x)
					{
						tempBool = true;
					}
					else
					{
						this.matrix4X4[i - 1, (tempBool) ? j - 1 : j] = matrix[i, j];
					}
				}
				tempBool = false;
			}
		}
	}
}
