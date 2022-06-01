import java.util.Scanner;

class Solution{
    public static void main(String[] args) {

        Scanner sc = new Scanner(System.in);
        
        int cnt = sc.nextInt();
        String arr[] = new String[cnt];
        System.out.print(cnt);
        for(int i = 0; i < cnt; i++){
            arr[i] = sc.next();
        }
        for(int i = 0; i < cnt; i++){
            System.out.print(arr[i]);
        }
    }
}