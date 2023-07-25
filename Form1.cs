using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Data.Text;


namespace Linear_Regression
{
    public partial class Form1 : Form
    {   //creating Matracies
        Matrix<double> xMatrix;
        Matrix<double> xMatrix1;
        Matrix<double> yMatrix;
        Matrix<double> aMatrix;
        Matrix<double> ErrorsMatrix;
        Matrix<double> sseMatrix;
        double slope;
        double bias;

        public Form1()
        {
            InitializeComponent();
            chart1.Titles.Add("Linear regression");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // setting each matrix to read from a CSV or TXT file
           xMatrix  = DelimitedReader.Read<double>(@"C:\Users\j23b9\10975\Files\StockMKTopenDays2.txt", false, ",", false);
           xMatrix1 = DelimitedReader.Read<double>(@"C:\Users\j23b9\10975\Files\StockMKTopenDays.csv", false, ",", false);
           yMatrix = DelimitedReader.Read<double>(@"C:\Users\j23b9\10975\Files\MSFTdaily.csv", false, ",", false);

        }

        private void button1_Click(object sender, EventArgs e)
        {
           LeastSquares ls = new LeastSquares();
            //Getting Point and Slope
            ls.LeastSquaresMethod(xMatrix, yMatrix, out aMatrix);
            //Getting a matrix full of all the errors
            ls.SquareOfErrorsMethod(xMatrix1, yMatrix, aMatrix, out ErrorsMatrix,out bias, out slope);
            //Gettting sum of square of errors
            ls.SumOfSquareOfErrorsMethod(yMatrix, ErrorsMatrix, out sseMatrix);
            //showing Point and Slope as well as sum of Square of Errors
            textBox1.AppendText(aMatrix.ToString());
            textBox1.AppendText(sseMatrix.ToString());


        }

        private void button2_Click(object sender, EventArgs e)
        {
            LeastSquares ls = new LeastSquares();
            // adding microsoft points
            for (int i = 0; i < xMatrix1.ToArray().Length; i++)
            {
                chart1.Series["Microsoft Stock"].Points.AddXY(xMatrix1[i, 0], yMatrix[i, 0]);
            }
            //inputing the line from the point slope formula
            for (double x = 0; x <= 250; x++)
            {
                double y = bias + slope * x;
                chart1.Series["Regression Line"].Points.AddXY(x, y);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //using point slope for prediction
            double tempx =double.Parse(textBox2.Text);
            textBox1.AppendText(((slope * tempx)+ bias).ToString("F2"));
            textBox1.AppendText(" ");
        }
    }
}
