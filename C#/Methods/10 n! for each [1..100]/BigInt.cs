using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_n__for_each__1._100_
{
    class BigInt
    {
        List<byte> number;

        public BigInt(int n)
        {
            number = ConvertToBigInt(n);
        }

        public BigInt()
        {
            number = new List<byte>();
        }

        private List<byte> ConvertToBigInt(int n)
        {
            number = new List<byte>();       
            do
            {
                number.Add((byte)(n % 10));
                n /= 10;
            }
            while (n > 0);
            return number;
         }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            for (int i = number.Count - 1; i >= 0; i--)
            {
                str.Append(number[i]);
            }
            return str.ToString();
        }



        internal void Multiply(int n)
        {
            Multiply(new BigInt(n));
        }


        public void Multiply(BigInt multiplyer)
        {
            byte product;
            byte reminder;
            BigInt tempSum = new BigInt(0);
            BigInt tempProduct = new BigInt();
            for(int i = 0; i < multiplyer.number.Count; i++)
            {
                reminder = 0;
                tempProduct.number.Clear();
                foreach (byte num in number)
                {
                    product = (byte)(num * multiplyer.number[i] + reminder);
                    reminder = AddProduct(tempProduct, product);
                }
                if (reminder > 0)
                {
                    tempProduct.number.Add(reminder);
                }
                tempSum.Sum(tempProduct, i);
            }
            number = tempSum.number;
        }

        private byte AddProduct(BigInt temp, byte product)
        {
            if (product < 10)
            {
                temp.number.Add(product);
                return 0;
            }
            else
            {
                temp.number.Add((byte)(product % 10));
                return (byte)(product / 10);
            }
        }

        public void Sum(BigInt num, int shift = 0)
        {
            byte reminder = 0;
            byte tempSum;
            int index = 0;

            if (number.Count <= num.number.Count + shift)
            {
                for (int i = shift; i < number.Count; i++)
                {
                    tempSum = (byte)(num.number[index] + number[i] + reminder);
                    reminder = AddSum(this, tempSum, i);
                    index++;
                }
                while (index < num.number.Count)
                {
                    tempSum = (byte)(num.number[index] + reminder);
                    number.Add(1);
                    reminder = AddSum(this, tempSum, this.number.Count - 1);
                    index++;
                }
                if (reminder == 1)
                {
                    number.Add(1);
                }
            }
            else
            {
                for (int i = shift; i < num.number.Count; i++)
                {
                    tempSum = (byte)(num.number[index] + number[i] + reminder);
                    reminder = AddSum(this, tempSum, i);
                    index++;
                }
                while (index < number.Count)
                {
                    tempSum = (byte)(number[index] + reminder);                    
                    reminder = AddSum(this, tempSum, index);
                    index++;
                }
                if (reminder == 1)
                {
                    number.Add(1);
                }
            }
        }

        private byte AddSum(BigInt bigger, byte tempSum, int index)
        {           
            if (tempSum >= 10)
            {
                bigger.number[index] = (byte)(tempSum % 10);
                return 1;
            }
            else
            {
                bigger.number[index] = tempSum;
                return 0;
            }
        }
    }
}
