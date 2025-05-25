using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<QuestionGame> questions = new List<QuestionGame>
            {
                new QuestionGame("What is the capital of Abia state?", new[]{"Umuaiha","Aba","isikwato","bende"},0),
                new QuestionGame("What is the capital of Adamawa state?", new[]{"Yola","Mubi","Ganye","Numan"},0),
                new QuestionGame("What is the capital of Akwa Ibom state?", new[]{"Abia","Ikot Ekpene","Oron","Uyo"},3),

            };
            
            int score = 0;
            Console.WriteLine("Welcome to the Game App!");
            for (int i = 0; i < questions.Count; i++) 
            {
                Console.WriteLine($"Question {i + 1}: {questions[i].Text}");
                for (int a = 0; a < questions[i].Optionsgames.Length; a++)
                {
                    Console.WriteLine($"{a + 1}. {questions[i].Optionsgames[a]}");
                }
                Console.Write("Enter your answer (1-4): ");
                string input = Console.ReadLine();
                if(int.TryParse(input, out int answerindex) && answerindex - 1 == questions[i].CorrectAnswerIndex)
                {
                    Console.Write("\nYour answer is correct!\n");
                    score++;
                }
                else
                {
                    Console.WriteLine($"\nYour answer is incorrect. The correct answer is {questions[i].Optionsgames[questions[i].CorrectAnswerIndex]}.\n");
                }
                Console.WriteLine(new string('-',30));
               
            }
            Console.WriteLine($"\nYou Score {score} out of {questions.Count}.\n");
            Console.WriteLine("Thanks you chigo for playing this game");
        }

        
    }
    public class QuestionGame
    {
        public string Text { get; }
        public string[] Optionsgames { get; }
        public int CorrectAnswerIndex { get; }

        public QuestionGame(string text, string[] optionsgames, int correctanswerindex)
        {
            Text = text;
            Optionsgames = optionsgames;
            CorrectAnswerIndex = correctanswerindex;
        }
    }
}
