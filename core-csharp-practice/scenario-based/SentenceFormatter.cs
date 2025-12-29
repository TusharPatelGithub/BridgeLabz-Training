using System.Threading.Channels;
using System.Xml;

class SetenceFormatter
{

// for getting the longest word

    
static void LongestWord(char[] b)
{
    string currentWord = "";
    string longest = "";
    for (int i = 0; i < b.Length; i++)
    {
        if (b[i] != ' ')
        {
            currentWord += b[i];
        }
        else
        {
            if (currentWord.Length > longest.Length)
            {
                longest = currentWord;
            }
            currentWord = "";
        }
    }
    if (currentWord.Length > longest.Length)
    {
        longest = currentWord;
    }

    Console.WriteLine("Longest word is: " + longest);
}


//for count in the nunmber of words 


    static void CountWords(char[] b)
    {
        Console.WriteLine("Number of words is "+b.Length);
    }
    static void space(string b)
    {
        bool check=false;
        int j=0;
        char[] result=new char[b.Length];
        for(int i = 0; i < b.Length; i++)
        {
            if(b[i]!=' ')
            {
                result[j++]=b[i];
                check=false;
            }
            else
            {
                if (!check)
                {
                    result[j++]=b[i];
                    check=true;
                }
            }

        }
        if(j>0&&result[j-1]==' ')
        {
            j--;
        }
        int x=0;
        if(result[0]==' ')
        {
            for(int i = 1; i < result.Length; i++)
            {
                x=i;
                result[--x]=result[i];
            }
        }
        Caps(result);
    }



    //for capital letter



    static void Caps(char[] b)
    {
        if (b[0] >= 'a' && b[0] <= 'z')
        {
            int ascii=b[0];
            ascii=ascii-32;
            char bh=(char)ascii;
            b[0]=bh;
        }
       

        int j=0;
        for(int i = 0; i < b.Length; i++)
        {
            if(i!=b.Length-1){
            if (b[i] == '.' || b[i] == ',' || b[i] == '!')
            {
                j=i+2;
                    if (b[j] >= 'a' || b[j] <= 'z')
                    {
                       int z=b[j];
                       z=z-32;
                       char ch1=(char)z;
                       b[j]=ch1;
                    }
                
            }
        }}
        Console.WriteLine("Correct paragraph is: \n");
        for(int i = 0; i < b.Length; i++)
        {
            Console.Write(b[i]);
        }
        Console.WriteLine();
        Console.WriteLine("Enter you choice: \n 1: Count the number of words in paragraph. \n 2: Find and display the longest word. " );
        int ch=Convert.ToInt16(Console.ReadLine());
        switch (ch)
        {
            case 1: CountWords(b);
            break;
            case 2: LongestWord(b);
            break;
            default: Console.WriteLine("Enter a valid number: ");
            break;
        }
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the paragraph: ");
        string b=Console.ReadLine()??"";
        space(b);
    }
}