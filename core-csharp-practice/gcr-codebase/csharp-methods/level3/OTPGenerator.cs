using System;

public class OTPGenerator
{
        public static int GenerateOTP()
    {
        Random rand = new Random();
        return rand.Next(100000, 1000000); 
    }

    public static bool AreOTPsUnique(int[] otps)
    {
        for (int i = 0; i < otps.Length; i++)
        {
            for (int j = i + 1; j < otps.Length; j++)
            {
                if (otps[i] == otps[j])
                    return false;
            }
        }
        return true;
    }

    public static void Main()
    {
        int[] otpArray = new int[10];

        for (int i = 0; i < otpArray.Length; i++)
        {
            otpArray[i] = GenerateOTP();
            Console.WriteLine("Generated OTP " + (i + 1) + ": " + otpArray[i]);
        }

        if (AreOTPsUnique(otpArray))
            Console.WriteLine("All OTPs are unique.");
        else
            Console.WriteLine("Duplicate OTPs found.");
    }
}
