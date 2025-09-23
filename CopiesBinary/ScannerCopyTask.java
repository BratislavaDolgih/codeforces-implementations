package edu.september.designalgorithms;

import java.util.Scanner;

public class ScannerCopyTask {
    public static void main(String... args) {
        Scanner s = new Scanner(System.in);
        System.out.print("mA: ");
        int myAmount = s.nextInt();
        System.out.print("mF: ");
        byte myF = s.nextByte();
        System.out.print("mS: ");
        byte myS = s.nextByte();
        System.out.println(XeroxHelper.calculation(new Xerox(myAmount, myF, myS)));
    }
}

record Xerox(int copiesAmount, byte firstSeconds, byte secondSeconds) { }

final class XeroxHelper {
    public static long calculation(Xerox currentXerox) {
        // Делаем n-1 копий, потому что на старте нужен онли 1 сканер.
        int n = currentXerox.copiesAmount() - 1;
        byte x = currentXerox.firstSeconds();
        byte y = currentXerox.secondSeconds();

        // Будем брать промежуток [left, right], где ищем минимальное время,
        // за которое copies1 + copies2 >= n-1.

        long left = 0;

        // Худший случай: онли самый медленный сканер в соло собачит.
        long right = (long) n * Math.max(x, y);

        // Начинается бинпоиск по времени t
        while (left < right) {
            long mid = (left + right) / 2;

            // Сколько копий (сделает первый сканер за mid секунд) +
            // (сделает второй сканер за mid секунд)
            long copies = mid / x + mid / y;

            // Если мы наткнулись, когда копий больше или равно, чем n:
    //  К примеру, нужно 4, а мы сделали аж 6 копий!
            if (copies >= n) {
                // возможно меньшее время тоже подойдёт!
                right = mid;
            } else {
                // нужно больше времени.
    //  К примеру, нужно 4, а мы сделали 3
                left = mid + 1;
            }
        }

        return left + Math.min(x, y); // Вначале мы забрали 1 копию, вернём.
    }
}