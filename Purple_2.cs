using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_2 :Purple
    {
        private string[] _output;
        public string[] Output
        {
            get
            {
                if (_output == null) return null;
                var copy = new string[_output.Length];
                Array.Copy(_output, copy, _output.Length);
                return copy;
            }
        }
        public Purple_2(string input) : base(input) { }
        public override void Review()
        {
            if (Input == null) return;
            _output = new string[0];
            var array_answers = Input.Split(' ');
            string finals_word = null;
            int limit = 0;
            var answers = new string[0];
            string[] str = new string[0];
            int count = 0;
            for (int a = 0; a < array_answers.Length-1;)
            {
                

                    int finals_result = limit + array_answers[a].Length + count;
                    if (finals_result <= 50)
                    {
                        count++;
                        limit += array_answers[a].Length;
                        Array.Resize(ref str, str.Length + 1);
                        str[str.Length - 1] = array_answers[a];
                        a++;
                        if (finals_result + array_answers[a].Length + 1 <= 50 && a == array_answers.Length - 1)
                        {
                            count++;
                            limit += array_answers[a].Length;
                            Array.Resize(ref str, str.Length + 1);
                            str[str.Length - 1] = array_answers[a];
                        }
                        else if (finals_result + array_answers[a].Length + 1 > 50 && a == array_answers.Length - 1)
                        {
                            finals_word = array_answers[a];
                        }
                    }
                if (finals_result + array_answers[a].Length + 1 > 50 || a == array_answers.Length - 1)
                {
                    {
                        if (str.Length != 1)
                        {
                            int coef = ((50 - limit) / (str.Length - 1));
                            int coef_count = ((50 - limit) % (str.Length - 1));
                            if (coef_count != 0)
                            {
                                for (int i = 0; i < coef_count; i++)
                                {
                                    answers.Append(str[i]).ToArray();
                                    string s = new String(' ', coef + 1);
                                    answers.Append(s).ToArray();
                                }
                            }
                            for (int p = coef_count; p < str.Length - 1; p++)
                            {
                                answers.Append(str[p]);
                                string s = new String(' ', coef);
                                answers.Append(s);
                            }
                            answers.Append(str[str.Length - 1]);
                        }
                        else { answers.Append(str[0]); }

                        count = 0;
                        limit = 0;
                        str = new string[0];
                        Array.Resize(ref _output, _output.Length + 1);
                        _output[_output.Length - 1] = answers.ToString();
                        answers = new string[0];
                    }
                }
                    if (finals_word != null)
                    {
                        Array.Resize(ref _output, _output.Length + 1);
                        _output[_output.Length - 1] = array_answers[array_answers.Length - 1].ToString();

                    }
            }
        }

        public override string ToString()
        {
            string ans = "";
            foreach (var s in _output) { ans += s + '\n'; }
            ans = ans.Remove(ans.Length - 1, 1);
            return ans;
        }
    }
}
