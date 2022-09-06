using System;
using System.Collections.Generic;

namespace ValidParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            var validInputs = new List<string>() { "()", "{}", "[]" };
            string[] inputs = { "()", "()[]{}", "(]", "([)]", "{[]}", "{[]}{[]}" };

            Console.WriteLine(ValidParentheses(inputs[0], validInputs));
            Console.WriteLine(ValidParentheses(inputs[1], validInputs));
            Console.WriteLine(ValidParentheses(inputs[2], validInputs));
            Console.WriteLine(ValidParentheses(inputs[3], validInputs));
            Console.WriteLine(ValidParentheses(inputs[4], validInputs));
            Console.WriteLine(ValidParentheses(inputs[5], validInputs));
        }

        // Checks if input string is valid if:
        // Open brackets must be closed by the same type of brackets.
        // Open brackets must be closed in the correct order.
        private static bool ValidParentheses(string input, IEnumerable<string> validInputs)
        {
            if (input.Length == 0)
            {
                return true;
            }

            foreach (string validInput in validInputs)
            {
                string reducedInput = input.Replace(validInput, "");

                // A valid input exists as a substring of the input
                if (input != reducedInput)
                {
                    // Reduce the size of valid inputs for recursive call
                    List<string> newValidInputs = new List<string>(validInputs);
                    newValidInputs.Remove(validInput);

                    return ValidParentheses(reducedInput, newValidInputs);
                }
            }

            // A valid input does not exist as a substring of the input
            return false;
        }
    }
}
