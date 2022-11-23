using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom.Compiler;

namespace tamrin
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
            string[] Met = { "ATG" };
            string[] Phe = { "TTT", "TTC" };
            string[] Pro = { "CCT", "CCC", "CCA", "CCG" };
            string[] Ser = { "TCT", "TCC", "TCA", "TCG", "AGT", "AGC" };
            string[] Thr = { "ACT", "ACC", "ACA", "ACG" };
            string[] Trp = { "TGG" };
            string[] Tyr = { "TAT", "TAC" };
            string[] Val = { "GTT", "GTC", "GTA", "GTG" };
            string[] Stp = { "TAA", "TGA", "TAG" };
            string[] gender = { "AAA", "TTT" , "GGG" , "CCC" };
            string DNA_text;
            string dna = null;
            Console.WriteLine("please enter the way you want to input ");
            string str_way = Console.ReadLine();
            int way = 0;
            bool flag1 = true;
            while (flag1)
            {
                if (!(int.TryParse(str_way , out way )))
                {
                    Console.WriteLine("the number should be an integer and between 1 and 3");
                    str_way = Console.ReadLine();
                }
                else if (!(way > 0 && way < 4))
                {
                    Console.WriteLine("the number must be between 1 and 3 ");
                    str_way = Console.ReadLine();
                }
                else
                {
                    flag1 = false;
                }
            }
            switch (way)
            {
                case 1:
                    {
                        DNA_text = @"c:\load dna1.txt";
                        dna = File.ReadAllText(DNA_text);
                        char[] Dna = new char[dna.Length];
                        for (int i = 0; i < dna.Length; i++)
                        {
                            Dna[i] = dna[i];
                        }
                        Console.WriteLine(Dna);
                        for (int i = 0; i < Dna.Length; i++)
                        {
                            if (!((Dna[i] == 'A') || (Dna[i] == 'C') || (Dna[i] == 'G') || (Dna[i] == 'T' )))
                            {
                                Console.WriteLine("you DNA structure is wrong");
                            }

                        }
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("enter the dna code ");
                        dna = Console.ReadLine();
                        char[] Dna = dna.ToCharArray();
                        for (int i = 0; i < Dna.Length; i++)
                        {
                            if (!((Dna[i] == 'A') || (Dna[i] == 'C') || (Dna[i] == 'G') || (Dna[i] == 'T')))
                            {
                                Console.WriteLine("you DNA structure is wrong");
                            }
                        }
                        break;
                    }
                case 3:
                    {
                        string mydna;
                        Random random = new Random();
                        random.Next(0, 5);
                        Console.WriteLine("please enter the gender operation you want ");
                        string op = Console.ReadLine();
                        mydna = "AGT" + gender[random.Next(0, gender.Length)] + gender[random.Next(0, gender.Length)] + Stp[random.Next(0, Stp.Length)];
                        char[] my_dna = mydna.ToCharArray();
                        bool flag2 = true;
                        if (op == "f")
                        {
                            while (flag2)
                            {
                                if (!(((my_dna[4] == 'A') || (my_dna[4] == 'T')) && ((my_dna[7] == 'A') || (my_dna[7] == 'T'))))
                                {
                                    mydna = "AGT" + gender[random.Next(0, gender.Length)] + gender[random.Next(0, gender.Length)] + Stp[random.Next(0, Stp.Length)];
                                    my_dna = mydna.ToCharArray();
                                }
                                else
                                {
                                    flag2 = false;
                                }
                            }
                            Console.WriteLine(my_dna);
                        }
                        else if (op == "m")
                        {
                            while (flag2)
                            {
                                if ((((my_dna[4] == 'A') || (my_dna[4] == 'T')) && ((my_dna[7] == 'A') || (my_dna[7] == 'T'))) && (!(((my_dna[4] == 'G') || (my_dna[4] == 'C')) && ((my_dna[7] == 'A') || (my_dna[7] == 'T')))))
                                {
                                    mydna = "AGT" + gender[random.Next(0, gender.Length)] + gender[random.Next(0, gender.Length)] + Stp[random.Next(0, Stp.Length)];
                                    my_dna = mydna.ToCharArray();
                                }
                                else
                                {
                                    flag2 = false;
                                }
                            }
                            Console.WriteLine(my_dna);
                        }
                        break;
                        }
                default:
                    {
                        Console.WriteLine(" sina");
                        break;
                    }
            }
            Console.ReadLine();
        }
    }
}
