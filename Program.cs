

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
            string[] gender = { "AAA", "TTT", "GGG", "CCC" };
            string DNA_text;
            string dna = null;
            /*Console.WriteLine("please enter the way you want to input ");
            string str_way = Console.ReadLine();
            int way = 0;
            bool flag1 = true;
            while (flag1)
            {
                if (!(int.TryParse(str_way, out way)))
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
                            if (!((Dna[i] == 'A') || (Dna[i] == 'C') || (Dna[i] == 'G') || (Dna[i] == 'T')))
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
            }*/
            //op6
            Console.WriteLine("enter the dna code ");
            dna = Console.ReadLine();
            char[] Dna = dna.ToCharArray();
            for (int i = 0; i < Dna.Length; i++)
            {
                if (!((Dna[i] == 'A') || (Dna[i] == 'C') || (Dna[i] == 'G') || (Dna[i] == 'T')|| (Dna[i]==' ')))
                {
                    Console.WriteLine("you DNA structure is wrong");
                }
            }

             for ( int i = 0; i < Dna.Length; i++)
            {
                if (Dna[i] == 'A')
                    Dna[i] = 'T';
                else if (Dna[i] == 'T')
                    Dna[i] = 'A';
                else if (Dna[i] == 'G')
                    Dna[i] = 'C';
                else if (Dna[i] == 'C')
                    Dna[i] = 'G';
                Console.Write(Dna[i]);
                }
            //op7
            int sta = 0;
            string[] dna_codons = new string[50];
            string codon;
            Console.WriteLine("enter the dna code ");
            string dnav = Console.ReadLine();
            char[] Dna_string = dnav.ToCharArray();

            int h = 0;
            int k = 0;
            Console.Write("DNA strand  : " + " ");
            for (int i = sta; i < Dna_string.Length; i += 3)
            {
                codon = Convert.ToString(Dna_string[i]) + Convert.ToString(Dna_string[i + 1]) + Convert.ToString(Dna_string[i + 2]);
                dna_codons[h] = codon;
                Console.Write(dna_codons[h]+" ");
                h++;
            }
            Console.Write("\n" + "Amino Acids : " + " ");
            for (int i = sta; i < Dna_string.Length; i += 3)
            {
                codon = Convert.ToString(Dna_string[i]) + Convert.ToString(Dna_string[i + 1]) + Convert.ToString(Dna_string[i + 2]);
                dna_codons[k] = codon;
                if (codon == "ATG")
                    Console.Write("" + "Met" + " ");
                else if (codon == "GCT" || codon == "GCC" || codon == "GCA" || codon == "GCG")
                    Console.Write("" + "ALA" + " ");
                else if (codon == "GAT" || codon == "GAC")
                    Console.Write("" + "ASP" + " ");
                else if (codon == "ACT" || codon == "ACC" || codon == "ACA" || codon == "ACG")
                    Console.Write("" + "THR" + " ");
                else if (codon == "CGT" || codon == "CGC" || codon == "CGA" || codon == "CGG" || codon == "AGA" || codon == "AGG")
                    Console.Write("" + "ARG" + " ");
                else if (codon == "AAT" || codon == "AAC")
                    Console.Write("" + "ASN" + " ");
                else if (codon == "TGT" || codon == "TGC")
                    Console.Write("" + "CYS" + " ");
                else if (codon == "CAA" || codon == "CAG")
                    Console.Write("" + "GLN" + " ");
                else if (codon == "GLU" || codon == "GAG")
                    Console.Write("" + "GLU" + " ");
                else if (codon == "GGT" || codon == "GGC" || codon == "GGA" || codon == "GGG")
                    Console.Write("" + "GLY" + " ");
                else if (codon == "CAT" || codon == "CAC")
                    Console.Write("" + "HİS" + " ");
                else if (codon == "ATT" || codon == "ATC" || codon == "ATAA")
                    Console.Write("" + "ILE" + " ");
                else if (codon == "CTT" || codon == "CTC" || codon == "CTA" || codon == "CTG" || codon == "TTA" || codon == "TTG")
                    Console.Write("" + "LEU" + " ");
                else if (codon == "AAA" || codon == "AAG")
                    Console.Write("" + "LYS" + " ");
                else if (codon == "TTT" || codon == "TTC")
                    Console.Write("" + "PHE" + " ");
                else if (codon == "CCT" || codon == "CCC" || codon == "CCA" || codon == "CCG")
                    Console.Write("" + "PRO" + " ");
                else if (codon == "TCT" || codon == "TCC" || codon == "TCA" || codon == "TCG" || codon == "AGT" || codon == "AGC")
                    Console.Write("" + "SER" + " ");
                else if (codon == "TGG")
                    Console.Write("" + "TRP" + " ");
                else if (codon == "TAC" || codon == "TAT")
                    Console.Write("" + "TYR" + " ");
                else if (codon == "GTT" || codon == "GTC" || codon == "GTA" || codon == "GTG")
                    Console.Write("" + "VAL" + " ");
                else if (codon == "TAA" || codon == "TGA" || codon == "TAG")
                    Console.Write("" + "END" + " ");
                k++;
            }



            //op8
            int beg = 0;
            string[] dna_codonss = new string[50];
            string codonn;

            string dnay = Console.ReadLine();
            char[] Dna_stringg = dnay.ToCharArray();

            int j = 0;
            Console.Write("DNA strand (stage 1) : " + " ");
            for (int i = beg; i < Dna_string.Length; i += 3)
            {
                codon = Convert.ToString(Dna_string[i]) + Convert.ToString(Dna_string[i + 1]) + Convert.ToString(Dna_string[i + 2]);
                dna_codons[j] = codon;
                Console.Write(dna_codons[j] + " ");
                j++;
            }
            Console.WriteLine("\n" + "Number of codons:" + j);
            Console.WriteLine("how many codons will you delete?");
            int delete = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("From which codon will you start the deletion?");
            int start = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < start - 1; i++)
            {
                codon = Convert.ToString(Dna_string[i]) + Convert.ToString(Dna_string[i + 1]) + Convert.ToString(Dna_string[i + 2]);
                dna_codons[j] = codon;
                Console.Write(dna_codons[i] + " ");
            }
            for (int i = start + delete - 1; i < j; i++)
            {
                codon = Convert.ToString(Dna_string[i]) + Convert.ToString(Dna_string[i + 1]) + Convert.ToString(Dna_string[i + 2]);
                dna_codons[j] = codon;
                Console.Write(" " + dna_codons[i] + " ");
            }





        }     
    }
}
