package edu.october.algorithms;

import java.util.Arrays;

public class CrushStack {
    private CrushGroup[] data;
    private int topIndex;
    private static final int DEFAULT_CAPACITY = 1000;

    public CrushStack() {
        data = new CrushGroup[DEFAULT_CAPACITY];
        topIndex = -1;
    }

    public void push(CrushGroup crushes) {
        ensureCapacity();
        data[++topIndex] = crushes;
    }

    public CrushGroup pop() {
        if (isEmpty()) { throw new IllegalStateException("Stack is empty"); }
        CrushGroup poppingGroup = data[topIndex];
        data[topIndex--] = null;
        return poppingGroup;
    }

    public CrushGroup peek() {
        if (isEmpty()) {
           throw new IllegalStateException("Stack is empty.");
        }
        return data[topIndex];
    }

    private void ensureCapacity() {
        if (this.size() == data.length) {
            this.data = Arrays.copyOf(data, data.length * 2);
        }
    }
    public boolean isEmpty() { return topIndex == -1; }
    private int size() {
        return topIndex + 1;
    }
}

record CrushGroup(byte colour, int amount) { }