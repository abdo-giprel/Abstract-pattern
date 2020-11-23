using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace AbstractClass
{
    public class FactoryProducer
    {
        public AbstractFactory GetFactory(string factoryName)
        {
            if (factoryName == "shape")
            {
                return new ShapeFactory();
            }
            else if (factoryName =="color")
            {
                return new ColorFactory();
            }
            return null;
        }

    }
    public abstract class AbstractFactory
    {
        public abstract IShape GetShape(string shapeName);
        public abstract IColor GetColor(string colorName);
    }

    #region ShapeFactory
    public class ShapeFactory : AbstractFactory
    {
        public override IShape GetShape(string shapeName)
        {
            if (shapeName == "circle")
            {
                return new Circle();
            }
            return null;
        }

        public override IColor GetColor(string colorName)
        {
            throw new NotImplementedException("You Must use GetShape Function instead in Main");
        }
    }
    public interface IShape
    {
        void draw();
    }
    public class Circle : IShape
    {
        public void draw()
        {
            Console.Write(" drawing circle: " + "O");
            Console.WriteLine();

        }
    }


    #endregion

    #region ColorFactory

    public class ColorFactory:AbstractFactory
    {
        public override IColor GetColor(string colorName)
        {
            if (colorName == "red")
            {
                return new Red();
            }
            return null;
        }

        public override IShape GetShape(string shapeName)
        {
            throw new NotImplementedException("You Must use GetColor Function instead in Main");
        }
    }
    public interface IColor
    {
        void Fill();
    }
    public class Red:IColor
    {
        public void Fill()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("I am red");
            Console.ResetColor();
        }
    }
    

    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            FactoryProducer fp = new FactoryProducer();
            fp.GetFactory("shape").GetShape("circle").draw();
            FactoryProducer fp2 =new FactoryProducer();
            fp2.GetFactory("color").GetColor("red").Fill();
            Console.ReadKey();
        }
    }
}
