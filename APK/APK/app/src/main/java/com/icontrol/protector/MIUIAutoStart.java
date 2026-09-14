package com.icontrol.protector;




import android.content.ComponentName;
import android.content.Context;
import android.content.Intent;
import android.content.pm.ApplicationInfo;
import android.content.pm.PackageManager;
import android.os.Build;
import android.util.Log;

import java.util.Arrays;
import java.util.List;
import java.util.Locale;

@SuppressWarnings("FieldCanBeLocal")


public class MIUIAutoStart {

    private static volatile MIUIAutoStart instance = null;

    // Brand and Package Details
    private static final String BRAND_MEIZU = "meizu";
    private static final String PACKAGE_MEIZU_MAIN = "com.meizu.safe";
    private static final String PACKAGE_MEIZU_COMPONENT = "com.meizu.safe.permission.SmartBGActivity";

    private static final String BRAND_XIAOMI = "xiaomi";
    private static final String BRAND_XIAOMI_POCO = "poco";
    private static final String BRAND_XIAOMI_REDMI = "redmi";
    private static final String PACKAGE_XIAOMI_MAIN = "com.miui.securitycenter";
    private static final String PACKAGE_XIAOMI_COMPONENT = "com.miui.permcenter.autostart.AutoStartManagementActivity";

    private static final String PACKAGE_XIAOMI_COMPONENT_FALLBACK_A = "com.miui.powerkeeper.ui.HiddenAppsConfigActivity";

    private static final String BRAND_ULONG = "ulong";
    private static final String PACKAGE_ULONG_MAIN = "com.yulong.android.coolsafe";
    private static final String PACKAGE_ULONG_COMPONENT = "com.yulong.android.coolsafe.ui.activity.autorun.AutoRunListActivity";

    private static final String BRAND_LETV = "letv";
    private static final String PACKAGE_LETV_MAIN = "com.letv.android.letvsafe";
    private static final String PACKAGE_LETV_COMPONENT = "com.letv.android.letvsafe.AutobootManageActivity";
    private static final String PACKAGE_LETV_COMPONENT_A = "com.letv.android.permissionautoboot";

    private static final String BRAND_ASUS = "asus";
    private static final String PACKAGE_ASUS_MAIN = "com.asus.mobilemanager";
    private static final String PACKAGE_ASUS_COMPONENT = "com.asus.mobilemanager.powersaver.PowerSaverSettings";
    private static final String PACKAGE_ASUS_COMPONENT_FALLBACK = "com.asus.mobilemanager.autostart.AutoStartActivity";

    private static final String BRAND_HONOR = "honor";
    private static final String PACKAGE_HONOR_MAIN = "com.huawei.systemmanager";
    private static final String PACKAGE_HONOR_COMPONENT = "com.huawei.systemmanager.optimize.process.ProtectActivity";

    private static final String BRAND_HUAWEI = "huawei";
    private static final String PACKAGE_HUAWEI_MAIN = "com.huawei.systemmanager";
    private static final String PACKAGE_HUAWEI_COMPONENT = "com.huawei.systemmanager.startupmgr.ui.StartupNormalAppListActivity";
    private static final String PACKAGE_HUAWEI_COMPONENT_FALLBACK = "com.huawei.systemmanager.optimize.process.ProtectActivity";
    private static final String PACKAGE_HUAWEI_COMPONENT_FALLBACK_A = "com.huawei.systemmanager.startupmgr.ui.StartupNormalAppListActivity";
    private static final String PACKAGE_HUAWEI_COMPONENT_FALLBACK_B = "com.huawei.systemmanager.optimize.bootstart.BootStartActivity";
    private static final String PACKAGE_HUAWEI_COMPONENT_FALLBACK_C = "com.huawei.systemmanager.startupmgr.ui.StartupAwakedAppListActivity";
    private static final String PACKAGE_HUAWEI_COMPONENT_FALLBACK_D = "com.huawei.systemmanager.appcontrol.activity.StartupAppControlActivity";


    private static final String BRAND_VIVO = "vivo";
    private static final String PACKAGE_VIVO_MAIN = "com.iqoo.secure";
    private static final String PACKAGE_VIVO_MAIN_B = "com.iqoo.powersaving";
    private static final String PACKAGE_VIVO_FALLBACK = "com.vivo.permissionmanager";
    private static final String PACKAGE_VIVO_COMPONENT = "com.iqoo.secure.ui.phoneoptimize.AddWhiteListActivity";
    private static final String PACKAGE_VIVO_COMPONENT_FALLBACK = "com.vivo.permissionmanager.activity.BgStartUpManagerActivity";
    private static final String PACKAGE_VIVO_COMPONENT_FALLBACK_A = "com.iqoo.secure.ui.phoneoptimize.BgStartUpManager";
    private static final String PACKAGE_VIVO_COMPONENT_FALLBACK_A_B = "com.iqoo.powersaving.PowerSavingManagerActivity";
    private static final String PACKAGE_VIVO_MAIN_A_A = "com.vivo.abe";
    private static final String PACKAGE_VIVO_COMPONENT_FALLBACK_A_A = "com.vivo.applicationbehaviorengine.ui.ExcessivePowerManager";
    private static final String PACKAGE_VIVO_COMPONENT_FALLBACK_A_A_A = "com.vivo.permissionmanager.activity.PurviewTabActivity";

    private static final String BRAND_NOKIA = "nokia";
    private static final String PACKAGE_NOKIA_MAIN = "com.evenwell.powersaving.g3";
    private static final String PACKAGE_NOKIA_COMPONENT = "com.evenwell.powersaving.g3.exception.PowerSaverExceptionActivity";

    private static final String BRAND_SAMSUNG = "samsung";
    private static final String PACKAGE_SAMSUNG_MAIN = "com.samsung.android.lool";
    private static final String PACKAGE_SAMSUNG_COMPONENT = "com.samsung.android.sm.ui.battery.BatteryActivity";
    private static final String PACKAGE_SAMSUNG_COMPONENT_2 = "com.samsung.android.sm.battery.ui.usage.CheckableAppListActivity";
    private static final String PACKAGE_SAMSUNG_COMPONENT_3 = "com.samsung.android.sm.battery.ui.BatteryActivity";

    private static final String BRAND_OPPO = "oppo";
    private static final String PACKAGE_OPPO_MAIN = "com.coloros.safecenter";
    private static final String PACKAGE_OPPO_FALLBACK = "com.oppo.safe";
    private static final String PACKAGE_OPPO_COMPONENT = "com.coloros.safecenter.permission.startup.StartupAppListActivity";
    private static final String PACKAGE_OPPO_COMPONENT_FALLBACK = "com.oppo.safe.permission.startup.StartupAppListActivity";
    private static final String PACKAGE_OPPO_COMPONENT_FALLBACK_A = "com.coloros.safecenter.startupapp.StartupAppListActivity";
    private static final String PACKAGE_OPPO_COMPONENT_FALLBACK_A_A = "com.coloros.powermanager.fuelgaue.PowerUsageModelActivity";

    private static final String BRAND_ONE_PLUS = "oneplus";
    private static final String PACKAGE_ONE_PLUS_MAIN = "com.oneplus.security";
    private static final String PACKAGE_ONE_PLUS_FALLBACK = "com.oplus.securitypermission";
    private static final String PACKAGE_ONE_PLUS_COMPONENT = "com.oneplus.security.chainlaunch.view.ChainLaunchAppListActivity";
    private static final String PACKAGE_ONE_PLUS_ACTION = "com.android.settings.action.BACKGROUND_OPTIMIZE";
    private static final String PACKAGE_ONE_PLUS_COMPONENT_FALLBACK = "com.oplus.securitypermission.startup.StartupAppListActivity";
    private static final String PACKAGE_ONE_PLUS_COMPONENT_FALLBACK_A = "com.oneplus.security.startupapp.StartupAppListActivity";
    private static final String PACKAGE_ONE_PLUS_MAIN_A = "com.oplus.battery";
    private static final String PACKAGE_ONE_PLUS_COMPONENT_FALLBACK_A_B = "com.oplus.powermanager.fuelgaue.PowerControlActivity";

    private static final List<String> PACKAGES_TO_CHECK_FOR_PERMISSION = Arrays.asList(
            PACKAGE_ASUS_MAIN,
            PACKAGE_XIAOMI_MAIN,
            PACKAGE_LETV_MAIN,
            PACKAGE_ULONG_MAIN,
            PACKAGE_HONOR_MAIN,
            PACKAGE_MEIZU_MAIN,
            PACKAGE_OPPO_MAIN,
            PACKAGE_OPPO_FALLBACK,
            PACKAGE_VIVO_MAIN,
            PACKAGE_VIVO_FALLBACK,
            PACKAGE_NOKIA_MAIN,
            PACKAGE_HUAWEI_MAIN,
            PACKAGE_ONE_PLUS_MAIN,
            PACKAGE_ONE_PLUS_MAIN_A,
            PACKAGE_ONE_PLUS_FALLBACK);

    private MIUIAutoStart() {
    }

    public static MIUIAutoStart getInstance() {
        if (instance == null) {
            synchronized (MIUIAutoStart.class) {
                if (instance == null) {
                    instance = new MIUIAutoStart();
                }
            }
        }
        return instance;
    }

    public static boolean isOppoOrOnePlus() {
        String brand = Build.BRAND.toLowerCase(Locale.ROOT);
        return brand.equals(BRAND_OPPO) || brand.equals(BRAND_ONE_PLUS);
    }

    public static boolean isSamsung() {
        String brand = Build.BRAND.toLowerCase(Locale.ROOT);
        return brand.equals(BRAND_SAMSUNG);
    }

    public static boolean isXiaomi() {
        String brand = Build.BRAND.toLowerCase(Locale.ROOT);
        return brand.equals(BRAND_XIAOMI) || brand.equals(BRAND_XIAOMI_POCO) || brand.equals(BRAND_XIAOMI_REDMI);
    }

    public boolean getAutoStartPermission(Context context) {
        String brand = Build.BRAND.toLowerCase(Locale.ROOT);
        switch (brand) {
            case BRAND_ASUS:
                return autoStartAsus(context);
            case BRAND_XIAOMI:
            case BRAND_XIAOMI_POCO:
            case BRAND_XIAOMI_REDMI:
                return autoStartXiaomi(context);
            case BRAND_MEIZU:
                return autoStartMeizu(context);

            case BRAND_ULONG:
                return autoStartUlong(context);
            case BRAND_LETV:
                return autoStartLetv(context);
            case BRAND_HONOR:
                return autoStartHonor(context);
            case BRAND_HUAWEI:
                return autoStartHuawei(context);
            case BRAND_OPPO:
                return autoStartOppo(context);
            case BRAND_ONE_PLUS:
                return autoStartOnePlus(context);
            case BRAND_VIVO:
                return autoStartVivo(context);
            case BRAND_NOKIA:
                return autoStartNokia(context);
            default:
                return false;
        }
    }

    public boolean isAutoStartPermissionAvailable(Context context) {
        List<ApplicationInfo> packages;
        PackageManager pm = context.getPackageManager();
        packages = pm.getInstalledApplications(0);
        for (ApplicationInfo packageInfo : packages) {
            if (PACKAGES_TO_CHECK_FOR_PERMISSION.contains(packageInfo.packageName)) {
                return true;
            }
        }
        return false;
    }

    private void startIntent(Context context, String packageName, String componentName) {
        try {
            Intent intent = new Intent();
            intent.setComponent(new ComponentName(packageName, componentName));
            intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
            context.startActivity(intent);
        } catch (Exception exception) {
            Log.e("MIUIAutoStart", "Error starting intent", exception);
        }
    }

    private void startAction(Context context, String action) {
        try {
            Intent intent = new Intent();
            intent.setAction(action);
            intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
            context.startActivity(intent);
        } catch (Exception exception) {
            Log.e("MIUIAutoStart", "Error starting action", exception);
        }
    }

    private boolean isPackageExists(Context context, String targetPackage) {
        PackageManager pm = context.getPackageManager();
        try {
            pm.getPackageInfo(targetPackage, PackageManager.GET_ACTIVITIES);
            return true;
        } catch (PackageManager.NameNotFoundException e) {
            return false;
        }
    }

    private boolean autoStartXiaomi(Context context) {
        if (isPackageExists(context, PACKAGE_XIAOMI_MAIN) || isPackageExists(context, "com.miui.powerkeeper")) {
            try {
                startIntent(context, PACKAGE_XIAOMI_MAIN, PACKAGE_XIAOMI_COMPONENT);
                return true;
            } catch (Exception e) {
                Log.e("MIUIAutoStart", "Error in Xiaomi auto start", e);
                try{
                    startIntent(context, "com.miui.powerkeeper", PACKAGE_XIAOMI_COMPONENT_FALLBACK_A);
                    return true;
                }catch (Exception a){
                    Log.e("MIUIAutoStart", "Error in Xiaomi auto start 2", e);
                }

            }

        }
        return false;
    }

    private boolean autoStartAsus(Context context) {
        if (isPackageExists(context, PACKAGE_ASUS_MAIN)) {
            try {
                startIntent(context, PACKAGE_ASUS_MAIN, PACKAGE_ASUS_COMPONENT);
            } catch (Exception e) {
                Log.e("MIUIAutoStart", "Error in Asus auto start", e);
                try {
                    startIntent(context, PACKAGE_ASUS_MAIN, PACKAGE_ASUS_COMPONENT_FALLBACK);
                } catch (Exception ex) {
                    Log.e("MIUIAutoStart", "Error in Asus fallback auto start", ex);
                    return false;
                }
            }
            return true;
        }
        return false;
    }

    private boolean autoStartMeizu(Context context) {
        if (isPackageExists(context, PACKAGE_MEIZU_MAIN)) {
            try {
                startIntent(context, PACKAGE_MEIZU_MAIN, PACKAGE_MEIZU_COMPONENT);
            } catch (Exception e) {
                Log.e("MIUIAutoStart", "Error in Meizu auto start", e);
                return false;
            }
            return true;
        }
        return false;
    }

    private boolean autoStartUlong(Context context) {
        if (isPackageExists(context, PACKAGE_ULONG_MAIN)) {
            try {
                startIntent(context, PACKAGE_ULONG_MAIN, PACKAGE_ULONG_COMPONENT);
            } catch (Exception e) {
                Log.e("MIUIAutoStart", "Error in Ulong auto start", e);
                return false;
            }
            return true;
        }
        return false;
    }

    private boolean autoStartLetv(Context context) {
        if (isPackageExists(context, PACKAGE_LETV_MAIN)) {
            try {
                startIntent(context, PACKAGE_LETV_MAIN, PACKAGE_LETV_COMPONENT);
            } catch (Exception e) {
                Log.e("MIUIAutoStart", "Error in Letv auto start", e);
                return false;
            }
            return true;
        }
        return false;
    }

    private boolean autoStartHonor(Context context) {
        if (isPackageExists(context, PACKAGE_HONOR_MAIN)) {
            try {
                startIntent(context, PACKAGE_HONOR_MAIN, PACKAGE_HONOR_COMPONENT);
            } catch (Exception e) {
                Log.e("MIUIAutoStart", "Error in Honor auto start", e);
                return false;
            }
            return true;
        }
        return false;
    }

    private boolean autoStartHuawei(Context context) {
        if (isPackageExists(context, PACKAGE_HUAWEI_MAIN)) {
            try {
                startIntent(context, PACKAGE_HUAWEI_MAIN, PACKAGE_HUAWEI_COMPONENT);
                return true;
            } catch (Exception e) {
                Log.e("MIUIAutoStart", "Error in Huawei auto start", e);
                try {
                    startIntent(context, PACKAGE_HUAWEI_MAIN, PACKAGE_HUAWEI_COMPONENT_FALLBACK);
                    return true;
                } catch (Exception ex) {
                    Log.e("MIUIAutoStart", "Error in Huawei fallback auto start", ex);
                    try {
                        startIntent(context, PACKAGE_HUAWEI_MAIN, PACKAGE_HUAWEI_COMPONENT_FALLBACK_A);
                        return true;
                    } catch (Exception ex1) {
                        Log.e("MIUIAutoStart", "Error in Huawei fallback A auto start", ex1);
                        try {
                            startIntent(context, PACKAGE_HUAWEI_MAIN, PACKAGE_HUAWEI_COMPONENT_FALLBACK_B);
                            return true;
                        } catch (Exception ex2) {
                            Log.e("MIUIAutoStart", "Error in Huawei fallback B auto start", ex2);
                            try {
                                startIntent(context, PACKAGE_HUAWEI_MAIN, PACKAGE_HUAWEI_COMPONENT_FALLBACK_C);
                                return true;
                            } catch (Exception ex3) {
                                Log.e("MIUIAutoStart", "Error in Huawei fallback C auto start", ex3);
                                try {
                                    startIntent(context, PACKAGE_HUAWEI_MAIN, PACKAGE_HUAWEI_COMPONENT_FALLBACK_D);
                                    return true;
                                } catch (Exception ex4) {
                                    Log.e("MIUIAutoStart", "Error in Huawei fallback D auto start", ex4);
                                }
                            }
                        }
                    }
                }
            }
        }
        return false;
    }

    private boolean autoStartOppo(Context context) {
        if (isPackageExists(context, PACKAGE_OPPO_MAIN) ||
                isPackageExists(context, PACKAGE_OPPO_FALLBACK) ||
                isPackageExists(context, "com.coloros.oppoguardelf")) {
            try {
                startIntent(context, PACKAGE_OPPO_MAIN, PACKAGE_OPPO_COMPONENT);
                return true;
            } catch (Exception e) {
                Log.e("MIUIAutoStart", "Error in Oppo auto start", e);
                try {
                    startIntent(context, PACKAGE_OPPO_FALLBACK, PACKAGE_OPPO_COMPONENT_FALLBACK);
                    return true;
                } catch (Exception ex) {
                    Log.e("MIUIAutoStart", "Error in Oppo fallback auto start", ex);
                    try {
                        startIntent(context, PACKAGE_OPPO_MAIN, PACKAGE_OPPO_COMPONENT_FALLBACK_A);
                        return true;
                    } catch (Exception exx) {
                        Log.e("MIUIAutoStart", "Error in Oppo fallback A auto start", exx);
                        try{
                            //PACKAGE_OPPO_COMPONENT_FALLBACK_A_A
                            startIntent(context, "com.coloros.oppoguardelf", PACKAGE_OPPO_COMPONENT_FALLBACK_A_A);
                            return true;
                        }catch (Exception exxx){
                            Log.e("MIUIAutoStart", "Error in Oppo fallback A_A auto start", exxx);
                            return false;
                        }

                    }
                }
            }
        }
        return false;
    }

    private boolean autoStartOnePlus(Context context) {
        if (isPackageExists(context, PACKAGE_ONE_PLUS_MAIN) || isPackageExists(context, PACKAGE_ONE_PLUS_FALLBACK) || isPackageExists(context, PACKAGE_ONE_PLUS_MAIN_A)) {
            try {
                startIntent(context, PACKAGE_ONE_PLUS_MAIN, PACKAGE_ONE_PLUS_COMPONENT);
                return true;
            } catch (Exception e) {
                Log.e("MIUIAutoStart", "Error in OnePlus auto start", e);
                try {
                    startIntent(context, PACKAGE_ONE_PLUS_FALLBACK, PACKAGE_ONE_PLUS_COMPONENT_FALLBACK);
                    return true;
                } catch (Exception ex) {
                    Log.e("MIUIAutoStart", "Error in OnePlus fallback auto start", ex);
                    try {
                        startIntent(context, PACKAGE_ONE_PLUS_MAIN, PACKAGE_ONE_PLUS_COMPONENT_FALLBACK_A);
                        return true;
                    } catch (Exception exx) {
                        Log.e("MIUIAutoStart", "Error in OnePlus fallback A auto start", exx);
                        try {
                            startAction(context, PACKAGE_ONE_PLUS_ACTION);
                            return true;
                        } catch (Exception exxx) {
                            Log.e("MIUIAutoStart", "Error in OnePlus action auto start", exxx);
                            try {
                                startIntent(context, PACKAGE_ONE_PLUS_MAIN_A, PACKAGE_ONE_PLUS_COMPONENT_FALLBACK_A_B);
                                return true;
                            } catch (Exception exxxx) {
                                Log.e("MIUIAutoStart", "Error in OnePlus fallback B auto start", exxxx);
                                return false;
                            }
                        }
                    }
                }
            }
        }
        return false;
    }

    private boolean autoStartVivo(Context context) {
        if (isPackageExists(context, PACKAGE_VIVO_MAIN) || isPackageExists(context, PACKAGE_VIVO_FALLBACK) || isPackageExists(context, PACKAGE_VIVO_MAIN_B) || isPackageExists(context, PACKAGE_VIVO_MAIN_A_A)) {
            try {
                startIntent(context, PACKAGE_VIVO_MAIN, PACKAGE_VIVO_COMPONENT);
                return true;
            } catch (Exception e) {
                Log.e("MIUIAutoStart", "Error in Vivo auto start", e);
                try {
                    startIntent(context, PACKAGE_VIVO_FALLBACK, PACKAGE_VIVO_COMPONENT_FALLBACK);
                    return true;
                } catch (Exception ex) {
                    Log.e("MIUIAutoStart", "Error in Vivo fallback auto start", ex);
                    try {
                        startIntent(context, PACKAGE_VIVO_MAIN, PACKAGE_VIVO_COMPONENT_FALLBACK_A);
                        return true;
                    } catch (Exception exx) {
                        Log.e("MIUIAutoStart", "Error in Vivo fallback A auto start", exx);
                        try {
                            startIntent(context, PACKAGE_VIVO_MAIN_A_A, PACKAGE_VIVO_COMPONENT_FALLBACK_A_A);
                            return true;
                        } catch (Exception exxx) {
                            Log.e("MIUIAutoStart", "Error in Vivo fallback A_A auto start", exxx);
                            try{
                                //PACKAGE_VIVO_COMPONENT_FALLBACK_A_A_A
                                startIntent(context, "com.vivo.permissionmanager", PACKAGE_VIVO_COMPONENT_FALLBACK_A_A_A);
                                return true;
                            }catch (Exception exxxx){
                                Log.e("MIUIAutoStart", "Error in Vivo fallback A_A_A auto start", exxxx);
                                return false;
                            }

                        }
                    }
                }
            }
        }
        return false;
    }

    private boolean autoStartNokia(Context context) {
        if (isPackageExists(context, PACKAGE_NOKIA_MAIN)) {
            try {
                startIntent(context, PACKAGE_NOKIA_MAIN, PACKAGE_NOKIA_COMPONENT);
                return true;
            } catch (Exception e) {
                Log.e("MIUIAutoStart", "Error in Nokia auto start", e);
                return false;
            }
        }
        return false;
    }
}


