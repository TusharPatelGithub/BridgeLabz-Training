using System;

class SnakeLadder
{
    private const int BOARD_LIMIT = 100;
    public static int RollDiceValue()
    {
        Random random = new Random();
        return random.Next(1, 7);
    }
    public static int CalculateNextPosition(int currentPos, int diceValue)
    {
        int tempPosition = currentPos + diceValue;
        if (tempPosition > BOARD_LIMIT)
            return currentPos;

        return tempPosition;
    }
    public static int CheckSnakeOrLadder(int position)
    {
        switch (position)
        {
            case 3:
                Console.WriteLine("Ladder! Climb up to 22");
                return 22;

            case 9:
                Console.WriteLine("Ladder! Climb up to 34");
                return 34;

            case 22:
                Console.WriteLine("Ladder! Climb up to 41");
                return 41;

            case 29:
                Console.WriteLine("Ladder! Climb up to 77");
                return 77;

            case 50:
                Console.WriteLine("Ladder! Climb up to 67");
                return 67;

            case 71:
                Console.WriteLine("Ladder! Climb up to 92");
                return 92;

            case 88:
                Console.WriteLine("Ladder! Climb up to 99");
                return 99;

            case 32:
                Console.WriteLine("Snake! Slide down to 10");
                return 10;

            case 36:
                Console.WriteLine("Snake! Slide down to 10");
                return 10;

            case 48:
                Console.WriteLine("Snake! Slide down to 26");
                return 26;

            case 62:
                Console.WriteLine("Snake! Slide down to 18");
                return 18;

            case 95:
                Console.WriteLine("Snake! Slide down to 56");
                return 56;

            case 97:
                Console.WriteLine("Snake! Slide down to 78");
                return 78;

            default:
                return position;
        }
    }
    public static bool HasWon(int position)
    {
        return position == BOARD_LIMIT;
    }
    public static void Main(string[] args)
    {
        Console.WriteLine(" SNAKE AND LADDER GAME ");
        Console.Write("Enter number of players (2 to 4): ");
        int totalPlayers = Convert.ToInt32(Console.ReadLine());
        if (totalPlayers < 2 || totalPlayers > 4)
        {
            Console.WriteLine("Invalid player count!");
            return;
        }
        string[] playerNames = { "Player A", "Player B", "Player C", "Player D" };
        int[] playerPositions = new int[4];
        bool gameOver = false;
        int currentTurn = 0;
        while (!gameOver)
        {
            string currentPlayerName = playerNames[currentTurn];
            int currentPos = playerPositions[currentTurn];
            int diceValue = RollDiceValue();
            Console.WriteLine($"\n{currentPlayerName} rolled: {diceValue}");
            int movedPosition = CalculateNextPosition(currentPos, diceValue);

            if (movedPosition == currentPos)
            {
                Console.WriteLine($"{currentPlayerName} stays at {currentPos} (roll exceeded 100)");
            }
            else
            {
                int finalPosition = CheckSnakeOrLadder(movedPosition);
                Console.WriteLine($"{currentPlayerName}: {currentPos} → {finalPosition}");
                playerPositions[currentTurn] = finalPosition;

                if (HasWon(finalPosition))
                {
                    Console.WriteLine($"\n {currentPlayerName} WINS THE GAME! ");
                    break;
                }
            }

            currentTurn++;
            if (currentTurn >= totalPlayers)
                currentTurn = 0;
        }
    }
}
