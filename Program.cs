using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPro.UI;

namespace TaskPro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuHandler menuHandler = new MenuHandler();
            menuHandler.ShowMainMenu();

        }
    }
}
