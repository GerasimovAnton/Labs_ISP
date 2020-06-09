using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CSLaba7
{
    class RationalNum : IComparable<RationalNum>
    {
        private long numerator;
        private long denominator;

        public long Numerator { get => numerator;}
        public long Denominator { get => denominator; }


        public RationalNum(long n, long m)
        {
            if (m <= 0) throw new Exception("Denominator cannot be less than 1");

            numerator = n;
            denominator = m;
        }
        public RationalNum(long n) : this(n, 1) { }
        public RationalNum()
        {
            numerator = 0;
            denominator = 1;
        }
        public RationalNum(RationalNum other)
        {
            if (other == null)
            {
                numerator = 0;
                denominator = 1;
                return;
            }

            numerator = other.numerator;
            denominator = other.denominator;
        }

        private static long GCD(long a, long b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        public override string ToString()
        {
            return ToString("");
        }
        public string ToString(string format)
        {
            if (String.IsNullOrEmpty(format))
            {
                format = "fraction";
            }
            format = format.Trim().ToLowerInvariant();
            switch (format)
            {
                case "fraction":
                    return Numerator.ToString() + '/' + Denominator.ToString();
                case "float":
                    return ((decimal)this).ToString();
                case "integer":
                    return ((long)this).ToString();
                default:
                    throw new Exception("Unsupported format");
            }
        }

        public static RationalNum Parse(string s)
        {
            Regex regex;
            MatchCollection match;

            regex = new Regex(@"-?\d+");
            match = regex.Matches(s);

            if (match.Count == 2)
            {
                try
                {
                    return new RationalNum( long.Parse(match[0].Value),
                                            long.Parse(match[1].Value));
                }
                catch { }
            }

            if (match.Count == 1)
            {
                try
                {
                    return new RationalNum(long.Parse(match[0].Value));
                }
                catch { }
            }

            throw new Exception("Unsupported arguments");
        }

        public int CompareTo(RationalNum other)
        {
            double a = (double)this;
            double b = (double)other;

            return (a >= b) ? (a > b) ? 1 : 0 : -1;
        }

        public static implicit operator RationalNum(long num)
        {
            return new CSLaba7.RationalNum(num);
        }

        public static implicit operator RationalNum(double d)
        {
            long denominator = 1;
            while (d % 1 != 0)
            {
                d *= 10;
                denominator *= 10;
            }
            long k = GCD((long)d, denominator);
            return new CSLaba7.RationalNum((long)(d / k), denominator / k);
        }

        public static explicit operator long(RationalNum num)
        {
            return ((num.Numerator - (Math.Abs(num.Numerator) % num.Denominator)) / num.Denominator);
        }

        public static explicit operator double(RationalNum num)
        {
            return ((double)num.Numerator / num.Denominator);
        }

        public static RationalNum operator +(RationalNum a, RationalNum b)
        {
            long n, m;

            n = a.Numerator * b.Denominator + a.Denominator * b.Numerator;
            m = a.Denominator * b.Denominator;

            return new RationalNum(n, m);
        }
        public static RationalNum operator -(RationalNum a, RationalNum b)
        {
            long n, m;
            n = a.Numerator * b.Denominator - a.Denominator * b.Numerator;
            m = a.Denominator * b.Denominator;
            
            return new RationalNum(n, m);
        }
        public static RationalNum operator *(RationalNum a, RationalNum b)
        {
            long n, m;
     
            n = a.Numerator * b.Numerator;
            m = a.Denominator * b.Denominator;

            return new RationalNum(n, m);
        }
        public static RationalNum operator /(RationalNum a, RationalNum b)
        {
            long n, m;

            n = a.Numerator * b.Denominator;
            m = a.Denominator * b.Numerator;
            
            return new RationalNum(n, m);
        }

        public static bool operator <(RationalNum a, RationalNum b)
        {
            return a.CompareTo(b) == -1;
        }
        public static bool operator >(RationalNum a, RationalNum b)
        {
            return a.CompareTo(b) == 1;
        }
        public static bool operator ==(RationalNum a, RationalNum b)
        {
            return a.CompareTo(b) == 0;
        }
        public static bool operator !=(RationalNum a, RationalNum b)
        {
            return a.CompareTo(b) != 0;
        }
        public static bool operator <=(RationalNum a, RationalNum b)
        {
            return a.CompareTo(b) != 1;
        }
        public static bool operator >=(RationalNum a, RationalNum b)
        {
            return a.CompareTo(b) != -1;
        }
        public static RationalNum operator ++(RationalNum a)
        {
            return a + 1;
        }
        public static RationalNum operator --(RationalNum a)
        {
            return a - 1;
        }


    }
}
