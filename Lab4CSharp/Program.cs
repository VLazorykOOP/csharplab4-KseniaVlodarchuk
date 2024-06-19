using System;

public class Date
{
    private DateTime date;

    public Date(DateTime initialDate)
    {
        date = initialDate;
    }

    // Індексатор для доступу до i-го дня
    public DateTime this[int index]
    {
        get
        {
            return date.AddDays(index);
        }
    }

    // Операція !
    public static bool operator !(Date d)
    {
        return d.date.Day != DateTime.DaysInMonth(d.date.Year, d.date.Month);
    }

    // Перевантаження true і false
    public static bool operator true(Date d)
    {
        return d.date.Month == 1 && d.date.Day == 1;
    }

    public static bool operator false(Date d)
    {
        return !(d);
    }

    // Операція &
    public static bool operator &(Date d1, Date d2)
    {
        return d1.date == d2.date;
    }

    // Перетворення у string
    public static implicit operator string(Date d)
    {
        return d.date.ToString("yyyy-MM-dd");
    }

    // Перетворення з string
    public static implicit operator Date(string s)
    {
        return new Date(DateTime.Parse(s));
    }
}

public class VectorByte
{
    protected byte[] BArray;   // масив
    protected uint n;          // розмір вектора
    protected int codeError;   // код помилки
    protected static uint num_vec; // кількість векторів

    // Конструктор без параметрів
    public VectorByte()
    {
        BArray = new byte[1];
        n = 1;
        BArray[0] = 0;
        codeError = 0;
        num_vec++;
    }

    // Конструктор з одним параметром - розмір вектора
    public VectorByte(uint size)
    {
        BArray = new byte[size];
        n = size;
        for (uint i = 0; i < size; i++)
        {
            BArray[i] = 0;
        }
        codeError = 0;
        num_vec++;
    }

    // Конструктор із двома параметрами - розмір вектора та значення ініціалізації
    public VectorByte(uint size, byte initialValue)
    {
        BArray = new byte[size];
        n = size;
        for (uint i = 0; i < size; i++)
        {
            BArray[i] = initialValue;
        }
        codeError = 0;
        num_vec++;
    }

    // Деструктор
    ~VectorByte()
    {
        Console.WriteLine("Вектор знищено.");
        num_vec--;
    }

    // Введення елементів вектора з клавіатури
    public void InputElements()
    {
        for (uint i = 0; i < n; i++)
        {
            bool validInput = false;
            while (!validInput)
            {
                Console.Write($"Введіть елемент {i}: ");
                string input = Console.ReadLine();
                if (byte.TryParse(input, out byte value))
                {
                    BArray[i] = value;
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Неправильне введення. Будь ласка, введіть число.");
                }
            }
        }
    }

    // Виведення елементів вектора на екран
    public void OutputElements()
    {
        for (uint i = 0; i < n; i++)
        {
            Console.Write($"{BArray[i]} ");
        }
        Console.WriteLine();
    }

    // Присвоєння елементам масиву вектора деякого значення
    public void AssignValue(byte value)
    {
        for (uint i = 0; i < n; i++)
        {
            BArray[i] = value;
        }
    }

    // Статичний метод, що підраховує кількість векторів даного типу
    public static uint CountVectors()
    {
        return num_vec;
    }

    // Властивість, що повертає розмірність вектора (доступні лише для читання)
    public uint Size
    {
        get { return n; }
    }

    // Властивість, що дозволяє отримати-встановити значення поля codeError (доступні для читання і запису)
    public int CodeError
    {
        get { return codeError; }
        set { codeError = value; }
    }

    // Індексатор
    public byte this[int index]
    {
        get
        {
            if (index >= 0 && index < n)
            {
                codeError = 0;
                return BArray[index];
            }
            else
            {
                codeError = -1;
                return 0;
            }
        }
        set
        {
            if (index >= 0 && index < n)
            {
                BArray[index] = value;
                codeError = 0;
            }
            else
            {
                codeError = -1;
            }
        }
    }

    // Перевантаження унарних операцій ++ і --
    public static VectorByte operator ++(VectorByte v)
    {
        for (uint i = 0; i < v.n; i++)
        {
            v.BArray[i]++;
        }
        return v;
    }

    public static VectorByte operator --(VectorByte v)
    {
        for (uint i = 0; i < v.n; i++)
        {
            v.BArray[i]--;
        }
        return v;
    }

    // Перевантаження сталих true і false
    public static bool operator true(VectorByte v)
    {
        if (v.n != 0)
        {
            foreach (var item in v.BArray)
            {
                if (item != 0) return true;
            }
        }
        return false;
    }

    public static bool operator false(VectorByte v)
    {
        if (v.n == 0)
        {
            return true;
        }
        foreach (var item in v.BArray)
        {
            if (item != 0) return false;
        }
        return true;
    }
}


public class MatrixByte
{
    // Поля класу
    protected byte[,] ByteArray;
    protected uint n, m;
    protected int codeError;
    protected static int num_vec;
  
    // Конструктор без параметрів
    public MatrixByte()
    {
        n = 1;
        m = 1;
        ByteArray = new byte[n, m];
        codeError = 0;
        num_vec++;
    }

    // Конструктор з двома параметрами
    public MatrixByte(uint sizeN, uint sizeM)
    {
        n = sizeN;
        m = sizeM;
        ByteArray = new byte[n, m];
        codeError = 0;
        num_vec++;
    }

    // Конструктор з трьома параметрами
    public MatrixByte(uint sizeN, uint sizeM, byte initValue)
    {
        n = sizeN;
        m = sizeM;
        ByteArray = new byte[n, m];
        codeError = 0;
        num_vec++;

        // Ініціалізація значеннями initValue
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                ByteArray[i, j] = initValue;
            }
        }
    }

    // Деструктор
    ~MatrixByte()
    {
        Console.WriteLine("Деструктор класу MatrixByte викликано.");
    }

    // Метод для введення елементів матриці з клавіатури
    public void InputValues()
    {
        Console.WriteLine("Введіть елементи матриці:");

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                bool validInput = false;
                while (!validInput)
                {
                    Console.Write($"ByteArray[{i},{j}]: ");
                    string input = Console.ReadLine();
                    byte value;

                    if (byte.TryParse(input, out value))
                    {
                        ByteArray[i, j] = value;
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Некоректне значення. Введіть ціле число від 0 до 255.");
                        codeError = -1; // код помилки -1 при некоректному введенні
                    }
                }
            }
        }
    }

    // Метод для виведення елементів матриці на екран
    public void PrintValues()
    {
        Console.WriteLine("Елементи матриці:");

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"{ByteArray[i, j]} ");
            }
            Console.WriteLine();
        }
    }

    // Метод для присвоєння всім елементам матриці певного значення
    public void AssignValue(byte value)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                ByteArray[i, j] = value;
            }
        }
    }

    // Статичний метод для підрахунку кількості матриць даного типу
    public static int CountMatrices()
    {
        return num_vec;
    }

    // Властивість для отримання розмірності матриці (тільки для читання)
    public uint SizeN => n;
    public uint SizeM => m;

    // Властивість для доступу до поля codeError (для читання і запису)
    public int ErrorCode
    {
        get { return codeError; }
        set { codeError = value; }
    }

    // Індексатор з двома індексами
    public byte this[uint i, uint j]
    {
        get
        {
            if (i < n && j < m)
            {
                return ByteArray[i, j];
            }
            else
            {
                codeError = -1; // код помилки -1 при некоректному індексі
                return 0; // Повернення значення 0 при некоректному індексі (зчитування)
            }
        }
        set
        {
            if (i < n && j < m)
            {
                ByteArray[i, j] = value;
            }
            else
            {
                codeError = -1; // код помилки -1 при некоректному індексі (запис)
            }
        }
    }

    // Індексатор з одним індексом, що використовується для одновимірного доступу до масиву
    public byte this[uint k]
    {
        get
        {
            uint i = k / m;
            uint j = k % m;

            if (i < n && j < m)
            {
                return ByteArray[i, j];
            }
            else
            {
                codeError = -1; // код помилки -1 при некоректному індексі
                return 0; // Повернення значення 0 при некоректному індексі (зчитування)
            }
        }
    }
}




public class MatrixByte3
{
    private byte[,] data;
    private int rows;
    private int cols;

    public MatrixByte3(int rows, int cols)
    {
        this.rows = rows;
        this.cols = cols;
        data = new byte[rows, cols];
    }

    public byte this[int row, int col]
    {
        get { return data[row, col]; }
        set { data[row, col] = value; }
    }

    public static MatrixByte3 operator +(MatrixByte3 a, MatrixByte3 b)
    {
        if (a.rows != b.rows || a.cols != b.cols)
            throw new InvalidOperationException("Matrices must have the same dimensions for addition.");

        MatrixByte3 result = new MatrixByte3(a.rows, a.cols);
        for (int i = 0; i < a.rows; i++)
        {
            for (int j = 0; j < a.cols; j++)
            {
                result[i, j] = (byte)(a[i, j] + b[i, j]);
            }
        }
        return result;
    }

    public static MatrixByte3 operator +(MatrixByte3 a, byte scalar)
    {
        MatrixByte3 result = new MatrixByte3(a.rows, a.cols);
        for (int i = 0; i < a.rows; i++)
        {
            for (int j = 0; j < a.cols; j++)
            {
                result[i, j] = (byte)(a[i, j] + scalar);
            }
        }
        return result;
    }

    public static MatrixByte3 operator -(MatrixByte3 a, MatrixByte3 b)
    {
        if (a.rows != b.rows || a.cols != b.cols)
            throw new InvalidOperationException("Matrices must have the same dimensions for subtraction.");

        MatrixByte3 result = new MatrixByte3(a.rows, a.cols);
        for (int i = 0; i < a.rows; i++)
        {
            for (int j = 0; j < a.cols; j++)
            {
                result[i, j] = (byte)(a[i, j] - b[i, j]);
            }
        }
        return result;
    }

    public static MatrixByte3 operator -(MatrixByte3 a, byte scalar)
    {
        MatrixByte3 result = new MatrixByte3(a.rows, a.cols);
        for (int i = 0; i < a.rows; i++)
        {
            for (int j = 0; j < a.cols; j++)
            {
                result[i, j] = (byte)(a[i, j] - scalar);
            }
        }
        return result;
    }

    public static MatrixByte3 operator *(MatrixByte3 a, MatrixByte3 b)
    {
        if (a.cols != b.rows)
            throw new InvalidOperationException("Matrix multiplication dimensions are not valid.");

        MatrixByte3 result = new MatrixByte3(a.rows, b.cols);
        for (int i = 0; i < a.rows; i++)
        {
            for (int j = 0; j < b.cols; j++)
            {
                byte sum = 0;
                for (int k = 0; k < a.cols; k++)
                {
                    sum += (byte)(a[i, k] * b[k, j]);
                }
                result[i, j] = sum;
            }
        }
        return result;
    }

    public static MatrixByte3 operator *(MatrixByte3 a, byte scalar)
    {
        MatrixByte3 result = new MatrixByte3(a.rows, a.cols);
        for (int i = 0; i < a.rows; i++)
        {
            for (int j = 0; j < a.cols; j++)
            {
                result[i, j] = (byte)(a[i, j] * scalar);
            }
        }
        return result;
    }

    public static MatrixByte3 operator /(MatrixByte3 a, MatrixByte3 b)
    {
        if (a.rows != b.rows || a.cols != b.cols)
            throw new InvalidOperationException("Matrices must have the same dimensions for division.");

        MatrixByte3 result = new MatrixByte3(a.rows, a.cols);
        for (int i = 0; i < a.rows; i++)
        {
            for (int j = 0; j < a.cols; j++)
            {
                result[i, j] = (byte)(a[i, j] / b[i, j]);
            }
        }
        return result;
    }

    public static MatrixByte3 operator /(MatrixByte3 a, byte scalar)
    {
        MatrixByte3 result = new MatrixByte3(a.rows, a.cols);
        for (int i = 0; i < a.rows; i++)
        {
            for (int j = 0; j < a.cols; j++)
            {
                result[i, j] = (byte)(a[i, j] / scalar);
            }
        }
        return result;
    }

    public static MatrixByte3 operator %(MatrixByte3 a, MatrixByte3 b)
    {
        if (a.rows != b.rows || a.cols != b.cols)
            throw new InvalidOperationException("Matrices must have the same dimensions for modulus.");

        MatrixByte3 result = new MatrixByte3(a.rows, a.cols);
        for (int i = 0; i < a.rows; i++)
        {
            for (int j = 0; j < a.cols; j++)
            {
                result[i, j] = (byte)(a[i, j] % b[i, j]);
            }
        }
        return result;
    }

    public static MatrixByte3 operator %(MatrixByte3 a, byte scalar)
    {
        MatrixByte3 result = new MatrixByte3(a.rows, a.cols);
        for (int i = 0; i < a.rows; i++)
        {
            for (int j = 0; j < a.cols; j++)
            {
                result[i, j] = (byte)(a[i, j] % scalar);
            }
        }
        return result;
    }

    public static MatrixByte3 operator |(MatrixByte3 a, MatrixByte3 b)
    {
        if (a.rows != b.rows || a.cols != b.cols)
            throw new InvalidOperationException("Matrices must have the same dimensions for bitwise OR.");

        MatrixByte3 result = new MatrixByte3(a.rows, a.cols);
        for (int i = 0; i < a.rows; i++)
        {
            for (int j = 0; j < a.cols; j++)
            {
                result[i, j] = (byte)(a[i, j] | b[i, j]);
            }
        }
        return result;
    }

    public static MatrixByte3 operator |(MatrixByte3 a, byte scalar)
    {
        MatrixByte3 result = new MatrixByte3(a.rows, a.cols);
        for (int i = 0; i < a.rows; i++)
        {
            for (int j = 0; j < a.cols; j++)
            {
                result[i, j] = (byte)(a[i, j] | scalar);
            }
        }
        return result;
    }

    public static MatrixByte3 operator ^(MatrixByte3 a, MatrixByte3 b)
    {
        if (a.rows != b.rows || a.cols != b.cols)
            throw new InvalidOperationException("Matrices must have the same dimensions for bitwise XOR.");

        MatrixByte3 result = new MatrixByte3(a.rows, a.cols);
        for (int i = 0; i < a.rows; i++)
        {
            for (int j = 0; j < a.cols; j++)
            {
                result[i, j] = (byte)(a[i, j] ^ b[i, j]);
            }
        }
        return result;
    }

    public static MatrixByte3 operator ^(MatrixByte3 a, byte scalar)
    {
        MatrixByte3 result = new MatrixByte3(a.rows, a.cols);
        for (int i = 0; i < a.rows; i++)
        {
            for (int j = 0; j < a.cols; j++)
            {
                result[i, j] = (byte)(a[i, j] ^ scalar);
            }
        }
        return result;
    }

    public static MatrixByte3 operator >>(MatrixByte3 a, int shift)
    {
        MatrixByte3 result = new MatrixByte3(a.rows, a.cols);
        for (int i = 0; i < a.rows; i++)
        {
            for (int j = 0; j < a.cols; j++)
            {
                result[i, j] = (byte)(a[i, j] >> shift);
            }
        }
        return result;
    }

    public static MatrixByte3 operator <<(MatrixByte3 a, int shift)
    {
        MatrixByte3 result = new MatrixByte3(a.rows, a.cols);
        for (int i = 0; i < a.rows; i++)
        {
            for (int j = 0; j < a.cols; j++)
            {
                result[i, j] = (byte)(a[i, j] << shift);
            }
        }
        return result;
    }

    public void Print()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(data[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}

public class VectorByte3
{
    private byte[] data;
    private int size;

    public VectorByte3(int size)
    {
        this.size = size;
        data = new byte[size];
    }

    public byte this[int index]
    {
        get { return data[index]; }
        set { data[index] = value; }
    }

    public int Size
    {
        get { return size; }
    }

    public static VectorByte3 operator |(VectorByte3 a, VectorByte3 b)
    {
        if (a.size != b.size)
            throw new InvalidOperationException("Vectors must have the same size for bitwise OR.");

        VectorByte3 result = new VectorByte3(a.size);
        for (int i = 0; i < a.size; i++)
        {
            result[i] = (byte)(a[i] | b[i]);
        }
        return result;
    }

    public static VectorByte3 operator |(VectorByte3 a, byte scalar)
    {
        VectorByte3 result = new VectorByte3(a.size);
        for (int i = 0; i < a.size; i++)
        {
            result[i] = (byte)(a[i] | scalar);
        }
        return result;
    }
}


public class MatrixByte2
{
    public byte[,] matrix;
    public int n;
    public int m;

    // Конструктор
    public MatrixByte2(int rows, int cols)
    {
        n = rows;
        m = cols;
        matrix = new byte[n, m];
    }

    // Індексатор для доступу до елементів матриці
    public byte this[int i, int j]
    {
        get { return matrix[i, j]; }
        set { matrix[i, j] = value; }
    }

    // Перевантаження унарних операторів ++
    public static MatrixByte2 operator ++(MatrixByte2 mat)
    {
        for (int i = 0; i < mat.n; i++)
        {
            for (int j = 0; j < mat.m; j++)
            {
                mat.matrix[i, j]++;
            }
        }
        return mat;
    }

    // Перевантаження унарних операторів --
    public static MatrixByte2 operator --(MatrixByte2 mat)
    {
        for (int i = 0; i < mat.n; i++)
        {
            for (int j = 0; j < mat.m; j++)
            {
                mat.matrix[i, j]--;
            }
        }
        return mat;
    }

    // Перевантаження сталих true і false
    public static bool operator true(MatrixByte2 mat)
    {
        return mat.n != 0 && mat.m != 0;
    }

    public static bool operator false(MatrixByte2 mat)
    {
        return mat.n == 0 || mat.m == 0;
    }

    // Перевантаження унарної логічної операції !
    public static bool operator !(MatrixByte2 mat)
    {
        return mat.n == 0 || mat.m == 0;
    }

    // Перевантаження унарної побітової операції ~
    public static MatrixByte2 operator ~(MatrixByte2 mat)
    {
        for (int i = 0; i < mat.n; i++)
        {
            for (int j = 0; j < mat.m; j++)
            {
                mat.matrix[i, j] = (byte)~mat.matrix[i, j];
            }
        }
        return mat;
    }

    // Метод для виведення матриці
    public void Print2()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}


// Приклад використання
public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Показати дату через 5 днів від встановленої");
            Console.WriteLine("2. Перевірити чи дата не є останнім днем місяця");
            Console.WriteLine("3. Перетворення дати з рядка і назад");
            Console.WriteLine("4. Порівняти дві дати");
            Console.WriteLine("5. Перевірити чи дата є початком року");
            Console.WriteLine("6. Робота з вектором");
            Console.WriteLine("7. Робота з з Полями, Конструкторами, Деструктором,  Властивостями, Методами, Індексаторами");
            Console.WriteLine("8. Робота з з унарними операціями");
            Console.WriteLine("9. Робота з арифметичними і побітовими операціями");
            Console.WriteLine("0. Вихід");
            Console.Write("Оберіть опцію: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Option1();
                    break;
                case "2":
                    Option2();
                    break;
                case "3":
                    Option3();
                    break;
                case "4":
                    Option4();
                    break;
                case "5":
                    Option5();
                    break;
                case "6":
                    Option6();
                    break;
                case "7":
                    Option7();
                    break;
                case "8":
                    Option8();
                    break;
                case "9":
                    Option9();
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }

            if (!exit)
            {
                Console.WriteLine("\nНатисніть будь-яку клавішу для повернення до меню...");
                Console.ReadKey();
            }
        }
    }

    private static void Option1()
    {
        Date date1 = new Date(new DateTime(2024, 6, 19));
        Console.WriteLine(date1[5]); // Дата через 5 днів від встановленої
    }

    private static void Option2()
    {
        Date date1 = new Date(new DateTime(2024, 6, 19));
        Console.WriteLine(!date1); // Чи не є дата останнім днем місяця
    }

    private static void Option3()
    {
        Date date2 = "2024-01-01"; // Перетворення з рядка
        Console.WriteLine((string)date2); // Перетворення у рядок
    }

    private static void Option4()
    {
        Date date1 = new Date(new DateTime(2024, 6, 19));
        Date date2 = "2024-01-01"; // Перетворення з рядка
        Console.WriteLine(date1 & date2); // Порівняння дат
    }

    private static void Option5()
    {
        Date date2 = "2024-01-01"; // Перетворення з рядка
        if (date2)
        {
            Console.WriteLine("Це початок року.");
        }
        else
        {
            Console.WriteLine("Це не початок року.");
        }
    }

    private static void Option6()
    {
        VectorByte v1 = new VectorByte(5, 2);
        Console.WriteLine("Ініціалізація вектора v1 розміром 5 з початковим значенням 2");
        v1.OutputElements();

        Console.WriteLine("Введення елементів вектора з клавіатури");
        v1.InputElements();
        Console.WriteLine("\nНовий вектор");
        v1.OutputElements();

        Console.WriteLine("\nПрисвоєння елементам вектора значення 10");
        v1.AssignValue(10);
        v1.OutputElements();

        Console.WriteLine($"Кількість векторів: {VectorByte.CountVectors()}");

        Console.WriteLine($"Розмір вектора: {v1.Size}");

        v1[2] = 50;
        Console.WriteLine($"\nЗміна значення елемента вектора за індексом 2 та виведення цього значення:  {v1[2]}");

        try
        {
            v1[10] = 100;  // неправильний індекс
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine($"\nСпроба встановити значення за неправильним індексом 10 та виведення коду помилки  {v1.CodeError}");
        }

        Console.WriteLine("\nЗбільшення всіх елементів вектора на 1");
        v1++;
        v1.OutputElements();

        if (v1)
        {
            Console.WriteLine("Вектор не є пустим і містить ненульові елементи.");
        }
        else
        {
            Console.WriteLine("Вектор пустий або всі його елементи дорівнюють нулю.");
        }
    }

    private static void Option7()
    {
        // Створення матриці з розмірами 3x4 і ініціалізацією значеннями 1
        MatrixByte matrix = new MatrixByte(3, 4, 1);

        // Введення елементів матриці з клавіатури
        Console.WriteLine("Введіть значення для матриці:");
        matrix.InputValues();

        // Виведення матриці на екран
        matrix.PrintValues();

        // Доступ до елементів матриці за допомогою індексаторів
        Console.WriteLine("Елемент з індексом [1,2]: " + matrix[1, 2]);

        // Присвоєння значення всім елементам матриці
        matrix.AssignValue(5);

        // Виведення оновленої матриці на екран
        Console.WriteLine("Оновлена матриця:");
        matrix.PrintValues();

        // Використання одновимірного індексатора
        Console.WriteLine("Елемент з одновимірного індексу 7: " + matrix[7]);

        // Виведення розмірів матриці
        Console.WriteLine($"Розміри матриці: {matrix.SizeN} x {matrix.SizeM}");

        // Підрахунок кількості матриць даного типу
        Console.WriteLine($"Кількість матриць типу MatrixByte: {MatrixByte.CountMatrices()}");

        // Приклад роботи з кодом помилки
        matrix.ErrorCode = -2;
        Console.WriteLine($"Код помилки: {matrix.ErrorCode}");
    }

    private static void Option8()
    {
        MatrixByte2 matrix2 = new MatrixByte2(2, 2);
        matrix2[0, 0] = 1;
        matrix2[0, 1] = 2;
        matrix2[1, 0] = 3;
        matrix2[1, 1] = 4;

        Console.WriteLine("Початкова матриця:");
        matrix2.Print2();

        matrix2++;
        Console.WriteLine("Матриця після ++:");
        matrix2.Print2();

        matrix2--;
        Console.WriteLine("Матриця після --:");
        matrix2.Print2();

        Console.WriteLine("Матриця після ~:");
        (~matrix2).Print2();

        Console.WriteLine($"Логічна операція !: {!matrix2}");

        if (matrix2)
        {
            Console.WriteLine("Матриця має розміри більше 0.");
        }
        else
        {
            Console.WriteLine("Матриця має розміри 0.");
        }
    }

    private static void Option9()
    {
        // Тестування операцій
        MatrixByte3 mat1 = new MatrixByte3(2, 2);
        mat1[0, 0] = 1;
        mat1[0, 1] = 2;
        mat1[1, 0] = 3;
        mat1[1, 1] = 4;

        MatrixByte3 mat2 = new MatrixByte3(2, 2);
        mat2[0, 0] = 5;
        mat2[0, 1] = 6;
        mat2[1, 0] = 7;
        mat2[1, 1] = 8;

        MatrixByte3 result = mat1 + mat2;
        Console.WriteLine("\nОперація додавання (mat1 + mat2)");
        result.Print();

        result = mat1 - mat2;
        Console.WriteLine("\nОперація віднімання (mat1 - mat2)");
        result.Print();

        result = mat1 * 2;
        Console.WriteLine("\nОперація множення на скаляр (mat1 * 2)");
        result.Print();

        result = mat1 / 2;
        Console.WriteLine("\nОперація ділення на скаляр (mat1 / 2)");
        result.Print();

        result = mat1 % 2;
        Console.WriteLine("\nОперація остача від ділення на скаляр (mat1 % 2)");
        result.Print();

        result = mat1 | mat2;
        Console.WriteLine("\nОперація побітового OR (mat1 | mat2)");
        result.Print();

        result = mat1 ^ mat2;
        Console.WriteLine("\nОперація побітового XOR (mat1 ^ mat2)");
        result.Print();

        result = mat1 >> 1;
        Console.WriteLine("\nОперація побітового зсуву вправо (mat1 >> 1)");
        result.Print();

        result = mat1 << 1;
        Console.WriteLine("\nОперація побітового зсуву вліво (mat1 << 1)");
        result.Print();
    }
}
