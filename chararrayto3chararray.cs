using System;

namespace tring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //This code is exlpains to how to divide a string dna to char dna and sum 3 chars to a diffirent dna string array (calling dna_codon)
            int beg = 0;
            string[] dna_codons=new string[50];
            string codon;

            string dna = "ATGACTGATGAGAGATATTGA";
            char[] Dna_string = dna.ToCharArray();

            int j = 0;
            for(int i=beg; i <Dna_string.Length; i+=3)
            {
                codon = Convert.ToString(Dna_string[i]) + Convert.ToString(Dna_string[i+1]) + Convert.ToString(Dna_string[i+2]);
                dna_codons[j]=codon;
                Console.WriteLine(j+"=>"+dna_codons[j]);
                j++;
            }
        }
    }
}
