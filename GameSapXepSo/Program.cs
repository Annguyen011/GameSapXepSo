// Số dòng trong ma trậnk
int N = 3;
// Số cột trong ma trận
int M = 3;
// Tạo mảng 2 chiều với N và M
int[,] board = new int[N, M];
// Tạo ra biến để lấy vị trí của số 0 trong hàm random 
int currentRowOfZeroValue = 0;
int currentColumnOfZeroValue = 0;
// Tạo hàm in Board
void PrintBoard()
{
    for (int i = 0; i < N; i++)
    {
        for (int j = 0; j < M; j++)
        {
            // In giá trị i, j
            Console.Write(board[i, j] + " ");
        }
        // Ngắt dòng
        Console.WriteLine();
    }
}
// Tạo hàm thêm dữ liệu cho board
void initBoard()
{
    // Yêu cầu fill từ  0 => N*N
    int result = N * M;
    //Tạo list chứa các thành phần trong mảng
    List<int> list = new List<int>();

    for (int i = 0; i < result; i++)
    {
        list.Add(i);
    }
    // 0 1 2 3 4 5 6 7 8 
    // Tạo hàm random và chuẩn bị fill vào mảng
    Random random = new Random();

    for (int i = 0; i < N; i++)
    {

        for (int j = 0; j < M; j++)
        {
            // Lấy vị trí từ khoảng chặn list count
            // Ví dụ trong đây list.Count = 9 vậy nên pos chỉ có thế có
            // giá trị từ 0 - 8
            int pos = random.Next(list.Count);
            // Gán giá trị của list[pos] cho board
            int element = list[pos];
            board[i, j] = element;
            // Khi gán xong giá trị ta xóa giá trị đó tại list để cho không
            // bị lặp lại sau mỗi lần lặp
            list.RemoveAt(pos);
            // Lấy và gán giá trị của vị trí 0 trong bản số
            if (element == 0)
            {
                currentRowOfZeroValue = i;
                currentColumnOfZeroValue = j;
            }
        }


    }
}
initBoard();
while (true)
{
    Console.Clear();
    PrintBoard();
    // Sử dụng Console để lấy kí tự từ bàn phím
    ConsoleKeyInfo keyInfo = Console.ReadKey();


    if (keyInfo.Key == ConsoleKey.UpArrow)
    {
        // Tạo swap biến
        int temp = currentRowOfZeroValue;
        // Di chuyển đối tượng lên trên
        currentRowOfZeroValue--;
        if (currentRowOfZeroValue < 0)
        {
            currentRowOfZeroValue = temp;
        }
        else
        {
            // hoán vị 
            board[temp, currentColumnOfZeroValue] = board[currentRowOfZeroValue, currentColumnOfZeroValue];
            board[currentRowOfZeroValue, currentColumnOfZeroValue] = 0;
        }


    }
    else if (keyInfo.Key == ConsoleKey.DownArrow)
    {
        // Tạo swap biến
        int temp = currentRowOfZeroValue;
        // Di chuyển đối tượng xuống dưới
        currentRowOfZeroValue++;
        if (currentRowOfZeroValue >= 3)
        {
            currentRowOfZeroValue = temp;
        }
        else
        {
            // hoán vị 
            board[temp, currentColumnOfZeroValue] = board[currentRowOfZeroValue, currentColumnOfZeroValue];
            board[currentRowOfZeroValue, currentColumnOfZeroValue] = 0;
        }

    }
    else if (keyInfo.Key == ConsoleKey.LeftArrow)
    {
        // Tạo swap biến
        int temp = currentColumnOfZeroValue;
        // Di chuyển đối tượng sang trái
        currentColumnOfZeroValue--;
        if ((currentRowOfZeroValue < 0))
        {
            currentColumnOfZeroValue = temp;
        }
        else
        {
            //hoán vị 
            board[currentRowOfZeroValue, temp] = board[currentRowOfZeroValue, currentColumnOfZeroValue];
            board[currentRowOfZeroValue, currentColumnOfZeroValue] = 0;
        }


    }
    else if (keyInfo.Key == ConsoleKey.RightArrow)
    {
        // Tạo swap biến
        int temp = currentColumnOfZeroValue;
        // Di chuyển đối tượng sang phải
        currentColumnOfZeroValue++;
        if ((currentRowOfZeroValue < 0))
        {
            currentColumnOfZeroValue = temp;
        }
        else
        {
            //hoán vị 
            board[currentRowOfZeroValue, temp] = board[currentRowOfZeroValue, currentColumnOfZeroValue];
            board[currentRowOfZeroValue, currentColumnOfZeroValue] = 0;
        }
    }
}