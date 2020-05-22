using Shapes;
using System.Collections.Generic;
namespace Drawer{
    public class ShapesList{
        public List<Figure> list=new List<Figure>();
        public ShapesList() { }
        public ShapesMemento SaveState()
        {
            return new ShapesMemento(list);
        }
        public void RestoreState(ShapesMemento memento)
        {
            list.Clear();
            foreach (Figure fig in memento.list)
            {
                list.Add(fig.Clone());
            }
        }
    }
    public class ShapesMemento
    {
        public List<Figure> list;
        public ShapesMemento(List<Figure> figures)
        {
            list = new List<Figure>();
            foreach (Figure fig in figures)
            {
                list.Add(fig.Clone());
            }
        }
    }
    public class ShapesHistory
    {
        public Stack<ShapesMemento> History { get; private set; }
        public ShapesHistory()
        {
            History = new Stack<ShapesMemento>();
        }
    }
}