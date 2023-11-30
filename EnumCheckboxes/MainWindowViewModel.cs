using System.ComponentModel;

using CommunityToolkit.Mvvm.ComponentModel;

namespace EnumCheckboxes;

[Flags]
public enum SystemFlags : uint
{
    [Description("Fault")]
    SYSTEM_FLAG_FAULT = 0x00000001,
    [Description("CIO POST Done")]
    SYSTEM_FLAG_CIO_POST_DONE = 0x00000002,
    [Description("XRAY POST Done")]
    SYSTEM_FLAG_XRAY_POST_DONE = 0x00000004,
    [Description("FIL POST Done")]
    SYSTEM_FLAG_FIL_POST_DONE = 0x00000008,
    [Description("DS POST Done")]
    SYSTEM_FLAG_DS_POST_DONE = 0x00000010,
    [Description("HSS POST Done")]
    SYSTEM_FLAG_HSS_POST_DONE = 0x00000020,
    [Description("Prepare command")]
    SYSTEM_FLAG_PREPARE = 0x00000040,
    [Description("Inverter Ready")]
    SYSTEM_FLAG_INVERTER_READY = 0x00000080,
    [Description("KV Ready")]
    SYSTEM_FLAG_KV_READY = 0x00000100,
    [Description("Scan Control Ready")]
    SYSTEM_FLAG_SCAN_CONTROL_READY = 0x00000200,
    [Description("ANODE Ready")]
    SYSTEM_FLAG_ANODE_READY = 0x00000400,
    [Description("FIL Ready")]
    SYSTEM_FLAG_FIL_READY = 0x00000800,
    [Description("XRAY PROC Done")]
    SYSTEM_FLAG_XRAY_PROC_DONE = 0x00001000,
    [Description("FIL PROC Done")]
    SYSTEM_FLAG_FIL_PROC_DONE = 0x00002000,
    [Description("MG Active")]
    SYSTEM_FLAG_MG_ACTIVE = 0x00004000,
    [Description("Waiting Scan Result")]
    SYSTEM_FLAG_WAITING_SCAN_RESULT = 0x00008000,
    [Description("Init Standalone Done")]
    SYSTEM_FLAG_INIT_STANDALONE_DONE = 0x00010000,
    [Description("Power off requested")]
    SYSTEM_FLAG_POWER_OFF_REQUESTED = 0x00020000,
    [Description("Calibration Sync Ready")]
    SYSTEM_FLAG_CALIB_READY = 0x00040000,
    [Description("Grid Ready")]
    SYSTEM_FLAG_GRID_READY = 0x00080000,
    [Description("Hard reset requested")]
    SYSTEM_FLAG_HARD_RESET = 0x00100000
};

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private SystemFlags _flags;

    public MainWindowViewModel()
    {
        Flags = SystemFlags.SYSTEM_FLAG_ANODE_READY | SystemFlags.SYSTEM_FLAG_DS_POST_DONE | SystemFlags.SYSTEM_FLAG_KV_READY;
    }
}
