using System;
using System.Linq;

namespace GraphicalPlotter
{
    public class StringToFunctionConverter
    {
        public StringToFunctionConverter()
        {
        }

        //Returns null if the given string was not a function in the right format.
        public GraphicalFunction ConvertStringToGraphicalFunction(string input)
        {
            //TODO REMOVE
            throw new NotImplementedException();

            string[] functionStringParts = this.SplitFunctionStringIntoArray(input);

            foreach (string functionPart in functionStringParts)
            {
                FunctionParts currentFunctionPart = null;
                if (functionPart.Contains("sin"))
                {
                   //TODO WORK
                    throw new NotImplementedException();
                }
                else if (true)
                {
                }

                //if there is no right conversion or if any of the functions returned null no function will be generated, if there
                if (currentFunctionPart == null)
                {
                    return null;
                }
            }
        }

        // TODO RETURN TU PRIVATE INSTEAD OF PUBLIC
        public bool IsValidSinusFunction(string sinusFunction, out FunctionParts rightFunction)
        {
            double constantMultiplier;
            double degreeMultiplier;
            string constantMultiplierString = sinusFunction.Split('s')[0];
            //sin(x),+sin(x),-sin(x)
            if (constantMultiplierString == "" || constantMultiplierString == "+")
            {
                constantMultiplier = 1;
            }
            else if (constantMultiplierString == "-")
            {
                constantMultiplier = -1;
            }
            else if (!double.TryParse(constantMultiplierString, out constantMultiplier))
            {
                rightFunction = null;
                return false;
            }
            //function needs an x or else it would not be a function    
            string insideBrackets = sinusFunction.Split('(', ')')[1];

            

            if (!insideBrackets.Contains("x"))
            {
                //if the bracket only contains a number that is also valid but it would be a constant --> polynomial part.
                if (double.TryParse(insideBrackets, out degreeMultiplier))
                {
                    rightFunction = new PolynomialComponent(0, Math.Sin(degreeMultiplier) * constantMultiplier);
                    return true;
                   
                }




                rightFunction = null;
                return false;
            }

            string degreeMultiplierAsString = insideBrackets.Replace('x', ' ').Replace('*', ' ');
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

        //version 1 too much nesting
        //private bool IsValidSinusFunction(string sinusFunction, out FunctionParts rightSinFunction)
        //{
        //    double constantMultiplier;
        //    double degreeMultiplier;
        //    string constantMultiplierString = sinusFunction.Split('s')[0];
        //    //WHAT If somebody writes -sin(x) or sin(3*x) if the value below is empty that means its  = 1 ; if it is just a minus that is =-1
        //    if (constantMultiplierString == "" || constantMultiplierString == "+")
        //    {
        //        constantMultiplier = 1;
        //    }
        //    else if (constantMultiplierString == "-")
        //    {
        //        constantMultiplier = -1;
        //    }
        //    else if (double.TryParse(constantMultiplierString, out constantMultiplier))
        //    {
        //        //cases for +sin(x), sin(x) and -sin(x)

        //        //if the brackets dont contain x the function is invalid
        //        string insideBrackets = sinusFunction.Split('(', ')')[1];
        //        if (!insideBrackets.Contains("x"))
        //        {
        //            rightSinFunction = null;
        //            return false;
        //        }

        //        string degreeMultiplierAsString = insideBrackets.Replace('x', ' ').Replace('*', ' ');
        //        //TODO if there is nothing left then degMulti = 1
        //        //TODO if there is nothing left other than a minus then degMulti = -1
        //        //this should only leave us with the valid multiplier, but the user could have written some weird as shit so i hope i check all possibilties
        //        if (degreeMultiplierAsString == "" || degreeMultiplierAsString == "+")
        //        {
        //            degreeMultiplier = 1;
        //        }
        //        else if (degreeMultiplierAsString == "-")
        //        {
        //            degreeMultiplier = -1;
        //        }
        //        else if (double.TryParse(degreeMultiplierAsString, out degreeMultiplier))
        //        {
        //            rightSinFunction = new SineFunction(constantMultiplier, degreeMultiplier);
        //            return true;
        //        }
        //    }
        //    rightSinFunction = null;
        //    return false;
        //}

        private bool IsValidCosineFunction(string sinusFunction, out FunctionParts rightSinFunction)
        {
            double constantMultiplier;
            double degreeMultiplier;
            if (double.TryParse(sinusFunction.Split('c')[0], out constantMultiplier))
            {
                string insideBrackets = sinusFunction.Split('(', ')')[1];
                string multiplierAsString = insideBrackets.Replace('x', ' ').Replace('*', ' ');
                //this should only leave us with the valid multiplier, but the user could have written some weird as shit so i hope i check all possibilties
                if (double.TryParse(multiplierAsString, out degreeMultiplier))
                {
                    rightSinFunction = new CosineFunction(constantMultiplier, degreeMultiplier);
                    return true;
                }
            }
            rightSinFunction = null;
            return false;
        }

        private bool IsValidTangentFunction(string sinusFunction, out FunctionParts rightSinFunction)
        {
            double constantMultiplier;
            double degreeMultiplier;
            if (double.TryParse(sinusFunction.Split('t')[0], out constantMultiplier))
            {
                string insideBrackets = sinusFunction.Split('(', ')')[1];
                string multiplierAsString = insideBrackets.Replace('x', ' ').Replace('*', ' ');
                //this should only leave us with the valid multiplier, but the user could have written some weird as shit so i hope i check all possibilties
                if (double.TryParse(multiplierAsString, out degreeMultiplier))
                {
                    rightSinFunction = new TangentFunction(constantMultiplier, degreeMultiplier);
                    return true;
                }
            }
            rightSinFunction = null;
            return false;
        }

        private bool IsValidPolynomialPart(string sinusFunction, out FunctionParts rightSinFunction)
        {
            double constantMultiplier;
            double degreeMultiplier;
            if (double.TryParse(sinusFunction.Split('t')[0], out constantMultiplier))
            {
                string insideBrackets = sinusFunction.Split('(', ')')[1];
                string multiplierAsString = insideBrackets.Replace('x', ' ').Replace('*', ' ');
                //this should only leave us with the valid multiplier, but the user could have written some weird as shit so i hope i check all possibilties
                if (double.TryParse(multiplierAsString, out degreeMultiplier))
                {
                    rightSinFunction = new TangentFunction(constantMultiplier, degreeMultiplier);
                    return true;
                }
            }
            rightSinFunction = null;
            return false;
        }

        private string[] SplitFunctionStringIntoArray(string input)
        {
            char lastCharacter = ' ';
            string newStringToSplit = "";
            foreach (char currentCharacter in input)
            {
                if ((currentCharacter == '+' || currentCharacter == '-') && lastCharacter != '(')
                {
                    newStringToSplit += "j";
                }
                newStringToSplit += currentCharacter;
                lastCharacter = currentCharacter;
            }

            return newStringToSplit.Split('j');
        }

        //for the current implementation this is enough
        public bool DoesFunctionContainInvalidChracters(string input)
        {
            char[] allowedSymbols = new char[] { '-', '+', '(', ')', '*', /*'/',*/ 's', 'i', 'n', 'c', 'o', 't', 'x', '^', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            // it would return a "relative complement" which i had to look up because ive never seen that in english.
            var invalidCharacters = input.Except(allowedSymbols);
            if (invalidCharacters.Any())
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}