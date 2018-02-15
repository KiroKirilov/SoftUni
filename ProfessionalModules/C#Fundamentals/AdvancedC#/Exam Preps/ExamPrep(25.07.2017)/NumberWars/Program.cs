using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

public class TheHeiganDance
{
    public static void Main()
    {
        var firstPlayerHand = new Queue<string>(Console.ReadLine().Split());
        var secondPlayerHand = new Queue<string>(Console.ReadLine().Split());

        int turnCounter = 0;
        var gameOver = false;

        while (turnCounter < 1000000 && firstPlayerHand.Count > 0 && secondPlayerHand.Count > 0 && !gameOver)
        {
            turnCounter++;

            var firstCard = firstPlayerHand.Dequeue();
            var secondCard = secondPlayerHand.Dequeue();

            if (GetNumber(firstCard) > GetNumber(secondCard))
            {
                firstPlayerHand.Enqueue(firstCard);
                firstPlayerHand.Enqueue(secondCard);
            }
            else if (GetNumber(firstCard) < GetNumber(secondCard))
            {
                secondPlayerHand.Enqueue(secondCard);
                secondPlayerHand.Enqueue(firstCard);
            }
            else
            {
                var cardsForWinner = new List<string> { firstCard, secondCard };

                while (!gameOver)
                {
                    if (firstPlayerHand.Count >= 3 && secondPlayerHand.Count >= 3)
                    {
                        int playerOneSum = 0;
                        int playerTwoSum = 0;

                        for (int counter = 0; counter < 3; counter++)
                        {
                            var cardPlayerOne = firstPlayerHand.Dequeue();
                            var cardPlayerTwo = secondPlayerHand.Dequeue();
                            playerOneSum += GetChar(cardPlayerOne);
                            playerTwoSum += GetChar(cardPlayerTwo);

                            cardsForWinner.Add(cardPlayerOne);
                            cardsForWinner.Add(cardPlayerTwo);
                        }

                        if (playerOneSum > playerTwoSum)
                        {
                            AddCardsToPlayer(cardsForWinner, firstPlayerHand);
                            break;
                        }
                        else if (playerOneSum < playerTwoSum)
                        {
                            AddCardsToPlayer(cardsForWinner, secondPlayerHand);
                            break;
                        }
                    }
                    else
                    {
                        gameOver = true;
                    }
                }
            }
        }

        var result = "";

        if (firstPlayerHand.Count == secondPlayerHand.Count)
        {
            result = "Draw";
        }
        else if (firstPlayerHand.Count > secondPlayerHand.Count)
        {
            result = "First player wins";
        }
        else
        {
            result = "Second player wins";
        }

        Console.WriteLine("{0} after {1} turns", result, turnCounter);
    }

    static void AddCardsToPlayer(List<string> cards, Queue<string> winner)
    {
        foreach (var card in cards.OrderByDescending(c => GetNumber(c)).ThenByDescending(c => GetChar(c)))
        {
            winner.Enqueue(card);
        }
    }

    static int GetNumber(string card)
    {
        return int.Parse(card.Substring(0, card.Length - 1));
    }

    static int GetChar(string card)
    {
        return card[card.Length - 1];
    }
}