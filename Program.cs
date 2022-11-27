using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using System.Drawing;

namespace MarsGen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string first_choise_string, second_choise_string, codon, temp = "";
            int first_choise_int = 0, second_choise_int = 0, beg = 0;
            bool first_choise = true, second_choise = true, two_error = true, gene_structure = true , flag = true;
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
                        DNA_text = @"c:\load dna1.txt";
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
                        string mydna;
                        Random random = new Random();
                        random.Next(0, 5);
                        Console.WriteLine("please enter the gender operation you want ");
                        string op = Console.ReadLine();
                        mydna = "AGT" + gender[random.Next(0, gender.Length)] + gender[random.Next(0, gender.Length)] + Stp[random.Next(0, Stp.Length)];
                        char[] my_dna = mydna.ToCharArray();
                        bool flag2 = true;
                        if (op == "female")
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
                        }
                        else if (op == "male")
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
                                if (!(op == "male" || op == "female"))
                                {
                                    Console.WriteLine("pls write male or female for the operation ");
                                    op = Console.ReadLine();
                                }
                                else
                                {
                                    flag_3 = false;
                                }
                            }

                        }
                        string[] gen_op = new string[53];
                        Console.WriteLine();
                        for (int i = 0; i < my_dna.Length - 2; i = i +3)
                        {
                            gen_op[i] = Convert.ToString(my_dna[i]) + Convert.ToString(my_dna[i + 1]) + Convert.ToString(my_dna[i + 2]);
                        }
                        int j = random.Next(1, 7);
                        string add_dna , add_dna1;
                        string[] a_acid = { Ala[random.Next(0, 4)], Arg[random.Next(0, 6)], Asn[random.Next(0, 2)], Asp[random.Next(0, 2)], Cys[random.Next(0, 2)], Gln[random.Next(0, 2)], Glu[random.Next(0, 2)], Gly[random.Next(0, 4)], His[random.Next(0, 2)], Ile[random.Next(0, 3)], Leu[random.Next(0, 6)], Lys[random.Next(0, 2)], Phe[random.Next(0, 2)], Pro[random.Next(0, 4)], Ser[random.Next(0, 6)], Thr[random.Next(0, 4)], Trp[random.Next(0, 1)], Tyr[random.Next(0, 2)], Val[random.Next(0, 4)] };
                        for (int k = 0; k < j; k = k + 1)
                        {
                            add_dna1 = null;
                            string add_dna2 = null;
                            int h = random.Next(1, 7);
                            for (int z = 0; z < h; z = z +1)
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
                        Console.WriteLine(my_dna);
                        string[] ch_final = new string[100];
                        for (int i = 0; i < my_dna.Length - 2; i = i + 3)
                        {
                            final = Convert.ToString(my_dna[i]) + Convert.ToString(my_dna[i + 1]) + Convert.ToString(my_dna[i + 2]);
                            ch_final[a] = final;
                            Console.Write(ch_final[a] + " ");
                            a++;
                        }
                        dna = mydna;
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

            string[] dna_codons = new string[(Dna.Length - 1) / 3];
            Console.WriteLine(dna_codons.Length);

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
            for (int k = 0; k < 1; k++)
            {
                for (int i = beg; i < Dna.Length; i += 3)
                {
                    if ((i + 2) > Dna.Length) { gene_structure = false; break; }
                    codon = Convert.ToString(Dna[i]) + Convert.ToString(Dna[i + 1]) + Convert.ToString(Dna[i + 2]);
                    dna_codons[k] = codon;
                    Console.Write(dna_codons[k] + " ");
                }
            }
            //////////////////////////////////////////////////////////////////////////////////////////////////

            while (second_choise == true)
            {
                Console.WriteLine("\nYou entered your DNA\nPlease choose your operation:\n");
                Console.WriteLine("1-Check DNA gene structure\n2-Check DNA of BLOB organism\n3-Produce complement of a DNA sequence\n4-Determine amino acids\n" +
                    "5-Delete codons\n6-Insert codons\n7-Find codons\n8-Reverse codons\n9-Find the number of genes in a DNA strand\n10-Find the shortest gene\n" +
                    "11-Find the longest gene\n12-Find the most repeated n-nucleotide sequence\n13-Hydrogen bond statistics for a DNA strand\n14-Simulate BLOB generations\n");
                Console.Write("Your Operation:");
                second_choise_string = Console.ReadLine();
                if (int.TryParse(second_choise_string, out second_choise_int) == true) second_choise_int = Convert.ToInt32(second_choise_string);
                else { second_choise = true; Console.Clear(); }
                switch (second_choise_int)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
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
                    case 6:
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
                        second_choise = false;
                        break;

                    case 7:
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

                        second_choise = false;
                        break;
                    case 8:
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


                        second_choise = false;
                        break;

                    case 9:
                        second_choise = false;
                        break;
                    case 10:
                        second_choise = false;
                        break;
                    case 11:
                        second_choise = false;
                        break;
                    case 12:
                        second_choise = false;
                        break;
                    case 13:
                        second_choise = false;
                        break;
                    case 14:
                        second_choise = false;
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