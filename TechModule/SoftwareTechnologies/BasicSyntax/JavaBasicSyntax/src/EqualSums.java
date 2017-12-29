import java.util.Arrays;
import java.util.InputMismatchException;
import java.util.Scanner;

public class EqualSums {

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        int[] arr1 = Arrays.stream(scan.nextLine()
                .split(" "))
                .mapToInt(Integer::parseInt)
                .toArray();

        int leftSum = 0;
        int rightSum = 0;
        int i;

        for (i = 0; i < arr1.length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                leftSum += arr1[j];
            }

            for (int j = i+1; j < arr1.length; j++)
            {
                rightSum += arr1[j];
            }

            if (rightSum==leftSum)
            {
                System.out.println(i);
                break;
            }
            else
            {
                leftSum = 0;
                rightSum = 0;
            }
        }
        if (i==arr1.length)
        {
            System.out.println("no");
        }
    }
}