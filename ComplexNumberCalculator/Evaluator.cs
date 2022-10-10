namespace ComplexNumberCalculator
{
    public class Evaluator
    {
        public static ComplexNumber Evaluate(string expression)
        {
            string[] operators = new string[] { "+", "-", "*", "/", "^" };
            char[] separators = new char[] { '(', ')' };
            string[] expressionParts = expression.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            ComplexNumber result = new ComplexNumber(expressionParts[0]);
            for (int i = 1; i < expressionParts.Length; i++)
            {
                if (operators.Contains(expressionParts[i]))
                {
                    switch (expressionParts[i])
                    {
                        case "+":
                            result += new ComplexNumber(expressionParts[i + 1]);
                            break;

                        case "-":
                            result -= new ComplexNumber(expressionParts[i + 1]);
                            break;

                        case "*":
                            result *= new ComplexNumber(expressionParts[i + 1]);
                            break;

                        case "/":
                            result /= new ComplexNumber(expressionParts[i + 1]);
                            break;

                        case "^":
                            result ^= Double.Parse(expressionParts[i + 1]);
                            break;
                    }
                }
            }

            return result;
        }
    }
}