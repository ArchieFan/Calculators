using System;

public class Solution
{
    // Function to flip the sign using only "+"
    // operator (It is simple with '*' allowed.
    // We need to do a = (-1)*a
    static int flipSign(int a)
    {
        int neg = 0;

        // If sign is + ve turn it -ve
        // and vice-versa
        int tmp = a < 0 ? 1 : -1;
        while (a != 0)
        {
            neg += tmp;
            a += tmp;
        }
        return neg;
    }

    // Check if a and b are of different signs
    static bool areDifferentSign(int a, int b)
    {
        return ((a < 0 && b > 0) || (a > 0 && b < 0));
    }
    int Add(int x, int y)
    {
        // TODO: Write your code here
        return x + y;
    }

    int Subtract(int x, int y)
    {
        // TODO: Write your code here
        return x - y;
    }

    // Function to multiply a by b by
    // adding a to itself b time
    int Multiply(int x, int y)
    {
        // NB: you can ONLY use the addition and subtraction operators
        // TODO: Write your code here
        //return x * y;
        // because algo is faster if b<a
        if (x < y)
            return Multiply(y, x);

        // Adding a to itself b times
        int sum = 0;
        for (int i = Math.Abs(y); i > 0; i--)
            sum += x;

        // Check if final sign must be -ve or + ve
        if (y < 0)
            sum = flipSign(sum);

        return sum;
    }

    // Function to divide a by b by counting how many
    // times 'b' can be subtracted from 'a' before
    // getting 0
    int Divide(int x, int y)
    {
        // NB: you can ONLY use the addition and subtraction operators
        // TODO: Write your code here
        //return x / y;
        // Raise exception if b is 0
        if (y == 0)
            throw new ArithmeticException();

        int quotient = 0, dividend;

        // Negating b to subtract from a
        int divisor = flipSign(Math.Abs(y));

        // Subtracting divisor from dividend
        for (dividend = Math.Abs(x); dividend >= Math.Abs(divisor);
                                    dividend += divisor)
            quotient++;

        // Check if a and b are of similar symbols or not
        if (areDifferentSign(x, y))
            quotient = flipSign(quotient);
        return quotient;
    }

    static public string Run(string operation, int x, int y)
    {
        var solution = new Solution();

        switch (operation)
        {
            case "add":
                return solution.Add(x, y).ToString();
            case "subtract":
                return solution.Subtract(x, y).ToString();
            case "multiply":
                return solution.Multiply(x, y).ToString();
            case "divide":
                try
                {
                    return solution.Divide(x, y).ToString();
                }
                catch (Exception)
                {
                    return "Exception :- Divide by 0";
                }
                
            default:
                throw new ArgumentException("Invalid operation");
        }
    }
}