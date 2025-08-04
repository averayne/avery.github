using System;
using System.Collections.Generic;
using System.Linq;

namespace Hangman.BLL
{
    public class HangmanGame
    {
        private readonly string _wordToGuess;
        private readonly HashSet<char> _guessedLetters = new HashSet<char>();
        private int _remainingAttempts;

        public HangmanGame(string wordToGuess, int maxAttempts = 6)
        {
            _wordToGuess = wordToGuess.ToUpper();
            _remainingAttempts = maxAttempts;
        }

        public string GetMaskedWord()
        {
            string masked = "";
            foreach (char c in _wordToGuess)
            {
                if (_guessedLetters.Contains(c))
                {
                    masked += c;
                }
                else
                {
                    masked += "_";
                }
            }
            return masked;
        }

        public int GetRemainingAttempts()
        {
            return _remainingAttempts;
        }

        public bool IsWon()
        {
            foreach (char c in _wordToGuess)
            {
                if (!_guessedLetters.Contains(c))
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsLost()
        {
            return _remainingAttempts <= 0 && !IsWon();
        }

        public bool Guess(char letter)
        {
            letter = char.ToUpper(letter);

            if (_guessedLetters.Contains(letter))
            {
                return false;
            }

            _guessedLetters.Add(letter);

            if (!_wordToGuess.Contains(letter))
            {
                _remainingAttempts--;
            }

            return true;
        }

        public List<char> GetGuessedLetters()
        {
            List<char> sortedGuesses = _guessedLetters.ToList();
            sortedGuesses.Sort();
            return sortedGuesses;
        }
    }
}