import java.util.*;

public class CountWorkingDays {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String[] startDate = sc.nextLine().split("-");
        String[] endDate = sc.nextLine().split("-");
        int day = Integer.parseInt(startDate[0]);
        int month = Integer.parseInt(startDate[1]) - 1;
        int year = Integer.parseInt(startDate[2]);
        int endDay = Integer.parseInt(endDate[0]);
        int endMonth = Integer.parseInt(endDate[1]) - 1;
        int endYear = Integer.parseInt(endDate[2]);

        Calendar start = GregorianCalendar.getInstance();
        start.set(year, month, day);
        Calendar end = GregorianCalendar.getInstance();
        end.set(endYear, endMonth, endDay);



        Map<Integer, List<Integer>> map = new HashMap<>();

        map.put(1, new ArrayList<>());
        map.get(1).add(1);
        map.put(3, new ArrayList<>());
        map.get(3).add(3);
        map.put(5, new ArrayList<>());
        map.get(5).add(1);
        map.get(5).add(6);
        map.get(5).add(24);
        map.put(9, new ArrayList<>());
        map.get(9).add(6);
        map.get(9).add(22);
        map.put(11, new ArrayList<>());
        map.get(11).add(1);
        map.put(12, new ArrayList<>());
        map.get(12).add(24);
        map.get(12).add(25);
        map.get(12).add(26);


        int count = 0;

        for (Calendar i = start; i.before(end); i.add(Calendar.DATE, 1)) {
            int d = i.get(Calendar.DATE);
            int m = i.get(Calendar.MONTH);
            int dd = i.get(Calendar.DAY_OF_WEEK);
            if(!map.containsKey(m+1) || !map.get(m + 1).contains(d)){
                if(dd != Calendar.SUNDAY && dd != Calendar.SATURDAY){
                    count++;
                }
            }
        }

        System.out.println(count);
    }
}