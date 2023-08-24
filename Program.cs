using System;
using System.Text;

namespace FindSpacesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test etmek istediğiniz metni giriniz.");
            string text = Console.ReadLine();

            string correctedText = ManyMark(text);
            correctedText = MarkTest(correctedText);
            correctedText = CapitalLetterTest(correctedText);
            correctedText = SpaceTest(correctedText);


            Console.WriteLine(correctedText);
        }

        static string SpaceTest(string text)
        {
            StringBuilder newText = new StringBuilder();
            bool preSpace = false;

            foreach (char value in text)
            {
                if (value == ' ')
                {
                    if (preSpace)
                    {
                        continue;
                    }
                    preSpace = true;
                }
                else
                {
                    preSpace = false;
                }

                newText.Append(value);
            }

            return newText.ToString();
        }

        static string MarkTest(string text)
        {
            StringBuilder newText = new StringBuilder();
            bool postMarkSpace = false;
            char[] marks = { '.', ',', '!', '?' };

            foreach (char value in text)
            {
                if (char.IsPunctuation(value))
                {
                    newText.Append(value);
                    postMarkSpace = true;
                }
                else if (char.IsLetter(value))
                {
                    if (postMarkSpace)
                    {
                        newText.Append(' ');
                        postMarkSpace = false;
                    }

                    newText.Append(value);
                }
                else
                {
                    newText.Append(value);
                    postMarkSpace = false;
                }
            }

            return newText.ToString();
        }

        static string CapitalLetterTest(string text)
        {
            StringBuilder newText = new StringBuilder();
            bool bigLetter = true;

            foreach (char value in text)
            {
                if (char.IsPunctuation(value))
                {
                    newText.Append(value);
                    newText.Append(' ');
                    bigLetter = true;
                }
                else if (char.IsLetter(value))
                {
                    if (bigLetter)
                    {
                        newText.Append(char.ToUpper(value));
                        bigLetter = false;
                    }
                    else
                    {
                        newText.Append(char.ToLower(value));
                    }
                }
                else
                {
                    newText.Append(value);
                }
            }

            return newText.ToString();
        }

        static string ManyMark(string text)
        {
            StringBuilder newText = new StringBuilder();
            bool prevMark = false;

            foreach (char c in text)
            {
                if (!char.IsPunctuation(c))
                {
                    prevMark = false;
                    newText.Append(c);
                }
                else if (!prevMark)
                {
                    prevMark = true;
                    newText.Append(c);
                }
            }

            return newText.ToString();
        }
    }
}
