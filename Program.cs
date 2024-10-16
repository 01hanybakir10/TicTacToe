namespace TicTacToe
{
    public class Program
    {
        static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static char player = 'X';

        static void Main(string[] args)
        {
            int move;
            bool gameWon = false;

            do
            {
                Console.Clear();
                DisplayBoard();

                Console.WriteLine($"\nPlayer {player}, enter your move (1-9): ");
                move = int.Parse(Console.ReadLine()) - 1;

                if (board[move] != 'X' && board[move] != 'O')
                {
                    board[move] = player;
                    gameWon = CheckWin();

                    if (!gameWon)
                        player = (player == 'X') ? 'O' : 'X';
                }
                else
                {
                    Console.WriteLine("Invalid move! Try again.");
                    Console.ReadKey();
                }
            } while (!gameWon && !IsBoardFull());

            Console.Clear();
            DisplayBoard();

            if (gameWon)
                Console.WriteLine($"\nPlayer {player} wins!");
            else
                Console.WriteLine("\nIt's a draw!");

            Console.ReadKey();
        }

        static void DisplayBoard()
        {
            Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
        }

        static bool CheckWin()
        {
            // Winning combinations
            int[,] winPositions = new int[,]
            {
            { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, // Rows
            { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, // Columns
            { 0, 4, 8 }, { 2, 4, 6 }              // Diagonals
            };

            for (int i = 0; i < winPositions.GetLength(0); i++)
            {
                if (board[winPositions[i, 0]] == player &&
                    board[winPositions[i, 1]] == player &&
                    board[winPositions[i, 2]] == player)
                {
                    return true;
                }
            }
            return false;
        }

        static bool IsBoardFull()
        {
            foreach (char c in board)
            {
                if (c != 'X' && c != 'O')
                    return false;
            }
            return true;
        }

    }
}


