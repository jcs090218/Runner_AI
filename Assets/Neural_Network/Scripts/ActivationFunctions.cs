/**
 * $File: ActivationFunctions.cs $
 * $Date: 2022-09-17 23:04:52 $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information
 *                   Copyright © 2022 by Shen, Jen-Chieh $
 */
using System;

/// <summary>
/// List of all activation functions' implementation.
/// </summary>
public static class ActivationFunctions
{
    /* Variables */

    /* Setter & Getter */

    /* Functions */

    public static double Do(ActivationType type, double x, double a = 0.0f)
    {
        switch (type)
        {
            case ActivationType.Identity: return Identity(x);
            case ActivationType.BinaryStep: return BinaryStep(x);
            case ActivationType.Logistic: return Logistic(x);
            case ActivationType.Tanh: return Tanh(x);
            case ActivationType.ArcTan: return ArcTan(x);
            case ActivationType.ReLU: return ReLU(x);
            case ActivationType.PReLU: return PReLU(x, a);
            case ActivationType.ELU: return ELU(x, a);
            case ActivationType.SoftPlus: return SoftPlus(x);
            case ActivationType.BentIdentity: return BentIdentity(x);
            case ActivationType.Sinusoid: return Sinusoid(x);
            case ActivationType.Sinc: return Sinc(x);
            case ActivationType.Gaussian: return Gaussian(x);
            case ActivationType.Bipolar: return Bipolar(x);
            case ActivationType.BipolarSigmoid: return BipolarSigmoid(x);
            case ActivationType.SoftSign: return SoftSign(x);
        }
        return x;
    }

    /**
     * Activation Functions
     * 
     * Source: https://stackoverflow.com/questions/36384249/list-of-activation-functions-in-c-sharp
     * Credit: Rottjung, and Rusty Nail
     */
    public static double Identity(double x)
    {
        return x;
    }
    public static double BinaryStep(double x)
    {
        return x < 0 ? 0 : 1;
    }
    public static double Logistic(double x)
    {
        return 1 / (1 + Math.Pow(Math.E, -x));
    }
    public static double DLogistic(double x)
    {
        return Logistic(x) * (1 - Logistic(x));
    }
    public static double Tanh(double x)
    {
        return 2 / (1 + Math.Pow(Math.E, -(2 * x))) - 1;
    }
    public static double DTanh(double x)
    {
        return 1 - Math.Pow(Tanh(x), 2);
    }
    public static double ArcTan(double x)
    {
        return Math.Atan(x);
    }
    public static double DArcTan(double x)
    {
        return 1 / Math.Pow(x, 2) + 1;
    }
    // Rectified Linear Unit
    public static double ReLU(double x)
    {
        return Math.Max(0, x);  // x < 0 ? 0 : x;
    }
    public static double DReLU(double x)
    {
        return Math.Max(0, 1);  // x < 0 ? 0 : x;
    }
    // Parameteric Rectified Linear Unit 
    public static double PReLU(double x, double a)
    {
        return x < 0 ? a * x : x;
    }
    public static double DPReLU(double x, double a)
    {
        return x < 0 ? a : 1;
    }
    // Exponential Linear Unit 
    public static double ELU(double x, double a)
    {
        return x < 0 ? a * (Math.Pow(Math.E, x) - 1) : x;
    }
    public static double DELU(double x, double a)
    {
        return x < 0 ? ELU(x, a) + a : 1;
    }
    public static double SoftPlus(double x)
    {
        return Math.Log(Math.Exp(x) + 1);
    }
    public static double DSoftPlus(double x)
    {
        return Logistic(x);
    }
    public static double BentIdentity(double x)
    {
        return (((Math.Sqrt(Math.Pow(x, 2) + 1)) - 1) / 2) + x;
    }
    public static double DBentIdentity(double x)
    {
        return (x / (2 * Math.Sqrt(Math.Pow(x, 2) + 1))) + 1;
    }
    public static double SoftExponential(double x, double alpha = 0.0, double max_value = 0.0)
    {

        // """Soft Exponential activation function by Godfrey and Gashler
        // See: https://arxiv.org/pdf/1602.01321.pdf
        // ? == 0:  f(?, x) = x
        // ?  > 0:  f(?, x) = (exp(?x)-1) / ? + ?
        // ?< 0:  f(?, x) = -ln(1 - ?(x + ?)) / ?
        // """

        if (alpha == 0)
            return x;
        else if (alpha > 0)
            return alpha + (Math.Exp(alpha * x) - 1.0) / alpha;
        else
            return -Math.Log(1 - alpha * (x + alpha)) / alpha;
    }
    public static double Sinusoid(double x)
    {
        return Math.Sin(x);
    }
    public static double DSinusoid(double x)
    {
        return Math.Cos(x);
    }
    public static double Sinc(double x)
    {
        return x == 0 ? 1 : Math.Sin(x) / x;
    }
    public static double DSinc(double x)
    {
        return x == 0 ? 0 : (Math.Cos(x) / x) - (Math.Sin(x) / Math.Pow(x, 2));
    }
    public static double Gaussian(double x)
    {
        return Math.Pow(Math.E, Math.Pow(-x, 2));
    }
    public static double DGaussian(double x)
    {
        return -2 * x * Math.Pow(Math.E, Math.Pow(-x, 2));
    }
    public static double Bipolar(double x)
    {
        return x < 0 ? -1 : 1;
    }
    public static double BipolarSigmoid(double x)
    {
        return (1 - Math.Exp(-x)) / (1 + Math.Exp(-x));
    }
    public static double DBipolarSigmoid(double x)
    {
        return 0.5 * (1 + BipolarSigmoid(x)) * (1 - BipolarSigmoid(x));
    }
    // maps in between -1 & 1
    public static double SoftSign(double x)
    {
        return x / (1 + Math.Abs(x));
    }

    public static double Scaler(double x, double min, double max)
    {
        return (x - min) / (max - min);
    }
}
