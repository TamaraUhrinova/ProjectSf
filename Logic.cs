using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projectsf
{
    internal class Logic
    {
        private List<int> numbers;
        private string pathName;

        public Logic(){
            this.numbers = new List<int>();
            this.pathName = @"doplniť adresu"; // po spustení programu sa na tejto adrese vytvorí 6 filov
            this.createFiles(); 
            
            readFileToList($"{pathName}myFile1.txt"); 
            readFileToList($"{pathName}myFile2.txt");
            readFileToList($"{pathName}myFile3.txt");
            readFileToList($"{pathName}myFile4.txt");
            readFileToList($"{pathName}myFile5.txt"); 
            
            writeResult($"{pathName}result.txt"); 
        }
     

        /// <summary>
        /// method, which reads text from file, stores it in a string, split string into substrings based on commas, saves it into a list of numbers, converts it into integers and store it in a list
        /// </summary>
        /// <param name="pathName"></param>
        /// 

        private void readFileToList(string pathName) {
            string content = File.ReadAllText(pathName); 
            List<string> text = content.Split(',').ToList(); 
            
            foreach (var num in text) 
            {
               this.numbers.Add(int.Parse(num));
            }
        }


        /// <summary>
        /// method, which takes a list of numbers, sorts it, prints to a file with commas between each number
        /// </summary>
        /// <param name="pathName"></param>
        /// 

        private void writeResult(string pathName) {
            this.numbers.Sort();
            foreach (var num in this.numbers) {
                File.AppendAllText(pathName, num.ToString() + ",");
            }
        }



        /// <summary>
        /// method, which creates 5 input files, which each stores a list of random numbers from 1-100 with commas and 1 empty output file
        /// </summary>
        /// 

        private void createFiles(){
            string pathName;
            FileStream fs;
            for (int i = 1; i <= 5; i++)
            {
                Random rnd = new Random();
                pathName = $"{this.pathName}myFile{i}.txt"; 
                fs = File.Create(pathName); 
                fs.Close(); 

                for (int j = 1; j <= 10; j++) 
                {
                    File.AppendAllText(pathName, rnd.Next(1, 100).ToString()); 
                    if (j == 10) { break; } 
                    File.AppendAllText(pathName, ","); 
                }
            }
            pathName = $"{this.pathName}result.txt"; 
            fs = File.Create(pathName); 
            fs.Close();
        }
    }

}
