from sikuli import *
import HTMLTestRunner
bdLibPath = os.path.abspath(sys.argv[0] + "..")
if not bdLibPath in sys.path: sys.path.append(bdLibPath)
from _uimap import *

def OpenSkype():
    sleep(0.5)
    #Show desktop
    type("d", KEY_WIN); sleep(1)
    #Open Skype by desktop or quick Launch icon
    if exists(Desktop.icon_Skype):
        doubleClick(Desktop.icon_Skype)
    else:
        doubleClick(Desktop.icon_SkypeQuick)
    wait(Skype.input_Search, global_WaitTime); 

def SendSkypeMessageTo(toFriend, message = ""):
    wait(Skype.input_Search, global_WaitTime)
    #Find friend
    type(Skype.input_Search, toFriend)
    sleep(0.5)
    type(Key.ENTER)
    wait(Skype.title_TelerikQAChat, global_WaitTime)
    #Send message
    type(Skype.input_TypeMessage, message)
    type(Key.ENTER)
    sleep(0.5)

def DeleteLastMessage():
    #Delete message
    rightClick(Skype.area_LastMessage)
    click(Skype.popup_ContextMenu)
    wait(Skype.popup_RemoveMessage, global_WaitTime)
    click(Skype.button_AgreeToRemove)