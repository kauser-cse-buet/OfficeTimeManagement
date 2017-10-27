
import win32evtlog
readFlags = win32evtlog.EVENTLOG_BACKWARDS_READ|win32evtlog.EVENTLOG_SEQUENTIAL_READ
h = win32evtlog.OpenEventLog("math342-hoque04", "Windows")
log_list = win32evtlog.ReadEventLog(h, readFlags, 0)
