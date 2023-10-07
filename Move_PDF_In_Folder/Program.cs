using System;
using System.IO;

namespace Move_PDF_In_Folder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("MOVING EVERY FILE TO FOLDER");
            Console.WriteLine("-------------------------------");
            string input;
            do
            {
                Console.Write("Input the directory that you want to organize: ");
                string rootPath = Console.ReadLine();

                if (!Directory.Exists(rootPath))
                {
                    Directory.CreateDirectory(rootPath);
                }

                string[] pdfFiles = Directory.GetFiles(rootPath, "*.pdf");
                int movedFiles = 0;
                foreach (string pdfFile in pdfFiles)
                {
                    // Extract the file name without the extension.
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(pdfFile);

                    // Create a folder with the extracted file name.
                    string destinationFolder = Path.Combine(rootPath, fileNameWithoutExtension);

                    if (!Directory.Exists(destinationFolder))
                    {
                        Directory.CreateDirectory(destinationFolder);
                    }

                    try
                    {
                        // Move the PDF file into the corresponding folder.
                        string destinationFilePath =
                            Path.Combine(destinationFolder, Path.GetFileName(pdfFile).Replace('-', ' '));
                        File.Move(pdfFile, destinationFilePath);
                        Console.WriteLine($"Moved '{Path.GetFileName(pdfFile)}' to '{destinationFolder}'");
                        movedFiles++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error moving '{Path.GetFileName(pdfFile)}': {ex.Message}");
                    }
                    finally
                    {
                        Console.WriteLine($"Done. Total files moved: {movedFiles}");
                    }
                }

                Console.WriteLine("Do you want to try again? y/n");
                input = Console.ReadLine();
            } while (Convert.ToString(input).ToLower() != "n");
            


        }
    }
}
