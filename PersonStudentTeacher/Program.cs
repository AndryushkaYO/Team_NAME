using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PersonStudentTeacher
{
    class Program
    {
        public static void WriteExceptionMessage(Exception ex, string s)
        {
            Console.WriteLine($"Type: {s}\n\nMessage: {ex.Message}\n\nStackTrace: {ex.StackTrace}\n\nDate: {DateTime.Now.ToString()}");
            Console.WriteLine("\n\t-----------------------------------------------------------------------------\n");
        }
        static void Main(string[] args)
        {
            try
            {
                ExceptionsHandler.Do();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"ERROR 1: {e.Message}");
                WriteExceptionMessage(e, "ArgumentException");
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine($"ERROR 2: {e.Message}");
                WriteExceptionMessage(e, "DirectoryNotFoundException");
            }
            catch (PathTooLongException e)
            {
                Console.WriteLine($"ERROR 3: {e.Message}");
                WriteExceptionMessage(e, "PathTooLongException");
            }
            catch (IOException e) //FileNotFound is included here
            {
                Console.WriteLine($"ERROR 4: {e.Message}");
                WriteExceptionMessage(e, "IOException");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"ERROR 5: {e.Message}");
                WriteExceptionMessage(e, "FormatException");
            }
            catch (InvalidDataException e)
            {
                Console.WriteLine($"ERROR 6: {e.Message}");
                WriteExceptionMessage(e, "InvalidDataException");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"ERROR 7: {e.Message}");
                WriteExceptionMessage(e, "InvalidOperationException");
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR!!! " + e.Message);
                WriteExceptionMessage(e, "UnknownForMeException");
            }
            Console.ReadLine();
        }
    }   
}
