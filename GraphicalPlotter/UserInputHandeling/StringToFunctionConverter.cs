using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace GraphicalPlotter
{
    public class StringToFunctionConverter
    {
        public StringToFunctionConverter()
        {
            //// why do i have to set a culture for a double conversion??? If your a fucking multimillion dollar business WHY WHY WHY can you just fucking write a method that works with a point and also a comma. godamnit.
        }

        //// Returns out null if the given string was not a function in the right format.
        public bool TryParseStringToGraphicalFunction(string input, out GraphicalFunction graphicalFunction)
        {
            List<FunctionParts> functionsCombined;

            if (this.TryParseStringToFunctionPartsList(input, out functionsCombined))
            {
                graphicalFunction = new GraphicalFunction(functionsCombined, Colors.Black);
                return true;
            }
            else
            {
                graphicalFunction = null;
                return false;
            }
        }

        public bool TryParseStringToFunctionPartsList(string input, out List<FunctionParts> functionComponents)
        {
            if (!this.DoesFunctionContainOnlyValidChracters(input))
            {
                functionComponents = null;
                return false;
            }

            string[] functionStringParts = this.SplitFunctionStringIntoArray(input);

            List<FunctionParts> functionsCombined = new List<FunctionParts>();

            foreach (string functionPart in functionStringParts)
            {
                FunctionParts currentFunctionPart = null;
                try
                {
                    if (functionPart.Contains("sin"))
                    {
                        this.TryParseSinusFunction(functionPart, out currentFunctionPart);
                    }
                    else if (functionPart.Contains("cos"))
                    {
                        this.TryParseCosineFunction(functionPart, out currentFunctionPart);
                    }
                    else if (functionPart.Contains("tan"))
                    {
                        this.TryParseTangentFunction(functionPart, out currentFunctionPart);
                    }
                    else if (functionPart == string.Empty)
                    {
                        continue;
                    }
                    else
                    {
                        this.TryParsePolynomialPart(functionPart, out currentFunctionPart);
                    }

                    //// if there is no right conversion or if any of the functions returned null no function will be generated
                    if (currentFunctionPart == null)
                    {
                        functionComponents = null;
                        return false;
                    }
                    else
                    {
                        functionsCombined.Add(currentFunctionPart);
                    }
                }
                catch (Exception)
                {
                    functionComponents = null;
                    return false;
                }
            }

            functionComponents = functionsCombined;
            return true;
        }

        //// false strings like : "-15**sin(2x)"; or "-15*sin(2x*x)"; are still beeing parsed, expecially in the last case it is deceiving, but if the user wants right inputs he will just have to stick to the rules.

        private bool TryParseSinusFunction(string sinusFunction, out FunctionParts rightFunction)
        {
            //// first strip of all whitespaces
            sinusFunction = sinusFunction.Replace(" ", "");

            double constantMultiplier;
            double degreeMultiplier;

            string constantMultiplierString = sinusFunction.Split('s')[0];
            //// sin(x),+sin(x),-sin(x)
            if (constantMultiplierString == "" || constantMultiplierString == "+")
            {
                constantMultiplier = 1;
            }
            else if (constantMultiplierString == "-")
            {
                constantMultiplier = -1;
            }
            else if (!double.TryParse(constantMultiplierString.Replace('*', ' '), out constantMultiplier))
            {
                rightFunction = null;
                return false;
            }
            //// function needs an x or else it would not be a function
            string insideBrackets = sinusFunction.Split('(', ')')[1];

            if (!insideBrackets.Contains("x"))
            {
                //// if the bracket only contains a number that is also valid but it would be a constant --> polynomial part.
                if (double.TryParse(insideBrackets, out degreeMultiplier))
                {
                    rightFunction = new PolynomialComponent(0, Math.Sin(degreeMultiplier) * constantMultiplier);
                    return true;
                }

                rightFunction = null;
                return false;
            }

            string degreeMultiplierAsString = insideBrackets.Replace('x', ' ').Replace('*', ' ').Replace(" ", "");
            //// HERE
            if (degreeMultiplierAsString == "" || degreeMultiplierAsString == "+")
            {
                degreeMultiplier = 1;
            }
            else if (degreeMultiplierAsString == "-")
            {
                degreeMultiplier = -1;
            }
            else if (!double.TryParse(degreeMultiplierAsString, out degreeMultiplier))
            {
                rightFunction = null;
                return false;
            }

            rightFunction = new SineFunction(constantMultiplier, degreeMultiplier);
            return true;
        }

        private bool TryParseCosineFunction(string cosineFunction, out FunctionParts rightFunction)
        {
            //// TODO first strip of all whitespaces
            cosineFunction = cosineFunction.Replace(" ", "");
            double constantMultiplier;
            double degreeMultiplier;
            string constantMultiplierString = cosineFunction.Split('c')[0];
            //// cos(x),+cos(x),-cos(x)
            if (constantMultiplierString == "" || constantMultiplierString == "+")
            {
                constantMultiplier = 1;
            }
            else if (constantMultiplierString == "-")
            {
                constantMultiplier = -1;
            }
            else if (!double.TryParse(constantMultiplierString.Replace('*', ' '), out constantMultiplier))
            {
                rightFunction = null;
                return false;
            }
            //// function needs an x or else it would not be a function
            string insideBrackets = cosineFunction.Split('(', ')')[1];

            if (!insideBrackets.Contains("x"))
            {
                //// if the bracket only contains a number that is also valid but it would be a constant --> polynomial part.
                if (double.TryParse(insideBrackets, out degreeMultiplier))
                {
                    rightFunction = new PolynomialComponent(0, Math.Cos(degreeMultiplier) * constantMultiplier);
                    return true;
                }

                rightFunction = null;
                return false;
            }

            string degreeMultiplierAsString = insideBrackets.Replace('x', ' ').Replace('*', ' ').Replace(" ", "");
            if (degreeMultiplierAsString == "" || degreeMultiplierAsString == "+")
            {
                degreeMultiplier = 1;
            }
            else if (degreeMultiplierAsString == "-")
            {
                degreeMultiplier = -1;
            }
            else if (!double.TryParse(degreeMultiplierAsString, out degreeMultiplier))
            {
                rightFunction = null;
                return false;
            }

            rightFunction = new CosineFunction(constantMultiplier, degreeMultiplier);
            return true;
        }

        private bool TryParseTangentFunction(string tangentFunction, out FunctionParts rightFunction)
        {
            tangentFunction = tangentFunction.Replace(" ", "");
            double constantMultiplier;
            double degreeMultiplier;
            string constantMultiplierString = tangentFunction.Split('t')[0];
            //// tan(x),+tan(x),-tan(x)
            if (constantMultiplierString == "" || constantMultiplierString == "+")
            {
                constantMultiplier = 1;
            }
            else if (constantMultiplierString == "-")
            {
                constantMultiplier = -1;
            }
            else if (!double.TryParse(constantMultiplierString.Replace('*', ' '), out constantMultiplier))
            {
                rightFunction = null;
                return false;
            }
            //// function needs an x or else it would not be a function
            string insideBrackets = tangentFunction.Split('(', ')')[1];

            if (!insideBrackets.Contains("x"))
            {
                //// if the bracket only contains a number that is also valid but it would be a constant --> polynomial part.
                if (double.TryParse(insideBrackets, out degreeMultiplier))
                {
                    rightFunction = new PolynomialComponent(0, Math.Cos(degreeMultiplier) * constantMultiplier);
                    return true;
                }

                rightFunction = null;
                return false;
            }

            string degreeMultiplierAsString = insideBrackets.Replace('x', ' ').Replace('*', ' ').Replace(" ", "");
            if (degreeMultiplierAsString == "" || degreeMultiplierAsString == "+")
            {
                degreeMultiplier = 1;
            }
            else if (degreeMultiplierAsString == "-")
            {
                degreeMultiplier = -1;
            }
            else if (!double.TryParse(degreeMultiplierAsString, out degreeMultiplier))
            {
                rightFunction = null;
                return false;
            }

            rightFunction = new TangentFunction(constantMultiplier, degreeMultiplier);
            return true;
        }

        //// This function is still full with holes but its better than nothing and with the current system it should work, maybe next time i need to actually save a function asa a FUNC or something like that. But i need more time to fix stuff like that
        private bool TryParsePolynomialPart(string polyFunction, out FunctionParts rightFunction)
        {
            polyFunction = polyFunction.Replace(" ", "").Replace("(", "").Replace(")", "");
            double constantMultiplier;
            double exponentenDegree;
            //// even if there is no x and its just a constant value, it will just return the full string as the only elemnt in the list
            string constantMultiplierString = polyFunction.Split('x')[0];
            //// tan(x),+tan(x),-tan(x)
            if (constantMultiplierString == "" || constantMultiplierString == "+")
            {
                constantMultiplier = 1;
            }
            else if (constantMultiplierString == "-")
            {
                constantMultiplier = -1;
            }
            //// constants like -4*3 will not be parsed, and well if the user cant calculate that in his head or calculater i guess its his own fault.
            //// Can not just be 4* or *3 becouse of the second and term in this if statement, and also needs to be a parseable number, then we just take this string and convert it into a normal function , at this point the string could be anything like -4*8*-9 etc
            //// and does not have a defined lenght, so we will just split at the "*" mark and try to sum up all parts, if the split does not work there maybe is another problem in the function.
            else if (constantMultiplierString.Split('*').Length >= 2
                && constantMultiplierString.Split('*')[1].Length < 0
                && double.TryParse(constantMultiplierString.Split('*')[1], out double secondmultiplier))
            {
                if (this.ParseAStringWithMultituteOfSimpleMultiplication(constantMultiplierString, out double sumOfCalculation))
                {
                    rightFunction = new PolynomialComponent(0, sumOfCalculation);
                    return true;
                }
                else
                {
                    rightFunction = null;
                    return false;
                }
            }
            else if (!double.TryParse(constantMultiplierString.Replace('*', ' '), out constantMultiplier))
            {
                rightFunction = null;
                return false;
            }

            //// at this point it must be a constant
            if (!polyFunction.Contains('x'))
            {
                rightFunction = new PolynomialComponent(0, constantMultiplier);
                return true;
            }
            else if (!polyFunction.Contains('^'))
            {
                exponentenDegree = 1;
            }
            else
            {
                string afterExponentMark = polyFunction.Split('^')[1];

                if (afterExponentMark == "")
                {
                    exponentenDegree = 1;
                }
                else if (!double.TryParse(afterExponentMark, out exponentenDegree))
                {
                    rightFunction = null;
                    return false;
                }
                if (!(exponentenDegree <= 10))
                {
                    rightFunction = null;
                    return false;
                }
            }

            rightFunction = new PolynomialComponent(exponentenDegree, constantMultiplier);
            return true;
        }

        public bool ParseAStringWithMultituteOfSimpleMultiplication(string toBeParsed, out double result)
        {
            string[] multipliers = toBeParsed.Split('*');
            double sum = 0;

            foreach (string multi in multipliers)
            {
                double currentResult;
                if (double.TryParse(multi, out currentResult))
                {
                    sum += currentResult;
                }
                else
                {
                    result = 0;
                    return false;
                }
            }
            result = sum;
            return true;
        }

        private string[] SplitFunctionStringIntoArray(string input)
        {
            input = input.Replace(" ", "");
            char lastCharacter = ' ';
            string newStringToSplit = "";
            foreach (char currentCharacter in input)
            {
                if ((currentCharacter == '+' || currentCharacter == '-') && !(lastCharacter == '(' || lastCharacter == '^' || lastCharacter == '*'))
                {
                    newStringToSplit += "j";
                }
                newStringToSplit += currentCharacter;
                lastCharacter = currentCharacter;
            }

            return newStringToSplit.Split('j');
        }

        //// for the current implementation this is enough
        public bool DoesFunctionContainOnlyValidChracters(string input)
        {
            char[] allowedSymbols = new char[] { '-', '+', '(', ')', '*', ',', 's', 'i', 'n', 'c', 'o', 't', 'x', 'a', '^', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ' ' };

            //// it would return a "relative complement" which i had to look up because ive never seen that in english.
            var invalidCharacters = input.Except(allowedSymbols);
            if (invalidCharacters.Any())
            {
                return false;
            }
            else if (input.Contains("**"))
            {
                return false;
            }
            {
                return true;
            }
        }
    }
}