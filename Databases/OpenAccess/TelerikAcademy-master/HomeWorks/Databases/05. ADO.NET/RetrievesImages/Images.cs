using System;
using System.IO;
using System.Linq;
using System.Text;

namespace RetrievesImages
{
    public class Image
    {
        private readonly byte[] imageData;

        public Image(byte[] imageData)
        {
            this.imageData = imageData;
        }

        private string GetImageType(string headerCode)
        {
            if (headerCode.StartsWith("FFD8FFE0"))
            {
                return "JPG";
            }
            else if (headerCode.StartsWith("49492A"))
            {
                return "TIFF";
            }
            else if (headerCode.StartsWith("424D"))
            {
                return "BMP";
            }
            else if (headerCode.StartsWith("474946"))
            {
                return "GIF";
            }
            else if (headerCode.StartsWith("89504E470D0A1A0A"))
            {
                return "PNG";
            }

            throw new Exception("Unsupported data type");
        }

        private string GetHeaderInfo(int offset = 0)
        {
            StringBuilder sb = new StringBuilder();

            int maxBytesToRead = 8 + offset;
            for (int i = offset; i < maxBytesToRead; i++)
            {
                sb.Append(this.imageData[i].ToString("X2"));
            }

            return sb.ToString();
        }

        private int CalculateImageOffset()
        {
            /*
             * First two bytes are signature of the OLE header
             * 
             * Number of bytes in an OLE header:
             * 
             * JPG,JPEG - 224
             * BMP - 78
             * DOC - 85
             * PDF - 85
             * SNP - 74
             * 
             * IMPORTANT: At the current moment this code will work only for the
             * BMP objects, becouse offset is set to 78
             */

            int offset = 0;
            if (this.imageData[0] == 21 && this.imageData[1] == 28)
            {
                offset = 78;
            }

            return offset;
        }

        /// <summary>
        /// Write the image to file
        /// </summary>
        /// <param name="path">Full path to the filename including the name of the file but without the extension.</param>
        public void WriteToFile(string path)
        {

            int offset = this.CalculateImageOffset();
            string headerInfo = this.GetHeaderInfo(offset);
            string fileExtension = this.GetImageType(headerInfo);

            FileStream stream = File.OpenWrite(path + "." + fileExtension);
            using (stream)
            {
                stream.Write(this.imageData, offset, this.imageData.Length - offset);
            }
        }
    }
}