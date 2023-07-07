using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ColorActions
{
    public static Action blue, green, yellow, gray, neutral;

    
    public static void CallNeutral() {
        if (neutral != null) {
            neutral();
        }
    }
    public static void CallBlue() {
        if (blue != null) {
            blue();
        }
    }
    public static void CallGreen() {
        if (green != null) {
            green();
        }
    }
    public static void CallYellow() {
        if (yellow != null) {
            yellow();
        }
    }
    public static void CallGray() {
        if (gray != null) {
            gray();
        }
    }
}
