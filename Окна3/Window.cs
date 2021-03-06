using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Окна3 {
    internal class Window : View {
        private Header header = new Header();
        public Container container;

        public Window(int x, int y, int width, int height, string title, Header header) : base(x, y, width, height) {
            this.header = header;
            container = new Container(x, y, width, height, title);
        }

        public void Pack(params View[] views) {
            container.Pack(views);
        }

        public void Choose_field() {
            container.Choose_field();
        }
        public void Press( bool is_new = false) {
            container.Press(is_new);
        }

        private void draw_window() {
            Drawer.Draw(x, y, width, height);
            header.Draw(x, y, width);
        }
        public override void Draw() {
            draw_window();
            container.Draw();
        }
        public override void Move(ConsoleKeyInfo s) {
            base.Move(s);
            container.Move(s);
            Draw();
        }
    }
}
