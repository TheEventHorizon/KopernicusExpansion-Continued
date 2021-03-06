﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace KopernicusExpansion
{
    namespace VertexHeightMap16
    {
        internal class Program
        {
            public static void Main(String[] args)
            {
                Console.WriteLine("Please make sure the following conditions are met: ");
                Console.WriteLine("    * The texture is a greyscale .raw file, with only one channel saved.");
                Console.WriteLine("    * The texture is 2 x 1");
                Console.WriteLine("    * The texture is exported with Macintosh byte order");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                // Load the texture
                if (args.Length == 0 || !File.Exists(args[0]))
                {
                    Console.WriteLine("ERROR: No texture found!");
                    return;
                }

                String texturePath = args[0];
                Byte[] data = File.ReadAllBytes(texturePath);


                // Create a new texture
                Int32 height = (Int32) Math.Sqrt(data.Length / 4d);
                Int32 width = 2 * height;
                Bitmap newImage = new Bitmap(width, height, PixelFormat.Format32bppArgb);
                for (Int32 x = 0; x < width; x++)
                {
                    for (Int32 y = 0; y < height; y++)
                    {
                        Int32 index = (y * width + x) * 2;
                        newImage.SetPixel(x, y, Color.FromArgb(data[index + 1], 0, data[index], 0));
                    }
                }

                // Save the new texture
                newImage.Save(texturePath + ".png", ImageFormat.Png);

                // We are done
                Console.WriteLine("Export finished! Path: " + texturePath + ".png");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}