//-----------------------------------------------------------------------
// <copyright file="StringToFunctionConverter.cs" company="FHWN">
//     Copyright (c) Monkey with a Typewriter GMBH. All rights reserved.
// </copyright>
// <author>Jens Hanssen</author>
// <summary>
// This class is used to convert a given user input string into a mathematical function that can be used to calculate y values for any given x value.
// </summary>
//-----------------------------------------------------------------------
namespace GraphicalPlotter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Media;

    /// <summary>
    /// This class is a converter that takes a user string and converts it into a mathematical functions, with which y values can be calculate for any x value.
    /// </summary>
    public class StringToFunctionConverter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringToFunctionConverter" /> class.
        /// </summary>
        public StringToFunctionConverter()
        {
        }

        //// Returns out null if the given string was not a function in the right format.

        /// <summary>
        /// This method tries to parse a string into Graphical function.
        /// </summary>
        /// <param name="input"> The input string that should be parsed.</param>
        /// <param name="graphicalFunction"> The resulting GraphicalFunction if the parse was successful, else this out parameters becomes null.</param>
        /// <returns> A boolean indicating whether or not the parse was successful.</returns>
        public bool TryParseStringToGraphicalFunction(string input, out GraphicalFunction graphicalFunction)
        {
            List<FunctionParts> functionsCombined;

            if (this.TryParseStringToFunctionPartsList(input, out functionsCombined))
            {
                graphicalFunction = new GraphicalFunction(functionsCombined, Colors.Black,1);
                return true;
            }
            else
            {
                graphicalFunction = null;
                return false;
            }
        }

        /// <summary>
        /// This method tries to parse a string into a list of FunctionParts. It does this by splitting the string at the + and - signs between different parts of the function.
        /// For each function part it tries to parse the part of the string. If ANY string parts fails to be parsed, it is assumed the full string is not a valid mathematical function.
        /// </summary>
        /// <param name="input"> The string for which to create the list of FunctionParts for.</param>
        /// <param name="functionComponents"> The out parameter for the list of FunctionParts. If the parse was not successful null is put into the out parameter.</param>
        /// <returns> A boolean indicating whether or not the parse was successful.</returns>
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

        /// <summary>
        /// This method checks a string for allowed characters. If the string contains any other characters false is returned, else it returns true.
        /// </summary>
        /// <param name="input"> The string which needs to be checked for allowed symbols.</param>
        /// <returns> A boolean indicating whether or not the string does contain only valid characters. </returns>
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

        /// <summary>
        /// This method tries to parse a string that only contains constant values that are connected by +,- and * signs into a double value.
        /// </summary>
        /// <param name="toBeParsed"> The string for which to parse. </param>
        /// <param name="result"> The out parameter containing the result of the multiplication,  addition and subtraction for the constant values. If the string could not be parsed this double will be zero.</param>
        /// <returns > A boolean indicating whether or not the parse was successful.</returns>
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

        //// false strings like : "-15**sin(2x)"; or "-15*sin(2x*x)"; are still beeing parsed, expecially in the last case it is deceiving, but if the user wants right inputs he will just have to stick to the rules.

        /// <summary>
        /// This method tries to parse a string for which it was determined that it contains a sin function. 
        /// If the parse is successful a valid SineFunction is created and the method returns true.
        /// </summary>
        /// <param name="sinusFunctionAsString"> The string containing the assumed sine function for which to parse.</param>
        /// <param name="rightFunction"> The out parameter containing the SinusFunctions as a FunctionParts. If the parse fails this parameter will be set to null.</param>
        /// <returns> A boolean indicating whether or not the parse was successful.</returns>
        private bool TryParseSinusFunction(string sinusFunctionAsString, out FunctionParts rightFunction)
        {
            //// first strip of all whitespaces
            sinusFunctionAsString = sinusFunctionAsString.Replace(" ", string.Empty);

            double constantMultiplier;
            double degreeMultiplier;

            string constantMultiplierString = sinusFunctionAsString.Split('s')[0];
            //// sin(x),+sin(x),-sin(x)
            if (constantMultiplierString == string.Empty || constantMultiplierString == "+")
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
            string insideBrackets = sinusFunctionAsString.Split('(', ')')[1];

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

            string degreeMultiplierAsString = insideBrackets.Replace('x', ' ').Replace('*', ' ').Replace(" ", string.Empty);
            //// HERE
            if (degreeMultiplierAsString == string.Empty || degreeMultiplierAsString == "+")
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

        /// <summary>
        /// This method tries to parse a string for which it was determined that it contains a cos function. 
        /// If the parse is successful a valid CosineFunction is created and the method returns true.
        /// </summary>
        /// <param name="cosineFunctionAsString"> The string containing the assumed sine function for which to parse.</param>
        /// <param name="rightFunction"> The out parameter containing the CosineFunctions as a FunctionParts. If the parse fails this parameter will be set to null.</param>
        /// <returns> A boolean indicating whether or not the parse was successful.</returns>
        private bool TryParseCosineFunction(string cosineFunctionAsString, out FunctionParts rightFunction)
        {
            //// TODO first strip of all whitespaces
            cosineFunctionAsString = cosineFunctionAsString.Replace(" ", string.Empty);
            double constantMultiplier;
            double degreeMultiplier;
            string constantMultiplierString = cosineFunctionAsString.Split('c')[0];
            //// cos(x),+cos(x),-cos(x)
            if (constantMultiplierString == string.Empty || constantMultiplierString == "+")
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
            string insideBrackets = cosineFunctionAsString.Split('(', ')')[1];

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

            string degreeMultiplierAsString = insideBrackets.Replace('x', ' ').Replace('*', ' ').Replace(" ", string.Empty);
            if (degreeMultiplierAsString == string.Empty || degreeMultiplierAsString == "+")
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

        /// <summary>
        /// This method tries to parse a string for which it was determined that it contains a tan function. 
        /// If the parse is successful a valid TangentFunction is created and the method returns true.
        /// </summary>
        /// <param name="tangentFunctionAsString"> The string containing the assumed tangent function for which to parse.</param>
        /// <param name="rightFunction"> The out parameter containing the TangentFunctions as a FunctionParts. If the parse fails this parameter will be set to null.</param>
        /// <returns> A boolean indicating whether or not the parse was successful.</returns>
        private bool TryParseTangentFunction(string tangentFunctionAsString, out FunctionParts rightFunction)
        {
            tangentFunctionAsString = tangentFunctionAsString.Replace(" ", string.Empty);
            double constantMultiplier;
            double degreeMultiplier;
            string constantMultiplierString = tangentFunctionAsString.Split('t')[0];
            //// tan(x),+tan(x),-tan(x)
            if (constantMultiplierString == string.Empty || constantMultiplierString == "+")
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
            string insideBrackets = tangentFunctionAsString.Split('(', ')')[1];

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

            string degreeMultiplierAsString = insideBrackets.Replace('x', ' ').Replace('*', ' ').Replace(" ", string.Empty);
            if (degreeMultiplierAsString == string.Empty || degreeMultiplierAsString == "+")
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

        //// This function is still full with holes but its better than nothing and with the current system it should work, maybe next time i need to actually save a function asa a FUNC 
        ////or something like that. But i need more time to fix stuff like that

        /// <summary>
        /// This method tries to parse a string for which it was determined that it contains polynomial function part. 
        /// If the parse is successful a valid PolynomialComponent is created and the method returns true.
        /// </summary>
        /// <param name="polyFunctionAsString"> The string containing the assumed Polynomial Component function for which to parse.</param>
        /// <param name="rightFunction"> The out parameter containing the PolynomialComponent as a FunctionParts. If the parse fails this parameter will be set to null.</param>
        /// <returns> A boolean indicating whether or not the parse was successful.</returns>
        private bool TryParsePolynomialPart(string polyFunctionAsString, out FunctionParts rightFunction)
        {
            polyFunctionAsString = polyFunctionAsString.Replace(" ", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty);
            double constantMultiplier;
            double exponentenDegree;
            //// even if there is no x and its just a constant value, it will just return the full string as the only elemnt in the list
            string constantMultiplierString = polyFunctionAsString.Split('x')[0];
            //// tan(x),+tan(x),-tan(x)
            if (constantMultiplierString == string.Empty || constantMultiplierString == "+")
            {
                constantMultiplier = 1;
            }
            else if (constantMultiplierString == "-")
            {
                constantMultiplier = -1;
            }
            else if (constantMultiplierString.Split('*').Length >= 2
                && constantMultiplierString.Split('*')[1].Length < 0
                && double.TryParse(constantMultiplierString.Split('*')[1], out double secondmultiplier))
            {
                //// constants like -4*3 will not be parsed, and well if the user cant calculate that in his head or calculater i guess its his own fault.
                //// Can not just be 4* or *3 becouse of the second and term in this if statement, and also needs to be a parseable number, then we just take this string and convert it into a normal function , at this point the string could be anything like -4*8*-9 etc
                //// and does not have a defined lenght, so we will just split at the "*" mark and try to sum up all parts, if the split does not work there maybe is another problem in the function.
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
            if (!polyFunctionAsString.Contains('x'))
            {
                rightFunction = new PolynomialComponent(0, constantMultiplier);
                return true;
            }
            else if (!polyFunctionAsString.Contains('^'))
            {
                exponentenDegree = 1;
            }
            else
            {
                string afterExponentMark = polyFunctionAsString.Split('^')[1];

                if (afterExponentMark == string.Empty)
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

        /// <summary>
        /// This method splits a string that is suspected to be a function into a string array at the + and - operators.
        /// </summary>
        /// <param name="input"> The string that should be split up.</param>
        /// <returns> An array of string containing suspected Function Parts.</returns>
        private string[] SplitFunctionStringIntoArray(string input)
        {
            input = input.Replace(" ", string.Empty);
            char lastCharacter = ' ';
            string newStringToSplit = string.Empty;
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
    }
}