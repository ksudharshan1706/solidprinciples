using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.Liskov_substitution_Principle
{

    public interface IBird
    {
        void Speak();
    }
    public class Lsp
    {
        public void TestFunction(Bird bird)
        {
            bird.Fly();
        }
    }
    public class Bird     
    {
        public string name;
        public Bird(string name)
        {
            this.name = name;
        }

        public virtual void Fly()
        {
            Console.WriteLine($"{this.name} Fly");
        }
    }

    public class Sparrow : Bird, IBird
    {
        public Sparrow(string name) : base(name)  // Calling the base class constructor
        {
            // No need to manually assign name and description here
        }

        public override void Fly()
        {
            Console.WriteLine("Sparrow Fly");
        }

        public void Speak()
        {
            Console.WriteLine("Sparrow Speaks");
        }
    }

    public class Pengiun : IBird
    {
        public void Speak()
        {
            Console.WriteLine("pengiun Speaks");
        }
    }


}
