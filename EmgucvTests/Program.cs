using Emgu.CV;
using Emgu.CV.CvEnum;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Mat pic = new Mat();
        pic = CvInvoke.Imread("C:\\Users\\agha_\\Downloads\\cevizlik\\cevizlik\\46\\20\\2019-09-23-14-55-B1A862F8-BCF3-4147-9B70-835BB26A2049.tif");
        //pic = GetContentScaled(pic, 0.1, 0.1, 1, 1);



        //CvInvoke.Imshow("Image", pic);

        #region Blur
        Mat gauisanBlur = new Mat();
        CvInvoke.GaussianBlur(pic, gauisanBlur, new System.Drawing.Size(101, 101), 7.0);


        Mat gauisanBlurResize = new Mat();
        CvInvoke.Resize(gauisanBlur, gauisanBlurResize, new System.Drawing.Size(pic.Cols / 10, pic.Rows / 10) , 0, 0, Inter.Area);
        CvInvoke.Imshow("Gaussian Blur", gauisanBlurResize);

        /*
        Mat blur = new Mat();
        CvInvoke.Blur(pic, blur, new System.Drawing.Size(15, 15), new System.Drawing.Point());
        CvInvoke.Imshow("Blur", blur);


        Mat medianBlur = new Mat();
        CvInvoke.MedianBlur(pic, medianBlur, 15);
        CvInvoke.Imshow("Median Blur", medianBlur);


        Mat stackBlur = new Mat();
        CvInvoke.StackBlur(pic, stackBlur, new System.Drawing.Size(15, 15));
        CvInvoke.Imshow("Stack Blur", stackBlur);
        */
        #endregion

        CvInvoke.WaitKey();
    }

    private static Mat GetContentScaled(Mat src, double xScale, double yScale, double xTrans, double yTrans, Inter interpolation = Inter.Linear)
    {
        var dst = new Mat(src.Size, src.Depth, src.NumberOfChannels);
        var translateTransform = new Matrix<double>(2, 3)
        {
            [0, 0] = xScale, // xScale
            [1, 1] = yScale, // yScale
            [0, 2] = xTrans + (src.Width - src.Width * xScale) / 2.0, //x translation + compensation of  x scaling
            [1, 2] = yTrans + (src.Height - src.Height * yScale) / 2.0 // y translation + compensation of y scaling
        };
        CvInvoke.WarpAffine(src, dst, translateTransform, dst.Size, interpolation);

        return dst;
    }
}