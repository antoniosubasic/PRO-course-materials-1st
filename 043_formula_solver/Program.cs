// constant string for all possible operators
const string POSSIBLE_OPERATORS = "+-*/";

#region Main Program
// ask the user for a formula
Console.Write("Enter the formula: ");
// store the input in formula and remove all spaces
string formula = Console.ReadLine()!.Replace(" ", "");

// providing the google calculation link for checking purposes
string googleCalculatorLink = $"https://www.google.com/search?q={formula.Replace("+", "%2B").Replace("/", "%2F")}";

// run the loop as long as operators are found in formula
while (ContainsOperator(formula, POSSIBLE_OPERATORS, true))
{
    // create a list for all operator indices
    List<int> operatorIndices = new List<int>();

    // counting the number of divisions
    int numberOfDivisions = 0;
    // loop through formula
    for (int i = 1; i < formula.Length; i++)
    {
        // NOTE: when an operator was found, i is increased by one so the character behind the operator is skipped, allows calculations like:
        // 10--10
        // 2*-10

        // each divison operator-index is added to the front of the list
        if (formula[i] == '/') { operatorIndices.Insert(0, i); i++; numberOfDivisions++; }
        // each multiplication operator-index is added inbetween the divisions and additions/subractions (to avoid mistakes like: 10 / 5 * 2 = 10 / 10 = 1)
        else if (formula[i] == '*') { operatorIndices.Insert(numberOfDivisions, i); i++; }
        // each addition or subtraction operator-index is added to the end of the list
        else if (formula[i] is '+' or '-') { operatorIndices.Add(i); i++; }
    }

    // default value for leftOperatorIndex is 0 and default value for rightOperatorIndex is formula.Length, so the default indices start from left and go all the way to the right
    int leftOperatorIndex = 0, rightOperatorIndex = formula.Length;
    // creating a sorted list for the operator indices
    List<int> sortedOperatorIndices = operatorIndices.OrderBy(p => p).ToList();
    // loop through the sorted list, to get the operators on the left and right of the current operator
    for (int i = 0; i < sortedOperatorIndices.Count; i++)
    {
        // finding the first operator from the operatorIndices in the sorted list
        if (sortedOperatorIndices[i] == operatorIndices[0])
        {
            // if it's not the first operator in the list, leftOperatorIndex is set to the operator on the left from the current operator (and 1 is added to avoid including the operator)
            if (i != 0) { leftOperatorIndex = sortedOperatorIndices[i - 1] + 1; }
            // if it's not the last operator in the list, rightOperatorIndex is set to the operator on the right from the current operator
            if (i != sortedOperatorIndices.Count - 1) { rightOperatorIndex = sortedOperatorIndices[i + 1]; }
            break;
        }
    }

    // evaluating the result and passing the term/substring (from the operator on the left - to the operator from the right) as the parameter
    double result = EvaluateTerm(formula.Substring(leftOperatorIndex, rightOperatorIndex - leftOperatorIndex));

    // substituting the term/substring (from the operator on the left - to the operator from the right) with the evaluted result
    formula = $"{formula.Substring(0, leftOperatorIndex)}{result}{formula.Substring(rightOperatorIndex)}";
}

// print out the result
// if the input/formula was empty/none, 0 is printed as the result
Console.Write("The result is: ");
Console.WriteLine(formula == "" ? "0" : formula);

// printing the google calculation link
Console.WriteLine("\nNot sure if it's correct?");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"Google Calculator: {googleCalculatorLink}");
Console.ResetColor();
#endregion


#region Methods
// method to evaluate a single term
double EvaluateTerm(string term)
{
    // loop through term (excluding the first character)
    int i;
    for (i = 1; i < term.Length; i++)
    {
        // break when the first operator (non-digit and not '.') was found, to leave i as the index of the operator
        if (!Char.IsDigit(term[i]) && term[i] != '.') { break; }
    }

    // saving the operator
    char @operator = term[i];
    // using substring to get the first number (from start to i)
    double firstNumber = double.Parse(term.Substring(0, i));
    // using substring to get the second number (from i + 1 to end)
    double secondNumber = double.Parse(term.Substring(i + 1));

    // calculating the result with a switch
    double result = 0;
    switch (@operator)
    {
        case '+': result = firstNumber + secondNumber; break;
        case '-': result = firstNumber - secondNumber; break;
        case '*': result = firstNumber * secondNumber; break;
        case '/': result = firstNumber / secondNumber; break;
    }

    // returning the result
    return result;
}

// method to check if a text contains given characters
bool ContainsOperator(string @string, string possibleOperators, bool ignoreFirstChar)
{
    // loop thorugh text starting from...
    // 1 if first character should be ignored
    // 0 if first character should be included
    for (int i = ignoreFirstChar ? 1 : 0; i < @string.Length; i++)
    {
        // if the current character is contained in the possible characters, true is returned
        if (possibleOperators.Contains(@string[i])) { return true; }
    }

    // if the loop was exited without finding an operator, false is returned
    return false;
}
#endregion