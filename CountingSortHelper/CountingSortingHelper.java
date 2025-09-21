package edu.september.designalgorithms;

import java.util.Scanner;

public class CountingSortingHelper {
    public static void main(String... args) {
        int elementAmount = inputScanner.nextInt();
        int[] myArr = new int[elementAmount];

        fillArray(myArr); // filling
        countingSort(myArr); // Sorting by countSort
        viewArray(myArr); // viewing
    }

    /**
     * Объяснение сортировки подсчётом на примере
     * array = [1, 4, 1, 2, 7, 5, 2, -2, 0]:
     *
     * min = -2; max = 7, значит массив подсчёта будет из 10 элементов.
     *
     * count = [0,0,0,0,0,0,0,0,0,0]
     * индексы соответствуют значениям от -2 до 7
     * index 0 -> -2, index 1 -> -1, ..., index 9 -> 7
     *
     * i=0 → число = -2, count[0]=1 → добавляем -2 → arr = [-2]
     * i=1 → число = -1, count[1]=0 → ничего
     * i=2 → число = 0, count[2]=1 → добавляем 0 → arr = [-2, 0]
     *
     * и так далее...
     */

    /**
     * Сортировка подсчётом - O(n + k)
     * @param arr входной массив целых чисел.
     */
    public static void countingSort(int[] arr) {
        if (arr.length == 0) { return; }

        int max = arr[0],
                min = arr[0];
        for (int n : arr) {
            if (max < n) { max = n; }
            if (min > n) { min = n; }
        }

        // Для корректной работы с отрицательными числами.
        int range = max - min + 1;

        int[] countingArray = new int[range];

        // Сдвиг для работы с отрицательными числами в том же числе
        // Если min = -3, num = 3, то countingArray[0]++
        for (int num : arr) {
            countingArray[num - min]++;
        }

        int index = 0;
        for (int i = 0; i < countingArray.length; ++i) {
            while (countingArray[i] > 0) {
                // Возвращаем отрицательную нотацию.
                // arr[0] = 0 - 3 = -3.
                // index++ - для повторения.
                arr[index++] = i + min;
                countingArray[i]--;
            }
        }
    }

    /**
     * Хелпер по заполнению массива
     * @param arr determined, but empty array.
     */
    public static void fillArray(int[] arr) {
        for (int i = 0; i < arr.length; ++i) {
            arr[i] = inputScanner.nextInt();
        }
    }

    /**
     * Helper for printing the array.
     * @param arr array with Integer values.
     */
    public static void viewArray(int[] arr) {
        for (int value : arr) {
            System.out.print(value + " ");
        }
        System.out.println();
    }

    /**
     * Global scanner of this program with {@code System.in} stream.
     */
    private static final Scanner inputScanner = new Scanner(System.in);
}
