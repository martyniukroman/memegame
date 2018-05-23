using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1 {
    public class Meme {

        public string Source { set; get; }
        public List<string> Answers { get; set; }
        public Meme()
        {
            Answers = new List<string>();
        }

    }
}
