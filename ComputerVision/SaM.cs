using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ComputerVision
{
    public class SaM
    {
        public double x;
        public double y;
        public double width;
        public double height;
        public double avgR;
        public double avgG;
        public double avgB;
        public SaM(double x, double y, double width, double height, double avgR, double avgG, double avgB)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.avgR = avgR;
            this.avgG = avgG;
            this.avgB = avgB;
        }
    }
}
