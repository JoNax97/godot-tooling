using Godot;

namespace GodotLib.Util;

public static class MathUtils
{
    //https://www.rorydriscoll.com/2016/03/07/frame-rate-independent-damping-using-lerp/
    public static float Damp(float source, float target, float smoothing, double dt)
    {
        return Mathf.Lerp(source, target, GetDampWeight(smoothing, dt));
    }

    public static float DampAngle(float source, float target, float smoothing, double dt)
    {
        return Mathf.LerpAngle(source, target, GetDampWeight(smoothing, dt));
    }

    public static Vector2 Damp(this Vector2 source, Vector2 target, float smoothing, double dt)
    {
        return source.Lerp(target, GetDampWeight(smoothing, dt));
    }

    public static Vector3 Damp(this Vector3 source, Vector3 target, float smoothing, double dt)
    {
        return source.Lerp(target, GetDampWeight(smoothing, dt));
    }
    
    public static Vector3 Sdamp(this Vector3 source, Vector3 target, float smoothing, double dt)
    {
        return source.Slerp(target, GetDampWeight(smoothing, dt));
    }
    
    public static Basis Sdamp(this Basis source, Basis target, float smoothing, double dt)
    {
        return source.Slerp(target, GetDampWeight(smoothing, dt));
    }

    private static float GetDampWeight(float smoothing, double dt)
    {
        return 1 - Mathf.Pow(smoothing, (float)dt);
    }

    public static Vector3 DegToRad(Vector3 degrees)
    {
        return degrees * 0.017453292f;
    }
    
    public static Vector2 DegToRad(Vector2 degrees)
    {
        return degrees * 0.017453292f;
    }
    
    public static Vector3 RadToDeg(Vector3 radians)
    {
        return radians * 57.29578f;
    }
    
    public static Vector2 RadToDeg(Vector2 radians)
    {
        return radians * 57.29578f;
    }

    public static void Clamp(this ref float value, float min, float max) 
    {
        value = Mathf.Clamp(value, min, max);
    }
    
    public static void Clamp(this ref int value, int min, int max) 
    {
        value = Mathf.Clamp(value, min, max);
    }
    
    public static void MoveToward(this ref float value, float to, float delta)
    {
        value = Mathf.MoveToward(value, to, delta);
    }
}