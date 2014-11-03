from sikuli import *
import HTMLTestRunner
bdLibPath = os.path.abspath(sys.argv[0] + "..")
if not bdLibPath in sys.path: sys.path.append(bdLibPath)
from _uimap import *

def RunBrowserToUrl(browser, toUrl):
    __default_SleepTime = 0.5
    #TestAction("Start " + browser + " " + toUrl)
    sleep(__default_SleepTime)
    type("d", KEY_WIN); sleep(__default_SleepTime)
    type("r", KEY_WIN); sleep(__default_SleepTime)
    type(browser + " "); sleep(__default_SleepTime)
    type(toUrl); sleep(__default_SleepTime)
    type(Key.ENTER)

def OpenFacebook():
    RunBrowserToUrl("chrome", "http://facebook.com")
    wait(Facebook.input_Search, global_WaitTime); 

def SendMessageTo(toFriend, message):
    wait(Facebook.button_Messages, global_WaitTime)
    #Open message form
    click(Facebook.button_Messages)
    click(Facebook.button_NewMessage)
    #Find friend
    wait(Facebook.input_UserToRecieve, global_WaitTime)
    type(Facebook.input_UserToRecieve, toFriend)
    type(Key.ENTER)
    #Type message
    type(Facebook.input_MessageText, message)
    #Send message
    type(Key.ENTER)
    waitVanish(Facebook.input_UserToRecieve, global_WaitTime)