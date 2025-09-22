package edu.september.designalgorithms;

import java.util.Arrays;

public class MaxHeap {
    private int[] heap;
    private int size;
    private static final int DEFAULT_CAPACITY = 10;

    public MaxHeap() {
        heap = new int[DEFAULT_CAPACITY];
        size = 0;
    }

    /**
     * Метод добавления в конец кучи. Метод вполне стандартный, только в конце происходит поднятие наверх в случае
     * нарушения условий кучи.
     * @see MaxHeap#heapifyUp()
     * @param value элемент целочисленный
     */
    public void add(int value) {
        ensureCapacity();
        heap[size] = value;
        size++;
        heapifyUp();
    }

    /**
     * Получение максимума кучи с последующим удалением его.
     * @return целочисленный максимум
     */
    public int poll() {
        if (size == 0) { throw new IllegalStateException("Heap is empty"); }
        int max = heap[0];
        heap[0] = heap[size-1];
        size--;
        heapifyDown();
        return max;
    }

    /**
     * Смотрим на максимум кучи.
     * @return целочисленное значение максимума
     */
    public int peek() {
        if (size == 0) { throw new IllegalStateException("Heap is empty"); }
        return heap[0];
    }

    /**
     * Метод, который поднимает наверх элементы, которые нарушают условия кучи.
     */
    private void heapifyUp() {
        int index = size - 1;
        while (hasParent(index) && heap[index] > heap[getParentIndex(index)]) {
            swap(index, getParentIndex(index));
            index = getParentIndex(index);
        }
    }

    /**
     * Нормализация кучи после удаления корня.
     */
    private void heapifyDown() {
        int index = 0;
        while (hasLeftChild(index)) {
            int largerChildIndex = getLeftChildIndex(index);
            if (hasRightChild(index) &&
            heap[getRightChildIndex(index)] > heap[largerChildIndex]) {
                largerChildIndex = getRightChildIndex(index);
            }

            if (heap[index] >= heap[largerChildIndex]) { break; }

            swap(index, largerChildIndex);
            index = largerChildIndex;
        }
    }

    /*
    Методы-геттеры для получения индекса левого/правого ребёнка и родителя.
     */
    private int getLeftChildIndex(int parent) { return 2 * parent + 1; }
    private int getRightChildIndex(int parent) { return 2 * parent + 2; }
    private int getParentIndex(int child) { return (child - 1) / 2; }

    private boolean hasLeftChild(int index) { return getLeftChildIndex(index) < size;}
    private boolean hasRightChild(int index) { return getRightChildIndex(index) < size;}
    private boolean hasParent(int index) { return index > 0; }

    /**
     * Сваппер
     * @param i индекс свапаемого элемента
     * @param j индекс свапающего элемента
     */
    private void swap(int i, int j) {
        int temp = heap[i];
        heap[i] = heap[j];
        heap[j] = temp;
    }

    /**
     * Метод, увеличивающий кучу, если мы превысим размер текущий
     * (начиная с {@code DEFAULT_CAPACITY})
     */
    private void ensureCapacity() {
        if (size == heap.length) {
            heap = Arrays.copyOf(heap, heap.length * 2);
        }
    }

    /**
     * Вывод кучи.
     */
    public void viewHeap() {
        for (int i = 0; i < size; ++i) {
            System.out.print(heap[i] + " ");
        }
        System.out.println();
    }
}
