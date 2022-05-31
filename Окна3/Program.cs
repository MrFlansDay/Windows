using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Окна3 {
    internal class Program {
        static void Main(string[] args) {
            Window window = new Window(2, 2, 20, 10, "1", new Header());
            Window_manager.List_Add(window);
            Window window2 = new Window(2, 2, 15, 10, "2", new Header());
            Window_manager.List_Add(window2);
            Window window3 = new Window(2, 2, 15, 10, "3", new Header());
            Window_manager.List_Add(window3);
            Window w;
            w = Window_manager.active_window;
            Action action = () => { Window_manager.List_Remove(w); };
            Action action1 = () => { 
                Window window1 = new Window(2, 2, 15, 10, "3", new Header());
                Window_manager.List_Add(window1);
            };
            window.Pack(new Button(4, 4, 5, 5, action1), new Button(10, 3, 10, 5, action, "textaaa"));

            while (true) {
                Window_manager.Draw_windows();
                Window_manager.Start();
            }

        }
        
    }
}
