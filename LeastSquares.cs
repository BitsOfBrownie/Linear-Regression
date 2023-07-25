using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Data.Text;

namespace Linear_Regression
{
    internal class LeastSquares
    {
        public Matrix<double> LeastSquaresMethod(Matrix<double> xMatrix, Matrix<double> yMatrix, out Matrix<double> aMatrix)
        {
            // A =(X^T X)^-1 X^T Y
            aMatrix = xMatrix.Transpose()*xMatrix;
            aMatrix = aMatrix.Inverse();
            aMatrix = aMatrix*(xMatrix.Transpose()*yMatrix);
            return aMatrix;
        }
        public Matrix<double> SquareOfErrorsMethod(Matrix<double> xMatrix, Matrix<double> yMatrix, Matrix<double> aMatrix, out Matrix<double> ErrorsMatrix, out double bias, out double slope)
        {
            // Getting error matrix
            bias = aMatrix[0, 0];
            slope = aMatrix[1, 0];
            ErrorsMatrix = (slope * xMatrix) + bias;

            return ErrorsMatrix;
        }
        public Matrix<double>SumOfSquareOfErrorsMethod(Matrix<double> yMatrix, Matrix<double> ErrorsMatrix, out Matrix<double> sseMatrix)
        {
            //SSE = E^T E
            sseMatrix = yMatrix - ErrorsMatrix;
            sseMatrix = sseMatrix.Transpose()*sseMatrix;
            return sseMatrix;
        }
    }
}
