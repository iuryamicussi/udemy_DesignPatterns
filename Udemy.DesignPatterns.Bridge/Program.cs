using System;
using Autofac;
using static System.Console;

namespace Udemy.DesignPatterns.Bridge
{
    public interface IRenderer
    {
        void RenderCircle(float radius);
    }
    
    public class VectorRender : IRenderer
    {
        public void RenderCircle(float radius)
        {
            WriteLine($"Drawing a circle of radius {radius}");
        }
    }
    
    public class RasterRender : IRenderer
    {
        public void RenderCircle(float radius)
        {
            WriteLine($"Drawing pixels for circle with radius {radius}");
        }
    }

    public abstract class Shape
    {
        protected IRenderer renderer;

        protected Shape(IRenderer render)
        {
            this.renderer = render;    
        }

        public abstract void Draw();
        public abstract void Resize(float factor);
    }
    
    public class Circle : Shape
    {
        private float radius;

        public Circle(IRenderer render, float radius) : base(render)
        {
            this.radius = radius;    
        }

        public override void Draw()
        {
            renderer.RenderCircle(radius);
        }

        public override void Resize(float factor)
        {
            radius *= factor;
        }
    }

    class Program
    {
        /*static void Main(string[] args)
        {
//            IRenderer renderer = new RasterRender();
            IRenderer renderer = new VectorRender();
            var circle = new Circle(renderer,5);
            circle.Draw();
            circle.Resize(2);
            circle.Draw();
        }*/
        static void Main(string[] args)
        {
            var cb = new ContainerBuilder();
            cb.RegisterType<VectorRender>().As<IRenderer>()
                .SingleInstance();
            cb.Register((c, p) =>
                new Circle(c.Resolve<IRenderer>(),
                    p.Positional<float>(0)));
            using (var c = cb.Build())
            {
                var circle = c.Resolve<Circle>(
                    new PositionalParameter(0, 5f)
                );
                circle.Draw();
                circle.Resize(2);
                circle.Draw();
            }
            

        }
    }
}