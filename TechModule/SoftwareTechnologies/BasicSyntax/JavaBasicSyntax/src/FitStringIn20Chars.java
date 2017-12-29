import java.util.Arrays;
import java.util.InputMismatchException;
import java.util.Scanner;

public class FitStringIn20Chars {

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String str = scan.nextLine();

        if (str.length()>20){
            str=str.substring(0, 20);
        }

        if (str.length()<20){
            for (int i = str.length();i<=20;i++){
                str+="*";
            }
        }

        System.out.println(str);
    }
}