using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 콘솔슈팅_3차
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameLoop gl = new GameLoop();
            gl.Init();
            gl.Awake();            

            while (true)
            {
                gl.Update();
                gl.Render();
            }


        }
    }
}
