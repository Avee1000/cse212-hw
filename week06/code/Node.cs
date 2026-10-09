public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data)
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // 1. Base case: Value found at the current node
        if (value == Data)
        {
            return true;
        }

        // 2. Search the left subtree
        if (value < Data)
        {
            return Left != null && Left.Contains(value);
        }

        // 3. Search the right subtree
        return Right != null && Right.Contains(value);
    }

    public int GetHeight()
    {
        // --- 1. Check Left Child ---
        int leftHeight;
        if (Left is null)
        {
            leftHeight = 0; // If null, the height is 0
        }
        else
        {
            leftHeight = Left.GetHeight(); 
        }

        // --- 2. Check Right Child ---
        int rightHeight;
        if (Right is null)
        {
            rightHeight = 0; // If null, the height is 0
        }
        else
        {
            rightHeight = Right.GetHeight(); 
        }

        // --- 3. Calculate Final Height ---
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}