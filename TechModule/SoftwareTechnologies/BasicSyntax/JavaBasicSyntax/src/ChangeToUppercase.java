import java.util.*;

public class ChangeToUppercase {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String text = scan.nextLine();
        // <upcase>pesho</upcase>alabala ->PESHO alabala
        while (text.contains("<upcase>")) {
            int indexStart = text.indexOf("<upcase>");
            int indexEnd = text.indexOf("</upcase>") + 9;//length-a
            String textToReplace = text.substring(indexStart, indexEnd);
            String textToUpper = textToReplace
                    .substring("<upcase>".length(), textToReplace.length() - "</upcase>".length())
                    .toUpperCase();
            text = text.replace(textToReplace, textToUpper);
        }
        System.out.println(text);
    }
}