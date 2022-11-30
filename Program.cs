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
using System.Globalization;
using Microsoft.Win32.SafeHandles;

namespace MarsGen
{
    internal class Program
    {
        static string random_dna()
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
            Console.WriteLine("Please enter the gender operation you want ");
            string op = Console.ReadLine().ToLower();
            mydna = "AGT" + gender[random.Next(0, gender.Length)] + gender[random.Next(0, gender.Length)] + Stp[random.Next(0, Stp.Length)];
            char[] my_dna = mydna.ToCharArray();
            bool flag2 = true;
            if (op == "female" || op == "f")
            {
                while (flag2)
                {
                    if (!(((my_dna[4] == 'A') || (my_dna[4] == 'T')) && ((my_dna[7] == 'A') || (my_dna[7] == 'T'))))
                    {
                        mydna = "ATG" + gender[random.Next(0, gender.Length)] + gender[random.Next(0, gender.Length)] + Stp[random.Next(0, Stp.Length)];
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
                        mydna = "AGT" + gender[random.Next(0, gender.Length)] + gender[random.Next(0, gender.Length)] + Stp[random.Next(0, Stp.Length)];
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
                add_dna2 = "ATG" + add_dna1 + Stp[random.Next(0, 2)];
                mydna = mydna + add_dna2;
            }
            my_dna = mydna.ToCharArray();
            int a = 0;
            string final;
            //Console.WriteLine(my_dna);
            string[] ch_final = new string[100];
            for (int i = 0; i < my_dna.Length - 2; i = i + 3)
            {
                final = Convert.ToString(my_dna[i]) + Convert.ToString(my_dna[i + 1]) + Convert.ToString(my_dna[i + 2]);
                ch_final[a] = final;
                //Console.Write(ch_final[a] +" ");
                a++;
            }
            return mydna;
        }

        static void Main(string[] args)
        {
            string first_choise_string, second_choise_string, codon = "";
            int first_choise_int = 0, second_choise_int = 0, beg = 0;
            bool first_choise = true, second_choise = true, gene_structure = true;
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

            while (first_choise == true)
            {
                Console.WriteLine("Welcome to Project MarsGen!\nPlease select one of these to continue:");
                Console.WriteLine("1-Open a text file\n2-Write a strand\n3-Random generate a strand");
                Console.Write("Your choise:");
                first_choise_string = Console.ReadLine();
                if (int.TryParse(first_choise_string, out first_choise_int) == true) first_choise_int = Convert.ToInt32(first_choise_string);
                else { first_choise = true; Console.Clear(); }
                switch (first_choise_int)
                {
                    case 1:
                        //Console.Write("Please enter your text file name:");
                        //DNA_text=Console.ReadLine();
                        //DNA_text = @"c:\load dna1.txt";
                        DNA_text = @"C:\load dna1.txt";
                        dna = File.ReadAllText(DNA_text);
                        dna.ToUpper();

                        //Console.WriteLine(dna);
                        first_choise = false;
                        break;
                    case 2:
                        Console.WriteLine("enter the dna code ");
                        dna = Console.ReadLine();
                        dna.ToUpper();
                        char[] DNA = dna.ToCharArray();
                        for (int i = 0; i < DNA.Length; i++)
                        {
                            if (!((DNA[i] == 'A') || (DNA[i] == 'C') || (DNA[i] == 'G') || (DNA[i] == 'T')))
                            {
                                Console.WriteLine("you DNA structure is wrong");
                            }
                        }
                        first_choise = false;
                        break;

                    case 3:
                        dna = random_dna();
                        first_choise = false;
                        break;
                    default:
                        first_choise = true;
                        Console.Clear();
                        Console.WriteLine("Please enter 1,2 or 3!!\n\n");
                        break;
                }
            }
            //////////////////////////////////////////////////////////////////////////////////////////////////
            char[] Dna = dna.ToCharArray();
            for (int i = 0; i < dna.Length; i++)
            {
                Dna[i] = dna[i];
            }

            string[] dna_codons = new string[(Dna.Length + 1) / 3];
            //Console.WriteLine(dna_codons.Length);

            //Console.WriteLine(Dna);
            for (int i = 0; i < Dna.Length; i++)
            {
                if (!((Dna[i] == 'A') || (Dna[i] == 'C') || (Dna[i] == 'G') || (Dna[i] == 'T')))
                {
                    Console.Clear();
                    Console.WriteLine("Your DNA structure is wrong");
                }

            }

            Console.Write("\nYour DNA: ");
            for (int k = 0; k < (Dna.Length + 1) / 3; k++)
            {
                for (int i = beg; i < beg + 3; i += 3)
                {
                    int g = i;
                    if (g + 2 > Dna.Length) { gene_structure = false; break; }
                    codon = Convert.ToString(Dna[i]) + Convert.ToString(Dna[i + 1]) + Convert.ToString(Dna[i + 2]);
                }
                dna_codons[k] = codon;
                beg += 3;
            }
            for (int i = 0; i < dna_codons.Length; i++) Console.Write(dna_codons[i] + " ");
            Console.WriteLine("\n===>" + dna_codons[0]);
            Console.WriteLine(dna_codons.Length);
            //////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\n\nYou entered your DNA");
            while (second_choise == true)
            {
                Console.WriteLine("\nPlease choose your operation:\n");
                Console.WriteLine("4-Check DNA gene structure\n5-Check DNA of BLOB organism\n6-Produce complement of a DNA sequence\n7-Determine amino acids\n" +
                    "8-Delete codons\n9-Insert codons\n10-Find codons\n11-Reverse codons\n12-Find the number of genes in a DNA strand\n13-Find the shortest gene\n" +
                    "14-Find the longest gene\n15-Find the most repeated n-nucleotide sequence\n16-Hydrogen bond statistics for a DNA strand\n17-Simulate BLOB generations\n18-QUIT\n");
                Console.Write("Your Operation:");
                second_choise_string = Console.ReadLine();
                if (int.TryParse(second_choise_string, out second_choise_int) == true) second_choise_int = Convert.ToInt32(second_choise_string);
                else { second_choise = true; Console.Clear(); }
                switch (second_choise_int)
                {
                    case 4:
                        int start_codon = 0 , stop_codon = 0, index_first = 0 , index_last = 0 , flag = 0 ;
                        if (flag == 0)
                        {
                            if (dna_codons[0] != "ATG" || dna_codons[dna_codons.Length - 1] != "TAA" && dna_codons[dna_codons.Length - 1] != "TGA" && dna_codons[dna_codons.Length - 1] != "TAG")
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
                        for (int i = 0; i < dna_codons.Length; i++)
                            Console.Write(dna_codons[i]);
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
                        string c1 = dna_codons[2];
                        string c2 = dna_codons[4];
                        bool control1 = false;
                        bool control2 = false;
                        bool control3 = false;
                        Console.Write("DNA strand: ");
                        for (int i = 0; i < dna_codons.Length; i++)
                            Console.Write(dna_codons[i]);
                        Console.WriteLine();
                        if (!((c1 == "TTT" || c1 == "AAA") && (c2 == "TTT" || c2 == "AAA") || (c1 == "GGG" || c1 == "CCC") && c1 != c2 && (c2 == "CCC" || c2 == "GGG")))
                        {
                            Console.Write("Gender error. ");
                            control1 = true;
                        }
                        bool aa;
                        bool bb = true;
                        //kodon error
                        for (int i = 0; i < dna_codons.Length && bb == true; i += 2)
                        {
                            if (dna_codons[i] == "ATG")
                            {
                                aa = true;
                                for (int s = i + 2; s < dna_codons.Length && aa == true; s += 2)
                                {
                                    if (dna_codons[s] == "TAA" || dna_codons[s] == "TGA" || dna_codons[s] == "TAG")
                                    {
                                        if (!((s - i) / 2 > 1) || B_counter >= 8)
                                        {
                                            Console.Write("Number of codons error. ");
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
                                Console.Write("Number of codons error.");
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
                            Console.Write("BLOB is OK.");
                        second_choise = true;
                        Console.ReadLine();
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        Console.Write("DNA strand (stage 1) : " + " ");
                        for (int k = 0; k < 1; k++)
                        {
                            for (int i = beg; i < Dna.Length; i += 3)
                            {
                                codon = Convert.ToString(Dna[i]) + Convert.ToString(Dna[i + 1]) + Convert.ToString(Dna[i + 2]);
                                dna_codons[k] = codon;
                                Console.Write(dna_codons[k] + " ");
                            }
                        }
                        //Console.WriteLine("\n" + "Number of codons:" + k);
                        Console.WriteLine("how many codons will you delete?");
                        int delete = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("From which codonn will you start the deletion?");
                        int start = Convert.ToInt32(Console.ReadLine());
                        for (int k = 0; k < 1; k++)
                        {
                            for (int i = 0; i < start - 1; i++)
                            {
                                codon = Convert.ToString(Dna[i]) + Convert.ToString(Dna[i + 1]) + Convert.ToString(Dna[i + 2]);
                                dna_codons[k] = codon;
                                Console.Write(dna_codons[k] + " ");
                            }
                        }
                        for (int k = 0; k < 1; k++)
                        {
                            for (int i = start + delete - 1; i < k; i++)
                            {
                                codon = Convert.ToString(Dna[i]) + Convert.ToString(Dna[i + 1]) + Convert.ToString(Dna[i + 2]);
                                dna_codons[k] = codon;
                                Console.Write(dna_codons[k] + " ");
                            }
                        }
                        break;
                    case 9:
                        int mth_codon;
                        string added_codon;

                        Console.WriteLine("Please enter codons you want to add:");
                        char[] add = (Console.ReadLine().ToUpper()).ToCharArray();
                        Console.WriteLine("Please enter position (from m th codon):");
                        mth_codon = Convert.ToInt16(Console.ReadLine());

                        char[] added = new char[Dna.Length + add.Length]; // New DNA chain created and maken char.

                        for (int i = 0; i < 3 * mth_codon; i++) // Begginer DNA
                        {
                            added[i] = Dna[i];
                        }
                        for (int i = 0; i < add.Length; i++) // New  added codons
                        {
                            added[3 * mth_codon + i] = add[i];
                        }
                        for (int i = 3 * mth_codon; i < Dna.Length; i++) // Final DNA
                        {
                            added[3 * mth_codon + i] = Dna[i];
                        }

                        string[] dna_added = new string[(added.Length)];

                        for (int k = 0; k < 1; k++)
                        {
                            for (int i = beg; i < added.Length; i += 3)
                            {
                                if ((i + 2) > added.Length) { gene_structure = false; break; }
                                added_codon = Convert.ToString(added[i]) + Convert.ToString(added[i + 1]) + Convert.ToString(added[i + 2]);
                                dna_added[k] = added_codon;
                                Console.Write(" " + dna_added[k]);
                            }
                        }
                        second_choise = true;
                        break;

                    case 10:
                        string find3;
                        int find_from;
                        Console.Write("Please enter codon to find:");
                        char[] find = Console.ReadLine().ToUpper().ToCharArray();
                        Console.Write("Starting point:");
                        find_from = Convert.ToInt32(Console.ReadLine());

                        string[] finding = new string[(find.Length)];
                        for (int k = 0; k < 1; k++)
                        {
                            for (int i = beg; i < find.Length; i += 3)
                            {
                                if ((i + 2) > find.Length) { gene_structure = false; break; }
                                find3 = Convert.ToString(find[i]) + Convert.ToString(find[i + 1]) + Convert.ToString(find[i + 2]);
                                finding[k] = find3;
                                Console.Write(" " + finding[k]);
                            }
                        }
                        //int count = Array.IndexOf(dna_codons, finding);
                        //Console.WriteLine(count);

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

                        //for (int i = 0; i < dna_codons.Length; i++) Console.Write(reversed_dna[i] + " ");


                        second_choise = true;
                        break;

                    case 12:
                        int count_1 = 0 , j = 0;
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
                        Console.WriteLine("number of gens : " + count_1);
                        Console.ReadLine();
                        second_choise = true;
                        break;
                    case 13:
                        int a = 0 , count = 0 , b = 0 , pos = 0 , c = 0;
                        int min = int.MaxValue;
                        string[] min_dna = new string[100];
                        while(a < dna_codons.Length)
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
                                    for (int i = a ; i < b + 1; i++)
                                    {
                                        min_dna[c++] = dna_codons[i];
                                    }
                                }

                            }
                            a++;
                        }
                        Console.WriteLine("shortes gen : ");
                        for (int i = 0; i < c; i++)
                        {
                            Console.Write(min_dna[i] + " ");
                        }
                        Console.WriteLine();
                        Console.WriteLine("nuber of codons in the gen : " + min);
                        Console.WriteLine("position of the gen : " + (pos + 1));
                        Console.ReadLine();
                        second_choise = true;
                        break;
                    case 14:
                        a = 0;
                        count = 0;
                        b = 0;
                        pos = 0;
                        c = 0;
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
                        Console.WriteLine("longest gen : ");
                        for (int i = 0; i < c; i++)
                        {
                            Console.Write(max_dna[i] + " ");
                        }
                        Console.WriteLine();
                        Console.WriteLine("nuber of codons in the gen : " + max);
                        Console.WriteLine("position of the gen : " + (pos + 1));
                        Console.ReadLine();
                        second_choise = true;
                        break;
                    case 15:
                        int repeate = 0, z = 0 , v = 0 , t = 0;
                        int max_rep = int.MinValue;
                        string[] num = new string[100];
                        string[] max_repeat = new string[100];
                        Console.WriteLine("Enter the number of nucletide ");
                        int number = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < Dna.Length; i++)
                        {
                            while (z < Dna.Length)
                            {
                                v = 0;
                                for (int h =z; h <= number; h++)
                                {
                                    num[v] = Convert.ToString(Dna[h]);
                                    v++;
                                }
                                number++;
                                for (int l = 0; l < Dna.Length; l++)
                                {
                                    t = 0;
                                    bool flag_1 = true;
                                    while (t <= number)
                                    {
                                        if (num[t] == Convert.ToString(Dna[l]))
                                        {
                                            repeate++;
                                        }
                                        t++;
                                    }
                                    if (repeate > max_rep)
                                    {
                                        max_rep = repeate;
                                        for (int y = 0; y < num.Length; y++)
                                        {
                                            max_repeat[y] = num[y];
                                        }
                                    }
                                }
                                z++;
                            }
                        }
                        Console.Write("thr number of nucletide you enter : ");
                        Console.Write(number);
                        Console.WriteLine();
                        Console.WriteLine("most repeate sequence : ");
                        for (int u = 0; u < max_repeat.Length; u++)
                        {
                            Console.Write(max_repeat[u]);
                        }
                        Console.WriteLine();
                        Console.WriteLine("frequency : " + max_rep);
                        Console.ReadLine();
                        second_choise = true;
                        break;
                    case 16:
                        int hydrogen_bonds_2 = 0, hydrogen_bonds_3 = 0;
                        for (int i = 0; i < Dna.Length; i++)
                        {
                            if (Dna[i] == 'A' || Dna[i] == 'T')
                            {
                                hydrogen_bonds_2++;
                            }
                            else
                            {
                                hydrogen_bonds_3++;
                            }
                        }

                        Console.WriteLine("Number of pairing with 2-hydrogen bonds: " + hydrogen_bonds_2);
                        Console.WriteLine("Number of pairing with 3-hydrogen bonds: " + hydrogen_bonds_3);
                        Console.WriteLine("Number of hydrogen bonds: " + ((hydrogen_bonds_2 * 2) + (hydrogen_bonds_3 * 3)));
                        second_choise = true;
                        break;
                    case 17:

                        second_choise = true;
                        break;
                    case 18:
                        second_choise = false;
                        Console.Clear();
                        Console.WriteLine("Do you really want to quit?");
                        //if()
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
