# Linear-Regression
This repository contains the code and dataset for a stock market predictor developed using linear regression techniques. The primary objective of this project is to provide a rudimentary framework to predict the direction of stock prices based on historical data. It's crucial to keep in mind that this is a simplistic predictive model and should not be used as a sole instrument for investment decisions.

if you would like to use this model you will need 3 .csv or .txt files. one of them with a single colomn matrix for the Y axis (I used daily stock prices for microsoft over the last year) then the other two files are the X axis. The X axis needs one file to just have the numbers you need and the other needs the be the same but a 2*n matrix with the first colomn as 1 so it should look like this 1,48 - 1,567 - 1,89. I will include 2 .csv and 1 .txt files for example

This model uses the Least Squares method to find the point and slope of the data and then creates a line best representing the trajectory of the numbers. The equation I used is A = (X^T X)^-1 X^T Y
 
