using System.Diagnostics;
using System.Runtime.CompilerServices;
using Turtles;

namespace GodotLib.Debug;

public static class Assertions
{
    [Conditional("DEBUG")]
    [DebuggerHidden, StackTraceHidden]
    public static void AssertNotNull(object obj, string message = null, [CallerArgumentExpression(nameof(obj))]string objName = null)
    {
        AssertInternal(obj != null, message ?? $"{objName} was null.");
    }
    
    [Conditional("DEBUG")]
    [DebuggerHidden, StackTraceHidden]
    public static void AssertEqual(object obj1, object obj2, string message = null, [CallerArgumentExpression(nameof(obj1))]string obj1Name = null, [CallerArgumentExpression(nameof(obj2))]string obj2Name = null)
    {
        AssertInternal(obj1.Equals(obj2), message ?? $"{obj1Name} was not equal to {obj2Name}.");
    }
    
    [Conditional("DEBUG")]
    [DebuggerHidden, StackTraceHidden]
    public static void AssertNotEqual(object obj1, object obj2, string message = null, [CallerArgumentExpression(nameof(obj1))]string obj1Name = null, [CallerArgumentExpression(nameof(obj2))]string obj2Name = null)
    {
        AssertInternal(!obj1.Equals(obj2), message ?? $"{obj1Name} was equal to {obj2Name}.");
    }
    
    [Conditional("DEBUG")]
    [DebuggerHidden, StackTraceHidden]
    public static void Assert(bool condition, [CallerArgumentExpression(nameof(condition))] string message = null)
    {
        AssertInternal(condition, message);
    }

    [Conditional("DEBUG")]
    [DebuggerHidden, StackTraceHidden]
    private static void AssertInternal(bool condition, string message)
    {
        if (condition) return;
        EngineDebugger.Debug();
        throw new AssertionException("Assert failed: " + message);
    }
}

[StackTraceHidden]
public class AssertionException(string message) : Exception(message);