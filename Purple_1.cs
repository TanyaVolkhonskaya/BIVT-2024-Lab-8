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

                int count = 0;
                for (int i = answer.Length - 1; i >= 0; i--)
                {
                    if (Char.IsDigit(answer[i])) { count++; }
                }
                if (count != 0) { answers.Append(answer).ToString(); }
                else
                {
                    char[] place = new char[answer.Length];
                    var ans = new char[answer.Length];
                    int n = answer.Length;
                    for (int i = answer.Length - 1; i >= 0; i--)
                    {
                        if (Char.IsLetter(answer[i]) || answer[i] == '–' || answer[i] == '\'' || answer[i] == '-')
                        {
                            ans[i] = answer[i];
                            place[i] = ' ';
                        }
                        else
                        {
                            place[i] = answer[i];
                            ans[i] = ' ';
                            count++;
                        }
                    }
                    if (count == 0)
                    {
                        var temp = new Char[answer.Length];
                        for (int i = answer.Length - 1; i >= 0; i--)
                        {
                            temp[answer.Length - i - 1] = answer[i];
                        }
                        answers.Append(temp).ToString();
                    }
                    else
                    {
                        char[] a = new char[0];
                        foreach (var f in ans)
                        {
                            if (f != ' ')
                            {
                                Array.Resize(ref a, a.Length + 1);
                                a[a.Length - 1] = f;
                            }
                        }

                        char[] temp = new char[a.Length];
                        for (int i = a.Length - 1; i >= 0; i--)
                        {
                            temp[a.Length - i - 1] = a[i];
                        }
                        int j = 0;
                        for (int i = 0; i < place.Length; i++)
                        {
                            if (place[i] != ' ')
                            {
                                answers.Append(place[i]).ToString();
                            }
                            else
                            {
                                answers.Append(temp[j]).ToString();
                                j++;
                            }

                        }

                    }
                }
                    answers.Append(' ');
                    _output = answers.ToString();
                
            }
        }
        public override string ToString()
        {
            return _output;
        }

    }
}
