using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_1 :Purple
    {
        private string _output;
        public string Output=> _output;
        public Purple_1(string input) : base(input){ }
        public override void Review()
        {
            if (Input == null) return;
            var array_answers = Input.Split(' ');
            var answers = new StringBuilder();
            foreach (var answer in array_answers)
            {
                if (String.IsNullOrEmpty(answer)) {
                    answers.Append(answer);
                    if (answer != array_answers[array_answers.Length - 1])
                    {
                        answers.Append(' ');
                    }
                    _output = answers.ToString(); 
                    continue; 
                }
                int count = 0;
                int let_count = 0;
                for (int i = answer.Length - 1; i >= 0; i--)
                {
                    if (Char.IsDigit(answer[i])) { count++; }
                    if (Char.IsLetter(answer[i]) || answer[i] == '-' || answer[i] == '\'') { let_count++; }
                }
                if (count != 0) { answers.Append(answer);
                    if (answer != array_answers[array_answers.Length - 1])
                    {
                        answers.Append(' ');
                    }
                    _output = answers.ToString(); continue; }
                else if (let_count == answer.Length) {answers.Append(answer.Reverse().ToArray());
                    if (answer != array_answers[array_answers.Length - 1])
                    {
                        answers.Append(' ');
                    }
                    _output = answers.ToString(); continue; }
                else
                {
                    char[] place = new char[answer.Length];
                    var ans = new char[answer.Length];
                    for (int i = answer.Length - 1; i >= 0; i--)
                    {
                        if (Char.IsLetter(answer[i]) || answer[i] == '-' || answer[i] == '\'')
                        {
                            ans[i] = answer[i];
                            place[i] = '0';
                        }
                        else
                        {
                            place[i] = answer[i];
                            ans[i] = '0';
                        }
                    }

                    char[] a = new char[0];
                    for (int i = ans.Length-1; i >=0; i--)
                    {
                        if (ans[i] != '0')
                        {
                            Array.Resize(ref a, a.Length + 1);
                            a[a.Length - 1] = ans[i];
                        }
                    }
                    int j = 0;
                    for (int i = 0; i < place.Length; i++)
                    {
                        if (place[i] != '0')
                        {
                            answers.Append(place[i]);
                        }
                        else
                        {
                            answers.Append(a[j]);
                            j++;
                        }
                    }
                        if (answer != array_answers[array_answers.Length - 1])
                        {
                            answers.Append(' ');
                        }
                        _output = answers.ToString(); continue;
                    

                }

            }

        }
        
        public override string ToString()
        {
            return _output;
        }
       
    }
}
