using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.Liskov_substitution_Principle
{
    public class Lsp
    {
        public void TestFunction(Bird bird)
        {
            bird.Fly();
            bird.Speak();
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

        public virtual void Speak()
        {
            Console.WriteLine($"{this.name} Speaks");
        }
    }

    public class Sparrow : Bird
    {
        public Sparrow(string name) : base(name)  // Calling the base class constructor
        {
            // No need to manually assign name and description here
        }

        public override void Fly()
        {
            Console.WriteLine("Sparrow Fly");
        }

        public override void Speak()
        {
            Console.WriteLine("Sparrow Speaks");
        }
    }

    public class Pengiun : Bird
    {

        public Pengiun(string name) : base(name)  // Calling the base class constructor
        {
            // No need to manually assign name and description here
        }

        public override void Fly()
        {
            throw new NotImplementedException("Cannot fly");
        }


        public override void Speak()
        {
            Console.WriteLine("Sparrow Speaks");
        }
    }


}
