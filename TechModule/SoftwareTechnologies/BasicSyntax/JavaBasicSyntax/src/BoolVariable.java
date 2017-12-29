import java.util.Scanner;

public class BoolVariable {

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        boolean bool = scan.nextBoolean();

        if (bool)
            System.out.println("Yes");
        else
            System.out.println("No");
    }
}