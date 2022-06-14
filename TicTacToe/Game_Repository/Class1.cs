using System;
namespace Game_Repository;
public class GameRepository
{
    public char[] tic = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};


    public void Board() {
        System.Console.WriteLine("     |     |     \n" + 
        $"  {tic[1]}  |  {tic[2]}  |  {tic[3]}\n" + 
        "_____|_____|_____\n" + 
        "     |     |\n" + 
        $"  {tic[4]}  |  {tic[5]}  |  {tic[6]}\n" + 
        "_____|_____|_____\n" + 
        "     |     |\n" + 
        $"  {tic[7]}  |  {tic[8]}  |  {tic[9]}\n" + 
        "     |     |\n");
    }

    public int CheckForWin() {
        if (tic[1] == tic[2] && tic[2] == tic[3]) {
            return 1;
        }
        else if (tic[4] == tic[5] && tic[5] == tic[6]) {
            return 1;
        }
        else if (tic[7] == tic[8] && tic[8] == tic[9]) {
            return 1;
        }
        else if (tic[1] == tic[4] && tic[4] == tic[7]) {
            return 1;
        }
        else if (tic[2] == tic[5] && tic[5] == tic[8]) {
            return 1;
        }
        else if (tic[3] == tic[6] && tic[6] == tic[9]) {
            return 1;
        }
        else if (tic[1] == tic[5] && tic[5] == tic[9]) {
            return 1;
        }
        else if (tic[3] == tic[5] && tic[5] == tic[7]) {
            return 1;
        }
        else if (tic[1] != '1' && tic[2] != '2' && tic[3] != '3' && tic[4] != '4' && tic[5] != '5' && tic[6] != '6' && tic[7] != '7' && tic[8] != '8' && tic[9] != '9') {
            return -1;
        }
        else {
            return 0;
        }
    }
}
