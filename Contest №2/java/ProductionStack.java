package edu.october.algorithms;

import java.util.Arrays;

public class ProductionStack {
    private int[] data;
    private int top;
    private static final int DEFAULT_CAPACITY = 12;

    /**
     * Конструктор для построения стека.
     */
    public ProductionStack() {
        data = new int[DEFAULT_CAPACITY];
        top = -1;

        historyOfMinimum = new MinHistory();
    }

    /**
     * Добавление на верхушку стека элемента
     * @param value целочисленное значение
     */
    public void push(int value) {
        ensureCapacity();
        // Минуем занятую (или пустую) позицию
        data[++top] = value;

        // Теперь ведение истории минимумов
        if (historyOfMinimum.peekCurrent() != -1) {
            if (historyOfMinimum.peekCurrent() > value) {
                historyOfMinimum.push(value);
            }
        } else {
            historyOfMinimum.push(value);
        }
    }

    /**
     * Забирать верхушку стека.
     * @return целочисленное значение верхушки стека
     */
    public int pop() {
        if (isEmpty()) { throw new IllegalStateException("Stack is empty!"); }

        int popingElement = data[top];
        data[top--] = 0;
        if (popingElement == historyOfMinimum.peekCurrent()) {
            historyOfMinimum.pop();
        }

        return popingElement;
    }

    /**
     * Посмотреть верхушку стека
     */
    public int peek() {
        if (isEmpty()) { throw new IllegalStateException("Stack is empty!"); }
        return data[top];
    }

    /**
     * Проверка на пустоту стека
     * @return
     */
    public boolean isEmpty() {
        return top == -1;
    }

    /**
     * Увеличивалка размера.
     */
    public void ensureCapacity() {
        if (size() == data.length - 1) {
            this.data = Arrays.copyOf(data, data.length * 2);
        }
    }

    public int size() {
        return top + 1;
    }

    // Работа с минимумами.

    private MinHistory historyOfMinimum;

    private class MinHistory {
        private int[] historyBody;
        private int minTop = -1;

        public MinHistory() {
            historyBody = new int[DEFAULT_CAPACITY];
        }

        public void push(int minValue) {
            localEnsureCapacity();
            historyBody[++minTop] = minValue;
        }

        private void pop() {
            if (!isEmpty()) {
                historyBody[minTop--] = 0;
            }
        }

        private int peekCurrent() {
            if (localIsEmpty()) {
                return -1;
            }
            return historyBody[minTop];
        }

        private void localEnsureCapacity() {
            if (this.size() == historyBody.length - 1) {
                this.historyBody = Arrays.copyOf(historyBody, historyBody.length * 2);
            }
        }
        private int size() { return minTop + 1; }
        private boolean localIsEmpty() {
            return minTop == -1;
        }
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder("ProductionStack[");
        for (int position : this.data) {
            sb.append(position + " ");
        }
        sb.append("]");
        return sb.toString();
    }
}