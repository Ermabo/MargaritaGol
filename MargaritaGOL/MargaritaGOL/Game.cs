using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MargaritaGOL
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Generation> GenerationList;
        public Game()
        {
            GenerationList = new List<Generation>();
            Name = DateTime.Now.ToString();
        }

        public Game(Game gameToCopy)
        {
            Name = DateTime.Now.ToString();
            GenerationList = new List<Generation>();
            foreach (var gen in gameToCopy.GenerationList)
            {
                Generation newGen = new Generation(gen);
                GenerationList.Add(newGen);
            }
        }


        public override string ToString()
        {
            return this.Name; 
        }
    }
}
