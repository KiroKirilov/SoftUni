import java.util.*;

public class PhonebookUpgrade {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        TreeMap<String, String> phonebook = new TreeMap<String,String>();

        while (true) {
            String input = scan.nextLine();
            if (input.equals("END"))
                break;
            String[] tokens = input.split("\\s");
            String command = tokens[0];


            if (command.equals("A")) {
                String phone = tokens[2];
                String name = tokens[1];
                phonebook.put(name, phone);
            } else if (command.equals("S")){
                String name = tokens[1];
                if (phonebook.containsKey(name))
                    System.out.printf("%s -> %s\n", name, phonebook.get(name));
                else
                    System.out.printf("Contact %s does not exist.\n", name);
            } else if (command.equals("ListAll")) {
                for(Map.Entry<String,String> entry : phonebook.entrySet()) {
                    String key = entry.getKey();
                    String value = entry.getValue();

                    System.out.println(key + " -> " + value);
                }
            }
        }
    }
}