using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SevenZ.Calculator
{
   public partial class Calculator
   {
      private readonly string[] pC = { "a", "b", "c", "d", "f", "g", "h", "i", "j", "k" };
      public bool[] active = new bool[10];
      public bool Qs;

      Stack<double> operands;
      Stack<string> operators;

      string token;
      int tokenPos;
      string expression;

      public Calculator()
      {
         Qs = false;
         Reset();
      }

      public void Reset()
      {
         LoadConstants();
         Clear();
      }

      public void Clear()
      {
         operands = new Stack<double>();
         operators = new Stack<string>();

         operators.Push(Token.Sentinel);
         token = Token.None;
         tokenPos = -1;
      }

      /// <summary>
      /// Evaluates mathematical expression
      /// </summary>
      /// <param name="expr">Input expression</param>
      /// <returns>Result in double format</returns>
      public double Evaluate(string expr)
      {
         Clear();
         expression = expr;
         if (Normalize(ref expression))
         {
            double result = Parse();
            return result;
         }
         else
         {
            ThrowException("Blank input expression");
            return 0;
         }
      }

      private double Parse()
      {
         ParseBinary();
         Expect(Token.End);
         return operands.Peek();
      }

      /// <summary>
      /// Parse binary operations
      /// </summary>
      private void ParseBinary()
      {
         ParsePrimary();

         while (Token.IsBinary(token))
         {
            PushOperator(token);
            NextToken();
            ParsePrimary();
         }

         while (operators.Peek() != Token.Sentinel)
            PopOperator();
      }

      /// <summary>
      /// Parse primary tokens: digits, variables, functions, parentheses
      /// </summary>
      private void ParsePrimary()
      {
         if (Token.IsDigit(token)) // reading numbers
         {
            ParseDigit();
         }
         else if (Token.IsName(token)) // variable or function (both binary and unary)
         {
            ParseName();
         }
         else if (Token.IsUnary(token)) // unary operator (unary minus)
         {
            PushOperator(Token.ConvertOperator(token));
            NextToken();
            ParsePrimary();
         }
         else if (token == Token.PLeft) // parentheses
         {
            NextToken();
            operators.Push(Token.Sentinel); // add sentinel to operators stack
            ParseBinary();
            Expect(Token.PRight, Token.Separator);
            operators.Pop(); // pop sentinel from the stack

            TryInsertMultiply();
            TryRightSideOperator();
         }
         else if (token == Token.Separator) // arguments separator in funtions (',')
         {
            NextToken();
            ParsePrimary();
         }
         else
            ThrowException("Syntax error");
      }



      private void ParseDigit()
      {
         StringBuilder tmpNumber = new StringBuilder();

         while (Token.IsDigit(token)) 
         {
            CollectToken(ref tmpNumber); 
         }

         operands.Push(double.Parse(tmpNumber.ToString(), System.Globalization.CultureInfo.InvariantCulture));
         TryInsertMultiply();
         TryRightSideOperator();
      }

      /// <summary>
      /// Turn name into a variable or a function
      /// </summary>
      private void ParseName()
      {
         StringBuilder tmpName = new StringBuilder();
         
         while (Token.IsName(token)) 
         {
            CollectToken(ref tmpName); 
         }

         string name = tmpName.ToString();

         if (Token.IsFunction(name)) // Execute operand in case of driver's function (Sin, Cos e.t.c)
         {
            PushOperator(name);
            ParsePrimary();
         }
         else //Variable: char (one or more) and digit (zero or more). Ex: v, a1, bb, c3d
         {
             if (Qs)
             {
                 int i;
                 bool was = false;
                 for (i = 0; i < 10; i++)
                 {
                     if (name == pC[i])
                     {
                         was = true;
                         break;
                     }
                 }

                 if (was) active[i] = true;
             }

            if (token == Token.Store) // in case of var=Expression
            {
               NextToken();
               SetVariable(name, Parse());
            }
            else
            {
               operands.Push(GetVariable(name));
               TryInsertMultiply();
               TryRightSideOperator();
               
            }
         }
      }

      /// <summary>
      /// Check x(...), make it equal to x*(...)
      /// numberFunc(..) or numberVar, change to -> number*Func(..) or number*Var
      /// Check (...)(...), make it equal to (...)*(...)
      /// </summary>
      private void TryInsertMultiply()
      {
         if (!Token.IsBinary(token) && !Token.IsSpecial(token) && !Token.IsRightSide(token))
         {
            PushOperator(Token.Multiply);
            ParsePrimary();
         }
      }

      /// <summary>
      /// Check for right-side operators (Factorial) and for arguments separator 
      /// </summary>
      private void TryRightSideOperator()
      {
         switch(token)
         {
            case Token.Factorial :
            {
               PushOperator(Token.Factorial);
               NextToken();
               TryInsertMultiply();
               break;
            }
            case Token.Separator:
               ParsePrimary(); // arguments separator in functions F(x1, x2 ... xn)
               break;
         }   
      }

      private void PushOperator(string op)
      {
         while ( Token.Compare(operators.Peek(),op) > 0) //Token.Precedence(operators.Peek()) >= Token.Precedence(op))
            PopOperator();

         operators.Push(op);
      }

      private void PopOperator()
      {
         if (Token.IsBinary(operators.Peek()))
         {
            double o2 = operands.Pop();
            double o1 = operands.Pop();
            Calculate(operators.Pop(), o1, o2);
         }
         else // unary operator
         {
            Calculate(operators.Pop(), operands.Pop());
         }
      }

      /// <summary>
      /// Get next token from the expression
      /// </summary>
      private void NextToken()
      {
         if (token != Token.End)
         {
            token = expression[++tokenPos].ToString();
         }
      }

      /// <summary>
      /// Read token character by character
      /// </summary>
      /// <param name="sb">Temporary buffer</param>
      private void CollectToken(ref StringBuilder sb)
      {
         sb.Append(token);
         NextToken();
      }
      
      private void Expect(params string[] expectedTokens)
      {
         for (int i = 0; i < expectedTokens.Length; i++)
            if (token == expectedTokens[i])
            {
               NextToken();
               return;
            }
         
         ThrowException("Syntax error: " + Token.ToString(expectedTokens[0]) + "  expected");
      }

      /// <summary>
      /// Normalizes expression.
      /// </summary>
      /// <param name="s">Expression string</param>
      /// <returns>Returns true, if expression is suitable for evaluating.</returns>
      private bool Normalize(ref string s)
      {
         s = s.Replace(" ", "").Replace("\t", " ").ToLower() + Token.End;

         if (s.Length >= 2) // any character and End token
         {
            //if (Token.IsBinary(s[0].ToString()) && !Token.IsName(
            NextToken();
            return true;
         }

         return false;
      }

      private void ThrowException(string message)
      {
         throw new CalculateException(message, tokenPos);
      }

   }

   public class CalculateException : Exception
   {
      //int position;

      /*
      public CalculateException(string message, int position)
         : base("Error at position " + position.ToString() + "\r\n" + message)
      {
         this.position = position;
      }
       */

      public CalculateException(string message, int position): base(message)
      {
          
      }

      //public int TokenPosition
      //{
     //   get { return position; }
     // }
   }
}
