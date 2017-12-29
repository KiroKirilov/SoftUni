import java.util.InputMismatchException;
import java.util.Scanner;

public class IndexOfLetters {

    public static void main(String[] args) {
        char[] alphabet = {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};

        Scanner scan = new Scanner(System.in);
        String  word = scan.nextLine();

        for (char ch: word.toCharArray()) {
            System.out.printf("%c -> %s%n",ch,new String(alphabet).indexOf(ch));
        }
    }
}