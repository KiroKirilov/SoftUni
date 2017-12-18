import java.util.InputMismatchException;
import java.util.Scanner;

public class MaxSequenceOfIncreasing {

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String line1 = scan.nextLine();

        String[] arrStrings = line1.split(" ");
        int[] sequence=new int[arrStrings.length];
        for (int i = 0; i < arrStrings.length; i++) {
            sequence[i]=Integer.parseInt(arrStrings[i]);
        }
        int maxStart = 0;
        int maxLen = 1;
        int currentStart = 0;
        int currentLen = 1;

        for (int i = 1; i < sequence.length; i++)
        {
            if (sequence[i] > sequence[i - 1])
            {
                currentLen++;
                if (currentLen > maxLen)
                {
                    maxLen = currentLen;
                    maxStart = currentStart;
                }
            }
            else
            {
                currentStart = i;
                currentLen = 1;
            }
        }
        for (int i = maxStart; i < maxStart + maxLen; i++)
            System.out.printf(sequence[i] + " ");
    }
}