using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SplashKitSDK;

namespace CheckMate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new Window("CheckMate", Constant.WinWidth, Constant.WinHeight);
            Game game = new Game();

            do
            {
                
                SplashKit.ProcessEvents();

                SplashKit.ClearScreen();


                game.Draw();

                game.ProcessEvents();


                SplashKit.RefreshScreen();
                
            } while (!SplashKit.WindowCloseRequested("CheckMate"));
        }
    }
}