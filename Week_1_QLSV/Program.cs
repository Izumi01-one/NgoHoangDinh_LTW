using QLSV;
using System.Text;

namespace QLSV
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            MenuManager menu = new MenuManager();
            menu.Chay();
        }
    }
}