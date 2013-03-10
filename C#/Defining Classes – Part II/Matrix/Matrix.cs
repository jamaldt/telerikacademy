using System;
using System.Text;

public class Matrix<T>
    where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
{

    private int rows;
    private int cols;
    private T[,] data;

    public int Rows
    {
        get
        {
            return rows;
        }
    }

    public int Cols
    {
        get
        {
            return cols;
        }
    }

    public T this[int row, int col]
    {
        get
        {
            if (row >= 0 && row < rows && col >= 0 && col < cols)
            {
                return data[row, col];
            }
            else
            {
                throw new IndexOutOfRangeException(String.Format("Cell ({0}, {1}) is invalid.", row, col));
            }
        }
        set
        {
            if (row >= 0 && row < rows && col >= 0 && col < cols)
            {
                data[row, col] = value;
            }
            else
            {
                throw new IndexOutOfRangeException(String.Format("Cell ({0}, {1}) is invalid.", row, col));
            }
        }
    }

    public Matrix(int rows, int cols)
    {
        if (rows <= 0 || cols <= 0)
        {
            throw new ArgumentException("Matrix dimensions must be positive integers.");
        }

        this.rows = rows;
        this.cols = cols;
        this.data = new T[rows, cols];
    }

    public Matrix(T[,] value)
    {
        if (value == null || value.GetLength(0) == 0 || value.GetLength(1) == 0)
        {
            throw new ArgumentException("The two-dimensional initialization array must contain at least one item.");
        }

        this.rows = value.GetLength(0);
        this.cols = value.GetLength(1);
        data = (T[,])value.Clone();
    }


    public static Matrix<T> operator -(Matrix<T> m)
    {
        return Multiply(-1, m);
    }

    public static Matrix<T> operator +(Matrix<T> m1, Matrix<T> m2)
    {
        return Add(m1, m2);
    }

    public static Matrix<T> operator -(Matrix<T> m1, Matrix<T> m2)
    {
        return Add(m1, -m2);
    }

    public static Matrix<T> operator *(Matrix<T> m1, Matrix<T> m2)
    {
        return Multiply(m1, m2);
    }

    public static Matrix<T> operator *(int c, Matrix<T> m)
    {
        return Multiply(c, m);
    }

    public static Matrix<T> operator *(Matrix<T> m, int c)
    {
        return Multiply(c, m);
    }

    public static bool operator true(Matrix<T> m)
    {
        if (m == null || m.rows == 0 || m.cols == 0)
        {
            return false;
        }

        for (int row = 0; row < m.rows; row++)
        {
            for (int col = 0; col < m.cols; col++)
            {
                if (!m[row, col].Equals(default(T)))
                {
                    return true;
                }
            }
        }

        return false;
    }

    public static bool operator false(Matrix<T> m)
    {
        if (m == null || m.rows == 0 || m.cols == 0)
        {
            return true;
        }

        for (int row = 0; row < m.rows; row++)
        {
            for (int col = 0; col < m.cols; col++)
            {
                if (!m[row, col].Equals(default(T)))
                {
                    return false;
                }
            }
        }

        return true;
    }


    private static Matrix<T> Multiply(Matrix<T> m1, Matrix<T> m2)
    {
        if (m1 == null || m2 == null)
        {
            throw new Exception("Matrices are not initialized.");
        }

        if (m1.cols != m2.rows)
        {
            throw new Exception("Invalid dimensions of matrices!");
        }

        try
        {
            Matrix<T> result = new Matrix<T>(m1.rows, m2.cols);

            for (int row = 0; row < result.rows; row++)
            {
                for (int col = 0; col < result.cols; col++)
                {
                    result[row, col] = default(T);
                    for (int i = 0; i < m1.cols; i++)
                    {
                        checked
                        {
                            result[row, col] += (dynamic)m1[row, i] * m2[i, col];
                        }
                    }
                }
            }

            return result;
        }
        catch (OverflowException ex)
        {
            throw new OverflowException("Multiplication resulted in an overflow.", ex);
        }
    }

    private static Matrix<T> Multiply(int c, Matrix<T> m)
    {
        if (m == null)
        {
            throw new Exception("Matrix is not initialized.");
        }

        try
        {
            Matrix<T> result = new Matrix<T>(m.rows, m.cols);

            for (int row = 0; row < m.rows; row++)
            {
                for (int col = 0; col < m.cols; col++)
                {
                    checked
                    {
                        result[row, col] = (dynamic)m[row, col] * c;
                    }
                }
            }

            return result;
        }
        catch (OverflowException ex)
        {
            throw new OverflowException("Multiplication resulted in an overflow.", ex);
        }
    }

    private static Matrix<T> Add(Matrix<T> m1, Matrix<T> m2)
    {
        if (m1 == null || m2 == null)
        {
            throw new Exception("Matrices are not initialized.");
        }

        if (m1.rows != m2.rows || m1.cols != m2.cols)
        {
            throw new Exception("Matrices must have the same dimensions.");
        }

        try
        {
            Matrix<T> result = new Matrix<T>(m1.rows, m1.cols);

            for (int row = 0; row < result.rows; row++)
            {
                for (int col = 0; col < result.cols; col++)
                {
                    checked
                    {
                        result[row, col] = (dynamic)m1[row, col] + m2[row, col];
                    }
                }
            }

            return result;
        }
        catch (OverflowException ex)
        {
            throw new OverflowException("Addition resulted in an overflow.", ex);
        }
    }
}


