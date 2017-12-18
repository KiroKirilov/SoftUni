import java.util.InputMismatchException;
import java.util.Scanner;

public class VowelOrDigit {

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String input=scan.nextLine().toLowerCase();

        try {
            Integer.parseInt(input);
            System.out.println("digit");
        }
        catch (NumberFormatException ex) {
            if (input.equals("a") || input.equals("e")||input.equals("o")||input.equals("i")||input.equals("u")) {
                System.out.println("vowel");
            }
            else
                System.out.println("other");
        }
    }
}