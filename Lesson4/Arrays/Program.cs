int[] massiv = new int[4];

int[] m = new int[4] { 1, 2, 3, 4};
int[] m2 = {1, 3, 4}; // new int[3]
var m3 = new int[] { 1, 3, 4};
var m4 = new int[6];

foreach (int i in m)
{
    Console.Write(i);
}

int[] m1 = new int[] { 1, 3, 4, 4, 5 };

m1[1] = 4;

Console.WriteLine(m1[1]);

for (int i = 0; i < m1.Length; i++)
{
    m1[i] += 2;
    Console.WriteLine(m1[i]);
}

// Masala 3 ta son kiritiladi
// 1
// 4
// 5 
// 1 va 4 dan ozi bilan keyingi 5ta son bir birigakopaytrib chiqarilsin
// 4, 10, 18, 28, 40

Console.WriteLine();

//var input = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
//for(int i = 0; i < input[2]; i++) 
//    Console.WriteLine(input[0]++ * input[1]++);

int[,] massiv1 = new int[4,3];

int[,] ms = new int[2,3]
{
    {1,2,3}, 
    {2,4,5}
};

int[,] ms2 = //new int[2,4]
{
    {1,2,3,5},
    {5,6,7,4}
};

int[,,] ms3 = //new int[2,3,2]
{
    {{1,2},{2,3},{4,5}},
    {{6,7},{8,9},{5,4}}
};

Console.WriteLine(ms3[0,0,0]);
Console.WriteLine(ms3[1,0,0]);
Console.WriteLine(ms3[1,2,1]);

// Jagged arrays

int[][] massiv2 = new int[4][];

int[][] mj = new int[2][]
{
    new int[]{ 1, 2 }, 
    new int[]{ 2, 4, 5 }
};

int[][,] mj2 = //new int[2][4]
{
    new int[,]{{1,2}, {2,4}},
    new int[,]{{1,3}, {4,6}}
};

int[][,] mj3 = //new int[2][2,2]
{
    new int[,]{{1,2}, {2,4}},
    new int[,]{{1,3}, {4,6}}
};

Console.WriteLine(mj3[0][0, 0]);
Console.WriteLine(mj3[1][0, 0]);
Console.WriteLine(mj3[1][1, 1]);

string[][] str = new string[2][];
char[,] char2 = new char[1,2];

// masala
// 4 + 2 = ?
// 6, 4, 5, 5

// 4 * 2 = ?
// 8, 56, 6, 5
//...

string[][] quiz = new string[][]
{
    new string[]{"4 + 2 = ?", "3", "5", "6", "2", "8"},  
    new string[]{"4 * 2 = ?", "2", "8", "18", "22", "0"},
    new string[]{"4 / 2 = ?", "5", "145", "652", "9", "2"},
    new string[]{"4 - 2 = ?", "A", "A. 2", "B. 652", "9"}
};

for (int i = 0; i < quiz.Length; i++)
{
    for (int j = 0; j < quiz[i].Length; j++)
    {
        if (j == 0) Console.WriteLine("Savol = " + quiz[i][j]);
        else if(j != 1) Console.WriteLine($"{j - 1}. {quiz[i][j]}");
    }
    
    Console.Write("Javob : ");
    var input = Console.ReadLine();

    string javob = "Notogri";
    if (input == (int.Parse(quiz[i][1]) - 1).ToString()) javob = "Togri";

    Console.WriteLine($"{javob}\n Keyingi savolga enter bosing");
    Console.ReadKey();
}