using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Class;

namespace WpfApp1
{
    class UndoRedo
    {
        public static Stack<Product> BeforeStepStack = new Stack<Product>();
        public static Stack<Product> AfterStepStack = new Stack<Product>();
        public UndoRedo() { }

        public static void redo() 
        {
            if (AfterStepStack.Count > 0)
            {
                Product newProduct = AfterStepStack.Pop();
                if (DataFile.productList.Contains(newProduct))
                {
                    DataFile.RemoveProduct(newProduct);
                }
                else
                {
                    DataFile.AddProduct(newProduct);
                }
                BeforeStepStack.Push(newProduct);
            }
        }

        public static void undo() 
        {
            if (BeforeStepStack.Count > 0)
            {
                Product newProduct = BeforeStepStack.Pop();

                if (DataFile.productList.Contains(newProduct))
                {
                    DataFile.RemoveProduct(newProduct);
                }
                else
                {
                    DataFile.AddProduct(newProduct);
                }

                AfterStepStack.Push(newProduct);
            }
        }
    }
}

