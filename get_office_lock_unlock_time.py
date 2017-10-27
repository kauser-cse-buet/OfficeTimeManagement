# for more details follow the link: http://docs.activestate.com/activepython/3.3/pywin32/Windows_NT_Eventlog.html


import win32evtlog
readFlags = win32evtlog.EVENTLOG_BACKWARDS_READ|win32evtlog.EVENTLOG_SEQUENTIAL_READ
h = win32evtlog.OpenEventLog("math342-hoque04", "Windows")
log_list = win32evtlog.ReadEventLog(h, readFlags, 0)
