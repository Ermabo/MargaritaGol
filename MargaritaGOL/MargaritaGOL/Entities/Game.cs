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
        public virtual List<Generation> GenerationList { get; set; }
        public Game()
        {
            GenerationList = new List<Generation>(); // Every game contains a list of Generations
            Name = DateTime.Now.ToString();
        }

        /// <summary>
        /// Constructor for copying a whole a game to avoid reference-type problems
        /// </summary>
        /// <param name="gameToCopy"></param>
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
