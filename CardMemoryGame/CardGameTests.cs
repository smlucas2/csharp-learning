using CardMemoryGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CardGameTests
{
    [STAThread]
    public static void Main(string[] args)
    {
        System.Windows.Application app = new System.Windows.Application();
        app.Run(new MainWindow());
    }
}
