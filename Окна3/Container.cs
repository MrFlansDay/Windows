using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Окна3 {
    internal class Container : View {
        public Button button;
        private TextField textField;
        private Label label;
        public List<View> items;
        
        public Container(int x, int y, int width, int height, string text) : base(x, y, width, height) {

            Action action = () => { Window_manager.List_Remove(Window_manager.active_window); };
            button = new Button(width - 1, y + 1, 10, 3, action);


            textField = new TextField(x + 1, y + 3, 5, 3, text);


            label = new Label(x+1, y+1, width, height, text);
            items = new List<View>() { button, textField};
        }

        public int iterator = 1;



        public void Pack(params View[] views) {
            for (int i = 0; i < views.Length; i++) {
                views[i].y += y;
                views[i].x += x;
                items.Add(views[i]);
            }
            Draw();
        }
        public void Choose_field() {
            if (items[iterator % items.Count()] is TextField temp) {
                temp.Is_active = true;
                if (items[(iterator - 1) % items.Count()] is TextField temp1) {
                    temp1.Is_active = false;
                } else if (items[(iterator - 1) % items.Count()] is Button temp2) {
                    temp2.Is_active = false;
                }
                iterator++;
            }
            else if (items[iterator % items.Count()] is Button temp1) {
                temp1.Is_active = true;
                if (items[(iterator - 1) % items.Count()] is TextField temp2) {
                    temp2.Is_active = false;
                }
                else if (items[(iterator - 1) % items.Count()] is Button temp3) {
                    temp3.Is_active = false;
                }
                iterator++;
            }
            Draw();
        } 

        public void Press(bool is_new) {
            foreach (var item in items) {
                if (item is TextField temp) {
                    if (temp.Is_active) temp.Write(is_new);
                } else if (item is Button temp2) {
                    if (temp2.Is_active) temp2.Press();
                }

            }
        }


        public override void Draw() {
            base.Draw();
            label.Draw();
            foreach(View view in items) {
                if (view is TextField temp) {
                    temp.Draw();
                } else {
                    view.Draw();
                }
                
            }
        }

        public override void Move(ConsoleKeyInfo s) {
            base.Move(s);
            label.Move(s);
            foreach (View view in items) {
                if (view is TextField temp) {
                    temp.Move(s);
                }
                else {
                    view.Move(s);
                }

            }
            Draw();
        }
    }
}
