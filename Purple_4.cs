using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_4 : Purple
    {
        public (string, char)[] _code;
        private string _output;
        public string Output => _output;
        public Purple_4(string input, (string, char)[] code) : base(input)
        {
            _code = code;
        }
        
        public override void Review()
        {
            if (Input == null) return;
            var answer = new StringBuilder();
            for (int i = 0; i < Input.Length; i++)
            {
                int count = -1;
                for (int j = 0; j < _code.Length; j++)
                {
                    if (_code[j].Item2 == Input[i])
                    {
                        count = j;
                        continue;
                    }
                }
                if (count == -1)
                {
                    answer.Append(Input[i]);
                }
                else
                {
                    answer.Append(_code[count].Item1);    
                }
            }
            _output= answer.ToString();
        }
        public override string ToString()
        {
            return _output;
        }
    }
}
