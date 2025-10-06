package edu.october.algorithms;

import java.util.Scanner;

public class CrushBallsAnalog {
    public static void main(String... args) {
        Scanner sc = new Scanner(System.in);
        System.out.println("Напиши размер и цвета шариков: ");
        int ballsSize = sc.nextInt();
        byte[] balls = new byte[ballsSize];
        for (int ballIdx = 0; ballIdx < ballsSize; ++ballIdx) {
            balls[ballIdx] = sc.nextByte();
        }

        CrushStack cs = new CrushStack();
        int totalScore = 0;

        // 10 3 3 2 1 1 1 2 2 3 3 -> 10
        for (int i = 0; i < balls.length - 1; ++i) {
            if (!cs.isEmpty() && cs.peek().colour() == balls[i]) {
                CrushGroup top = cs.pop();
                int newAmount = top.amount() + 1;

                if (newAmount == 3) {
                    while (i < balls.length - 1
                            && balls[i] == balls[i+1]) {
                        newAmount++;
                        ++i;
                    }
                    // Убираем группу.
                    totalScore += newAmount;
                } else {
                    cs.push(new CrushGroup(balls[i], newAmount));
                }
            } else {
                cs.push(new CrushGroup(balls[i], 1));
            }
        }

        System.out.println(totalScore);
    }
}