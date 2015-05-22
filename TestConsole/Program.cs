using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] states = new string[5]          {            "Alabama","California","Florida",            "Louisiana","Texas"         };
            string[] capitals = new string[5]         {            "Montgomery","Sacramento","Tallahassee",            "Baton Rouge","Austin"         };
            
            for (int i = 0; i < states.Length; i++)
            {
                for (int j = i+1; j < states.Length; j++)
                { 
                string temp1;
                string temp2;
                if(countVowels(states[j]) < countVowels(states[i]))
                {
                    temp1 = states[j];
                    states[j] = states[i];
                    states[i] = temp1;
                    temp2 = capitals[j];
                    capitals[j] = capitals[i];
                    capitals[i] = temp2;
                }
            }
            }
            for (int i = 0; i < states.Length; i++)
            {
                Console.WriteLine(capitals[i] + " is the capital of " + states[i]);                
            }
            Console.ReadLine();
        }

        public static int countVowels(string str)
        {
            int vowelcount=0;
            str = str.ToUpper();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'A' || str[i] == 'E' || str[i] == 'I' || str[i] == 'O' || str[i] == 'U')
                {
                    vowelcount += 1;
                }
            }
            return vowelcount;
        }
    }
   
}
