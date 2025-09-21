package edu.september.designalgorithms;

import java.util.Arrays;
import java.util.Scanner;

public class MergeSortingHelper {
    public static void main(String... args) {
        int elementAmount = inputScanner.nextInt();
        int[] myArr = new int[elementAmount];

        fillArray(myArr); // filling
        mergeSort(myArr); // Sorting by mergeSort
        viewArray(myArr); // viewing
    }

    /**
     * Разберу сортировку на примере с CodeForces.
     * Дан массив [1 8 2 1 4 7 3 2 3 6].
     *
     * ПЕРВЫЙ ШАГ: делим массив пополам:
     * Левая часть:  [1, 8, 2, 1, 4]
     * Правая часть: [7, 3, 2, 3, 6]
     *
     * ЕЩЁ РАЗ ДЕЛИМ ЛЕВУЮ ЧАСТЬ:
     * [1, 8]   и   [2, 1, 4]
     * [1] и [8] → сливаем → [1, 8]
     * [2] и [1, 4]; [1] и [4] → [1, 4]
     *
     * [1, 8] + [1, 2, 4] → [1, 1, 2, 4, 8]
     *
     * То же самое происходит и со второй частью!
     */


    // Запрещаем создавать объект класса.
    private MergeSortingHelper() {}

    /**
     * Рекурсивная сортировка слиянием за O(n * logn)
     * @param arr входящий массив целых чисел
     */
    public static void mergeSort(int[] arr) {
        if (arr.length < 2) { return; }

        int mid = arr.length / 2;
        int[] left = Arrays.copyOfRange(arr, 0, mid);
        int[] right = Arrays.copyOfRange(arr, mid, arr.length);

        mergeSort(left);
        mergeSort(right);

        merge(arr, left, right);
    }

    /**
     * Метод слияния двух отсортированных половинок.
     * @param arr исходный массив
     * @param left левая подчасть исходного массива
     * @param right правая подчасть исходного массива
     */
    private static void merge(int[] arr, int[] left, int[] right) {
        int size = left.length + right.length;
        int[] result = new int[size];

        int i = 0, j = 0, k = 0;

        while (i < left.length && j < right.length) {
            if (left[i] <= right[j]) {
                result[k++] = left[i++];
            } else {
                result[k++] = right[j++];
            }
        }

        while (i < left.length) { result[k++] = left[i++]; }
        while (j < right.length) { result[k++] = right[j++]; }

        System.arraycopy(result, 0, arr, 0, size);
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
    public static final Scanner inputScanner = new Scanner(System.in);
}
