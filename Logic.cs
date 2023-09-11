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
            this.pathName = @"C:\Users\tamarau\Desktop\numberFiles/"; //chang
            this.createFiles();
            readFileToList($"{pathName}myFile1.txt");
            readFileToList($"{pathName}myFile2.txt");
            readFileToList($"{pathName}myFile3.txt");
            readFileToList($"{pathName}myFile4.txt");
            readFileToList($"{pathName}myFile5.txt"); 
            writeResult($"{pathName}result.txt");
        }

        private void readFileToList(string pathName) {
            string content = File.ReadAllText(pathName);
            List<string> text = content.Split(',').ToList();
            foreach (var num in text)
            {
               this.numbers.Add(int.Parse(num));
            }
        }

        private void writeResult(string pathName) {
            this.numbers.Sort();
            foreach (var num in this.numbers) {
                File.AppendAllText(pathName, num.ToString() + ",");
            }
        }





        /*-----------------------------------------------------------------------------*/
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
