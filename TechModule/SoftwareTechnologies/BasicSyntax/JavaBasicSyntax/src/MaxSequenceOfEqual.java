import java.util.InputMismatchException;
import java.util.Scanner;

public class MaxSequenceOfEqual {

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String line1 = scan.nextLine();

        String[] arrStrings = line1.split(" ");
        int[] arr1=new int[arrStrings.length];
        for (int i = 0; i < arrStrings.length; i++) {
            arr1[i]=Integer.parseInt(arrStrings[i]);
        }
        int equalNumber=arr1[0];
        int currLength = 1;
        int bestLength = 0 ;

        for (int i = 1; i < arr1.length; i++)
        {
            if (arr1[i] == arr1[i - 1])
            {
                currLength++;
                if (currLength > bestLength)
                {
                    bestLength = currLength;
                    equalNumber = arr1[i];
                }
            }
            else currLength = 1;
        }
        for (int i = 1; i <= bestLength; i++)
        {
            System.out.printf(equalNumber+" ");
        }
    }
}