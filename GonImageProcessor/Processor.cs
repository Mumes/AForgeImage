using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Imaging;
using System.Drawing.Imaging;
using System.Drawing;

namespace GonImageProcessor
{
    public class ImgProcessor
    {
        float x;
        float y;
        Bitmap Img { get; set; }
        public float X { get; private set; }
        public float Y { get; private set; }
        public  ImgProcessor(Bitmap _img)
        {
            Img = _img;
        }
        public void calcCross()
        {
            FindBlobs();
           X= Img.Width / 2 - x;
           Y= Img.Height / 2 - y;
        }
        public void FindBlobs()
        {
            BlobCounterBase bc = new BlobCounter();
            bc.FilterBlobs = true;
            bc.MinWidth = 5;
            bc.MinHeight = 5;
            // process binary image
            bc.ProcessImage(Img);
            Blob[] blobs = bc.GetObjects(Img, false);
            x=blobs[0].CenterOfGravity.X;
            y = blobs[0].CenterOfGravity.Y;
        }
    }
}
