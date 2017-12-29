import java.util.InputMismatchException;
import java.util.Scanner;

public class IntToHexAndBin {

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int n =scan.nextInt();

        String bin=Integer.toString(n,2);
        String hex=Integer.toString(n,16).toUpperCase();

        System.out.println(hex);
        System.out.println(bin);
    }
}