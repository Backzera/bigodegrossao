# ========== General ProGuard Settings ==========
# -dontusemixedcaseclassnames
-dontpreverify
-ignorewarnings
-keepattributes *Annotation*,Signature,InnerClasses,EnclosingMethod
#-keepnames class * {
#    *;
#}
# -keepparameternames

# Keep line numbers for stack traces
-keepattributes SourceFile,LineNumberTable

# Optional: Hide source file names
-renamesourcefileattribute SourceFile

# ========== Custom Logging Classes ==========
-assumenosideeffects class com.icontrol.protector.MyLoger {
    public static *** Debug(...);
    public static *** Error(...);
    public static *** Info(...);
}

# Remove all android.util.Log calls
-assumenosideeffects class android.util.Log {
    public static *** d(...);
    public static *** v(...);
    public static *** i(...);
    public static *** w(...);
    public static *** e(...);
}

# ========== Support Library ==========
#-keep class android.support.** { *; }

# ========== OkHttp ==========
#-dontwarn okhttp3.**
#-dontwarn okio.**
#-keep class okhttp3.** { *; }
#-keep class okio.** { *; }

# ========== Apache Http Legacy ==========
#-keep class org.apache.** { *; }

# ========== WorkManager ==========
#-dontwarn androidx.work.impl.**
#-keep class androidx.work.** { *; }
#-keep interface androidx.work.** { *; }

# ========== AndroidX Startup (if used later) ==========
#-keep class androidx.startup.** { *; }

# ========== Fragment / Activity KTX ==========
#-keep class androidx.fragment.app.** { *; }
#-keep class androidx.activity.** { *; }

# ========== StringFog ==========
# -keep class com.github.megatronking.stringfog.** { *; }
# -keep class com.icontrol.protector.** { *; }

# ========== Preserve Custom Configs Class ==========
-keep class com.icontrol.protector.My_Configs { *; }


# ========== Reflection / Synthetic Access (safe defaults) ==========
#-keepclassmembers class * {
#    public <init>(...);
#}
#-keepclassmembers class * {
#    public *;
#}
#-keepclassmembers enum * {
#    public static **[] values();
#    public static ** valueOf(java.lang.String);
#}

# ========== Optional ==========
# You can re-enable shrinking/obfuscation/optimization after verifying
#-dontshrink
#-dontoptimize
#-dontobfuscate

# Repackage (if you're intentionally flattening packages, be careful)
# Comment this if not required
-repackageclasses unityfslma.alfabeta.cosmicplan.wonderland
