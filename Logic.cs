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
            this.pathName = @"C:\Users\tamarau\Desktop\numberFiles/"; 
            this.createFiles(); //vytvorí 5 vstupných a jeden výstupny file na adrese pathName  
            
            readFileToList($"{pathName}myFile1.txt"); //načítajú sa všetky čísla do jedného listu
            readFileToList($"{pathName}myFile2.txt");
            readFileToList($"{pathName}myFile3.txt");
            readFileToList($"{pathName}myFile4.txt");
            readFileToList($"{pathName}myFile5.txt"); 
            
            writeResult($"{pathName}result.txt"); //čísla sa v liste usporiadajú a vypíšu do výstupného file
        }

        private void readFileToList(string pathName) {
            string content = File.ReadAllText(pathName); //funkcia na načítanie textu z file do stringu
            List<string> text = content.Split(',').ToList(); // pomocný zoznam, funkcia split rozdelí na základe čiarok string do pola, ktorý funkciou ToList konvertujeme na zoznam
            
            foreach (var num in text) //pridáme všetky prvky zoznamu, ktoré konvertujeme na integer
            {
               this.numbers.Add(int.Parse(num));
            }
        }

        private void writeResult(string pathName) {
            this.numbers.Sort(); //funkcia na usporiadanie
            foreach (var num in this.numbers) { //pridáme každý prvok zo zonamu s čiarkou
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

                for (int j = 1; j <= 10; j++) //pridá 10 random čísel do filu
                {
                    File.AppendAllText(pathName, rnd.Next(1, 100).ToString()); 
                    if (j == 10) { break; } // výnimka, pri poslednom čísle nebola čiarka
                    File.AppendAllText(pathName, ","); //pridanie textu do file
                }
            }
            pathName = $"{this.pathName}result.txt"; 
            fs = File.Create(pathName); //vytvorenie výstupného file 
            fs.Close();
        }
    }

}
