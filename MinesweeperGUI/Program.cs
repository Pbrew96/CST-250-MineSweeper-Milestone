/* Patrick Brewster
 * CST-250
 * Milestone 5
 * Minesweeper Game
 * 7/19/2026
 */
namespace MinesweeperGUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmStartGame());
        }
    }
}