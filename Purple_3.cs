using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_3 : Purple
    {
        private string _output;
        public string Output => _output;
        public (string, char)[] Codes { get; private set; }
        private char[] Code;
        public Purple_3(string input) : base(input) 
        {
            Codes = new (string, char)[0];
            Code= new char[0];
            for (char c= ' ';Code.Length<5 && c <= '~'; c++)
            {
                if (!input.Contains(c))
                    Code = Code.Append(c).ToArray();
            }

        }
        public override void Review()
        {
            if (Input == null) return;
            var answer = new StringBuilder();
            var array = Input.Split(' ');
            string[] v = new string[0];
            int[] c = new int[0];
            foreach (var item in array)
            {
                for (int i = 0; i < item.Length - 1; i++)
                {
                    int count = 0;
                    string duo = $"{item[i]}{item[i + 1]}";
                    for (int j = 0; j < v.Length; j++)
                    {
                        if (v[j] == duo && char.IsLetter(item[i]) && char.IsLetter(item[i + 1]))
                        {
                            count++;
                            c[j]++;
                            continue;
                        }
                    }
                    if (count == 0 && char.IsLetter(item[i]) && char.IsLetter(item[i + 1]))
                    {
                        Array.Resize(ref v, v.Length + 1);
                        v[v.Length - 1] = duo;
                        Array.Resize(ref c, c.Length + 1);
                        c[c.Length - 1] = 1;
                    }
                }
            }
            for (int i=0; i<v.Length; i++)
            {
                int j = i, k = i - 1;
                while (k >= 0){
                    if (c[j] > c[k])
                    {
                        (c[j], c[k]) = (c[k], c[j]);
                        (v[j], v[k]) = (v[k], v[j]);
                    }
                    j = k;
                    k--;
                }
            }
            v = v.Take(5).ToArray();
            var final = Input;
            for (int i = 0; i < Math.Min(5, v.Length); i++)
            {
                Codes = Codes.Append((v[i], Code[i])).ToArray();
            }
            for (int i = 0; i < v.Length; i++)
            {
                int j;
                for (j = 0; j < final.Length - 1; j++)
                {

                    if ($"{final[j]}{final[j + 1]}" == v[i])
                    {
                        answer.Append(Code[i]);
                        j++;
                    }
                    else { answer.Append(final[j]); }
                }
                if (j == final.Length - 1) { answer.Append(final[j]); }
                final = answer.ToString();
                answer = new StringBuilder();
            }

            _output = final;
            
        }
        public override string ToString()
        {
            return _output;
        }

    }
}
