using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeterminantFinder
{
	class Matrix5X5Determinant
	{
		public static bool addition = true;

		static void Main(string[] args)
		{
			int determinant = 0;
			List<Matrix4X4> matrix4X4 = new List<Matrix4X4>();
			List<Matrix3X3> matrix3X3 = new List<Matrix3X3>();
			int[,] matrix = new int[5, 5];

			Fill5X5Matrix(matrix);

			for (int i = 0; i < 5; i++)
			{
				matrix4X4.Add(new Matrix4X4(matrix, matrix[0, i], i));
			}

			foreach (Matrix4X4 tempMatrix in matrix4X4)
			{
				for (int i = 0; i < 4; i++)
				{
					matrix3X3.Add(new Matrix3X3(tempMatrix.matrix4X4, tempMatrix.number * tempMatrix.matrix4X4[0, i], i));
				}
			}

			addition = true;

			foreach (Matrix3X3 tempMatrix in matrix3X3)
			{
				if (addition)
				{
					determinant = determinant + tempMatrix.number * tempMatrix.determinant;
					addition = false;
				}
				else
				{
					determinant = determinant - tempMatrix.number * tempMatrix.determinant;
					addition = true;
				}
			}

			Console.WriteLine("Determinant of the matrix is " + determinant + ".");
		}

		public static void Fill5X5Matrix(int[,] matrix)
		{
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					matrix[i, j] = int.Parse(Console.ReadLine());
				}
			}
		}

		public static int DeterminantOf3X3Matrix(int[,] matrix)
		{
			int mainDiagonal = MainDiagonalOf3X3Matrix(matrix);
			int secondaryDiagonal = SecondaryDiagonalOf3X3Matrix(matrix);
			return mainDiagonal - secondaryDiagonal;
		}

		private static int MainDiagonalOf3X3Matrix(int[,] matrix)
		{
			int tempMultiplication = 1;
			int tempAddition = 0;

			for (int i = 0; i < 3; i++)
			{
				tempMultiplication = matrix[0, i % 3]*matrix[1, (i + 1) % 3]*matrix[2, (i + 2) % 3];
				tempAddition += tempMultiplication;
			}

			return tempAddition;
		}

		private static int SecondaryDiagonalOf3X3Matrix(int[,] matrix)
		{
			int tempMultiplication = 1;
			int tempAddition = 0;

			for (int i = 2; i >= 0; i--)
			{
				tempMultiplication = matrix[0, (i < 0) ? i + 3 : i] * matrix[1, (i - 1 < 0) ? i - 1 + 3 : i - 1] * matrix[2, (i - 2 < 0) ? i - 2 + 3 : i - 2];
				tempAddition += tempMultiplication;
				tempMultiplication = 1;
			}

			return tempAddition;
		}
	}
}
