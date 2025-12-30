    class EduQuize{
        static void PercentageScore(string[] correctanswer,string[] studentanswer){
            int count=0;
            for(int i = 0; i < correctanswer.Length; i++)
            {
                if(studentanswer[i].Equals(correctanswer[i], StringComparison.OrdinalIgnoreCase))  count++;
            }
            double percentage=(count/10.0)*100;
            if (percentage > 33)
            {
                Console.WriteLine("You are pass in exam ");
            }
            else
            {
                Console.WriteLine("You are fail in exam: ");
            }
        }
        static void DetailedFeedback(string[] correctanswer,string[] studentanswer)
        {
            int j=1;
            for(int i = 0; i < correctanswer.Length; i++)
            {
                if (studentanswer[i].Equals(correctanswer[i], StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Question "+ j++ +" is correct. ");
                }
                else
                {
                    Console.WriteLine("Question "+ j++ +" is incorrect. ");
                }
            }
        }
        static void Print(string[] correctanswer,string[] studentanswer)
        {
            Console.WriteLine("Enter your choice: 1. For calculating the score. \n 2.  For printing detailed feedback. \n 3. For percentage score.");
            int ch=Convert.ToInt16(Console.ReadLine());
            switch (ch)
            {
                case 1:  CalculateScore(correctanswer,studentanswer);
                break;
                case 2: DetailedFeedback(correctanswer,studentanswer);
                break;
                case 3: PercentageScore(correctanswer,studentanswer);
                break;
                default: Console.WriteLine("Enter the valid choice: ");
                break;
            }
            Print(correctanswer,studentanswer);x
        
        }
        public static void CalculateScore(string[] correctanswer,string[] studentanswer)
        {
            int count=0;
            for(int i = 0; i < correctanswer.Length; i++)
            {
                if(studentanswer[i].Equals(correctanswer[i], StringComparison.OrdinalIgnoreCase))  count++;

            }
            Console.WriteLine("Number of correct answer is "+count+" out of 10.");
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the correct answer: ");
            String[] correctanswer=new string[10];
        
            for(int i = 0; i < correctanswer.Length; i++)
            {
                correctanswer[i]=Console.ReadLine()??"";
            }
            Console.WriteLine("Enter the student answer: ");
            string[] studentanswer=new string[10];
            for(int i = 0; i < correctanswer.Length; i++)
            {
                studentanswer[i]=Console.ReadLine()??"";
            }
            Print(correctanswer,studentanswer);
        }
    }