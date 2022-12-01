using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using System.Drawing;
using System.Reflection;

namespace MarsGen
{
    internal class Program
    {
        static string random_dna(string op)
        {
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

            string mydna;
            Random random = new Random();
            random.Next(0, 5);
            mydna = Met[0] + gender[random.Next(0, gender.Length)] + gender[random.Next(0, gender.Length)] + Stp[random.Next(0, Stp.Length)];
            char[] my_dna = mydna.ToCharArray();
            bool flag2 = true;
            if (op == "female" || op == "f")
            {
                while (flag2)
                {
                    if (!(((my_dna[4] == 'A') || (my_dna[4] == 'T')) && ((my_dna[7] == 'A') || (my_dna[7] == 'T'))))
                    {
                        mydna = Met[0] + gender[random.Next(0, gender.Length)] + gender[random.Next(0, gender.Length)] + Stp[random.Next(0, Stp.Length)];
                        my_dna = mydna.ToCharArray();
                    }
                    else
                    {
                        flag2 = false;
                    }
                }
            }
            else if (op == "male" || op == "m")
            {
                while (flag2)
                {
                    if (!(((my_dna[4] == 'A') || (my_dna[4] == 'T')) && ((my_dna[7] == 'G') || (my_dna[7] == 'C'))) && (!(((my_dna[4] == 'G') || (my_dna[4] == 'C')) && ((my_dna[7] == 'T') || (my_dna[7] == 'A')))))
                    {
                        mydna = Met[0] + gender[random.Next(0, gender.Length)] + gender[random.Next(0, gender.Length)] + Stp[random.Next(0, Stp.Length)];
                        my_dna = mydna.ToCharArray();
                    }
                    else
                    {
                        flag2 = false;
                    }
                }
            }
            else
            {
                bool flag_3 = true;
                while (flag_3)
                {
                    if (!((op == "male" || op == "female") || (op == "m" || op == "f")))
                    {
                        Console.WriteLine("Please write male (m) or female (f) for the operation ");
                        op = Console.ReadLine();
                    }
                    else
                    {
                        flag_3 = false;
                    }
                }

            }
            string[] gen_op = new string[53];

            for (int i = 0; i < my_dna.Length - 2; i = i + 3)
            {
                gen_op[i] = Convert.ToString(my_dna[i]) + Convert.ToString(my_dna[i + 1]) + Convert.ToString(my_dna[i + 2]);
            }
            int j = random.Next(1, 7);
            string add_dna, add_dna1;
            string[] a_acid = { Ala[random.Next(0, 4)], Arg[random.Next(0, 6)], Asn[random.Next(0, 2)], Asp[random.Next(0, 2)], Cys[random.Next(0, 2)], Gln[random.Next(0, 2)], Glu[random.Next(0, 2)], Gly[random.Next(0, 4)], His[random.Next(0, 2)], Ile[random.Next(0, 3)], Leu[random.Next(0, 6)], Lys[random.Next(0, 2)], Phe[random.Next(0, 2)], Pro[random.Next(0, 4)], Ser[random.Next(0, 6)], Thr[random.Next(0, 4)], Trp[random.Next(0, 1)], Tyr[random.Next(0, 2)], Val[random.Next(0, 4)] };
            for (int k = 0; k < j; k = k + 1)
            {
                add_dna1 = null;
                string add_dna2 = null;
                int h = random.Next(1, 7);
                for (int z = 0; z < h; z = z + 1)
                {
                    add_dna = a_acid[random.Next(1, 18)];
                    add_dna1 = add_dna1 + add_dna;
                    add_dna = null;
                }
                add_dna2 = Met[0] + add_dna1 + Stp[random.Next(0, 2)];
                mydna = mydna + add_dna2;
            }
            my_dna = mydna.ToCharArray();
            int a = 0;
            string final;
            string[] ch_final = new string[100];
            for (int i = 0; i < my_dna.Length - 2; i = i + 3)
            {
                final = Convert.ToString(my_dna[i]) + Convert.ToString(my_dna[i + 1]) + Convert.ToString(my_dna[i + 2]);
                ch_final[a] = final;
                a++;
            }
            return mydna;
        }
        static string[] make_codon(char[]Dna,int beg,bool gene_structure)
        {
            string codon="";

            string[] dna_codons = new string[(Dna.Length + 1) / 3];

            for (int k = 0; k < (Dna.Length + 1) / 3; k++)
            {
                for (int i = beg; i < beg + 3; i += 3)
                {
                    int g = i;
                    if (g + 2 > Dna.Length)
                    {
                        gene_structure = false;
                        break;
                    }
                    codon = Convert.ToString(Dna[i]) + Convert.ToString(Dna[i + 1]) + Convert.ToString(Dna[i + 2]);
                }
                dna_codons[k] = codon;
                beg += 3;
            }
            return dna_codons;
        }
        static string codon_to_dna(string[] array)
        {
            string result = string.Empty;
            foreach (var item in array)
            {
                result += item;
            }
            return result;
        }
        static void show(string dna)
        {
            int beg = 0;
            for (int k = 0; k < dna.Length / 3; k++)
            {
                /*if (dna.Length % 2 == 0)
                {
                    for (int i = beg; i < beg + 2; i++)
                    {
                        Console.Write(dna[i]);
                    }
                    Console.Write(" ");
                    beg += 2;
                }*/
                if (dna.Length % 3 == 0)
                {
                    for (int i = beg; i < beg + 3; i++)
                    {
                        Console.Write(dna[i]);
                    }
                    Console.Write(" ");
                    beg += 3;
                }
            }
        }
        static bool check(char[] DNA)
        {
            bool ch = true;
            for (int i = 0; i < DNA.Length; i++)
            {
                if (!((DNA[i] == 'A') || (DNA[i] == 'C') || (DNA[i] == 'G') || (DNA[i] == 'T')))
                {
                    ch = false;
                }
            }

            if (ch == false) { Console.WriteLine("Your DNA structure is wrong"); return false; }
            else if (ch == true) return true;
            else return false;
        }
        static string enter_dna(StreamReader dna_text)
        {
            string first_choise_string;
            int first_choise_int = 0;
            bool first_choise = true;
            string dna = "";

            while (first_choise == true)
            {
                Console.WriteLine("1-Open a text file\n2-Write a strand\n3-Random generate a strand");
                Console.Write("Your choise:");
                first_choise_string = Console.ReadLine();
                if (int.TryParse(first_choise_string, out first_choise_int) == true)
                    first_choise_int = Convert.ToInt32(first_choise_string);
                else
                {
                    first_choise = true;
                }
                switch (first_choise_int)
                {
                    case 1:
                        if (dna_text.EndOfStream)
                        {
                            Console.WriteLine("Sorry but your text file ended why don't you choose random DNA generator or adding your DNA by manually?");
                            //Console.Read();
                            first_choise = true;
                            break;
                        }
                        dna = dna_text.ReadLine().ToUpper();
                        if (check(dna.ToCharArray()) == false) first_choise = true;
                        else first_choise = false;
                        break;
                    case 2:
                        Console.Write("Enter the DNA Code:");
                        dna = Console.ReadLine().ToUpper();
                        if (check(dna.ToCharArray()) == false) first_choise = true;
                        else first_choise = false;
                        break;
                    case 3:
                        Console.Write("Please enter the gender operation you want (m) or (f):");
                        string op = Console.ReadLine().ToLower();
                        dna = random_dna(op);
                        first_choise = false;
                        break;
                    default:
                        first_choise = true;
                        Console.WriteLine("Please enter 1,2 or 3!!");
                        break;
                }
            }
            return dna;
        }
        static string blob_gender(string[] blob_codon)
        {
            string gender;
            if ( ((blob_codon[1] == "AAA" && blob_codon[2] == "TTT" ) || (blob_codon[1] == "TTT" && blob_codon[2] == "AAA") )|| ( (blob_codon[1] == "AAA" && blob_codon[2] == "AAA")|| (blob_codon[1] == "TTT" && blob_codon[2] == "TTT") ) ) gender = "XX";
            else if ( ((blob_codon[1] == "GGG" || blob_codon[1] == "CCC") && (blob_codon[2] == "TTT"|| blob_codon[2] == "AAA")) || ((blob_codon[2] == "GGG" || blob_codon[2] == "CCC") && (blob_codon[1] == "TTT" || blob_codon[1] == "AAA")) )
                gender = "XY";
            else gender = "none";
            return gender;
        }
        static double find_c_g(string[] codon,string[] faulty)
        {
            double count = 0;
            for (int index = 0; index < codon.Length; index++)
            {
                if ( ((codon[index] == faulty[0] || codon[index] == faulty[1]) || (codon[index] == faulty[2] || codon[index] == faulty[3])) || ((codon[index] == faulty[4] || codon[index] == faulty[5]) || (codon[index] == faulty[6] || codon[index] == faulty[7])) )
                {
                    if (((codon[index+1] == faulty[0] || codon[index + 1] == faulty[1]) || (codon[index + 1] == faulty[2] || codon[index + 1] == faulty[3])) || ((codon[index + 1] == faulty[4] || codon[index + 1] == faulty[5]) || (codon[index + 1] == faulty[6] || codon[index + 1] == faulty[7])))
                    {
                        if (((codon[index + 2] == faulty[0] || codon[index + 2] == faulty[1]) || (codon[index + 2] == faulty[2] || codon[index + 2] == faulty[3])) || ((codon[index + 2] == faulty[4] || codon[index + 2] == faulty[5]) || (codon[index + 2] == faulty[6] || codon[index + 2] == faulty[7])))
                        {
                            if (((codon[index + 3] == faulty[0] || codon[index + 3] == faulty[1]) || (codon[index + 3] == faulty[2] || codon[index + 3] == faulty[3])) || ((codon[index + 3] == faulty[4] || codon[index + 3] == faulty[5]) || (codon[index + 3] == faulty[6] || codon[index + 3] == faulty[7])))
                            {
                                count -= 2;
                            }
                            count += 3;
                        }
                    }
                }
            }
            return count;
        }
        static void Main(string[] args)
        {
            string DNA_text = "C:\\Users\\sudek\\Documents\\CENG1\\CME 1251\\Project 2\\MarsGen\\dna1.txt";
            StreamReader dna_text= File.OpenText(DNA_text);
            bool game = true;
            while (game == true)
            {

                string second_choise_string, codon = "";
                int second_choise_int = 0, beg = 0;
                bool second_choise = true, gene_structure = true;
                string dna = "";

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
                string[] faulty = { "GGG", "GCG", "GGC", "CGG", "CCG", "CGC", "GCC", "CCC" };
                ///////////////////////////////////////////////////////////////////////////////////////////////////////

                Console.WriteLine("Welcome to Project MarsGen!\nPlease select one of these to continue:");
                dna = enter_dna(dna_text);

                //////////////////////////////////////////////////////////////////////////////////////////////////
                char[] Dna = dna.ToCharArray();
                string[] dna_codons = new string[(dna.Length / 3)];
                dna_codons = make_codon(Dna, beg, gene_structure);

                //////////////////////////////////////////////////////////////////////////////////////////////////
                Console.WriteLine("You entered your DNA");
                while (second_choise == true)
                {
                    Console.Write("\nYour DNA:");
                    show(dna);
                    Console.WriteLine("\nPlease choose your operation:");
                    Console.WriteLine(
                        "4-Check DNA gene structure\n5-Check DNA of BLOB organism\n6-Produce complement of a DNA sequence\n7-Determine amino acids\n" +
                        "8-Delete codons\n9-Insert codons\n10-Find codons\n11-Reverse codons\n12-Find the number of genes in a DNA strand\n13-Find the shortest gene\n" +
                        "14-Find the longest gene\n15-Find the most repeated n-nucleotide sequence\n16-Hydrogen bond statistics for a DNA strand\n17-Simulate BLOB generations\n18-QUIT\n");
                    Console.Write("Your Operation:");
                    second_choise_string = Console.ReadLine();
                    if (int.TryParse(second_choise_string, out second_choise_int) == true)
                        second_choise_int = Convert.ToInt32(second_choise_string);
                    else
                    {
                        second_choise = true;
                        Console.Clear();
                    }

                    switch (second_choise_int)
                    {
                        case 4:
                            int index_first = 0, index_last = 0, flag = 0;
                            if (flag == 0)
                            {
                                if (dna_codons[0] != Met[0] || dna_codons[dna_codons.Length - 1] != Stp[0] && dna_codons[dna_codons.Length - 1] != Stp[1] && dna_codons[dna_codons.Length - 1] != Stp[2])
                                {
                                    flag = 1;
                                }
                                for (int i = 0; i < dna_codons.Length; i = i + 2)
                                {
                                    for (int y = i; y < dna_codons.Length; y += 2)
                                    {
                                        if (dna_codons[y] == Met[0])
                                        {
                                            index_first = y;
                                        }
                                        else if (dna_codons[y] == Stp[0] || dna_codons[y] == Stp[1] || dna_codons[y] == Stp[2])
                                        {
                                            index_last = y;
                                            if (index_last != dna_codons.Length - 1 && dna_codons[index_last + 2] != Met[0])
                                            {
                                                flag = 1;
                                            }
                                            else
                                            {
                                                for (int k = index_first + 2; k < index_last; k = k + 2)
                                                {
                                                    if (dna_codons[k] == Met[0] || dna_codons[k] == Stp[0] || dna_codons[k] == Stp[1] || dna_codons[k] == Stp[2])
                                                    {
                                                        flag = 1;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                for (int o = 0; o < dna_codons.Length; o = o + 2)
                                {
                                    if (dna_codons[o].Length % 3 != 0)
                                    {
                                        flag = 2;
                                    }
                                }
                            }
                            else
                            {
                                for (int o = 0; o < dna_codons.Length; o = o + 2)
                                {
                                    if (dna_codons[o].Length % 3 != 0)
                                    {
                                        flag = 2;
                                    }
                                }
                            }
                            Console.Write("DNA strand: ");
                            show(dna);
                            if (flag == 0)
                                Console.WriteLine("\nGene structure is OK.");
                            else if (flag == 1)
                                Console.WriteLine("\nGene structure error.");
                            else
                                Console.WriteLine("\nCodon structure error.");
                            Console.ReadLine();
                            second_choise = true;
                            break;
                        case 5:
                            int B_counter = 0;
                            //cinsiyet kodonlarını test ediyorum
                            string c1 = dna_codons[1];
                            string c2 = dna_codons[2];
                            bool control1 = false;
                            bool control2 = false;
                            bool control3 = false;
                            Console.Write("DNA strand: ");
                            show(dna);
                            Console.WriteLine();
                            if (!(((c1 == "AAA" || c1 == "TTT") && (c2 == "TTT" || c2 == "AAA")) || ((c1 == "AAA" || c1 == "GGG") && (c2 == "GGG" || c2 == "AAA")) || ((c1 == "CCC" || c1 == "AAA") && (c2 == "AAA" || c2 == "CCC")) || ((c1 == "TTT" || c1 == "GGG") && (c2 == "GGG" || c2 == "TTT")) || ((c1 == "TTT" || c1 == "CCC") && (c2 == "CCC" || c2 == "TTT"))))
                            {
                                Console.Write("Gender error. ");
                                control1 = true;
                            }
                            bool aa;
                            bool bb = true;
                            //kodon error
                            for (int i = 0; i < dna_codons.Length && bb == true; i += 2)
                            {
                                if (dna_codons[i] == Met[0])
                                {
                                    aa = true;
                                    for (int s = i + 2; s < dna_codons.Length && aa == true; s += 2)
                                    {
                                        if (dna_codons[s] == "TAA" || dna_codons[s] == "TGA" || dna_codons[s] == "TAG")
                                        {
                                            if (!((s - i) / 2 >= 1) || B_counter > 8)
                                            {
                                                Console.Write("Number of codons error.1 ");
                                                aa = false;
                                                bb = false;
                                                control2 = true;
                                            }
                                            else
                                            {
                                                B_counter++;
                                                aa = false;
                                            }

                                        }
                                    }
                                }
                                else if ((B_counter == 0 || B_counter == 1) && i == dna_codons.Length)
                                {
                                    Console.Write("Number of codons error2.");
                                    bb = false;
                                    control2 |= true;
                                }
                            }
                            bool cc;
                            int counter3 = 0;
                            //genes error
                            for (int i = 0; i < dna_codons.Length; i += 2)
                            {
                                cc = true;
                                if (dna_codons[i] == "ATG")
                                {
                                    for (int d = i + 2; d < dna_codons.Length && cc == true; d += 2)
                                    {
                                        if (dna_codons[d] == "TAA" || dna_codons[d] == "TGA" || dna_codons[d] == "TAG")
                                        {
                                            counter3++;
                                            cc = false;
                                        }
                                    }
                                }
                            }
                            if (counter3 < 2 || counter3 > 7)
                            {
                                Console.Write("Number of genes error.");
                                control3 = true;
                            }
                            if (control1 == false && control2 == false && control3 == false)
                            {
                                Console.Write("BLOB is OK.");
                            }
                            second_choise = true;
                            Console.ReadLine();
                            break;
                        case 6:
                            char[] complement = new char[dna.Length];
                            Console.WriteLine("DNA strand : " + dna);
                            Console.Write("Complement : ");
                            for (int i = 0; i < dna.Length; i++)
                            {
                                if (Dna[i] == 'A')
                                    complement[i] = 'T';
                                else if (Dna[i] == 'T')
                                    complement[i] = 'A';
                                else if (Dna[i] == 'G')
                                    complement[i] = 'C';
                                else if (Dna[i] == 'C')
                                    complement[i] = 'G';
                                Console.Write(complement[i]);
                            }
                            break;
                        case 7:
                            int h7 = 0;
                            int y7 = 0;
                            Console.Write("DNA strand  : ");
                            show(dna);
                            make_codon(Dna, 0, true);
                            Console.Write("\n" + "Amino Acids : " + " ");
                            for (int i = 0; i < Dna.Length; i += 3)
                            {
                                codon = Convert.ToString(Dna[i]) + Convert.ToString(Dna[i + 1]) + Convert.ToString(Dna[i + 2]);
                                dna_codons[y7] = codon;
                                if (codon == "ATG")
                                    Console.Write("" + "MET" + " ");
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
                                else if (codon == "GAA" || codon == "GAG")
                                    Console.Write("" + "GLU" + " ");
                                else if (codon == "GGT" || codon == "GGC" || codon == "GGA" || codon == "GGG")
                                    Console.Write("" + "GLY" + " ");
                                else if (codon == "CAT" || codon == "CAC")
                                    Console.Write("" + "HİS" + " ");
                                else if (codon == "ATT" || codon == "ATC" || codon == "ATA")
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
                                y7++;
                            }
                            break;
                        case 8:
                            string dna_codons8start = "";
                            string dna_codons8delete = "";
                            string dna_codons8;
                            char[] Dna_string8 = dna.ToCharArray();
                            Console.Write("DNA strand (stage 1) :");
                            show(dna);
                            for (int k = 0; k < 1; k++)
                            {
                                for (int i = 0; i < Dna_string8.Length; i += 3)
                                {
                                    codon = Convert.ToString(Dna[i]) + Convert.ToString(Dna[i + 1]) + Convert.ToString(Dna[i + 2]);
                                    dna_codons[k] = codon;
                                    Console.Write(dna_codons[k] + " ");
                                }
                            }
                            Console.Write("\nHow many codons will you delete?" + "  →" + "  Answer : ");
                            int delete = Convert.ToInt16(Console.ReadLine());
                            Console.Write("From which codonn will you start the deletion?" + "  →" + "  Answer : ");
                            int start = Convert.ToInt16(Console.ReadLine());
                            Console.Write("DNA strand (stage 2) : ");
                            for (int k = 0; k < 1; k++)
                            {
                                for (int i = 0; i < 3 * (start - 1); i += 3)
                                {
                                    codon = Convert.ToString(Dna[i]) + Convert.ToString(Dna[i + 1]) + Convert.ToString(Dna[i + 2]);
                                    dna_codons[k] = codon;
                                    string y = dna_codons[k];

                                    dna_codons8start = dna_codons8start + y;
                                }
                            }
                            for (int k = 0; k < 1; k++)
                            {
                                for (int i = 3 * (start + delete - 1); i < Dna_string8.Length; i += 3)
                                {
                                    codon = Convert.ToString(Dna[i]) + Convert.ToString(Dna[i + 1]) + Convert.ToString(Dna[i + 2]);
                                    dna_codons[k] = codon;
                                    string x = dna_codons[k];
                                    dna_codons8delete = dna_codons8delete + x;
                                }
                            }
                            dna_codons8 = dna_codons8start + dna_codons8delete;
                            dna = dna_codons8;
                            show(dna);
                            second_choise = true;
                            break;
                        case 9:
                            int mth_codon;
                            string add = "";
                            bool ad = true;

                            while (ad)
                            {
                                Console.Write("\nCodons you will add" + "  →" + "  Answer : ");
                                add = Console.ReadLine().ToUpper();
                                if (check(add.ToCharArray()) == false || int.TryParse(add, out mth_codon) == true)
                                {
                                    Console.WriteLine("Please use just A,C,T,G not other things!");
                                    ad = true;
                                }
                                else ad = false;
                            }

                            Console.Write("From which codon will you start the deletion?" + "  →" + "  Answer : ");
                            mth_codon = Convert.ToInt16(Console.ReadLine());
                            char[] added = new char[Dna.Length + add.Length];
                            char[] afteradd = new char[Dna.Length];

                            for (int i = 0; i < (mth_codon * 3); i++) added[i] = Dna[i];
                            for (int i = 0; i < add.Length; i++) added[i + (mth_codon * 3)] = add[i];
                            for (int i = (mth_codon * 3); i < Dna.Length; i++) afteradd[i] = Dna[i];
                            for (int i = (mth_codon * 3); i < (Dna.Length); i++) added[i + add.Length] = afteradd[i];

                            dna = new string(added);

                            second_choise = true;
                            break;

                        case 10:
                            string find3 = null;
                            int find_from;
                            Console.Write("\nCodons you want to find" + "  →" + "  Answer : ");
                            char[] find = Console.ReadLine().ToUpper().ToCharArray();
                            Console.Write("Starting point:");
                            find_from = Convert.ToInt32(Console.ReadLine());

                            string[] finding = new string[(find.Length)];
                            for (int k = 0; k < 1; k++)
                            {
                                for (int i = find_from * 3; i < find.Length; i += 3)
                                {
                                    if ((i + 2) > find.Length)
                                    {
                                        gene_structure = false;
                                        break;
                                    }
                                    find3 = Convert.ToString(find[i]) + Convert.ToString(find[i + 1]) +
                                            Convert.ToString(find[i + 2]);
                                    finding[k] = find3;
                                    Console.Write(" " + finding[k]);
                                }
                                if (find3 == null) Console.WriteLine("Result: -1");
                                else {
                                    find_from++;
                                    Console.WriteLine("Result: " + find_from);
                                }
                            }
                            second_choise = true;
                            break;
                        case 11:
                            int reverse_from, reverse;
                            string[] reversed = dna_codons;
                            string[] reversed_dna = new string[dna_codons.Length];
                            Console.WriteLine("Please enter position (from m th codon):");
                            reverse_from = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("How many codons do you want to reverse:");
                            reverse = Convert.ToInt32(Console.ReadLine());

                            if ((reverse_from + reverse) > dna_codons.Length || reverse_from < 0 || reverse < 0)
                            {
                                Console.WriteLine("ERROR,TRY AGAIN");
                            }

                            Array.Reverse(reversed);

                            for (int i = 0; i < dna_codons.Length; i++)
                            {
                                reversed_dna[i] = dna_codons[i];
                            }
                            second_choise = true;
                            break;
                        case 12:
                            int count_1 = 0, j = 0;
                            for (int i = 0; i < dna_codons.Length; i++)
                            {
                                if (dna_codons[i] == Met[0])
                                {
                                    for (j = i; j < dna_codons.Length; j++)
                                    {
                                        if (dna_codons[j] == Stp[0] || dna_codons[j] == Stp[1] || dna_codons[j] == Stp[2])
                                        {
                                            count_1++;
                                        }
                                    }
                                    i = j;
                                }
                            }
                            Console.WriteLine("Number of Gens : " + count_1);
                            Console.ReadLine();
                            second_choise = true;
                            break;
                        case 13:
                            int a = 0, count = 0, b = 0, pos = 0, c = 0;
                            int min = int.MaxValue;
                            string[] min_dna = new string[100];
                            while (a < dna_codons.Length)
                            {
                                if (dna_codons[a] == Met[0])
                                {
                                    b = a;
                                    count = 1;
                                    while (dna_codons[b] != Stp[0] && dna_codons[b] != Stp[1] && dna_codons[b] != Stp[2])
                                    {
                                        b++;
                                        count++;
                                    }
                                    if (count < min)
                                    {
                                        min = count;
                                        pos = a;
                                        c = 0;
                                        for (int i = a; i < b + 1; i++)
                                        {
                                            min_dna[c++] = dna_codons[i];
                                        }
                                    }

                                }
                                a++;
                            }
                            Console.WriteLine("Shortest gen : ");
                            for (int i = 0; i < c; i++)
                            {
                                Console.Write(min_dna[i] + " ");
                            }
                            Console.WriteLine();
                            Console.WriteLine("Number of Codons in the Gen : " + min);
                            Console.WriteLine("Position of the gen : " + (pos + 1));
                            Console.ReadLine();
                            second_choise = true;
                            break;
                        case 14:
                            a = 0; count = 0; b = 0; pos = 0; c = 0;
                            int max = int.MinValue;
                            string[] max_dna = new string[100];
                            while (a < dna_codons.Length)
                            {
                                if (dna_codons[a] == Met[0])
                                {
                                    b = a;
                                    count = 1;
                                    while (dna_codons[b] != Stp[0] && dna_codons[b] != Stp[1] && dna_codons[b] != Stp[2])
                                    {
                                        b++;
                                        count++;
                                    }
                                    if (count > max)
                                    {
                                        max = count;
                                        pos = a;
                                        c = 0;
                                        for (int i = a; i < b + 1; i++)
                                        {
                                            max_dna[c++] = dna_codons[i];
                                        }
                                    }

                                }
                                a++;
                            }
                            Console.WriteLine("Longest gen : ");
                            for (int i = 0; i < c; i++)
                            {
                                Console.Write(max_dna[i] + " ");
                            }
                            Console.WriteLine();
                            Console.WriteLine("Number of codons in the gen : " + max);
                            Console.WriteLine("Position of the gen : " + (pos + 1));
                            Console.ReadLine();
                            second_choise = true;
                            break;

                        case 15:
                            Console.Write("Enter number of nucletide :");
                            int icharDNAarray = 0;// counter of index of charDNAarray
                            int n = Convert.ToInt32(Console.ReadLine());
                            char[] Temp1 = new char[Dna.Length];
                            char[] Temp2 = new char[Dna.Length];
                            int iTemp = 0;
                            flag = 0;
                            int count_2 = 0;
                            int max_2 = 0;
                            char[] Max = new char[n];
                            int iMax = 0;
                            while (icharDNAarray < Dna.Length - n)
                            {

                                iTemp = 0;
                                int q = icharDNAarray;
                                count_2 = 0;
                                for (int m = q; m < n + q; m++)
                                {
                                    Temp1[iTemp++] = Dna[m];

                                }
                                q = q + n;

                                while (q < Dna.Length)
                                {
                                    if (Dna[q] == Temp1[0])
                                    {
                                        iTemp = 0;

                                        for (int m = q; m < n + q && m < Dna.Length; m++)
                                        {
                                            Temp2[iTemp++] = Dna[m];

                                        }
                                        flag = 0;
                                        for (int i = 0; i < n; i++)
                                            if (Temp1[i] == Temp2[i])
                                                flag++;
                                        if (flag == n)
                                        {
                                            q = q + n;
                                            count_2++;
                                        }
                                        else
                                            q++;
                                    }
                                    else
                                        q++;
                                }
                                if (count_2 > max_2)
                                {
                                    max_2 = count_2;
                                    iMax = 0;
                                    for (int i = icharDNAarray; i < n + icharDNAarray; i++)
                                        Max[iMax++] = Dna[i];
                                }


                                icharDNAarray++;

                            }// end of whileeeee

                            Console.Write("Most repeated sequence :");
                            for (int i = 0; i < n; i++)
                                Console.Write(Max[i]);
                            Console.WriteLine();
                            Console.WriteLine("Frequency:" + max_2);
                            Console.ReadLine();
                            Console.ReadLine();
                            second_choise = true;
                            break;
                        case 16:
                            int hydrogen_bonds_2 = 0, hydrogen_bonds_3 = 0;
                            for (int i = 0; i < Dna.Length; i++)
                            {
                                if (Dna[i] == 'A' || Dna[i] == 'T') hydrogen_bonds_2++;
                                else hydrogen_bonds_3++;
                            }

                            Console.WriteLine("Number of pairing with 2-hydrogen bonds: " + hydrogen_bonds_2);
                            Console.WriteLine("Number of pairing with 3-hydrogen bonds: " + hydrogen_bonds_3);
                            Console.WriteLine("Number of hydrogen bonds: " + ((hydrogen_bonds_2 * 2) + (hydrogen_bonds_3 * 3)));
                            second_choise = true;
                            break;

                        case 17:
                            Random random = new Random();
                            string dna1 = dna, dna2 = "", blob3_gender = "";
                            int blob3_length;
                            int blob3_length_count=0;
                            /*char[] blob1 = dna1.ToCharArray();
                            string[] blob1_codon = make_codon(blob1, 0, true);
                            string blob1_gender = blob_gender(blob1_codon);*/
                            gene_structure = true;
                            int generation = 1;
                            Console.Clear();
                            while (gene_structure)
                            {
                                char[] blob1 = dna1.ToCharArray();
                                string[] blob1_codon = make_codon(blob1, 0, true);
                                string blob1_gender = blob_gender(blob1_codon);
                                
                                if (generation == 1) {
                                    if (blob1_gender == "XY")
                                    {
                                        Console.WriteLine("Please enter the 2nd DNA (Female) :");
                                        dna2 = enter_dna(dna_text);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Please enter the 2nd DNA (Male) :");
                                        dna2 = enter_dna(dna_text);
                                    }
                                }
                                else
                                {
                                    if (blob1_gender == "XY") dna2 = random_dna("f");
                                    else if (blob1_gender == "XX") dna2 = random_dna("m");
                                }
                                char[] blob2 = dna2.ToCharArray();
                                string[] blob2_codon = make_codon(blob2, 0, true);
                                string blob2_gender = blob_gender(blob2_codon);

                                if(blob1_gender== blob2_gender) { Console.WriteLine("Sorry but you entered wrong gender. Please enter again!"); generation = 0; gene_structure = false; }
                                

                                if (blob1.Length == blob2.Length || (blob1.Length > blob2.Length)) blob3_length = blob1.Length;
                                else blob3_length = blob2.Length;
                                char[] blob3 = new char[blob3_length];
                                string[] blob3_codon = make_codon(blob3, 0, true);

                                for (int i = 0; i <= 4; i++)
                                {
                                    while (i < 2)
                                    {
                                        blob3_codon[i] = blob1_codon[i];
                                        i++;
                                    }
                                    while (i >= 2 && i < 4)
                                    {
                                        blob3_codon[i] = blob2_codon[i];
                                        i++;
                                    }
                                }
                                blob3_gender = blob_gender(blob3_codon);

                                bool gen = true;
                                int codon_int = 4;
                                bool first_blob = true;
                                bool second_blob = true;
                                while (first_blob || second_blob)
                                {

                                    try
                                    {
                                        while (gen)
                                        {

                                            blob3_codon[codon_int] = blob1_codon[codon_int];
                                            if ((blob1_codon[codon_int] == Stp[0] || blob1_codon[codon_int] == Stp[1]) || blob1_codon[codon_int] == Stp[2])
                                            {
                                                gen = false;
                                            }
                                            codon_int++;
                                        }
                                    }
                                    catch
                                    {
                                        first_blob = false;
                                    }
                                    int dna2_codon_int = codon_int;
                                    gen = true;
                                    bool starting = false;
                                    try
                                    {
                                        while (gen)
                                        {
                                            if (blob2_codon[dna2_codon_int] == Met[0])
                                            {
                                                starting = true;
                                            }
                                            if (starting)
                                            {
                                                blob3_codon[codon_int] = blob2_codon[dna2_codon_int];
                                                if (((blob2_codon[dna2_codon_int] == Stp[0] || blob2_codon[dna2_codon_int] == Stp[1]) || blob2_codon[dna2_codon_int] == Stp[2]))
                                                {
                                                    gen = false;
                                                }
                                                codon_int++;
                                            }
                                            dna2_codon_int++;
                                        }
                                    }
                                    catch
                                    {
                                        second_blob = false;
                                    }
                                }
                                if(generation >= 1 && generation<=20) Console.Write("Generation "+generation+"\nBLOB 1-" + blob1_gender + ":"+ dna1+"\nBLOB 2-"+ blob2_gender+ ":" + dna2);

                                

                                dna1 = codon_to_dna(blob3_codon);

                                double c_g=find_c_g(blob3_codon,faulty);
                                double ratio = (c_g * 100 / (double)blob3_codon.Length);

                                if (generation >= 1 && generation < 20)
                                {
                                    Console.Write("\nBLOB 3-" + blob3_gender + ":");
                                    show(dna1);
                                    Console.WriteLine("\nBLOB3 faulty codons ratio = " + ratio + "%");
                                }
                                if (ratio > 10)
                                {
                                    Console.WriteLine("Newborn dies. Generations are over.");
                                    gene_structure = false;
                                    second_choise = true;
                                    Console.ReadLine();
                                }
                                else if(generation==20) {
                                    Console.Clear();
                                    Console.WriteLine("Please wait for other test generations."); 
                                }
                                else if (generation >20 && generation < 100) Console.Write("+");
                                else if (generation == 100)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Generations continues after.");
                                    second_choise = true;
                                    gene_structure = false;
                                }
                                generation++;
                            }
                            break;
                        case 18:
                            second_choise = false;
                            Console.Clear();
                            string answer;
                            Console.WriteLine("Do you want to return main menu (m) or quit (q)?");
                            Console.Write("Answer:");
                            answer = Console.ReadLine().ToLower();
                            if ((answer == "main menu" || answer == "m") || (answer == "menu" || answer == "main"))
                                game = true;
                            else if (answer == "quit" || answer == "q")
                            {
                                game = false;
                            }
                            break;
                        default:
                            second_choise = true;
                            Console.Clear();
                            break;
                    }
                }
            }
        }
    }
}
