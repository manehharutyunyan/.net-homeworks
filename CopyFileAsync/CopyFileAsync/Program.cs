using System;
using System.IO;
using System.Threading.Tasks;

namespace CopyFileAsync
{
    class Program
    {
        static int readedBytes = 0;
        static long countOfReadedBytes = 0;
        static long fileSize = 0;

        /// <summary>
        ///  Writes a block of bytes to the file stream.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        static Task WriteToFile(byte[] buffer, int offset, int count, FileStream stream)
        {
            return Task.Run(() =>
            {
                stream.Write(buffer, offset, count);
            });
        }

        /// <summary>
        ///  Reads a block of bytes from the stream and writes the data in a given buffer.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        static Task<int> ReadFromFile(byte[] buffer, int offset, int count, FileStream stream)
        {
            return Task.Run(() =>
            {
                readedBytes = stream.Read(buffer, offset, count);
                countOfReadedBytes += readedBytes;
                return readedBytes;
            });
        }

        /// <summary>
        /// Copies one file contents to another file
        /// </summary>
        /// <param name="soursePath"></param>
        /// <param name="copyPath"></param>
        /// <returns></returns>
        public static async Task CopyFile(string soursePath, string copyPath)
        {
            using (FileStream stream = File.OpenRead(soursePath))
            using (FileStream writeStream = File.OpenWrite(copyPath))
            {
                byte[] buffer = new byte[5000];
                fileSize = stream.Length;

                int numBytesToRead = (int)stream.Length;
                do
                {
                    numBytesToRead -= readedBytes;
                    await ReadFromFile(buffer, 0, 1, stream).ConfigureAwait(false);
                    await WriteToFile(buffer, 0, 1, writeStream).ConfigureAwait(false);
                } while (numBytesToRead > 0);
            }
        }


        static void Main(string[] args)
        {
            string path = @"C:\Users\maneh_onrsjft\source\repos\Homeworks\CopyFileAsync";
            string sourceFile = "t.txt";
            string copyFile = "tCopy.txt";
            string sourcepath = Path.Combine(path, sourceFile);
            string copypath = Path.Combine(path, copyFile);

            CopyFile(sourcepath, copypath);
            while (fileSize != countOfReadedBytes)
            {
                 Console.WriteLine(countOfReadedBytes * 100 / fileSize + "%");
            }
        }
    }
}
