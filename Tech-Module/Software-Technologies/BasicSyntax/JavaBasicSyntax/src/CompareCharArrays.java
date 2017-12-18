import java.util.InputMismatchException;
import java.util.Scanner;

public class CompareCharArrays {

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String line1 = scan.nextLine();
        String line2 = scan.nextLine();
        int length = 0;

        char[] arr1 = line1.replaceAll(" ", "").toCharArray();

        char[] arr2 = line2.replaceAll(" ", "").toCharArray();

        if (arr1.length > arr2.length) length = arr2.length;
        else length = arr1.length;

        for (int i = 0; i < length; i++) {
            if (arr1[i] < arr2[i]) {
                System.out.println(String.valueOf(arr1));
                System.out.println(String.valueOf(arr2));
                break;
            } else if (arr2[i] < arr1[i]) {
                System.out.println(String.valueOf(arr2));
                System.out.println(String.valueOf(arr1));
                break;
            }
            else if (i == length-1)
            {
                if (arr1.length > arr2.length)
                {
                    System.out.println(String.valueOf(arr2));
                    System.out.println(String.valueOf(arr1));
                }
                else
                {
                    System.out.println(String.valueOf(arr1));
                    System.out.println(String.valueOf(arr2));
                }
            }
        }
    }
}