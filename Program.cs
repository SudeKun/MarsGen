using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsGen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string first_choise_string;
            int first_choise_int;
            bool f_choise=true,two_error=true;
            string DNA_text, dna = null;

            ///////////////////////////////////////////////////////////////////////////////////////////////////////
            string[] Ala = { "GCT", "GCC", "GCA", "GCG" };
            string[] Arg = { "CGT", "CGC", "CGA", "CGG", "AGA", "AGG" };
            string[] Asn = { "AAT", "AAC" };
            string[] Asp = { "GAT", "GAC" };
            string[] Cys = { "TGT", "TGC" };
            string[] Gln = { "CAA", "CAG" };
            string[] Glu = { "GAA", "GAG" };
            string[] Gly = { "GGT", "GGC", "GGA", "GGG" };
            string[] His = { "CAT", "CAC" };
            string[] Ile = { "ATT", "ATC", "ATA" };
            string[] Leu = { "CTT", "CTC", "CTA", "CTG", "TTA", "TTG" };
            string[] Lys = { "AAA", "AAG" };
            string[] Met = { "ATG" }; //START
            string[] Phe = { "TTT", "TTC" };
            string[] Pro = { "CCT", "CCC", "CCA", "CCG" };
            string[] Ser = { "TCT", "TCC", "TCA", "TCG", "AGT", "AGC" };
            string[] Thr = { "ACT", "ACC", "ACA", "ACG" };
            string[] Trp = { "TGG" };
            string[] Tyr = { "TAT", "TAC" };
            string[] Val = { "GTT", "GTC", "GTA", "GTG" };
            string[] Stp = { "TAA", "TGA", "TAG" }; //STOP
            string[] gender = { Lys[0], Phe[0], Gly[3], Pro[1] };
            ///////////////////////////////////////////////////////////////////////////////////////////////////////
            while (f_choise==true)
            {
                Console.WriteLine("Welcome to Project MarsGen!\nPlease select one of these to continue:");
                Console.WriteLine("1-Open a text file\n2-Write a strand\n3-Random generate a strand");
                Console.Write("Your choise:");
                first_choise_string = Console.ReadLine();
                if (int.TryParse(first_choise_string, out first_choise_int) == true) first_choise_int = Convert.ToInt32(first_choise_string);
                else { f_choise = true; Console.Clear(); }
                switch (first_choise_int)
                {
                    case 1:
                        //Console.Write("Please enter your text file name:");
                        //DNA_text=Console.ReadLine();
                        Console.Write("\nYour DNA: ");
                        DNA_text = "C:\\Users\\sudek\\Documents\\CENG1\\CME 1251\\Project 2\\MarsGen\\dna1.txt";
                        dna = File.ReadAllText(DNA_text);
                        char[] Dna_txt = dna.ToCharArray();
                        Console.WriteLine(dna);
                        f_choise = false;
                        break;
                    case 2:
                        /*while (two_error == true)
                        {*/
                            Console.WriteLine("Please enter your DNA code:");
                            dna = Console.ReadLine();
                            char[] Dna_string = dna.ToCharArray();
                            /*for (int i = 0; i < dna.Length; i++)
                            {
                                if (Dna_string[i] == 'A' || Dna_string[i] == 'C' || Dna_string[i] == 'T' || Dna_string[i] == 'G') { two_error = true; }
                            }
                            Console.WriteLine("Please write again!\nReminder:You can only use 'A' , 'T' , 'C' , 'G' "); 
                            two_error = false; 
                            Console.Clear();*/
                       // }
                        f_choise = false;
                        break;
                    case 3:
                        f_choise = false;
                        break;
                    default:
                        f_choise=true;
                        Console.Clear();
                        Console.WriteLine("Please enter 1,2 or 3!!\n\n");
                        break;
                }
            }
        }
    }
}
