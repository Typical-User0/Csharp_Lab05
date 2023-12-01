
class MyMatrix
{
    private int[,] matrix;
    private int rows;
    private int columns;
    private Random random = new Random();

    public MyMatrix(int rows, int columns)
    {
        this.rows = rows;
        this.columns = columns;
        matrix = new int[rows, columns];
        Fill();
    }

    public void Fill()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                matrix[i, j] = random.Next(1, 101);
            }
        }
    }

    public void ChangeSize(int newRows, int newColumns)
    {
        int[,] newMatrix = new int[newRows, newColumns];
        for (int i = 0; i < Math.Min(rows, newRows); i++)
        {
            for (int j = 0; j < Math.Min(columns, newColumns); j++)
            {
                newMatrix[i, j] = matrix[i, j];
            }
        }

        matrix = newMatrix;
        rows = newRows;
        columns = newColumns;

        if (newRows > rows || newColumns > columns)
        {
            for (int i = rows; i < newRows; i++)
            {
                for (int j = columns; j < newColumns; j++)
                {
                    matrix[i, j] = random.Next(1, 101);
                }
            }
        }
    }

    public void ShowPartially(int startRow, int endRow, int startColumn, int endColumn)
    {
        for (int i = startRow; i <= endRow; i++)
        {
            for (int j = startColumn; j <= endColumn; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    public void Show()
    {
        ShowPartially(0, rows - 1, 0, columns - 1);
    }

    public int this[int index1, int index2]
    {
        get { return matrix[index1, index2]; }
        set { matrix[index1, index2] = value; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the number of rows: ");
        int rows = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Enter the number of columns: ");
        int columns = int.Parse(Console.ReadLine()!);

        MyMatrix matrix = new MyMatrix(rows, columns);
        matrix.Show();

        Console.WriteLine("\nEnter new size:");
        Console.Write("New rows: ");
        int newRows = int.Parse(Console.ReadLine()!);
        Console.Write("New columns: ");
        int newColumns = int.Parse(Console.ReadLine()!);

        matrix.ChangeSize(newRows, newColumns);
        matrix.Show();

        Console.WriteLine("\nEnter the range to display:");
        Console.Write("Start Row: ");
        int startRow = int.Parse(Console.ReadLine()!);
        Console.Write("End Row: ");
        int endRow = int.Parse(Console.ReadLine()!);
        Console.Write("Start Column: ");
        int startColumn = int.Parse(Console.ReadLine()!);
        Console.Write("End Column: ");
        int endColumn = int.Parse(Console.ReadLine()!);

        matrix.ShowPartially(startRow, endRow, startColumn, endColumn);
    }
}
